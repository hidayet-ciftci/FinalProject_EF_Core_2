using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : IProductDal
    {

        public void Add(Product entity)
        {
            // Idisposable pattern implamentation of C#
            using (NorthwindContext context=new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakalamak için kullanıyor.
                addedEntity.State = EntityState.Added; // eklenecek bir nesne olduğunu belirt
                context.SaveChanges(); // değişikliği gerçekleştir ve kaydet.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakalamak için kullanıyor.
                deletedEntity.State = EntityState.Deleted; // Silinecek bir nesne olduğunu belirt
                context.SaveChanges(); // değişikliği gerçekleştir ve kaydet.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();
            }
        }

        public List<Product> GetAllByCategory(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); // referansı yakalamak için kullanıyor.
                updatedEntity.State = EntityState.Modified; // güncellenecek bir nesne olduğunu belirt
                context.SaveChanges(); // değişikliği gerçekleştir ve kaydet.
            }
        }
    }
}
