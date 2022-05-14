using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            manager._creditCalculatorBase = new Before2010CreditCalculator();
            manager.SaveCredit();

            manager._creditCalculatorBase = new After2010CreditCalculator();
            manager.SaveCredit();

            Console.ReadLine();
        }
    }

     abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

     class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Calculated Before 2010" );
        }
    }


     class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Calculated After 2010");
        }
    }


    class Manager
    {
       public CreditCalculatorBase _creditCalculatorBase { get; set; }

        public void SaveCredit()
        {
            Console.WriteLine("Manager business");
            _creditCalculatorBase.Calculate();
        }
    }

}
