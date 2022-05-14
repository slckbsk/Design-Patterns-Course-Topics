using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customer = new CustomerManager(new MAILSender());
            customer.UpDateCustomer();

            Console.ReadLine();
        }
    }



    abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Saved!");
        }

        public abstract void Send(Body body);

    }

    class Body
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }

    class MAILSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send via MAILSender", body.Title);
        }
    }

    class SMSSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was send via SMSSender", body.Title);
        }
    }


     class CustomerManager
    {
        MessageSenderBase _messageSenderBase;

        public CustomerManager(MessageSenderBase messageSenderBase)
        {
            _messageSenderBase = messageSenderBase;
        }

        public void UpDateCustomer()
        {
            _messageSenderBase.Send(new Body { Title = "KURS İLE ALAKALI" });
            Console.WriteLine("Customer update");
        }
    }


    class NewCustomerManager : CustomerManager // DİYE KULLANABİLİRİZ
    {
        public NewCustomerManager(MessageSenderBase messageSenderBase) : base(messageSenderBase)
        {
        }
    }
}
