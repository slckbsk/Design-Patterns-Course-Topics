using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccesor(vicePresident);
            vicePresident.SetSuccesor(president);

            Expens expens = new Expens
            {
                Detail = "For president birthday party",
                Amount = 15300
            };
            manager.HandleExpense(expens);

            Console.ReadLine();
        }
    }

    class Expens
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpensHandlerBase
    {
        protected ExpensHandlerBase _succesor;
        public abstract void HandleExpense(Expens expens);

        public void SetSuccesor(ExpensHandlerBase succesor)
        {
            _succesor = succesor;
        }
    }

    class President : ExpensHandlerBase
    {
        public override void HandleExpense(Expens expens)
        {
            if (expens.Amount > 5000 && expens.Amount <= 10000)
            {
                Console.WriteLine("President Handel the expens, dont worry be happy");
            }
            else
            {
                Console.WriteLine("Now you are in trouble");
            }
        }
    }

    class VicePresident : ExpensHandlerBase
    {
        public override void HandleExpense(Expens expens)
        {
            if (expens.Amount > 1000 && expens.Amount <= 5000)
            {
                Console.WriteLine("VicePresident Handel the expens, dont worry be happy");
            }
            else if (_succesor != null)
            {
                _succesor.HandleExpense(expens);
            }
        }
    }


    class Manager : ExpensHandlerBase
    {
        public override void HandleExpense(Expens expens)
        {
            if (expens.Amount <= 1000)
            {
                Console.WriteLine("Manager Handel the expens, dont worry be happy");
            }
            else if (_succesor != null)
            {
                _succesor.HandleExpense(expens);
            }
        }
    }
}
