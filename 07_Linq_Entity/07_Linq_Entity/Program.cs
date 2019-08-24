using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Linq_Entity
{
    class Program
    {
         static string[] fruits = {
        "Beetroot", "Butternut Squash", "Carrot", "Cherry", "Clementine", "Courgette",
        "Black-eye bean", "Date", "Elderberry", "Endive", "Fennel",  "Fig",
        "Apricot", "Apple", "Asparagus", "Aubergine", "Avocado", "Banana",
        "Broad bean", "Garlic", "Grape", "Green bean", "Guava", "Haricot bean",
        "Broccoli", "Honeydew melon", "Iceberg lettuce", "Kiwi fruit", "Lemon", "Mango", "Nectarine",
        "Brussels sprout", "Mushroom", "Nut", "Olive", "Pumpkin", "Pepper", "Orange"};

        static void Main(string[] args)
        {
            Print("OUR ARRAY", fruits);
            var firstLetters = fruits.Select(x => x[0]).ToList();
            Print("First letters", firstLetters);

            var startWithB = fruits.Where(x => x.StartsWith("B")).ToList();
            Print("Start with B", startWithB);


            fruits[0] = "111111";
            fruits[1] = "111111";
            fruits[3] = "2222222222";

            Print("OUR ARRAY", fruits);
            Print("First letters", firstLetters);
            Print("Start with B", startWithB);


            var lengths = fruits.Where(x => x.Length > 5).Select(x => x.Length);
            Print("Legths", lengths);

            var all2fruit = fruits.Where((x, i) => i % 2 == 0);
            Print("all x%2 == 0", all2fruit);

            //First --- FirstOrDefault
            //Single --- SingleOrDefault
            var carrot = fruits.Where(x => x == "Carrot").FirstOrDefault();
            Console.WriteLine(carrot);

            var carrotInd = fruits.Where((x, i) => x == "Carrot").Select((x, i) => i);
            Print("Test", carrotInd);

            //-----------------------------------
            var obj = new { name = "Olga", surname = "Ivanova" };
            Console.WriteLine(obj.name + " - " + obj.surname);

            var shop = fruits.Select(x => new { name =  x + ":", price = 100});
            foreach (var item in shop)
            {
                Console.WriteLine($"{item.name} {item.price}");
            }


            //---------------------------------------
            Person person = new Person
            {
                Name = "Stepan",
                Surname = "Vasiljev",
                Salary = 20000,
                Company = new Company
                {
                    Name = "CoolItWantToMe",
                    Branch = "IT",
                    City = "Lviv"
                }
            };

            var simplePerson = new { person.Surname, CompanyName = person.Company.Name };
            Console.WriteLine(simplePerson.Surname +"   "+ simplePerson.CompanyName);


            List<Person> people = new List<Person>
            {
                new Person
            {
                Name = "Stepan",
                Surname = "Vasiljev",
                Salary = 20000,
                Company = new Company
                {
                    Name = "CoolItWantToMe",
                    Branch = "Economic",
                    City = "Lviv"
                }
            },
            new Person
            {
                Name = "Olga",
                Surname = "Vasiljev",
                Salary = 7000,
                Company = new Company
                {
                    Name = "CoolItWantToMe",
                    Branch = "IT",
                    City = "Kiev"
                }
            },
            new Person
            {
                Name = "Petro",
                Surname = "Bilgush",
                Salary = 15600,
                Company = new Company
                {
                    Name = "CoolItWantToMe",
                    Branch = "IT",
                    City = "Lviv"
                }
            },
            new Person
            {
                Name = "Dima",
                Surname = "Ivanov",
                Salary = 18000,
                Company = new Company
                {
                    Name = "CoolItWantToMe",
                    Branch = "IT",
                    City = "Kiev"
                }
            },
              new Person
            {
                Name = "No name",
                Surname = "No name",
                Salary = 18000
            }
        };

            var salaryMore10000 = people.Where(x => x.Salary > 10000).ToList();
            Print("People", salaryMore10000);

            var lviv = people.Where(x => x.Company?.City == "Lviv").ToList();
            Print("People", lviv);

            var kiev = people.Where(x => x.Company?.City == "Kiev").Select(x => new { x.Surname, x.Salary });
            foreach (var item in kiev)
            {
                Console.WriteLine($"{item.Surname},  {item.Salary}");
            }

            Person personForDelete = people.Where(x => x.Name == "No name").FirstOrDefault();
            people.Remove(personForDelete);


            Print("People after delete", people);

            var avgSalery = people.Average(x => x.Salary);
            var mohIBoloto = fruits.Concat(people.Select(x => x.Name).ToList());


            var branches = new string[] { "Economic", "IT", "Machinary" };
            var isIt = branches.Contains("IT");
            var onlyMyBranches = people.Where(x => branches.Contains(x.Company.Branch));

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"-----------------BRANCHES-------------------");
            var branches2 = people.Select(x => x.Company.Branch).Distinct();
            foreach (var item in branches2)
            {
                Console.WriteLine(item);
            }

            people.ForEach(x => { x.Name = "Olga"; Console.WriteLine(x.Name); });

            foreach (var item in people)
            {
                Console.WriteLine(item.Name);
            }

            Console.ResetColor();
            var groups = people.GroupBy(x => x.Company.Branch);
            foreach (var item in groups)
            {
                Console.WriteLine(item.Key +":"+item.Count());
            }

            //---dont lok on it (only syntacsis)
            var employees = Employee.GetEmployee();
            people.Join(employees, p => p.Company.City, e => e.Address, (p, e) => new { p.Name, e.Surname });

            var maxSal = people.Max(x => x.Salary);

            people =  people.OrderBy(x => x.Company.City).ToList();
            Print("People after sort", people);

            // people.SelectMany
            var allWithout2First = people.Skip(2).ToList();


            var resString = fruits.Aggregate("", (x, y) => x + ", " + y);
            Console.WriteLine(resString);
        }

        static void Print<T> (string header, IEnumerable<T> collection)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"-----------------{header}-------------------");
            Console.ResetColor();
            foreach (var item in collection)
            {
                Console.Write($"{item},");
            }
        }

        static void Print(string header, IEnumerable<Person> collection)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"-----------------{header}-------------------");
            Console.ResetColor();
            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Surname}, {item.Name}, {item.Salary}, {item.Company?.Name}, {item.Company?.City}");
            }
        }
    }
}
