using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(Get(""));
            Console.Read();
        }

        static string Get(string patienId)
        {

            iCare.Net.RestRequest request = new iCare.Net.RestRequest("");//Config.Actions.GetCourses);
            request.AddUrlSegment("patienid", patienId);
            iCare.Net.RestClient c = new iCare.Net.RestClient("http://localhost:28273");
            Task<string> task = c.ExecuteAsync(request);

            string json = task.GetAwaiter().GetResult();

            return json;
        }
    }
}

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
            Uri uri = new Uri(string.Format("{0}/{1}{2}", host, request.Action, request.UrlSegments));
            HttpResponseMessage response;
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



    public class RestRequest
    {
        private HttpRequestHeaders headers;
        private string action = string.Empty;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        private Dictionary<string, string> urlSegments = new Dictionary<string, string>();

        private Dictionary<string, string> parameters = new Dictionary<string, string>();

        public Dictionary<string, string> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }

        private HttpMethod method = HttpMethod.Get;

        public HttpMethod Method
        {
            get { return method; }
            set { method = value; }
        }

        public RestRequest(string action)
        {
            this.action = action;
        }

        public RestRequest(string action, HttpMethod method)
        {
            this.action = action;
            this.method = method;
        }

        public void AddUrlSegment(string key, string value)
        {
            if (urlSegments.ContainsKey(key))
                urlSegments[key] = value;
            else
                urlSegments.Add(key, value);
        }

        public void AddParameter(string name, string value)
        {

            parameters.Add(name, value);
        }

        public string UrlSegments
        {
            get
            {
                StringBuilder segmentString = new StringBuilder();

                if (urlSegments.Count > 0)
                {
                    segmentString.Append("?");
                    foreach (string key in urlSegments.Keys)
                    {
                        segmentString.AppendFormat("{0}={1}&", key, urlSegments[key]);
                    }
                    segmentString.Remove(segmentString.Length - 1, 1);
                }

                return segmentString.ToString();
            }
        }


    }

}
