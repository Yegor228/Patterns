namespace Patterns
{
    public class Observer
    {
        public static void TestObserver()
        {
            BeerShop beerShop = new BeerShop("Бристоль");
            Subj yegor = new Subj("Yegor");
            Subj nastya = new Subj("Anastasia");
            beerShop.RegisterObserverable(yegor);
            beerShop.RegisterObserverable(nastya);
            while(true)
            {
                beerShop.NotifyObservers();
                Thread.Sleep(1000);
            }
        }
    }


    public class BeerShop : IObservable
    {
        private List<IObserver> _observers;
        public string Name { get; set; }
        public DateTime dt = new DateTime(2022, 04, 26, 22, 0, 0);
        public DateTime TimeToClose { get; set; }

        public BeerShop(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            Name = name;
            _observers = new List<IObserver>();
        }

        public void RegisterObserverable(IObserver observer)
        {
            if(!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            string dtSub = dt.Subtract(DateTime.Now).ToString();
            string ntf = " ALYARM! До закрытия магазина " + dtSub + " времени... Пиздуй за пивом, быстро! ";
            foreach (var a in _observers)
                a.Update(ntf);
        }
    }

    public class Subj : IObserver
    {
        public string Name { get; set; }

        public Subj(string name)
        {
            Name = name;
        }
        public void Update(string ntf)
        {
            Console.WriteLine("Уебан на " + Name + " " + ntf);
        }
    }


    public interface IObserver
    {
        void Update(string ntf);
    }

    public interface IObservable
    {
        void RegisterObserverable(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }

}
