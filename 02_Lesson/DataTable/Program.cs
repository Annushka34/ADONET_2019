using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTableEx
{
    class Program
    {

        static DataTable table;
        static void Main(string[] args)
        {
            CreateSchema();
            FillTable("New book", 25.23);
            FillTable("New book1", 120);
            FillTable("New book2", 13.78);
            ShowDataTable();
        }

        static void CreateSchema()
        {
            table = new DataTable();
            DataColumn col = new DataColumn("Name", typeof(string));
            table.Columns.Add(col);
            table.Columns.Add(new DataColumn("Price", typeof(double)));
        }

        static void FillTable(string name, double price)
        {
            DataRow row = table.NewRow();
            row["Name"] = name;
            row["Price"] = price;
            table.Rows.Add(row);
        }
        static void ShowDataTable()
        {
            foreach(DataRow rows in table.Rows)
            {
                foreach(DataColumn col in table.Columns)
                {
                    Console.WriteLine(col.ColumnName+": "+ rows[col]);
                }
            }
        }
    }
}
