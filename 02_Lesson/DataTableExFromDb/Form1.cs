using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataTableExFromDb
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        DataTable table;
        public Form1()
        {
            InitializeComponent();
            con =
            new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            table = new DataTable("book table");
            ReadSchema();
            ReadData();
            dataGridView1.DataSource = table;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns[1].ReadOnly = true;
        }
        void ReadSchema()
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select * from Book", con);
            SqlDataReader dr = com.ExecuteReader();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                table.Columns.Add(new DataColumn(dr.GetName(i), dr.GetFieldType(i)));
            }
            dr.Close();
            con.Close();
        }
        void ReadData()
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

       
    }
}
