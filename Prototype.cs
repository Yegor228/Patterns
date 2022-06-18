using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    internal class Prototype
    {
        public static void TestPrototype()
        {
            IFigure tmp = new Circle(10);
            var copy = tmp.Clone();
            copy.GetInfo();


            copy = new Rectangle(10, 20);
            copy.GetInfo();



        }
    }


    internal interface IFigure
    {
        public IFigure Clone();

        public void GetInfo();
    }

    internal class Circle : IFigure
    {
        private int _radius;
        public IFigure Clone()
        {
            return new Circle(_radius);
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом r = {0}", _radius);
        }

        public Circle(int r)
        {
            _radius = r;
        }

    }

    internal class Rectangle : IFigure
    {
        private int _weight;
        private int _height;
        public IFigure Clone()
        {
            return new Rectangle(_weight, _height);
        }

        public void GetInfo()
        {
            Console.WriteLine("Прямоугольник, в котором weight = {0}, height = {1}", _weight, _height);
        }

        public Rectangle(int w, int h)
        {
            _weight = w;
            _height = h;
        }
    }
}
