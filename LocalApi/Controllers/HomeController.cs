using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.IO;

namespace LocalApi.Controllers
{

    
    public class Result
    {
 
        public int ReturnCode
        {
            get;
            set;
        }

        
        public string Msg
        {
            get;
            set;
        }

        private  void AddIsoDateTimeConverter(JsonSerializer serializer)
        {
            IsoDateTimeConverter idtc = new IsoDateTimeConverter();
            //定义时间转化格式   
            idtc.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            //idtc.DateTimeFormat = "yyyy-MM-dd";   
            serializer.Converters.Add(idtc);
        }

        public  string Serialize()
        {
            JsonSerializer serializer = new JsonSerializer();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            AddIsoDateTimeConverter(serializer);

            using (TextWriter sw = new StringWriter())
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, this);
                return sw.ToString();
            }
        }

        public  Result DeSerialize(string json)
        {
            JsonSerializer serializer = new JsonSerializer();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            AddIsoDateTimeConverter(serializer);
            using (TextReader sr = new StringReader(json))
            using (JsonReader writer = new JsonTextReader(sr))
            {
                return (Result)serializer.Deserialize(sr, this.GetType());
            }
        }
    }
   
    public class CResult : Result
    {

        public List<ContentData> Data = new List<ContentData>();
    }


    public class ContentData
    {
        public string Title
        {
            get;
            set;

        }

        public string Content
        {
            get;
            set;
        }
    }
    public class HomeController : ApiController
    {
        //
      

        public ActionResult Index()
        {
            CResult r = new CResult();
            r.Data.Add(new ContentData { Title = "A1", Content = "B1" });
            r.Data.Add(new ContentData { Title = "A2", Content = "B2" });
            r.Data.Add(new ContentData { Title = "A3", Content = "B3" });
            r.Data.Add(new ContentData { Title = "A4", Content = "B4" });
           
            return new ContentResult() { Content = r.Serialize() };
        }
    }
}
