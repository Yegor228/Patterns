using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    internal class StrategyPattern
    {
        public static void TestStrategy()
        {
            SeaTurtle seaTurtle = new SeaTurtle("Олег", new Swim());
            Console.WriteLine(seaTurtle.Name);
            seaTurtle._movable.Move();
        }

    }


    internal interface IMovable
    {
        public void Move();
    }

    internal class Run : IMovable
    { 
        public void Move() => Console.WriteLine("Run!!");
        
    }

    internal class Swim : IMovable
    {
        public void Move() => Console.WriteLine("Swim!!");

    }

    internal abstract class Turtle
    {
        public IMovable _movable;
        public string Name { get; set; }

        public Turtle(string name, IMovable movable)
        {
            Name = name;
            _movable = movable;
        }
    }

    internal class SeaTurtle : Turtle
    {
        public SeaTurtle(string name, IMovable movable) : base(name, movable)
        { }
    }
}
