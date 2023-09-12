using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace ProjectDelta.Controllers
{
    internal enum RequestType
    {
        GET = 0,
        POST = 1
    }

    internal class HTTPRequestController
    {
        public static readonly int COUNT_OF_REQUEST_ATTEMPTS = 3;

        private static string[] _userAgents;
        private static Random _rnd;

        public static void Initialize()
        {
            _userAgents = Properties.Resources.UserAgents.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            _rnd = new Random(Guid.NewGuid().GetHashCode());
        }

        public static string GetRandomUserAgent()
        {
            string str = "";
            str = _userAgents[_rnd.Next(_userAgents.Length)];
            return str;
        }

        public static bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string SendRequest(string url, RequestType type, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null,
                                         int connectTimeoutMs = 1000)
        {
            try
            {
                string html = "";
                using (var request = new xNet.HttpRequest())
                {
                    request.SslCertificateValidatorCallback += ServerCertificateValidationCallback;
                    request.IgnoreProtocolErrors = true;
                    request.ConnectTimeout = connectTimeoutMs;

                    request.UserAgent = GetRandomUserAgent();
                    request.KeepAlive = true;

                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            request.AddHeader(header.Key, header.Value);
                        }
                    }
                    
                    RequestParams reqParams = null;
                    if (parameters != null)
                    {
                        reqParams = new RequestParams();
                        foreach (var param in parameters)
                        {
                            reqParams[param.Key] = param.Value;
                        }
                    }

                    xNet.HttpResponse response = null;
                    if (type == RequestType.GET)
                    {
                        response = request.Get(url, reqParams);
                    } 
                    else
                    {
                        response = request.Post(url, reqParams);
                    }

                    html = response.ToString();
                    return html;
                }
            } catch
            {
                return null;
            }
        }

        public static string DownloadImageBase64FromURL(string imageUrl, int connectTimeoutMs = 1000)
        {
            try
            {
                using (HttpRequest request = new HttpRequest())
                {
                    request.SslCertificateValidatorCallback += ServerCertificateValidationCallback;
                    request.IgnoreProtocolErrors = true;
                    request.ConnectTimeout = connectTimeoutMs;
                    request.UserAgent = GetRandomUserAgent();

                    HttpResponse response = request.Get(imageUrl);

                    if (response.IsOK)
                    {
                        byte[] imageBytes = response.ToBytes();

                        // Преобразуйте массив байтов в строку Base64
                        string base64Image = Convert.ToBase64String(imageBytes);
                        return base64Image;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static string ExecuteFunctionUntilSuccess(Func<string> function, int countOfAttempts)
        {
            string result = null;
            int attempts = 0;
            while (attempts++ < countOfAttempts)
            {
                result = function();
                if (result != null) break;
            }
            return result;
        }
    }
}
