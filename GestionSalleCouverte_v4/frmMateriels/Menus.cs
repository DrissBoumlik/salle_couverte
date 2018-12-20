using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionSalleCouverte
{
    public partial class MenuApp : Form
    {
        public static Produit f;
        public static Ajoutez_Modifier_un_emplacement p;
        public static Liste_Materiels l;
        public static Ajoutez_Modifier_une_Categorie c;
        //public static about b;
        public MenuApp()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(300, 100);
        }
      
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //this.Close(); 
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Form fo = new Form();
            //fo.Controls.Add(pictureBox1);
            //fo.AutoSize = true;
            //fo.StartPosition = FormStartPosition.CenterScreen;
            //fo.FormBorderStyle = FormBorderStyle.None;
            //fo.Size = pictureBox1.Size;
            //fo.ShowDialog();
           // Form1 f;
            if(f==null) {f= new Produit();
            f.Show();}
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           if( p==null) {p = new Ajoutez_Modifier_un_emplacement();
            p.Show();}
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (c == null)
            {
                c = new Ajoutez_Modifier_une_Categorie();
                c.Show();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (l == null)
            {
                l = new Liste_Materiels();
                l.Show();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //if (b == null) { b = new about(); b.Show(); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Menus_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void pictureBox1_MouseHover(object sender, EventArgs e)
        //{

        //    pictureBox1.Location = new Point(85, 40);
        //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //}

        //private void pictureBox1_MouseLeave(object sender, EventArgs e)
        //{
        //    pictureBox1.Location = new Point(85, 31);
        //    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        //}

        //private void pictureBox1_MouseHover_1(object sender, EventArgs e)
        //{

        //}
    }
}
