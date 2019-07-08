using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableExDb
{
    class Program
    {
        static SqlConnection con =
          new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
        static DataTable table = new DataTable("book table");
        static void Main(string[] args)
        {
            ReadSchema();
            //foreach(DataColumn col in table.Columns)
            //{
            //    Console.WriteLine(col.ColumnName+" "+ col.DataType);
            //}
            ReadData();
            Show1();
        }

        static void ReadSchema()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select * from Book", con);
            SqlDataReader dr = com.ExecuteReader();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                DataColumn col = new DataColumn(dr.GetName(i), dr.GetFieldType(i));
                table.Columns.Add(col);
                }
            dr.Close();
            con.Close();
        }

        static void ReadData()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select * from Book", con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                DataRow row = table.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];
                }
                table.Rows.Add(row);
            }
            dr.Close();
            con.Close();
        }
        static void Show()
        {
            foreach(DataRow rows in table.Rows)
            {
                foreach(DataColumn cl in table.Columns)
                {
                    Console.WriteLine(cl.ColumnName + ": "+rows[cl]);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        static void Show1()
        {
            foreach (DataRow rows in table.Rows)
            {
                
                Console.WriteLine(rows["id"]+" - "+rows["BookName"] + ": " + rows["CategoryId"]);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("-------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
