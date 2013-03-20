using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCare.Metro.Model
{
    public abstract class User
    {
        public int UID
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
    }

    public class Doctor:User
    {

    }

    public class Patient : User
    {

    }
}
