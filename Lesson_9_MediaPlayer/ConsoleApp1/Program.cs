using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            EfContext context = new EfContext();

            Genre genre = new Genre();
            genre.Color = "pink";
            genre.GenreName = "pop";

            context.Genres.Add(genre);
            context.SaveChanges();
            Console.WriteLine("saved");
            Console.WriteLine(context.Genres.FirstOrDefault().Id);
            Console.WriteLine(context.Genres.FirstOrDefault().GenreName);
            Console.WriteLine(context.Genres.FirstOrDefault().Color);
        }
    }
}
