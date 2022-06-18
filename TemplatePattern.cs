using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class TemplatePattern
    {
        public static void TestTemplate()
        {
            DrunkerTemplate drunkerVodka = new DrunkVodka();
            DrunkerTemplate drunkerPivo = new DrunkPivo();

            List<DrunkerTemplate> drunkerTemplates = new List<DrunkerTemplate>();
            drunkerTemplates.Add(drunkerVodka);
            drunkerTemplates.Add(drunkerPivo);
            foreach(var a in drunkerTemplates)
            {
                a.Drunk();
                a.Chill();
            }
        }

    }


    public abstract class DrunkerTemplate
    {
        public abstract void Drunk();

        public abstract void Chill();

    }

    public class DrunkPivo : DrunkerTemplate
    {
        public override void Drunk() => Console.WriteLine("Drunk pivko");

        public override void Chill() => Console.WriteLine("Eat pivchiki");
    }

    public class DrunkVodka : DrunkerTemplate
    {
        public override void Drunk() => Console.WriteLine("Drunk vodka");

        public override void Chill() => Console.WriteLine("Eat pickles");


    }
}
