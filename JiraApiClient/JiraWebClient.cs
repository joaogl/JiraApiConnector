using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JiraApiClient
{

    public class JiraWebClient : WebClient
    {
        public int Timeout { get; set; }
        private string token { get; set; }

        public JiraWebClient() : base()
        {
            this.Timeout = 600000;
            this.Encoding = Encoding.UTF8;
        }

        public JiraWebClient(string token) : base()
        {
            this.Timeout = 600000;
            this.Encoding = Encoding.UTF8;
            this.Headers.Add("Content-Type", "Application/Json");
            this.Headers.Add("Accept-Encoding", "gzip,deflate");
            this.token = token;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address) as HttpWebRequest;
            request.Timeout = Timeout;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            // request.Headers.Add("JSESSIONID", this.token);

            // Attach the cookie auth token
            var cook = new Cookie();
            cook.Domain = request.Host;
            cook.Path = "/";
            cook.Name = "JSESSIONID";
            cook.Value = this.token;

            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(cook);

            return request;
        }
    }

}
