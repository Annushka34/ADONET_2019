using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CodeFirst
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Address { get; set; }
        public int MyProperty { get; set; }
    }
}
