using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(StubLogger.GetLogger());
            manager.Save();
            Console.ReadLine();
        }
    }


    class Manager
    {
        private ILogger _logger;

        public Manager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            Console.WriteLine("Saved !");
            _logger.Log();
        }
    }

    interface ILogger
    {
        void Log();
    }


    class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }

    class NLogLogger : ILogger  
    {
        public void Log()
        {
            Console.WriteLine("Logged with NLogLogger");
        }
    }

    class StubLogger : ILogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();

        private StubLogger()
        {
            // BOŞ YAPICI
        }

        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger == null)
                {
                    _stubLogger = new StubLogger();
                }
            }
            return _stubLogger;
        }

        public void Log()
        {
            // BOŞ LOG
        }
    }

    class ManagerTest
    {
        public void SaveTest()
        {
            Manager manager = new Manager(StubLogger.GetLogger());
            manager.Save();
        }
    }
}
