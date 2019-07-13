using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProviderFactory
{
    public partial class Form1 : Form
    {
        DbConnection con = null;
        DbProviderFactory factory = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable t = DbProviderFactories.GetFactoryClasses();
            dataGridView1.DataSource = t;
            foreach(DataRow r in t.Rows)
            {
                cmb1.Items.Add(r[2].ToString());
            }        
           
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conString="";
            string provider = cmb1.SelectedItem.ToString();
            ConnectionStringSettingsCollection conStringsCol = ConfigurationManager.ConnectionStrings;
            foreach(ConnectionStringSettings conStr in conStringsCol)
            {
                if(provider == conStr.ProviderName)
                {
                    conString = conStr.ConnectionString;
                }
            }

            textBox1.Text = conString;


            //---ІНІЦІАЛІЗУЄМО ФАБРИКУ---
            factory = DbProviderFactories.GetFactory(provider);
            con = factory.CreateConnection();
            con.ConnectionString = conString;   
            con.Open();

            //------ВИТЯГУЄМО НАЗВИ ВСІХ БАЗ ДАНИХ-----
            string query1 = @"sys.sp_databases";
            SqlCommand cmd = new SqlCommand(query1,(SqlConnection) con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader rd =  cmd.ExecuteReader();
            DataTable t = new DataTable();
            
            DataColumn col = new DataColumn(rd.GetName(0));
            t.Columns.Add(col);
            while(rd.Read())
            {
                DataRow row = t.NewRow();
                row[0] = rd[0];
                t.Rows.Add(row);
            }
            dataGridView2.DataSource = t;
            con.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(con.ConnectionString);
            builder.InitialCatalog = dataGridView2.SelectedCells[0].Value.ToString();
            con.ConnectionString = builder.ConnectionString;
            //---СТВОРЮЄМО НОВЕ ВІКНО КУДИ В КОНСТРУКТОР ПЕРЕДАЄМО connection string
            DataBase dataBase = new DataBase(con.ConnectionString);
            dataBase.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnConnect.Enabled = true;
        }
    }
}
