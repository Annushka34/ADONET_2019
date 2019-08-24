using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSmth();
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine("main");
            }
            Console.ReadKey();
        }

        async static void DoSmth()
        {
            Console.WriteLine("start DoSmth");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("-");
            }
            //----task in parallel---
            var t = await VeryHardWork();
           // Console.WriteLine(t);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("*");
            }
            Console.WriteLine("end DoSmth");
        }

        static Task<string> VeryHardWork()
        {
            Console.WriteLine("VeryHardWork method");
            return Task.Run(() => { Thread.Sleep(2000); Console.WriteLine("Task finished;"); return "!!!!"; });
        }
    }
}
