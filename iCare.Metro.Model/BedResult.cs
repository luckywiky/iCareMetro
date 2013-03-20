using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iCare.Metro.Model
{
    [DataContract]
    public class BedResult : Result
    {
        public List<Bed> Beds
        {
            get;
            set;
        }
    }
}
