using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
              while(true)
                Menu(context);
            }
        }


        static void AddUser(EfContext _con)
        {
            //1 create object user
            User user = new User();
            user.Address = "Kiev";
            Console.WriteLine("Enter name");
            user.Name = Console.ReadLine();

            Console.WriteLine("Enter surname");
            user.Surname = Console.ReadLine();

            Console.WriteLine("Enter address");
            user.Address = Console.ReadLine();

            _con.Users.Add(user);
            _con.SaveChanges();
        }

        static void UpdateUser(EfContext _con)
        {
            //1 find object user
            User user = FindById(_con);
            ShowById(_con);


            Console.WriteLine("Enter name");
            var name = Console.ReadLine();
            user.Name = name != " " ? name : user.Name;

            Console.WriteLine("Enter surname");
            var suname = Console.ReadLine();
            user.Surname = suname != " " ? suname : user.Surname;

            Console.WriteLine("Enter address");
            var address = Console.ReadLine();
            user.Address = address != " " ? address : user.Address;

            _con.SaveChanges();
        }


        static void ShowAll(EfContext _con)
        {
            var users = _con.Users.ToList();

            foreach (var item in users)
            {
                Console.WriteLine($"{item.Id}   {item.Name}  {item.Surname}   {item.Address}");
            }
        }

        static User FindById(EfContext _con)
        {
            Console.WriteLine("Enter Id");
            var id = Int32.Parse(Console.ReadLine());
            var user = _con.Users.FirstOrDefault(x => x.Id == id);

            return user;
        }

        static void DeleteById(EfContext _con)
        {
            var user = FindById(_con);

            if (user != null)
            {
                _con.Users.Remove(user);
                _con.SaveChanges();
            }
            else Console.WriteLine("No such user");
        }

        static void ShowById(EfContext _con)
        {
            var user = FindById(_con);

            if (user != null)
            {
                Console.WriteLine($"{user.Id}   {user.Name}  {user.Surname}   {user.Address}");
            }
            else Console.WriteLine("No such user");
        }

        static void Menu(EfContext _con)
        {
            MenuShow();
            var key = Console.ReadLine();
            switch(key)
            {
                case "1":{ AddUser(_con); break;};
                case "2":{ UpdateUser(_con); break;};
                case "3":{ DeleteById(_con); break;};
                case "4":{ ShowAll(_con);  break; };
                case "5": { ShowById(_con);  break; };
            }
            Console.WriteLine();
            Console.WriteLine();
        }


        static void MenuShow()
        {
            Console.WriteLine("1.Add user");
            Console.WriteLine("2.Update");
            Console.WriteLine("3.Delete");
            Console.WriteLine("4.ViewAll");
            Console.WriteLine("5.ViewById");
            Console.WriteLine("6.-");
        }
    }
}
