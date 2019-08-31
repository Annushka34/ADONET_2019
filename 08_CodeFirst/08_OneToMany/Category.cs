using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_OneToMany
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        virtual public ICollection<Product> Products { get; set; }
    }
}
