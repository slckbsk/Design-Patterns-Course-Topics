using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            BuyStock buystock = new BuyStock(stockManager);
            SellStock sellstock = new SellStock(stockManager);
            sellstock.Execute();
            sellstock.Execute();
            sellstock.Execute();  // bu şekilde tek tek değilde 
            buystock.Execute();
            buystock.Execute();
            buystock.Execute();

            Console.WriteLine("------------");

            StockControler stockControler = new StockControler();

            stockControler.TakeOrder(buystock);
            stockControler.TakeOrder(sellstock);  // bu şekilde stockControler dan calıştırıyoruz  
            stockControler.TakeOrder(buystock);

            stockControler.PlaceOrders();

            Console.ReadLine();
        }
    }


    class StockManager
    {
        private string _name = "Laptop";
        private int _quantitiy = 10;
        public void Buy()
        {
            Console.WriteLine("Stock : {0}, {1} bought!", _name, _quantitiy);
        }

        public void Sell()
        {
            Console.WriteLine("Stock : {0}, {1} sold!", _name, _quantitiy);
        }
    }


    interface IOrder
    {
        void Execute();
    }


    class BuyStock : IOrder
    {
        private StockManager _stockManager;
        public BuyStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Buy();
        }
    }

    class SellStock : IOrder
    {
        private StockManager _stockManager;

        public SellStock(StockManager stockManager)
        {
            _stockManager = stockManager;
        }
        public void Execute()
        {
            _stockManager.Sell();
        }
    }


    class StockControler
    {
        List<IOrder> _orders = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            _orders.Add(order);
        }
        public void PlaceOrders()
        {
            foreach (IOrder o in _orders)
            {
                o.Execute();
            }

            _orders.Clear();
        }
    }
}

