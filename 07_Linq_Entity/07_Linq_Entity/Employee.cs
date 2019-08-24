using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Linq_Entity
{

    class Employee
    {
        public int id { set; get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }


        public static List<Employee> GetEmployee()
        {
            List<Employee> human = new List<Employee>();
            human.Add(new Employee { id = 1, Name = "Vaja", Surname = "Petrov", Address = "Rivne", Age = 16 });
            human.Add(new Employee { id = 2, Name = "Olga", Surname = "Pupkin", Address = "Kiev", Age = 18 });
            human.Add(new Employee { id = 3, Name = "Irina", Surname = "Zubkin", Address = "Odessa", Age = 20 });
            human.Add(new Employee { id = 4, Name = "Anton", Surname = "Zavkin", Address = "Rivne", Age = 18 });
            human.Add(new Employee { id = 5, Name = "Pilip", Surname = "Lapkin", Address = "Rivne", Age = 19 });
            human.Add(new Employee { id = 6, Name = "Josja", Surname = "Ivanov", Address = "Rivne", Age = 16 });
            human.Add(new Employee { id = 7, Name = "Miroslav", Surname = "Sidorov", Address = "Lviv", Age = 21 });
            human.Add(new Employee { id = 8, Name = "Igor", Surname = "Someone", Address = "Rivne", Age = 22 });
            return human;
        }

    }
}
