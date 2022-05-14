using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Manager manager = new Manager();
            manager.Save();
            Console.ReadLine();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void UserCheck()
        {
            Console.WriteLine("User Checked");
        }
    }

    internal interface IAuthorize
    {
        void UserCheck();
    }



    class Validation : IValidation
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }

    internal interface IValidation
    {
        void Validate();
    }

    class Manager
    {
        private CrossCuttongConsernsFacade _conserns;
        public Manager()
        {
            _conserns = new CrossCuttongConsernsFacade();
        }

        public void Save()
        {
            _conserns.logging.Log();
            _conserns.caching.Cache();
            _conserns.authorize.UserCheck();
            _conserns.validation.Validate();

            Console.WriteLine("Saved!");
        }



        // CrossCuttongConsernsFacade OLUŞTURMADAN 
        //private ILogging _logging;
        //private ICaching _caching;
        //private IAuthorize _authorize;

        //public Manager(ILogging logging, ICaching caching, IAuthorize authorize)
        //{
        //    _logging = logging;
        //    _caching = caching;
        //    _authorize = authorize;
        //}

        //public void Save()
        //{
        //    _logging.Log();
        //    _caching.Cache();
        //    _authorize.UserCheck();

        //    Console.WriteLine("Saved!");
        //}
    }

    class CrossCuttongConsernsFacade
    {
        public ILogging logging;
        public ICaching caching;
        public IAuthorize authorize;
        public IValidation validation;

        public CrossCuttongConsernsFacade()
        {
            logging = new Logging();
            caching = new Caching();
            authorize = new Authorize();
            validation = new Validation();
        }
    }
}
