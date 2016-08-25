# WinProxyAutoConfigQAT

Proxy Auto Configuration (PAC) files can be difficult to test because they are ECMAscript-ish but each browser or OS seems to implement their own subset of the language. Win/IE is probably the most archaic or limited in the language features that are supported. IE uses WinHTTP (or perhaps it's WinINET), Chrome uses its own V8 PAC evaluation or with the right options will use the WinHTTP PAC functionality. Because of these differences it can be hard to know whether a PAC file will work or not and it's tedious to go through manual tests.

This repo includes a simple tool to help with quality testing PAC files. It's a VS2015 dotNet CLI app that wraps the native WinHTTP API and calls it to test a nominate set of PAC files against a list of test URIs. Because it uses WinHTTP it should be a safe lowest common demoninator test - if your PAC file works with this tool then it should work in all browsers.

The build produces an executable and a DLL. The DLL covers a limited part of WinHTTP that is necessary and should be importable by tools such as powershell, which can't otherwise get at the necessary WinHTTP functions.

You could of course just reconfigure IE/Internet Settings to test your PAC manually. This tool is geared towards executing test cases without manual involvement.
