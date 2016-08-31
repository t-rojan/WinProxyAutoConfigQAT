using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using System.Runtime.InteropServices;
using WinHTTPdotNet;

namespace WinProxyAutoConfigQAT
{
    class Options
    {
            [OptionArray('p', "PacUrl", Required = true,
            HelpText = "One or more PAC URLs to test")]
        public string[] pacUrls { get; set; }
            [OptionArray('u', "Url", Required = true,
            HelpText = "One or more URLs to test against each PAC")]
        public string[] urls { get; set; }
            [Option('x', "inProcess", Required = false, DefaultValue = false,
            HelpText = "Execute PAC in-process (see WINHTTP_AUTOPROXY_RUN_INPROCESS)")]
        public bool inProcess { get; set; }
            [Option('c', "cache", Required = false, DefaultValue = false,
            HelpText = "Enable caching of PAC file and results (see WINHTTP_AUTOPROXY_NO_CACHE_CLIENT and WINHTTP_AUTOPROXY_NO_CACHE_SVC)")]
        public bool cache { get; set; }
            [HelpOption]
        public string GetUsage()
        {
            return CommandLine.Text.HelpText.AutoBuild(this,
              (CommandLine.Text.HelpText current) => CommandLine.Text.HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {

                WinHTTPdotNet.WinHTTPdotNet winhttp = new WinHTTPdotNet.WinHTTPdotNet();
                winhttp.Open(null, WinHTTPdotNet.WinHTTPdotNet.AccessType.WINHTTP_ACCESS_TYPE_NO_PROXY, null, null);

                WinHTTPdotNet.WinHTTPdotNet.AutoProxyOptions pOptions = new WinHTTPdotNet.WinHTTPdotNet.AutoProxyOptions();
                pOptions.dwFlags = WinHTTPdotNet.WinHTTPdotNet.AutoProxyFlags.WINHTTP_AUTOPROXY_CONFIG_URL;
                if (options.inProcess)
                {
                    pOptions.dwFlags |= WinHTTPdotNet.WinHTTPdotNet.AutoProxyFlags.WINHTTP_AUTOPROXY_RUN_INPROCESS;
                }
                if (! options.cache)
                {
                    pOptions.dwFlags |= WinHTTPdotNet.WinHTTPdotNet.AutoProxyFlags.WINHTTP_AUTOPROXY_NO_CACHE_CLIENT;
                    pOptions.dwFlags |= WinHTTPdotNet.WinHTTPdotNet.AutoProxyFlags.WINHTTP_AUTOPROXY_NO_CACHE_SVC;
                }          

                foreach (string pacUrl in options.pacUrls)
                {
                    pOptions.lpszAutoConfigUrl = pacUrl;
                    

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    foreach (string url in options.urls)
                    {
                        try
                        {

                            WinHTTPdotNet.WinHTTPdotNet.ProxyInfo pInfo = winhttp.GetProxyForUrl(url, ref pOptions);
                            watch.Stop();
                            System.Console.WriteLine(String.Format("{0} {1} {2} {3}ms succeeded {4} {5}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), pacUrl, url, watch.ElapsedMilliseconds, pInfo.dwAccessType.ToString(), pInfo.lpszProxy));

                        }
                        catch (WinHTTPException x)
                        {
                            watch.Stop();
                            System.Console.WriteLine(String.Format("{0} {1} {2} {3}ms failed {4}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), pacUrl, url, watch.ElapsedMilliseconds, x.Message));
                        }
                    }
                }
            }
            else
            {

            }
        }
    }
}
