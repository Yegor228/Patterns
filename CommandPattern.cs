using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class CommandPattern
    {
        public static void TestCommand()
        {
            ICommand bc = new BoozerCommand(new Boozer("Valera"));

            Invoker invoke = new Invoker(bc);

            invoke.Start();

            invoke.Stop();
        }


    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }


    public class Boozer
    {
        public string Name { get; set; }

        public Boozer(string name)
        {
            Name = name;
        }
        public void DrinkPivo() => Console.WriteLine("Drink pivo!");
        public void DrinkVodka() => Console.WriteLine("Drink vodka!");

        public void GoSleep() => Console.WriteLine("Go sleep!");
    }

    public class BoozerCommand: ICommand
    {
        private Boozer _boozer; 
        public BoozerCommand(Boozer boozer)
        {
            _boozer = boozer;
        }

        public void Execute()
        {
            _boozer.DrinkPivo();
            Task.Delay(1000).GetAwaiter().GetResult();
            _boozer.DrinkVodka();
        }

        public void Undo()
        {
            _boozer.GoSleep();
        }
    }

    public class Invoker
    {
        private ICommand _command;

        public Invoker(ICommand command)
        {
            _command = command;
        }

        public void Start()
        {
            _command.Execute();
        }

        public void Stop()
        {
            _command.Undo();
        }
    }

}
