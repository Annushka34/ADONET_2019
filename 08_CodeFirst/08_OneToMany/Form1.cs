using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08_OneToMany
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            EfContext context = new EfContext();
            dataGridView2.DataSource = context.Products.Select(x => new { x.Price, x.ProductName, x.Category.CategoryName }).ToList();
            context.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EfContext context = new EfContext();
            Product p = new Product();
            p.ProductName = textBox1.Text;
            p.Price = int.Parse(textBox2.Text);
            p.CategoryId = 1;
            context.Products.Add(p);
            context.SaveChanges();
            context.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EfContext context = new EfContext();
            string categoryName = textBox4.Text;
            var category = context.Categories.FirstOrDefault(x => x.CategoryName == categoryName);
            if (category != null)
            {
                var productsInCategory = category.Products.ToList();
                dataGridView1.DataSource = productsInCategory;
            }

            context.Dispose();
        }
    }
}
