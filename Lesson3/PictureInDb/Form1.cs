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

namespace PictureInDb
{
    public partial class Form1 : Form
    {
        SqlConnection con = null;
        DataTable table = null;
        SqlDataAdapter adapter = null;
        Image img = null;
        int selectedRow = -1;
        public Form1()
        {
            InitializeComponent();
            string connStr = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
            con = new SqlConnection(connStr);
          //  string query = "select * from Book";
            string query = "select Book.Id, BookName, Description, Price, Picture from Book left outer join Pictures on Book.Id = Pictures.BookId";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            table = new DataTable("Book");
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images | *.img; *.jpg; *.jpeg; *.png; *.bmp";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = dialog.FileName;
                img = new Bitmap(filePath);
                img = ResizeImg(img as Bitmap);
                
                pictureBox1.Image = img;
            }
        }

        //-----ЗМІНА РОЗМІРУ КАРТИНКИ
        public Bitmap ResizeImg(Bitmap img)
        {
            int maxW = 100;
            int maxh = 100;
            double resizeW = img.Width / maxW;
            double resizeH = img.Height / maxh; ;
            double resize = resizeH > resizeW ? resizeH : resizeW;
            maxh = (int)(img.Height / resize);
            maxW = (int)(img.Width / resize);
            Image newImg = new Bitmap(maxW, maxh);
            Graphics g = Graphics.FromImage(newImg);
            g.DrawImage(img, 0, 0, maxW, maxh);
            return newImg as Bitmap;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (selectedRow == -1)
            {
                lbl.Text = "Choose one book...";
                return;
            }
            lbl.Text = " ";
            if(table.Rows[selectedRow]["Picture"]!=null)
            {
                DialogResult rez = MessageBox.Show("Do you want to add image to this book?","Save",MessageBoxButtons.OKCancel);
                if (rez != DialogResult.OK)
                    return;
            }
            byte[] arr = ImageToByteArray(img);
            int insertedBook =(int) table.Rows[selectedRow]["Id"];
            string query = "Insert into Pictures values( @bookId, @picture)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add("@bookId", SqlDbType.Int).Value = insertedBook;
            cmd.Parameters.Add("@picture", SqlDbType.Image, arr.Length).Value = arr;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //----ПЕРЕМАЛЬОВУЄМО КАРТИНКУ В ДАТА ГРІД----(треба переробити)
            table.Rows[selectedRow][4] = arr;
            //dataGridView1.Refresh();
        }
        //-----ЗБЕРЕЖЕННЯ КАРТИНКИ В МАСИВ
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl.Text = " ";
            selectedRow = e.RowIndex;
        }
    }
}
