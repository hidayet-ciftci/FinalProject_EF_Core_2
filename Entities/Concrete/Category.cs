using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        // Kullanılmayan Class Olmayacak !!
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
