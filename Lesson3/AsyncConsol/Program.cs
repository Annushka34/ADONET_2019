using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsol
{
    class Program
    {
        static SqlConnection con = null;
        static void Main(string[] args)
        {
            string conStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;           
            con = new SqlConnection(conStr);
            Async_Exec(con);
        }
        static public void Async_Exec(SqlConnection myConnection)
        {
            SqlCommand myCommand = (SqlCommand)myConnection.CreateCommand();
            myCommand.CommandText = "WAITFOR DELAY '00:00:05';SELECT * FROM Book;";
            Console.WriteLine("Starting asynchronous retrieval of data...");
            myConnection.Open();
            //SqlDataReader myReader = myCommand.ExecuteReader();
            IAsyncResult cres = myCommand.BeginExecuteReader();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.WriteLine(i);
            }
            if (cres.IsCompleted)
                Console.WriteLine("Completed.");
            else
                Console.WriteLine("Have to wait for operation to complete...");
            SqlDataReader myReader = myCommand.EndExecuteReader(cres);
            try
            {
                while (myReader.Read())
                {
                    Console.WriteLine(myReader[0]+" "+ myReader[1] + " "+myReader[2] + " "+myReader[3]);
                }
            }
            finally
            {
                myReader.Close();
                myConnection.Close();
            }
            Console.ReadKey();
        }
    }
}
