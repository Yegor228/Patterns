using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    internal class Singleton
    {

        public static void TestSingleton()
        {
            SomeObj smObj = new SomeObj();
            var qqq = smObj.GetObj(10);
            Console.WriteLine(qqq.ID);
            qqq = smObj.GetObj(500);
            Console.WriteLine(qqq.ID);
            Console.WriteLine(smObj.TakeObjective.ID);

        }
    }



    public class SomeObj
    {
        private static Obj _obj;

        public Obj GetObj(int num)
        {
            if(_obj == null)
                _obj = new Obj(num);
            return _obj;
        }

        public Obj TakeObjective => _obj;

    }

    public class Obj
    {
        public int ID { get; set; }
        public Obj(int id) { ID = id; }
    }
}
