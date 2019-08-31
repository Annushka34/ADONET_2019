using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_DBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (EfContext context = new EfContext())
            {
                var addreses = context.Address;
                foreach (var item in addreses)
                {
                    Console.WriteLine($"{item.Id}    {item.Street}");
                }
            }
        }
    }
}
