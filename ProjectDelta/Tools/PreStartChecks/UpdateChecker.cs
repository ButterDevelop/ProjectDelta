using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelta.Tools.PreStartChecks
{
    internal class UpdateChecker
    {
        public static bool NewVersion()
        {
            try
            {
                string url = B64X.Encrypt("http://a116901.hostde27.fornex.host/delta/license/version.txt");
                HttpWebRequest requestnewversion = (HttpWebRequest)WebRequest.Create(B64X.Decrypt(url));
                requestnewversion.Method = "GET";
                requestnewversion.ServerCertificateValidationCallback += DLLHash.ServerCertificateValidationCallback;
                HttpWebResponse responze = (HttpWebResponse)requestnewversion.GetResponse();
                string html = new StreamReader(responze.GetResponseStream()).ReadToEnd();
                if (html != Properties.Resources.Version) return true; else return false;
            }
            catch { return false; }
        }
    }
}
