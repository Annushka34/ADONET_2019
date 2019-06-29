using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Parametrized
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                // connection.ConnectionString = connectionString;
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
                connection.Open();
                string query = "Select BookName From Book where Id = @a";

                SqlCommand com = new SqlCommand(query, connection);
                Console.WriteLine("Enter Id Book");
                string str = Console.ReadLine();
                int.TryParse(str, out var Id);
                SqlParameter param = new SqlParameter("@a", System.Data.SqlDbType.Int);
                param.Value = Id;
                com.Parameters.Add(param);

                string res = (string)com.ExecuteScalar();
                Console.WriteLine(res);

               
                string sqlProcedName = "GetBookAuthorAddress";
                SqlCommand com1 = new SqlCommand(sqlProcedName, connection);
                com1.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader =  com1.ExecuteReader();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader.GetName(i), 15}");
                }
                Console.WriteLine();
                while(reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.Write($"{reader[i],15}");
                    }
                    Console.WriteLine();
                }
                reader.Close();


                //---PROCEDURE WITH PARAMETERS INPUT AND OUTPUT---
                string sqlProcedName1 = "InsertIntoBook";
                SqlCommand com2 = new SqlCommand(sqlProcedName1, connection);
                com2.CommandType = System.Data.CommandType.StoredProcedure;
                //com2.Parameters.AddWithValue("@name", "Как правильно мечтать");
                SqlParameter param2 = new SqlParameter("@name",System.Data.SqlDbType.NVarChar, 250);
                param2.Value = "Мистецтво війни";
                com2.Parameters.Add(param2);
                SqlParameter param3 = new SqlParameter("@categoryName", System.Data.SqlDbType.NVarChar, 250);
                param3.Value = "Історичні";
                com2.Parameters.Add(param3);
                SqlParameter param4= new SqlParameter("@author", System.Data.SqlDbType.NVarChar, 250);
                param4.Value = "Петров";
                com2.Parameters.Add(param4);
                SqlParameter param5 = new SqlParameter("@price", System.Data.SqlDbType.Money);
                param5.Value = 250;
                com2.Parameters.Add(param5);
                SqlParameter param6 = new SqlParameter("@page", System.Data.SqlDbType.Int);
                param6.Value = 199;
                com2.Parameters.Add(param6);

                SqlParameter param7 = new SqlParameter("@succesMsg", System.Data.SqlDbType.NVarChar, 250);
                param7.Direction = System.Data.ParameterDirection.Output;
                com2.Parameters.Add(param7);
                SqlParameter param8 = new SqlParameter("@amountRows", System.Data.SqlDbType.Int);
                param8.Direction = System.Data.ParameterDirection.Output;
                com2.Parameters.Add(param8);

                com2.ExecuteNonQuery();
                Console.WriteLine(com2.Parameters["@succesMsg"].Value.ToString());
            }
        }
    }
}
