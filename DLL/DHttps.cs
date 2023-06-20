using System.Net;


namespace IMALOpening
{
    public class DHttps
    {
        public static HttpWebRequest CreateWebRequestOpenAcc()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var OpenAcc = MyConfig.GetValue<string>("AppSettings:OpenAccUrl");
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(OpenAcc);
            webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public static HttpWebRequest createChequebookUrl()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var OpenAcc = MyConfig.GetValue<string>("AppSettings:ChequebookUrl");
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(OpenAcc);
            webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public static HttpWebRequest CreateWebRequestCIF()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var CreateCIF = MyConfig.GetValue<string>("AppSettings:CreateCIF");
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(CreateCIF);
            webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        public static HttpWebRequest CreateWebRequestValidateCIF()
        {
            var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var CreateValidateCIF = MyConfig.GetValue<string>("AppSettings:ValidateCIFUrl");
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(CreateValidateCIF);
            webRequest.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            webRequest.Headers.Add(@"SOAP:Action");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
    }
}
