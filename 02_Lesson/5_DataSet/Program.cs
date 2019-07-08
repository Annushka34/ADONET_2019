using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_DataSet
{
        class Program
        {
            static SqlConnection con =
              new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            static DataSet ds = new DataSet();
            static DataTable book = new DataTable("book table");
            static DataTable author = new DataTable("author table");

        static void Main(string[] args)
            {
                ReadSchema("book", book);
                ReadSchema("author", author);
                book.Columns["AuthorId"].DataType = typeof(int);
                //foreach (DataColumn col in book.Columns)
                //{
                //    Console.WriteLine(col.ColumnName + " " + col.DataType);
                //}
                //foreach (DataColumn col in author.Columns)
                //{
                //    Console.WriteLine(col.ColumnName + " " + col.DataType);
                //}
                ReadData("book",book);
                ReadData("Author", author);
            Show(author);
            Show(book);

            ds.Tables.Add(book);
            ds.Tables.Add(author);

            author.Constraints.Add(new UniqueConstraint(author.Columns["Id"],true));
            book.Constraints.Add(new UniqueConstraint(book.Columns["Id"], true));
            //Console.WriteLine(author.Columns["Id"].ColumnName);
            //Console.WriteLine(book.Columns["AuthorId"].ColumnName);
            DataColumn childColumn = book.Columns["AuthorId"];
            DataColumn parentColumn = author.Columns["Id"];
            book.Constraints.Add(new ForeignKeyConstraint(parentColumn, childColumn));

            ////----------------------------------------------------
            DataRow row = book.NewRow();
            row[1] = "New new book";
            row[2] = "descript";
            row[3] = "255";
            row[4] = "25.5";
            row["AuthorId"] = 10;// 25; - вже працюватиме перевірка
            row["CategoryId"] = 500;// - немає перевірки форейн кі
            book.Rows.Add(row);
        }

            static void ReadSchema(string name, DataTable table)
            {
                con.Open();
            string query = "Select * from "+name;
                SqlCommand com = new SqlCommand(query, con);
                SqlDataReader dr = com.ExecuteReader();

                DataTable schema = dr.GetSchemaTable();
                foreach(DataRow row in schema.Rows)
                { 
                DataColumn col = new DataColumn((string)row["ColumnName"]);
                col.AllowDBNull = (bool)row["AllowDBNull"];
                col.Unique = (bool)row["IsUnique"];
                col.AutoIncrement = (bool)row["IsIdentity"];
                table.Columns.Add(col);
                }
                dr.Close();
                con.Close();
            }

            static void ReadData(string name, DataTable table)
            {
                con.Open();
                string query = "Select * from " + name;
                SqlCommand com = new SqlCommand(query, con);
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
            static void Show(DataTable table)
            {
                foreach (DataRow rows in table.Rows)
                {
                    foreach (DataColumn cl in table.Columns)
                    {
                        Console.WriteLine(cl.ColumnName + ": " + rows[cl]);
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("-------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        
        }
    }

