using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProviderFactory
{
    public partial class DataBase : Form
    {
        string conStr;
        SqlConnection con;
        public DataBase()
        {
            InitializeComponent();
        }
        public DataBase(string conStr)
        {
            InitializeComponent();
            this.conStr = conStr;
            con = new SqlConnection(conStr);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(conStr);
            string dataBase = builder.InitialCatalog;
            string query = @"select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_TYPE='BASE TABLE' and TABLE_CATALOG='" + dataBase+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            DataTable t = new DataTable();
            adapter.Fill(t);
            foreach(DataRow r in t.Rows)
            {
                cmbTables.Items.Add(r[0]);
            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = @"select * from " + cmbTables.SelectedItem.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            DataTable t = new DataTable();
            adapter.Fill(t);
            dgvTable.DataSource = t;
        }
    }
}
