using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace iCare.Metro.Model
{
    [DataContract]
    public class Result
    {
        [DataMember]        
        public int ReturnCode
        {
            get;
            set;
        }

        [DataMember]
        public string Msg
        {
            get;
            set;
        }


    }
}
