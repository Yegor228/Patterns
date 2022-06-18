namespace Patterns
{
    public class ChainOfResponsibility
    {
        public static void TestChainOf()
        {
            Chillers chillers = new Chillers(0, 100, 50);

            YegorPocketHandler handler = new YegorPocketHandler();
            SanyaPocketHandler sanyaPocketHandler = new SanyaPocketHandler();
            VityaPocketHandler vityaPocketHandler = new VityaPocketHandler();

            handler.Successor = sanyaPocketHandler;
            sanyaPocketHandler.Successor = vityaPocketHandler;
            handler.Handler(chillers);
        }

    }


    public class Chillers
    {
        public int YegorPocket { get; set; }

        public int SanyaPocket { get; set; }

        public int VityaPocket { get; set; }

        public Chillers(int a, int b, int c)
        {
            YegorPocket = a;
            SanyaPocket = b;
            VityaPocket = c;
        }
    }

    public abstract class PaymentHandler
    {
        public PaymentHandler? Successor { get; set; }

        public abstract void Handler(Chillers chillers);
    }

    public class YegorPocketHandler : PaymentHandler
    {
        public override void Handler(Chillers chillers)
        {
            if (chillers.YegorPocket > 0)
                Console.WriteLine("Я, Егор, покупаю пиво!");
            else if (Successor != null)
                Successor.Handler(chillers);
        }
    }
    public class SanyaPocketHandler : PaymentHandler
    {
        public override void Handler(Chillers chillers)
        {
            if (chillers.SanyaPocket > 0)
                Console.WriteLine("Я, Саня, покупаю пиво!");
            else if (Successor != null)
                Successor.Handler(chillers);

        }
    }
    public class VityaPocketHandler : PaymentHandler
    {
        public override void Handler(Chillers chillers)
        {
            if (chillers.VityaPocket > 0)
                Console.WriteLine("Я, Витя, покупаю пиво!");
            else if (Successor != null)
                Successor.Handler(chillers);
        }

    }

}
