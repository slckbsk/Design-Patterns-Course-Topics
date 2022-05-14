using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeObserver employeeObserver = new EmployeeObserver(); 
            ProductManager productManager = new ProductManager();
            productManager.Attach(employeeObserver);
            productManager.Attach(new CustomerObserver());
            productManager.Detach(employeeObserver);
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();   

        public void UpdatePrice()
        {
            Console.WriteLine("Product price updated");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer); 
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observerx in _observers)
            {
                observerx.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }

     class CustomerObserver: Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer: Product price chanced");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee: Product price chanced");
        }
    }
}
