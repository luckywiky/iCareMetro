using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iCare.Net
{
    public class RestClient
    {
        
        private string host;
        private HttpClientHandler handler;

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public RestClient(string host)
        {
            this.host = host;
          
            
        }

        public async Task<string> ExecuteAsync(RestRequest request)
        {
            handler = new HttpClientHandler { AutomaticDecompression = System.Net.DecompressionMethods.GZip };
            HttpClient client = new HttpClient(handler);
            Uri uri = new Uri(string.Format("http://{0}/{1}{2}",host, request.Action, request.UrlSegments));
            HttpResponseMessage response ;
            if (request.Method == HttpMethod.Get)
            {
                response = await client.GetAsync(uri);
            }
            else
            {
                HttpContent content = new FormUrlEncodedContent(request.Parameters);
                
                response = await client.PostAsync(uri, content);
            }
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
