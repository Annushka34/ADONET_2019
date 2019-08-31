using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_AsyncReadFileForm
{
    public partial class Form1 : Form
    {
        static string filename = @"D:/1.txt";
       // static int ind = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                byte[] arr = new byte[fs.Length];
                progressBar1.Maximum = (int)fs.Length+1;
                for (int i = 0; i < fs.Length; i++)
                {
                    fs.Read(arr, i, 1);
                    progressBar1.Value += 1;
                }
                textBox1.Text = Encoding.UTF8.GetString(arr);
            }
        }

      

        async private void btnAsync_Click_1(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                byte[] arr = new byte[fs.Length];
                progressBar1.Maximum = (int)fs.Length + 1;
                for (int i = 0; i < fs.Length; i++)
                {
                    await fs.ReadAsync(arr, i, 1);
                    progressBar1.Value += 1;
                }
                textBox1.Text = Encoding.UTF8.GetString(arr);
            }
        }
    }
}
