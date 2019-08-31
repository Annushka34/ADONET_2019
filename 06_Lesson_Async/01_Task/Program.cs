using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("1");
            }

            Task<string> t = new Task<string>(DoSmthAction);
            t.Start();

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("2");
            }
            Console.WriteLine(t.Result);

            Task<string> task2 = Task.Run(() => { Thread.Sleep(2000); return "Task run comlited"; });
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("task sleep. i'm work");
            }
            Console.WriteLine(task2.Result);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("MAIN FINISHED");
        }

        static string DoSmthAction ()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(10);
                Console.WriteLine("thread");
            }
            return "I have done!";
        }
    }
}
