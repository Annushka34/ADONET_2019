using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _03_CallbackConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var del = new Func<string, string>(HardImportantFunc);
            del.BeginInvoke("hello from main", CallBackFunc, 32);
            // Thread.Sleep(2000);

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(50);
                Console.Write("main");
            }

        }

        static string HardImportantFunc(string a)
        {
            Console.WriteLine("thread start " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(a);

            for (int i = 0; i < 30; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(50);
                Console.Write('*');
                Console.ResetColor();
            }
            Console.WriteLine("thread end " + Thread.CurrentThread.ManagedThreadId);
            return "thread say good bye";
        }

        static void CallBackFunc(IAsyncResult param)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("I am callback function\nI work in "+Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(param.AsyncState);//--32
            Console.ResetColor();
            Func<string, string> del = (Func<string, string>)((AsyncResult)param).AsyncDelegate;//--HardImportantFunc
            string rezultFromDel = del.EndInvoke(param);
            Console.WriteLine(rezultFromDel);
        }
    }
}
