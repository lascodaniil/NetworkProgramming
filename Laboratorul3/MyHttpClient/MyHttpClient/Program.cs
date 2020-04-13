using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyHttpClient
{


    class Program
    {

        /// place to save Cookie
        public static CookieCollection myCookie;

        static void Main(string[] args)
        {
            HttpClientRequestLogin();

            Thread t1 = new Thread(HttpClientResponseGet);
            Thread t2 = new Thread(HttpClientResponseGetReportOverWiew);
            Thread t3 = new Thread(HttpClientHead);
            Thread t4 = new Thread(HttpClientOptions);

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();

        }

        static void HttpClientRequestLogin()
        {
           
            var cookieContainer = new CookieContainer(); 

            WebProxy proxy = getWebProxy(); 
            var _handler = new HttpClientHandler { CookieContainer = cookieContainer, Proxy = proxy};
            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
            HttpClient httpClient = new HttpClient(_handler);
            Uri BaseUri = new Uri("https://moodle.ati.utm.md/login/index.php");

            var parameters = new Dictionary<string, string>();
                parameters["username"] = "lascodaniil";
                parameters["password"] = "Bicicleta25I!";
                
            

            var response = httpClient.PostAsync(BaseUri, new FormUrlEncodedContent(parameters));
            response.Wait();
       
            /// Save cookies
            CookieCollection cookies = _handler.CookieContainer.GetCookies(BaseUri);
            myCookie = cookies;

        }


        static WebProxy getWebProxy()
        {

            string proxyHost = "191.101.148.59";
            string proxyPort = "45785";

            string proxyUserName = "Sellascodaniil";
            string proxyPassword = "Q7t5ClS";

            var proxy = new WebProxy
            {
                Address = new Uri($"http://{proxyHost}:{proxyPort}"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,

                Credentials = new NetworkCredential(
                userName: proxyUserName,
                password: proxyPassword)
            };

            return proxy;
        }


        public static void HttpClientResponseGet()
        {

            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(myCookie);

            WebProxy proxy = getWebProxy();
            var _handler = new HttpClientHandler { CookieContainer = cookieContainer, Proxy = proxy };

            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            HttpClient httpClient = new HttpClient(_handler);
            Uri BaseUri = new Uri("https://moodle.ati.utm.md");

            var content = httpClient.GetStringAsync(BaseUri);
            content.Wait();

            string htmlPage = content.Result;
            getDataFromPage(htmlPage);
        }


        static void getDataFromPage(string response)
        {
            Regex regex = new Regex("<div class=\"coursename\"><a class=\"\" href=\"https://moodle.ati.utm.md/course/view.php.id=[0-9]{1,}\">[^.]+</a>", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(response);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("============================ GET ALL COURSES ============================");

            if (matches.Count > 0)
            {

                foreach (Match match in matches)
                {
                    string data = match.Value;


                    string coursName = getAllCoursesName(data);
                    Console.WriteLine("    " + coursName);

                }

                Console.WriteLine("============================ END OF ALL COURSES ============================");
                Console.WriteLine();
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("No matches found");
            }
        }


        public static void HttpClientResponseGetReportOverWiew()
        {

            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(myCookie);

            WebProxy proxy = getWebProxy();
            var _handler = new HttpClientHandler { CookieContainer = cookieContainer, Proxy = proxy };

            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            HttpClient httpClient = new HttpClient(_handler);
            Uri BaseUri = new Uri("https://moodle.ati.utm.md/grade/report/overview/index.php");

            var content = httpClient.GetStringAsync(BaseUri);
            content.Wait();

            string htmlPage = content.Result;

            getCoursesFromPage(htmlPage);
        }


        static void getCoursesFromPage(string response)
        {
            Regex regex = new Regex("[<a href=\"https://moodle.ati.utm.md/course/user.php?mode=grade&amp;id=][0-9]{1,}.amp;user=[0-9]+\">[^.]+</a></td><td class=\"cell [^a-b][0-9]\" id=\"grade-report-overview-[0-9]+_[^a-b][0-9]_[^a-b][0-9]\">[0-9,-]+</td", RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(response);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("============================  Cursurile la care particip ============================");

            int fixLen = 50;

            if (matches.Count > 0)
            {

                foreach (Match match in matches)
                {
                    string data = match.Value;

                    string coursesName = getCoursesName(data);
                    Console.Write("  " + coursesName);


                    /// Spaces form format string
                    for (int i = 0; i < fixLen - coursesName.Length; i++) Console.Write(" ");


                    string coursesCost = getCoursesCost(data);
                    Console.WriteLine(coursesCost);

                }

            }
            else
            {
                Console.WriteLine("No matches found");
            }

            Console.WriteLine("============================ End of Cursurile la care particip ============================");
        }


        static void HttpClientHead()
        {
            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(myCookie);

            WebProxy proxy = getWebProxy();
            var _handler = new HttpClientHandler { CookieContainer = cookieContainer, Proxy = proxy };

            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            HttpClient httpClient = new HttpClient(_handler);
            Uri BaseUri = new Uri("https://moodle.ati.utm.md");

            var result = httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Head, BaseUri));
            result.Wait();


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" ============================================ HEAD REQUEST ============================================ ");
            Console.WriteLine(result.Result);
            Console.WriteLine(" ============================================ END HEAD REQUEST ============================================ ");


        }

        static void HttpClientOptions()
        {
            CookieContainer cookieContainer = new CookieContainer();
            cookieContainer.Add(myCookie);

            WebProxy proxy = getWebProxy();
            var _handler = new HttpClientHandler { CookieContainer = cookieContainer, Proxy = proxy };

            _handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            HttpClient httpClient = new HttpClient(_handler);
            Uri BaseUri = new Uri("https://moodle.ati.utm.md");

            var result = httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Options, BaseUri));
            result.Wait();


            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(" ============================================ OPTIONS REQUEST ============================================ ");
            Console.WriteLine(result.Result);
            Console.WriteLine(" ============================================ END OPTIONS OPTIONS ============================================ ");
        }


        static string getAllCoursesName(string data)
        {
            int startIdx = 0;
            int endIxd = 0;
            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (data[i] == '<')
                {
                    endIxd = i - 1;
                    break;
                }
            }

            for (int i = endIxd; i >= 0; i--)
            {
                if (data[i] == '>')
                {
                    startIdx = i + 1;
                    break;
                }
            }

            int strLen = endIxd - startIdx + 1;
            string coursName = data.Substring(startIdx, strLen);

            return coursName;
        }


        static string getCoursesName(string data)
        {
            int startIdx = 0;
            int endIxd = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == '>')
                {
                    startIdx = i + 1;
                    break;
                }
            }

            for (int i = startIdx; i < data.Length; i++)
            {
                if (data[i] == '<')
                {
                    endIxd = i - 1;
                    break;
                }
            }

            int strLen = endIxd - startIdx + 1;
            string coursesName = data.Substring(startIdx, strLen);

            return coursesName;
        }


        static string getCoursesCost(string data)
        {
            int startIdx = 0;
            int endIxd = 0;
            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (data[i] == '<')
                {
                    endIxd = i - 1;
                    break;
                }
            }

            for (int i = endIxd; i >= 0; i--)
            {
                if (data[i] == '>')
                {
                    startIdx = i + 1;
                    break;
                }
            }

            int strLen2 = endIxd - startIdx + 1;
            string coursecCost = data.Substring(startIdx, strLen2);

            return coursecCost;
        }


       
    }
}
