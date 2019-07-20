using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _04_BeginInvokeForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAsynStart_Click(object sender, EventArgs e)
        {
            var del = new Action<int>(LoadFiles);
            del.BeginInvoke(100, null, null);
           // LoadFiles2(100);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LoadFiles(200);
        }

        private void LoadFiles(int count)
        {
            for (int i = 0; i < count; i++)
            {
            if (progressBar1.Value >= progressBar1.Maximum)
                progressBar1.Value = 0;
                Thread.Sleep(100);
            progressBar1.Value += progressBar1.Step;
            }
        }
        //private void LoadFiles2(int count)
        //{
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (progressBar2.Value >= progressBar2.Maximum)
        //            progressBar2.Value = 0;
        //        Thread.Sleep(100);
        //        progressBar2.Value += progressBar2.Step;
        //    }
        //}
    }
}
