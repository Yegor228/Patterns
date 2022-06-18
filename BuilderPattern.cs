using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class BuilderPattern
    {
        public static void TestBuilderPattern()
        {
            var ttt = new SoupCreator("Дефолтный");
            Soup soup = ttt.Build();
            Console.WriteLine(soup.ToString());
        }

    }


    public abstract class SoupBuilder
    {
        public abstract void FirstPart();
        public abstract void SecondPart();
        public abstract void ThirdPart();
        public abstract void AnyPart();
        public abstract Soup Build();
    }

    public class Soup
    {
        private List<string> _parts;
        public string Name { get; private set; }

        public Soup(string name)
        {
            try
            {
                if(name == null)
                    throw new ArgumentNullException("name");
                Name = name;
                _parts = new List<string>();
            }
            catch
            {
                throw;
            }
            
        }

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            return string.Join(" ", _parts.ToArray());
        }
    }

    public class SoupCreator : SoupBuilder
    {
        private Soup _soup;
        public SoupCreator(string name)
        {
            _soup = new Soup(name);
        }
        public override void FirstPart()
        {
            _soup.Add("Вода");
        }
        public override void SecondPart()
        {
            _soup.Add("Овощи");
        }
        public override void ThirdPart()
        {
            _soup.Add("Специи");
        }
        public override void AnyPart()
        {
            _soup.Add("Мясо");
        }

        public override Soup Build()
        {
            FirstPart();
            SecondPart();
            ThirdPart();
            AnyPart();
            return _soup;
        }
    }
}
