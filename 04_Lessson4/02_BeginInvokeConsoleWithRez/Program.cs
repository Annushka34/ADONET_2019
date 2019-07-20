using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _02_BeginInvokeConsoleWithRez
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("main start " + Thread.CurrentThread.ManagedThreadId);

            var del = new Func<int, int>(VeryImportantHardFunction);
            //int rezDelegate = del.Invoke(10);
            IAsyncResult rez = del.BeginInvoke(10, null, null);
            for (int i = 0; i < 100; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Thread.Sleep(50);
                Console.Write('-');
                Console.ResetColor();
            }

            int rezNumber = del.EndInvoke(rez);
            Console.WriteLine("MAIN THREAD WAITING......");
            Console.WriteLine("rezult of thread "+rezNumber);
            Console.WriteLine("main end " + Thread.CurrentThread.ManagedThreadId);
        }
        static int VeryImportantHardFunction(int param)
        {
            Console.WriteLine("thread start " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Enter number: ");
            int rez = int.Parse(Console.ReadLine());
            //int rez = 22;
            for (int i = 0; i < param; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(50);
                Console.Write('*');
                Console.ResetColor();
            }
            Console.WriteLine("thread end " + Thread.CurrentThread.ManagedThreadId);
            return rez;
        }
    }

}
