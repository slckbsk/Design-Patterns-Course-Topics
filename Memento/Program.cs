using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book
            {
                Author = "İmam Ahmed",
                Title = "Cehmiyeye Reddiye",
                Isbn = "23"
            };

            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Isbn = "31";
            book.Title = "Cehmiyeye ve Sapıklara Reddiye";

            book.ShowBook();

            book.ResotereFromUndo(history.Memento);
            book.ShowBook();


            Console.ReadLine();
        }
    }

    class Book
    {
        private string _author;
        private string _title;
        private string _isbn;
        private DateTime _lastEdited;

        public string Author {
            get {return _author;}
            set 
            {
                _author = value;
                SetLastEdited();
            }
        }

        public string Title { 
            get {return _title;}
            set 
            { 
                _title = value;
                SetLastEdited();
            }
        }

        public string Isbn {
            get {return _isbn;}
            set 
            {
                _isbn = value;
                SetLastEdited();
            }
        }

       private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_author, _title, _isbn, _lastEdited) ;
        }

        public void ResotereFromUndo(Memento memento)
        {   
            _author = memento.Author;
            _title = memento.Title;
            _isbn = memento.Isbn;   
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2}, edited : {3}", Isbn, Title, Author, _lastEdited);
        }
    }


    class Memento
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Isbn { get; set; }

        public DateTime LastEdited { get; set; }


        public Memento(string author, string title, string isbn, DateTime lastEdited)
        {
            Author = author;
            Title = title;
            Isbn = isbn;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
