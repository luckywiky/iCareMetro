using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCare.Metro.Model;
using iCare.Net;

namespace iCare.Metro.Operation
{
    public abstract class Api
    {
        private RestClient client;

        public RestClient Client
        {
            get { return client; }
            set { client = value; }
        }

        public Api()
        {
            client = new RestClient(Config.ApiHost);
        }

      


    }
}
