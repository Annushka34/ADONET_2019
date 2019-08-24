using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Linq_Entity
{
    public class Person
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public Company Company { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string Branch { get; set; }
        public string City { get; set; }

        public List<Person> People { get; set; } = new List<Person>();
    }
}
