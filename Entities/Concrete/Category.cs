using Core.Entities;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        // Kullanılmayan Class Olmayacak !!
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
