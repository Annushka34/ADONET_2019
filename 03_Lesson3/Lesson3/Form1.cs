 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson3
{
    public partial class Form1 : Form
    {
        SqlConnection con = null;
        DataSet dataSet = null;
        SqlDataAdapter adapter = null;
        public Form1()
        {
            InitializeComponent();
            string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
            con = new SqlConnection(connStr);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string query = "Select * from Book";
            adapter = new SqlDataAdapter(query,con);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            dataSet = new DataSet();
            adapter.Fill(dataSet,"Book");
            dgv.DataSource = dataSet.Tables["Book"];
            lblTableName.Text = dataSet.Tables["Book"].TableName;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            dataSet.RejectChanges();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            adapter.Update(dataSet.Tables["Book"].Select(null, null, DataViewRowState.Deleted));
        }

        private void btnIns_Click(object sender, EventArgs e)
        {
            adapter.Update(dataSet.Tables["Book"].Select(null, null, DataViewRowState.Added));
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            adapter.Update(dataSet.Tables["Book"].Select(null, null, DataViewRowState.ModifiedCurrent));
        }
     
    }
}
