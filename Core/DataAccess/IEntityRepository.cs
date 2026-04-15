using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    // where T: a,b,c ile yapısı T generic constraint koyarız. -> T nin a,b,c ye uygun olmalı
    // class -> referans olmalı , int double string olamaz
    // IEntity -> IEntity interface'i veya IEntity interface'ini implamente eden bir nesne, class olabilir.
    // new() -> instance'ı olan bir nesne olmalı -> abstract soyut nesneler olamaz -> abstract , interface nesneleri
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAllByCategory(int entityId);
    }
}
