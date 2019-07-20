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

namespace _05_AdoNetBeginInvoke
{
    public partial class Form1 : Form
    {
        SqlConnection con = null;
        string conStr;
        public Form1()
        {
            InitializeComponent();
            conStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
            con = new SqlConnection(conStr);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pbSynchron.Value < pbSynchron.Maximum)
                pbSynchron.Value += pbSynchron.Step;
            else
                pbSynchron.Value = 0;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pbAsynchrn.Value < pbAsynchrn.Maximum)
                pbAsynchrn.Value += pbAsynchrn.Step;
            else
                pbAsynchrn.Value = 0;
        }

        private void btnOpenForm2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(textBox1.Text);
            form2.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            timer1.Start();
            con.Open();
            string query = "Select * From Book; WAITFOR DELAY '00:00:05'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr =  com.ExecuteReader();

            DataTable t = new DataTable("Book");
            for (int i = 0; i < dr.FieldCount; i++)
            {
                DataColumn col = new DataColumn(dr.GetName(i), dr.GetFieldType(i));
                t.Columns.Add(col);
            }

            while(dr.Read())
            {
                DataRow row = t.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {                   
                    row[i] = dr[i];
                }
                t.Rows.Add(row);
            }

            con.Close();
            dgvSynchron.DataSource = t;
            pbSynchron.Value = pbSynchron.Maximum;
            timer1.Stop();
        }

        private void btnLoadAsync_Click(object sender, EventArgs e)
        {
            timer2.Start();
            con.Open();
            string query = "Select * From Book; WAITFOR DELAY '00:00:05'";
            SqlCommand com = new SqlCommand(query, con);
            AsyncCallback callbackDelegate = new AsyncCallback(CallbackFunc);
            IAsyncResult asyncResult = com.BeginExecuteReader(callbackDelegate, com);
        }

        private void CallbackFunc(IAsyncResult param)
        {
            SqlCommand com = (SqlCommand)param.AsyncState;
            SqlDataReader dr = com.EndExecuteReader(param);
            DataTable t = new DataTable("Book");
            for (int i = 0; i < dr.FieldCount; i++)
            {
                DataColumn col = new DataColumn(dr.GetName(i), dr.GetFieldType(i));
                t.Columns.Add(col);
            }

            while (dr.Read())
            {
                DataRow row = t.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];
                }
                t.Rows.Add(row);
            }

            con.Close();
            dgvAsynchron.DataSource = t;
            pbAsynchrn.Value = pbAsynchrn.Maximum;
            timer2.Stop();
        }
    }
}
