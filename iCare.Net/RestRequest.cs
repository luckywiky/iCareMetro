using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace iCare.Net
{
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

        public RestRequest(string action,HttpMethod method)
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
           
                parameters.Add(name,value);
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
