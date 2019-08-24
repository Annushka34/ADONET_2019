using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_AsyncReadFromFile
{
    class Program
    {
        static string filename = @"D:/1.txt";
        static void Main(string[] args)
        {
            ReadFile();
            Console.WriteLine("main finished");
        }


        static void ReadFile()
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                byte[] arr = new byte[fs.Length];
                fs.Read(arr, 0, (int)fs.Length);
                //for (int i = 0; i < arr.Length; i++)
                //{
                //    Console.WriteLine(arr[i]);
                //}
            }
        }
    }
}
