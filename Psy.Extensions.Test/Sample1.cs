using System; //<<-- This NameSpace Activate Dataset proceess by Psy.Extensions
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psy.Extensions.Test
{
    static class Sample1
    {
        internal static void Run()
        {
            object obj1 = 50;
            object obj2 = "a";
            object obj3 = DateTime.Now;

            int obj1Convert;
            string obj2Convert;
            DateTime obj3Convert;

            //Standart Convert
            obj1Convert = Convert.ToInt32(obj2); //System.InvalidCastException
            obj1Convert = Convert.ToInt32(obj3); //System.InvalidCastException
            obj1Convert = Convert.ToInt32(obj1); //OK

            obj2Convert = Convert.ToString(obj1); //Not Error Type Warning
            obj2Convert = Convert.ToString(obj3); //Not Error Type Warning
            obj2Convert = Convert.ToString(obj2); //OK

            obj3Convert = Convert.ToDateTime(obj1); //System.InvalidCastException
            obj3Convert = Convert.ToDateTime(obj2); //System.InvalidCastException
            obj3Convert = Convert.ToDateTime(obj3); //OK


            //Psy.Extension Convert
            obj1Convert = obj2.ToInt32(); //Not Error Cast = 0
            obj1Convert = obj3.ToInt32(); //Not Error Cast = 0
            obj1Convert = obj1.ToInt32(); //OK

            obj2Convert = obj1.ToStringAbs(); //Not Error Type Warning
            obj2Convert = obj3.ToStringAbs(); //Not Error Type Warning
            obj2Convert = obj2.ToStringAbs(); //OK

            obj3Convert = obj1.ToDateTime(); //Not Error Cast = DateTime MinValue
            obj3Convert = obj2.ToDateTime(); //Not Error Cast = DateTime MinValue
            obj3Convert = obj3.ToDateTime(); //OK
        }
    }
}
