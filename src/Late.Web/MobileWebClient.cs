using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace Late.Web
{
    public class MobileWebClient : IMobileWebClient
    {
        public string GetHtml(string url)
        {
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_3_3 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8J2 Safari/6533.18.5");

            using (Stream data = client.OpenRead(url))
            using (StreamReader reader = new StreamReader(data))
            {
                return reader.ReadToEnd();
            }
        }
    }
}