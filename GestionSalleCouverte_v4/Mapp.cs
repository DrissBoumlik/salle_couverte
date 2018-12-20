using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionSalleCouverte.Classes;
using GestionSalleCouverte.Forms;
using App_Gestion_Reservation;
namespace GestionSalleCouverte
{
    public partial class Mapp : Form
    {
        public Mapp()
        {
            InitializeComponent();
            _GA.cnx = new System.Data.SqlClient.SqlConnection(_GA.strCnx);
        }

        private void Mapp_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Finance f = new Finance(); f.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmPointage h = new frmPointage();
            h.Show();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form_Menu m = new Form_Menu();
            m.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MenuApp m = new MenuApp();
            m.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            _GA.Exit();
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            Finance f = new Finance(); f.Show();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.SizeMode = PictureBoxSizeMode.CenterImage;

        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.SizeMode = PictureBoxSizeMode.CenterImage;

        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            GestionStock g = new GestionStock();
            g.Show();
        }
    }
}
