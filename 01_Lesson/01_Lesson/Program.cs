using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Lesson
{
    class Program
    {
        static void Main(string[] args)
        {
           // string connectionString = @"Data Source=DESKTOP-LNTJUIU;Initial Catalog=BookShopPublisher;User ID=ANNA;Password=12;";
           // string connectionString = @"Data Source=DESKTOP-LNTJUIU;Initial Catalog=BookShopPublisher;Integrated Security=true;";
            SqlConnection connection = new SqlConnection();
            try
            {
               // connection.ConnectionString = connectionString;
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                connection.Open();
                Console.WriteLine("Hello. Im connected!");
                //var id = Console.ReadLine();
                //string query = "select BookName From Book Where Id=" + id;
                //SqlCommand command = new SqlCommand(query, connection);
                //var rezult =  command.ExecuteScalar();//---HERE QUERY DONE!!!
                //Console.WriteLine(rezult);

                //Console.WriteLine("Inserted - ");
                //Console.WriteLine(InsertIntoAutor(connection));

                //SelectAllFromAutor(connection);
                //SelectAllFromBook(connection);
                SelectAllFrom(connection);
                connection.Close();
                Console.WriteLine(  "You select:  "+ Menu());
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Connection close in catch block");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection close");
            }
        }

        static int InsertIntoAutor(SqlConnection con)
        {
            string query = @"INSERT INTO Author VALUES('Петров',3,2);";
            SqlCommand com = new SqlCommand(query, con);
            //---FOR DELETE UPDATE INSERT---
            var rez = com.ExecuteNonQuery();
            return rez;
        }

        static int SelectAllFromAutor(SqlConnection con)
        {
            string query = @"SELECT * FROM Author";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + " - " + reader[1] + " - " + reader["PublishId"]);
            }
            return 0;
        }

        static int SelectAllFromBook(SqlConnection con)
        {
            string query = @"SELECT * FROM Book";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i), 15}");
            }
            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],15}");
                }
                Console.WriteLine();
            }
           
            return 0;
        }

        static int SelectAllFrom(SqlConnection con)
        {
            string query = @"SELECT * FROM Book; SELECT * FROM Author;";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            int counter = 0;
            do
            {
                while (reader.Read())
                {
                    if (counter == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i),15}");
                        }
                    }
                    Console.WriteLine();
                    counter++;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i],15}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-----------------------------------------------");
                counter = 0;
            }
            while (reader.NextResult());
            return 0;
        }

        static int Menu()
        {
            int selected = 0;
            string[] menu = new string[4]
            {
                "1. Create",
                "2. Read",
                "3. Update",
                "4. Delete"
                //---add Get by Id
            };
            while (true)
            {
                for (int i = 0; i < menu.Length; i++)
                {
                    if (i == selected)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("->");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }
               switch( Console.ReadKey().Key)
               {
                    case ConsoleKey.DownArrow:
                        {
                            selected = selected < menu.Length - 1 ? selected + 1 : 0;
                            Console.Clear();
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            return selected;
                        }
                }
            }
        }
    }
}
