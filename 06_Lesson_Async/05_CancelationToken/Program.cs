using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_CanselationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            DoSmth(tokenSource);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine("main");
            }
            tokenSource.Cancel();
            Console.ReadKey();
        }

        async static void DoSmth(CancellationTokenSource tokenSource)
        {
            Console.WriteLine("start DoSmth");          


            //----task in parallel---
            var t = await VeryHardWork(tokenSource.Token);


            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("*");
            }
            Console.WriteLine("end DoSmth");
        }

        static Task<string> VeryHardWork(CancellationToken token)
        {
            Console.WriteLine("VeryHardWork method");
            return Task.Run(() => {
                for (int i = 0; i < 100; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("перервано ззовні"); return "canseled";
                    }
                    Thread.Sleep(50);
                    Console.WriteLine("task");
                }
                Console.WriteLine("Task finished;"); return "!!!!";
            });
        }
    }
}
