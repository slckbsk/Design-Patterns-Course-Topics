using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Proxy.CreditManager;

namespace Proxy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CreditManager manager = new CreditManager();


            CreaditBase manager = new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());
            Console.ReadLine();
        }
    }



    abstract class CreaditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreaditBase
    {
        public override int Calculate()
        {
            int total = 1;

            for (int i = 1; i < 5; i++)
            {
                total *= i;
                Thread.Sleep(500);
            }
            return total;
        }

        public class CreditManagerProxy : CreaditBase
        {
            private CreditManager _creaditManager;
            private int _cachedValue;
            public override int Calculate()
            {
                if (_creaditManager == null)
                {
                    _creaditManager = new CreditManager();
                    _cachedValue = _creaditManager.Calculate();
                }
                return _cachedValue;
            }
        }
    }
}
