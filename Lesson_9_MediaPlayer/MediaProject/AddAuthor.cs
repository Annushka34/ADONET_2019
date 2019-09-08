using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaProject
{
    public partial class AddAuthor : Form
    {
        public AddAuthor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EfContext context = new EfContext();
            Singer singer = new Singer();
            singer.Name = textBox1.Text;
            singer.UrlInfo = textBox2.Text;
            context.Singers.Add(singer);
            context.SaveChanges();
            this.Close();
        }
    }
}
