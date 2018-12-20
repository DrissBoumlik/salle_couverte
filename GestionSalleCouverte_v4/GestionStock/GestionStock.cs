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
    public partial class GestionStock : Form
    {
        public GestionStock()
        {
            InitializeComponent();
        }
        public static Produits f;
        public static CategorieProd p;
        public static ListProduit l;
        private void GestionStock_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (f == null)
            {
                f = new Produits();
                f.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (p == null)
            {
                p = new CategorieProd ();
                p.Show();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            if (l == null)
            {
                l = new ListProduit();
                l.Show();
            }
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
