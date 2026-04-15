using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        InMemoryProductDal InMemoryProductDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            InMemoryProductDal = new InMemoryProductDal();
        }
        public void WrongAdd(Product product)
        {
            InMemoryProductDal.Add(product);
        }

        public List<Product> WrongGetAll()
        {
            // iş kodları new kullanmaz!!
            return InMemoryProductDal.GetAll();

        }
        public List<Product> GetAll()
        {
            // iş kodları new kullanmaz!!
            return _productDal.GetAll();
            
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }
    }
}
