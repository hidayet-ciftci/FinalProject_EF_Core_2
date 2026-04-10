using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        List<Product> GetAllByCategory(int entityId);
    }
}
