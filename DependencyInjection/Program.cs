using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IProductDal>().To<NhProductDal>().InSingletonScope();
            ProductManager productManager = new ProductManager(kernel.Get<IProductDal>());


            // Ninject ÖNCESİ  ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.Save();

            Console.ReadLine();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with NH");
        }
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void Save()
        {
            _productDal.Save();
        }
    }
}
