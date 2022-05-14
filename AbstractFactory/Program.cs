using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new Factory2());
            manager.GetAll();
            Console.ReadLine();
        }
    }



    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class LogTBasak : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Log with LogTBasak");
        }
    }


    public class LogSBasak : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Log with LogSBasak");
        }
    }



    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with MemCache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cache with RedisCache");
        }
    }


    public abstract class CrossCuttingConsernFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConsernFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new LogTBasak();
        }
    }

    public class Factory2 : CrossCuttingConsernFactory
    {
        public override Caching CreateCaching()
        {
            return new MemCache();
        }

        public override Logging CreateLogger()
        {
            return new LogSBasak();
        }
    }


    public class Manager
    {
        private CrossCuttingConsernFactory _factory;

        Caching _caching;
        Logging _logging;

        public Manager(CrossCuttingConsernFactory factory)
        {
            _factory = factory;
            _caching = _factory.CreateCaching();
            _logging = _factory.CreateLogger();
        }


        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("data");

            Console.WriteLine("Listelendi");
        }
    }
}
