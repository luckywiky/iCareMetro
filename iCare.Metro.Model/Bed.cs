using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCare.Metro.Model
{
    public class Bed
    {

        public Bed(string no, string name, string sex, string age, string condition, string nursing)
        {
            BedNo = no;
            Name = name;
            Sex = sex;
            Age = age;
            Condition = condition;
            Nursing = nursing;
        }

        public string BedNo
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Sex
        {
            get;
            set;
        }

        public string Age
        {
            get;
            set;
        }

        public string Condition
        {
            get;
            set;
        }

        public string Nursing
        {
            get;
            set;
        }
    }
}
