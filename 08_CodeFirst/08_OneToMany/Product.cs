using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_OneToMany
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        virtual public Category Category { get; set; }
    }
}
