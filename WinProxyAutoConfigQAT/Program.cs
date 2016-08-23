using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using System.Runtime.InteropServices;
using WinHTTP;

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

                WinHTTP.WinHTTP winhttp = new WinHTTP.WinHTTP();
                winhttp.Open(null, WinHTTP.WinHTTP.AccessType.WINHTTP_ACCESS_TYPE_NO_PROXY, null, null);

                WinHTTP.WinHTTP.AutoProxyOptions pOptions = new WinHTTP.WinHTTP.AutoProxyOptions();

                foreach (string pacUrl in options.pacUrls)
                {
                    pOptions.lpszAutoConfigUrl = pacUrl;
                    pOptions.dwFlags = WinHTTP.WinHTTP.AutoProxyFlags.WINHTTP_AUTOPROXY_CONFIG_URL;

                    foreach (string url in options.urls)
                    {
                        try
                        {
                            WinHTTP.WinHTTP.ProxyInfo pInfo = winhttp.GetProxyForUrl(url, ref pOptions);
                            System.Console.WriteLine(String.Format("{0} {1} succeeded {2}", pacUrl, url, pInfo.lpszProxy));

                        }
                        catch (WinHTTPException x)
                        {
                            System.Console.WriteLine(String.Format("{0} {1} failed {2}", pacUrl, url, x.Message));
                        }
                    }
                }
            } else
            {
                
            }
        }
    }
}
