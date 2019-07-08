using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_DataAdapter
{
    class Program
    {
        static SqlConnection con =
          new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
        static void Main(string[] args)
        {
            SqlCommand comm = new SqlCommand("Select * From Book", con);
            SqlDataAdapter adapter = new SqlDataAdapter(comm);

            SqlCommandBuilder comb = new SqlCommandBuilder(adapter);
            DataTable book = new DataTable();
            adapter.Fill(book);

            foreach(DataRow row in book.Rows)
            {
                foreach(DataColumn col in book.Columns)
                {
                    Console.WriteLine(col.ColumnName+": "+row[col]);
                }
            }
        }
    }
}
