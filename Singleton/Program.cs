using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager(); // buna izin vermiyor
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _instance;
        static object _instanceLock = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            // Lock öncesi   return _instance ?? (_instance = new CustomerManager());

            lock (_instanceLock)
            {
                if (_instance == null)
                {
                    _instance = new CustomerManager();
                }
            }
        
        return _instance;
        
        }


        //public static CustomerManager CreateAsSingleton()
        //{
        //    if (_instance == null)
        //    {
        //        _instance = new CustomerManager();
        //    }
        //    return _instance;
        //}

        public void Save()
        {
            Console.WriteLine("Saved !");
        }
    }
}
