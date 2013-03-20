using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iCare.Metro.Model
{
    [DataContract]
    public class LoginResult : Result
    {
        [DataMember]
        public string UserID
        {
            get;
            set;
        }
        [DataMember]
        public string UserName
        {
            get;
            set;
        }
    }
}
