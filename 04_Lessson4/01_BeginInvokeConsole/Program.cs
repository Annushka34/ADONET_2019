using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_BeginInvokeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main start " + Thread.CurrentThread.ManagedThreadId);

            var del = new Action(VeryImportantHardFunction);
            IAsyncResult rez  = del.BeginInvoke(null, null);
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Thread.Sleep(50);
                Console.Write('-');
                Console.ResetColor();
            }
         //   Console.WriteLine("main end " + Thread.CurrentThread.ManagedThreadId);
            //while (!rez.IsCompleted)
            //{
            //    Console.WriteLine("thread works....");
            //    Thread.Sleep(50);
            //}
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Thread.Sleep(50);
                Console.Write('+');
                Console.ResetColor();
            }
            del.EndInvoke(rez);
            //Console.ReadKey();
        }
        static void VeryImportantHardFunction()
        {
            Console.WriteLine("delegate thread start " + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 30; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(50);
                Console.Write('*');
                Console.ResetColor();
            }
            Console.WriteLine("delegate thread end "+Thread.CurrentThread.ManagedThreadId);
        }
    }

}
