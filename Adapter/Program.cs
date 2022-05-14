using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new TBLoggerAdaptor());
            productManager.Save();

            Console.ReadLine();
        }
    }

    class ProductManager
    {

        private Ilogger _logger;

        public ProductManager(Ilogger logger)
        {
            _logger = logger;
        }


        public void Save()
        {
            _logger.log("\n User Data");
            Console.WriteLine("Save");
        }
    }


    interface Ilogger
    {
        void log(string message);
    }


    class SBlogger : Ilogger
    {
        public void log(string message)
        {
            Console.WriteLine("Logged with SB, {0}", message);
        }
    }


    class TBLoggerAdaptor : Ilogger
    {
        public void log(string message)
        {
            TBLogger _logger = new TBLogger();
            _logger.LogMessage(message);
        }
    }


    // nuget SENARYODA BU KOD DIŞARIDAN GELEM DOKUNAMIYORSUN
    public class TBLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with TB, {0}", message);
        }
    }



}
