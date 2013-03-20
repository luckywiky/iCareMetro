using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace iCare.Metro.Model
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

        private void AddIsoDateTimeConverter(JsonSerializer serializer)
        {
            IsoDateTimeConverter idtc = new IsoDateTimeConverter();
            //定义时间转化格式   
            idtc.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            //idtc.DateTimeFormat = "yyyy-MM-dd";   
            serializer.Converters.Add(idtc);
        }

        public string Serialize()
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

        public Result DeSerialize(string json)
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
}
