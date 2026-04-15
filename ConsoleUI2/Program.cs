using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI2
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            ProductTest();
            // CategoryTest();
        }

        private static void CategoryTest()
        {
            CatergoryManager categoryManager = new CatergoryManager(new EFCategoryDal());
            foreach (var product in categoryManager.GetAll())
            {
                Console.WriteLine(product.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EFProductDal());

            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            //Console.WriteLine("--------------------------------------------");
            //foreach (var product in productManager.GetAllByCategoryId(2))
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            //Console.WriteLine("--------------------------------------------");
            //foreach (var product in productManager.GetByUnitPrice(40, 100))
            //{
            //    Console.WriteLine(product.ProductName);
            //}
            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName + "  /  " + product.CategoryName);
            }
        }
    }
}