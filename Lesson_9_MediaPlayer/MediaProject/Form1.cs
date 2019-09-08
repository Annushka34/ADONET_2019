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
    public partial class Form1 : Form
    {
        EfContext context;
        ComboBox cbGenres;
        ComboBox cbAuthors;
        User user;
        public Form1()
        {
            InitializeComponent();
            splitContainer1.Panel2Collapsed = true;
            context = new EfContext();
            txtLogin.Text = "anna";
            txtPaswd.Text = "1111";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtLogin.Text;
            string pswd = txtPaswd.Text;
            user = context.Users.FirstOrDefault(x => x.UserName == name && x.Password == pswd);
            if( user == null)
            {
                lbError.Text = "No such user. Press Register button!";
                txtLogin.Text = string.Empty;
                txtPaswd.Text = string.Empty;
            }
            else
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                TabPage tabPage1 = new TabPage("MyLibrary");
                MyBtn btn = new MyBtn("PLAY");
                tabPage1.Controls.Add(btn);
                btn.SetBounds(10, 10, 150, 60);
                btn.Click += Btn_Click;
                tabControl1.TabPages.Add(tabPage1);


                cbGenres = new ComboBox();
                var genres = context.Genres.ToList();
                cbGenres.DataSource = genres;
                cbGenres.DisplayMember = "GenreName";
                cbGenres.SetBounds(10, 100, 150, 60);
                tabPage1.Controls.Add(cbGenres);

                cbAuthors = new ComboBox();
                var authors = context.Singers.ToList();
                cbAuthors.DataSource = authors;
                cbAuthors.DisplayMember = "Name";
                cbAuthors.SetBounds(10, 180, 150, 60);
                tabPage1.Controls.Add(cbAuthors);

                MyBtn btnAddAuthor = new MyBtn("ADD SINGER");
                btnAddAuthor.SetBounds(170, 180, 100, 30);
                tabPage1.Controls.Add(btnAddAuthor);
                btnAddAuthor.Click += BtnAddAuthor_Click;


                MyBtn btnAddSong = new MyBtn("ADD SONG");
                btnAddSong.SetBounds(170, 220, 100, 30);
                tabPage1.Controls.Add(btnAddSong);
                btnAddSong.Click += BtnAddSong_Click;


                MyBtn show = new MyBtn("VIEW ALL");
                show.SetBounds(210, 220, 250, 60);
                tabPage1.Controls.Add(show);
                show.Click += Show_Click; ;
            }
        }

        private void Show_Click(object sender, EventArgs e)
        {
            var singerSelected = context.Songs.Where(x => x.SingerId == 2);

            var singIds = user.UserSongs.Select(x => x.SongId).ToList();
            var songsInMyLibr = context.Songs.Where(x => singIds.Contains(x.Id)).ToList();
            //var singerSelected = context.Songs.Where(x => x.SingerId == 2);
        }

        private void BtnAddSong_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var filename = openFileDialog1.FileName;
                Song song = new Song();
                song.GenreId = ((Genre)cbGenres.SelectedItem).Id;
                song.SingerId = ((Singer)cbAuthors.SelectedItem).Id;
                song.SongName = filename;
                context.Songs.Add(song);

                UserSong userSong = new UserSong();
                userSong.UserId = user.Id;
                userSong.SongId = song.Id;
                context.UserSongs.Add(userSong);

                context.SaveChanges();
            }
        }

        private void BtnAddAuthor_Click(object sender, EventArgs e)
        {
            AddAuthor form2 = new AddAuthor();
            form2.Show();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage("MediaLibrary1");
            AxWMPLib.AxWindowsMediaPlayer mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            mediaPlayer.Width = this.Width + 20;
            mediaPlayer.SetBounds(20, 20, tabControl1.Width - 40, tabControl1.Height - 40);
            tabPage.Controls.Add(mediaPlayer);
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectedTab = tabPage;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
               // mediaPlayer.settings.autoStart = false;
                mediaPlayer.URL = openFileDialog1.FileName;
                mediaPlayer.Ctlcontrols.play();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel2Collapsed = false;
            //splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void btnRegisterRegister_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtRegisterLogin.Text != "" && txtRegisterPswd.Text != "")
            {
                if (context.Users.Any(x => x.Email == txtEmail.Text || x.UserName == txtRegisterLogin.Text))
                {
                    lblError2.Text = "User login or email not unique!";
                    txtEmail.Text = string.Empty;
                    txtRegisterPswd.Text = string.Empty;
                }
                User newUser = new User();
                newUser.Email = txtEmail.Text;
                newUser.UserName = txtRegisterLogin.Text;
                newUser.Password = txtRegisterPswd.Text;
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }
    }

    public class MyBtn : Button
    {
        public MyBtn(string text) : base()
        {
            this.Text = text;
            Width = 200;
            this.BackColor = Color.BlueViolet;
        }
    }
}
