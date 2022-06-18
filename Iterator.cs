using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class Iterator
    {

        public static void TestIterator()
        {
            Library lib = new Library(0);

            for(int i = 0; i < 10; i++)
            {
                string name = "Форсаж " + i;
                lib.AddBook(new Book { Id = i , Name = name, PageCount = i*100});
            }
            foreach (var a in lib)
                Console.WriteLine(a.ToString());
            Console.WriteLine();
            for (int i = 0; i < lib.Count; i++)
                Console.WriteLine(lib[i]);
        }
    }


    public class Library : IEnumerable, IEnumerator
    {
        public int Id { get; set; }

        private IEnumerator _iterator;
        private Book _value;
        public object Current => _value;

        public int Count => _books.Count;

        private List<Book> _books;

        public Library(int id)
        {
            Id = id;
            _books = new List<Book>();
        }

        public Book this[int index]
        {
            get
            {
                return _books[index];
            }
            set
            {
                _books[index] = value;
            }
        }

        public void AddBook(Book book) => _books.Add(book);

        public IEnumerator GetEnumerator()
        {
            _iterator = _books.GetEnumerator();
            return _iterator;
        }

        public bool MoveNext()
        {
            while(_iterator.MoveNext())
            {
                _value = (Book)_iterator.Current;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    public struct Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PageCount { get; set; }

        public override string ToString()
        {
            return String.Concat(Id + " " +  Name + " " + PageCount);
        }
    }
}
