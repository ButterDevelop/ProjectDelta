using Newtonsoft.Json;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Windows.Forms;

namespace ProjectDelta.Tools
{
    public static class CheckLicense
    {
        public static string Password = B64X.Encrypt("A45A51EE977B2B5C1A883C155C55A2AB"), approved = B64X.Encrypt("wrong");
        public static int remaining = 0;
        public static void GetRemainingTime()
        {
            string html = "";
            string url = B64X.Encrypt("http://a116901.hostde27.fornex.host/delta/license/LicenseEnd.php?q=" + MCrypt.Encrypt(MCrypt.Encrypt(ID.NewIDNumber)));
            int attempts = 0;
            bool quitFlag = false;
            while (attempts < 3 && !quitFlag)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(B64X.Decrypt(url));
                    request.Method = "GET";
                    request.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    html = B64X.Encrypt(new StreamReader(response.GetResponseStream()).ReadToEnd());
                    //Everything is good:
                    quitFlag = true;
                }
                catch { }
                attempts++;
                if (!quitFlag) Thread.Sleep(10 * 1000);
            }
            if (!quitFlag)
            {
                remaining = -7;
                return;
            }

            try
            {
                DateTime end = DateTime.Parse(MCrypt.Decrypt(MCrypt.Decrypt(B64X.Decrypt(html))));
                TimeSpan ts = end - DateTime.Now;

                remaining = (int)ts.TotalDays;
            } catch { remaining = -5; }
        }
        public static bool CheckInternetConnection()
        {
            int count = 0;
            try
            {
                Ping p = new Ping();
                PingReply pr = p.Send("google.com");
                if (pr.Status == IPStatus.Success)
                {
                    count++;
                }
            }
            catch { }

            try
            {
                Ping p = new Ping();
                PingReply pr = p.Send("google.ru");
                if (pr.Status == IPStatus.Success)
                {
                    count++;
                }
            }
            catch { }

            try
            {
                Ping p = new Ping();
                PingReply pr = p.Send("google.by");
                if (pr.Status == IPStatus.Success)
                {
                    count++;
                }
            }
            catch { }

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool ServerCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (certificate.GetRawCertDataString() == "3082065A30820542A003020102021100CF9FDF5357A105D7CBFF4BB7996757E9300D06092A864886F70D01010B05003072310B3009060355040613025553310B30090603550408130254583110300E06035504071307486F7573746F6E31153013060355040A130C6350616E656C2C20496E632E312D302B060355040313246350616E656C2C20496E632E2043657274696669636174696F6E20417574686F72697479301E170D3232303232383030303030305A170D3233303232383233353935395A301F311D301B06035504031314686F7374646532342E666F726E65782E686F737430820122300D06092A864886F70D01010105000382010F003082010A0282010100A6E0B830F1957676AAF1FDE08EC7184ECF2C5511B9076C81F33789DE8E258D970AF964B48693095E63063E6A566019C9B0FA8C2CA81032E84DA5794C0C20F7CED03C60AAD3387AF39A573D9EEF1364F5E6B687F70F2820AD2F910CAF1B8255CF4260067D5E60DB0F9F32A088BE249388ABEACE91BF0548C8E544CF160B4485DC61D7E3FF12635BF94B0EBFF9CF0F42194EC2D1A331564026523DEBBC9E39CD0DC7E99DBD5AA38B66D24E9B1DCB1A08A988393E26E4205D343F7FD3694B28EC3BE31D28FAACCC12A8E53040383FAC8B691B458C9EBB1CCF7F84C1900D61695393DD6BE192F7F4A39EA00ABE4A876B4F45C0207277D15BB40E8AE7404A1858329D0203010001A382033C30820338301F0603551D230418301680147E035A65416BA77E0AE1B89D08EA1D8E1D6AC765301D0603551D0E04160414738737C9161E8499A477D439012CE1C9229B9913300E0603551D0F0101FF0404030205A0300C0603551D130101FF04023000301D0603551D250416301406082B0601050507030106082B0601050507030230490603551D20044230403034060B2B06010401B231010202343025302306082B06010505070201161768747470733A2F2F7365637469676F2E636F6D2F4350533008060667810C010201304C0603551D1F044530433041A03FA03D863B687474703A2F2F63726C2E636F6D6F646F63612E636F6D2F6350616E656C496E6343657274696669636174696F6E417574686F726974792E63726C307D06082B060105050701010471306F304706082B06010505073002863B687474703A2F2F6372742E636F6D6F646F63612E636F6D2F6350616E656C496E6343657274696669636174696F6E417574686F726974792E637274302406082B060105050730018618687474703A2F2F6F6373702E636F6D6F646F63612E636F6D301F0603551D11041830168214686F7374646532342E666F726E65782E686F73743082017E060A2B06010401D6790204020482016E0482016A0168007600ADF7BEFA7CFF10C88B9D3D9C1E3E186AB467295DCFB10C24CA858634EBDC828A0000017F3FD359B0000004030047304502210080CC893EB3207BCD56604EA477FA70E0CCB49313EE976C3EF0CE861690DE094202201508B27E47EEAF75A6B106BD27242890B70818243D4D54947B9AA725470B41B50076007A328C54D8B72DB620EA38E0521EE98416703213854D3BD22BC13A57A352EB520000017F3FD359B20000040300473045022100ED7E7084FF456A358824A4DCBFFA85867D7756D4E7DE3B23FCD73EB76021D82D0220792D4EB28366FCF93F5D0BA9AACECCCCFFD61DBE9E59789C443EE902DB4B8288007600E83ED0DA3EF5063532E75728BC896BC903D3CBD1116BECEB69E1777D6D06BD6E0000017F3FD3599000000403004730450221008E96C3D3A51FD9B92DDD91D4D63E2640C213D53ED93876295F890018B85D47CE0220596C29685B4F4A5FFFAC6341E68DA52F874B7A0259B8E3E00EDDB2154E097492300D06092A864886F70D01010B050003820101002255B110CC55676180D685667B21789E82E54B9D1319690CAD2C9C24DC7596AB57B0A7043F0F486F4B4E25FBE2927C35AD61B0F69D1973B869A8CB108AB9649A8FF7B402D8B71A82A3CDEFE6748DDA9F6F6599F739F9FF6F1397DA2F378228939FCD5E9336653C37DD5036571CE1ED07AA85C1FE2BD74096BC11B891B8A6930C7E854D078481221C5544555A5BBE0629C5ABC8254FC9EC113D361528D508D24C1E7B8C603714107AF163C8034CDE95E7E56DAAEA8FD114275B66AE0D3F0E193C44DB39BD1661AD6CF2F4CFC9A43C4A52D50F68A24BF7755839F5FACB14F1AFD3459DABFD077CFE1974DB3034D71D6712C298FAF56905B640295762C169895BB8") return true; else return false;
        }

        public class jsonDes
        {
            private string Salt, Result;
            public string salt
            {
                get
                {
                    return Salt;
                }
                set
                {
                    Salt = B64X.Encrypt(value);
                }
            }
            public string result
            {
                get
                {
                    return Result;
                }
                set
                {
                    Result = B64X.Encrypt(value);
                }
            }
        }
        public static BigInteger fun(BigInteger p, BigInteger a, BigInteger b)
        {
            BigInteger s = BigInteger.One;
            for (int i = 1; i <= b.IntValue; i++)
            {
                s = s.Multiply(a).Mod(p);
            }
            return s;
        }
        public static void Check()
        {
            if (!CheckInternetConnection()) { if (!Program.silent) MessageBox.Show("Unable to connect the Internet!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); Environment.Exit(0); }

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;/* | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;*/

                Random myrandom = new Random(DateTime.Now.Millisecond * DateTime.Now.Second * DateTime.Now.Year);
                BigInteger p = BigInteger.ValueOf(myrandom.Next(1000, 10000)), g, A, a, B, k;
                p = p.NextProbablePrime();
                g = BigInteger.ValueOf(FirstLevelRoot.generator(p.IntValue));
                a = BigInteger.ValueOf(myrandom.Next(p.IntValue));//A
                A = fun(p, g, a);

                string url = B64X.Encrypt("http://a116901.hostde27.fornex.host/delta/license/InstaDirectMessageTime.php");
                HttpWebRequest requesttime = (HttpWebRequest)WebRequest.Create(B64X.Decrypt(url));
                requesttime.Method = "GET";
                requesttime.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
                HttpWebResponse responz = (HttpWebResponse)requesttime.GetResponse();
                string htmltime = B64X.Encrypt(new StreamReader(responz.GetResponseStream()).ReadToEnd());
                string hash = B64X.Encrypt(MCrypt.Decrypt(new string(B64X.Decrypt(htmltime).Reverse().ToArray())));
                hash = B64X.Encrypt(new string(B64X.Decrypt(hash).Reverse().ToArray()));

                url = B64X.Encrypt("http://a116901.hostde27.fornex.host/delta/license/InstaDirectMessageTime.php?q=" + MCrypt.Encrypt(B64X.Decrypt(hash)));
                HttpWebRequest requesttimereal = (HttpWebRequest)WebRequest.Create(B64X.Decrypt(url));
                requesttimereal.Method = "GET";
                requesttimereal.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
                requesttimereal.Headers.Add("Cookie", responz.Headers["Set-Cookie"].Remove(responz.Headers["Set-Cookie"].IndexOf(';')));
                HttpWebResponse responze = (HttpWebResponse)requesttimereal.GetResponse();
                string TIME = B64X.Encrypt(MCrypt.Decrypt(new StreamReader(responze.GetResponseStream()).ReadToEnd()));


                HttpWebRequest reqt = (HttpWebRequest)WebRequest.Create("http://a116901.hostde27.fornex.host/delta/license/InstaDirectMessageDH.php?q=" + MCrypt.Encrypt("p=" + p.ToString() + "&g=" + g.ToString() + "&A=" + A.ToString() + "&time=" + System.Web.HttpUtility.UrlEncode(B64X.Decrypt(TIME))));
                reqt.Method = "GET";
                reqt.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
                HttpWebResponse resp = (HttpWebResponse)reqt.GetResponse();
                string htmlB = B64X.Encrypt(new StreamReader(resp.GetResponseStream()).ReadToEnd());
                B = new BigInteger(MCrypt.Decrypt(B64X.Decrypt(htmlB)));

                string ConstString = B64X.Encrypt("abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_");
                Random random = new Random(DateTime.Now.Second);
                string salt = B64X.Encrypt(new string(Enumerable.Repeat(B64X.Decrypt(ConstString), 10).Select(s => s[random.Next(s.Length)]).ToArray()));
                var outStr = new Dictionary<string, string>
                {
                    {"time",       B64X.Decrypt(TIME)},
                    {"id",         ID.NewIDNumber},
                    {"salt", B64X.Decrypt(salt)}
                };

                string req = B64X.Encrypt(JsonConvert.SerializeObject(outStr));

                string res = "";
                for (int i = 0; i < B64X.Decrypt(req).Length; i++)
                {
                    k = BigInteger.ValueOf(B64X.Decrypt(req)[i]);

                    k = k.Multiply(fun(p, B, a)).Mod(p);
                    res = B64X.Encrypt(B64X.Decrypt(res) + k.ToString() + ".");
                }

                url = B64X.Encrypt("http://a116901.hostde27.fornex.host/delta/license/InstaDirectMessage.php?q=" + MCrypt.Encrypt(B64X.Decrypt(res)));
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(B64X.Decrypt(url));
                request.Method = "GET";
                request.ServerCertificateValidationCallback += ServerCertificateValidationCallback;
                request.Headers.Add("Cookie", resp.Headers["Set-Cookie"].Remove(resp.Headers["Set-Cookie"].IndexOf(';')));
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string html = B64X.Encrypt(new StreamReader(response.GetResponseStream()).ReadToEnd());
                
                string result = "";
                foreach (string value in MCrypt.Decrypt(B64X.Decrypt(html)).Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    k = BigInteger.ValueOf(long.Parse(value));

                    k = k.Multiply(fun(p, B, p.Subtract(BigInteger.One.Add(a)))).Mod(p);
                    result = B64X.Encrypt(B64X.Decrypt(result) + (char)k.IntValue);
                }
                jsonDes account = JsonConvert.DeserializeObject<jsonDes>(B64X.Decrypt(result));
                if (MCrypt.Decrypt(new string(MCrypt.Decrypt(B64X.Decrypt(account.salt)).Reverse().ToArray())) != B64X.Decrypt(salt) || B64X.Decrypt(account.result) != "OK") throw new Exception();
            }
            catch
            {
                //File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "RandomRofl.log"), MCrypt.Encrypt(Environment.NewLine + "saltish" + B64X.Encrypt("shka") + Environment.NewLine + e.ToString() + Environment.NewLine + B64X.Decrypt(tempik)), System.Text.Encoding.UTF8);
                if (!Program.silent) MessageBox.Show("Something went wrong!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var t = new Thread(() => ShowKeyForm());
                t.Start();
                t.Join();
                Environment.Exit(0);
            }

            Thread.Sleep(1500);
        }

        static void ShowKeyForm()
        {
            ShowKey showKey = new ShowKey();
            showKey.ShowDialog();
        }
    }
}
