using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _06_WaitHandleCons
{
    class Program
    {
        static void Main(string[] args)
        {
            var del = new Action(VeryImportantHardFunction);
            IAsyncResult rez =  del.BeginInvoke(null, null);
            WaitHandle waitHandle = rez.AsyncWaitHandle;

            var del2 = new Action(VeryImportantHardFunction2);
            IAsyncResult rez2 = del2.BeginInvoke(null, null);
            WaitHandle waitHandle2 = rez2.AsyncWaitHandle;

            WaitHandle[] waitHandleArr = new WaitHandle[2] { waitHandle, waitHandle2 };
            if (waitHandle.WaitOne(10000))
            {
                Console.WriteLine("waitHandle WaitOne");
            }

            Console.WriteLine("main start " + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 50; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Thread.Sleep(50);
                Console.Write('.');
                Console.ResetColor();
            }
            Console.WriteLine("\nmain end " + Thread.CurrentThread.ManagedThreadId);
           // waitHandle.WaitOne();
         //  WaitHandle.WaitAll(waitHandleArr);
        }

        static void VeryImportantHardFunction()
        {
            Console.WriteLine("thread start " + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 30; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(100);
                Console.Write('1');
                Console.ResetColor();
            }
            Console.WriteLine("\nthread end " + Thread.CurrentThread.ManagedThreadId);
        }
        static void VeryImportantHardFunction2()
        {
            Console.WriteLine("thread start " + Thread.CurrentThread.ManagedThreadId);

            for (int i = 0; i < 30; i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Thread.Sleep(100);
                Console.Write("2");
                Console.ResetColor();
            }
            Console.WriteLine("\nthread end " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
