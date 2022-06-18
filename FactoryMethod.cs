using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    internal class FactoryMethod
    {
        
        public static void TestFactoryMethod()
        {
            var subj = new SchoolFactory().CreateTecher("Сергей", 33, "M");
            Console.WriteLine($"{subj.Name} {subj.Age} {subj.Sex}");
            subj.DoWork();

            var subj2 = new ConstructorFactory().CreateConstructor("Валера", 47, "M");
            Console.WriteLine($"{subj2.Name} {subj2.Age} {subj2.Sex}");
            subj2.DoWork();
        }

    }


    public abstract class Man
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

        public abstract void DoWork();

        public Man(string name, int age, string sex)
        {
            Name = name; Age = age; Sex = sex; 
        }

    }

    public class Teacher : Man
    {
        public override void DoWork()
        {
            Console.WriteLine("Learn children");
        }
        public Teacher(string name, int age, string sex) : base(name, age, sex) { }
    }

    public class Constructor : Man
    {
        public override void DoWork()
        {
            Console.WriteLine("Build house");
        }

        public Constructor(string name, int age, string sex) : base(name, age, sex) { }
    }

    public class SchoolFactory
    {
        public Teacher CreateTecher(string name, int age, string sex)
        {
            return new Teacher(name, age, sex);
        }
    }

    public class ConstructorFactory
    {
        public Constructor CreateConstructor(string name, int age, string sex)
        {
            return new Constructor(name, age, sex);
        }
    }




}
