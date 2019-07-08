using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        static SqlConnection con = 
            new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
        static void Main(string[] args)
        {
           // MultiSelect2();
            //SelectWithParametrs(10);
            //ProcedureBookByCateg("Історичні");
            //ProcedureDeleteFromBook(2);
            //ProcedureFindAuthor(15);
            //Console.WriteLine(GetAuthorId(10)); 
        }

        static void MultiSelect2()
        {
            con.Open();
            string query = "select BookName from Book; select AuthorName from Author right outer join Book on Book.AuthorId = Author.Id";
            SqlCommand sql = new SqlCommand(query, con);
            SqlDataReader dr =  sql.ExecuteReader();
            do {
                while (dr.Read())
                {
                    Console.WriteLine(dr[0]);
                }
            }
            while( dr.NextResult() );
            dr.Close();
            con.Close();
        }
        static void SelectWithParametrs(int field)
        {
            con.Open();
            string query = "select * from Book where Id = @a";

            //SqlParameter param = new SqlParameter();
            //param.ParameterName = "@a";
            //param.SqlDbType = System.Data.SqlDbType.NVarChar;
            //param.SqlValue = field;

            SqlCommand sql = new SqlCommand(query, con);
            //sql.Parameters.Add(param);


            //sql.Parameters.Add("@a", SqlDbType.NVarChar).Value = field;

            sql.Parameters.AddWithValue("@a", field);
            SqlDataReader dr = sql.ExecuteReader();
                while (dr.Read())
                {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr.GetName(i)+":   ");
                    Console.WriteLine(dr[i]);
                }
                }
            dr.Close();
            con.Close();
        }
        static void ProcedureBookByCateg(string categName)
        {
            con.Open();
            SqlCommand com = new SqlCommand("BookByCateg", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@categ", SqlDbType.NVarChar).Value = categName;
            SqlDataReader dr = com.ExecuteReader();

            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr.GetName(i) + ":   ");
                    Console.WriteLine(dr[i]);
                }
            }
            con.Close();
        }
        static void ProcedureDeleteFromBook(int id)
        {
            con.Open();
            SqlCommand com = new SqlCommand("deleteFromBook", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@id", SqlDbType.Int).Value = id;

            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.NVarChar;
            param.ParameterName = "@mes";
            param.Size = 50;
            param.Direction = ParameterDirection.Output;
            com.Parameters.Add(param);
            com.ExecuteNonQuery();

            Console.WriteLine(com.Parameters["@mes"].Value.ToString());
            con.Close();
        }
        static void ProcedureFindAuthor(int id)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("findAuthor2", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            SqlParameter outputParam = 
                new SqlParameter("@author", System.Data.SqlDbType.NVarChar);
            outputParam.Size = 50;
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
            Console.WriteLine(cmd.Parameters["@author"].Value.ToString());
            con.Close();
        }

        static int GetAuthorId(int idBook)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GetAuthorId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookId", System.Data.SqlDbType.Int).Value = idBook;

            SqlParameter outputParam = new SqlParameter("@AuthorId", System.Data.SqlDbType.Int);
            outputParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(outputParam);
            cmd.ExecuteNonQuery();
            con.Close();
            return ((int)cmd.Parameters["@AuthorId"].Value);
        }
    }
}
