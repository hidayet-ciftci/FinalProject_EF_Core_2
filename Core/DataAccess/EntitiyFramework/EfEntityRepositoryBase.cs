using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntitiyFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext> :IEntityRepository<TEntity>
        where TEntity: class, IEntity,new()
        where TContext: DbContext, new()    
    {
        public void Add(TEntity entity)
        {
            // Idisposable pattern implamentation of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // referansı yakalamak için kullanıyor.
                addedEntity.State = EntityState.Added; // eklenecek bir nesne olduğunu belirt
                context.SaveChanges(); // değişikliği gerçekleştir ve kaydet.
            }
        }
         
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // referansı yakalamak için kullanıyor.
                deletedEntity.State = EntityState.Deleted; // Silinecek bir nesne olduğunu belirt
                context.SaveChanges(); // değişikliği gerçekleştir ve kaydet.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<TEntity> GetAllByCategory(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // referansı yakalamak için kullanıyor.
                updatedEntity.State = EntityState.Modified; // güncellenecek bir nesne olduğunu belirt
                context.SaveChanges(); // değişikliği gerçekleştir ve kaydet.
            }
        }
    }
}
