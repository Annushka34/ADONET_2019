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

namespace _7_DataAdapterForms
{
    public partial class Form1 : Form
    {
        static SqlConnection con =
        new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
        DataSet ds = null;
        SqlDataAdapter adapter = null;
        DataTable t;
        SqlCommandBuilder cmd = null;
        public Form1()
        {
            InitializeComponent();
            ds = new DataSet();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            SqlCommand comm = new SqlCommand("Select * From Book", con);
            adapter = new SqlDataAdapter(comm);
            adapter.TableMappings.Add("Table", "Book");
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //t = new DataTable();
            cmd = new SqlCommandBuilder(adapter);
            //adapter.Fill(t);
            adapter.Fill(ds);
            lblTable.Text = ds.Tables["Book"].TableName;
            dgv1.DataSource = ds.Tables["Book"];
         //   dgv1.DataSource = ds.Tables[0];
            //dgv1.DataSource = t;

        }


        private void btnEx_Click(object sender, EventArgs e)
        {
            string query = "select * from " + textBox1.Text;// - неправильно бо без параметрів
            SqlCommand comm = new SqlCommand(query, con);
            adapter = new SqlDataAdapter(comm);
            adapter.TableMappings.Add("Table", textBox1.Text);
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            cmd = new SqlCommandBuilder(adapter);

            adapter.Fill(ds);
            lblTable.Text = ds.Tables[textBox1.Text].TableName;
            dgv1.DataSource = ds.Tables[textBox1.Text];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            adapter.Update(ds);
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //textBox2.Text =  dgv1.CurrentCell.Value.ToString();
            for (int i = 0; i < dgv1.CurrentRow.Cells.Count; i++)
            {
                listBox1.Items.Add(dgv1.CurrentRow.Cells[i].Value.ToString());
            }
        }

    }
}
