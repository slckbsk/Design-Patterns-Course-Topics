using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ClassManager classManager = new ClassManager(new LoggerFactoryT());
            classManager.Save();
   

            Console.ReadLine();
        }
    }

    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }


    public interface ILogger
    {
        void Log();
    }




    public class LoggerFactoryS : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // iş katmanı nereye loglayacağımız karar veriyoruz
            return new SbLogger();
        }
    }

    public class LoggerFactoryT : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new TbLogger();
        }
    }



    public class SbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine(" Sblogger Selcuk");
        }
    }

    public class TbLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine(" Tblogger Tuncay");
        }
    }



    public class ClassManager
    {

        private ILoggerFactory _loggerFactory;

        public ClassManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;

        }

        public void Save()
        {
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
            Console.WriteLine("Saved !");
        }

    }

}
