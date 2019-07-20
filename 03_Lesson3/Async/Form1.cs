using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async
{
    public partial class Form1 : Form
    {
        SqlConnection con = null;
        DataTable t;
        delegate void mydel(string s);

        public Form1()
        {
            InitializeComponent();
            string conStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
            con = new SqlConnection(conStr);
        }

     
        private void btAsync_Click(object sender, EventArgs e)
        {   

            SqlCommand comm = con.CreateCommand();
            comm.CommandText = "WAITFOR DELAY '00:00:05';SELECT * FROM Book;";
            comm.CommandType = CommandType.Text;
            comm.CommandTimeout = 30;    ///    
            try
            {
                con.Open();
                AsyncCallback callback = new AsyncCallback(GetDataCallback);
                comm.BeginExecuteReader(callback, comm);
                MessageBox.Show("Added thread is working...");
                timer1.Start();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void GetDataCallback(IAsyncResult result)
        {
            SqlDataReader reader = null; try
            {        
                SqlCommand command = (SqlCommand)result.AsyncState;       ///       /// блок 2       
                reader = command.EndExecuteReader(result);       ///       
                t = new DataTable();
                int line = 0;
                do
                {
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i <                              
                                reader.FieldCount; i++)
                            {
                                t.Columns.Add(reader.GetName(i));
                            }
                            line++;
                        }
                        DataRow row = t.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {                   
                            row[i] = reader[i];
                        }
                        t.Rows.Add(row);
                    }
                }
                while (reader.NextResult());

                DgvAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show("From Callback 1:" + ex.Message);
            }
            finally
            {
                try
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("From Callback 2:" + ex.Message);
                }
            }
        }
        private void DgvAction()
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(DgvAction));
                return;
            }
            dataGridView1.DataSource = t;
            timer1.Stop();
            progressBar1.Value = progressBar1.Maximum;
        }
        private void AddToList(string row)
        {
            //MessageBox.Show("Added thread is working...");

            listBox1.Items.Add(row);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Step;

        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("WAITFOR DELAY '00:00:05'; select* from Book", con);
            com.CommandType = CommandType.Text; com.CommandTimeout = 30;
            con.Open();
            t = new DataTable();
            timer1.Start();
            label1.Text = "wait....";
            
            SqlDataReader dr = com.ExecuteReader();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                DataColumn col = new DataColumn(dr.GetName(i), dr.GetType());
                t.Columns.Add(col);
            }
            mydel del = AddToList;
            while (dr.Read())
            {
                string row = "";
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row += dr[i] + " ";
                }
                //  listBox1.Invoke(del, row);
                AddToList(row);
            }
            label1.Text = "complited...";
            timer1.Stop();
            progressBar1.Value = progressBar1.Maximum;
            dr.Close();
            con.Close();
        }

        public void TimerStart()
        {
            label1.Text = "wait....";
            timer1.Start();
        }
    }
}
