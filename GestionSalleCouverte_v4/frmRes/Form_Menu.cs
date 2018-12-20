using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App_Gestion_Reservation
{
    public partial class Form_Menu : Form
    {
        public Form_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Client c = new Form_Client();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            Form_reservation r = new Form_reservation();
            
            r.Show();
        }

        private void Form_Menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form_Client c = new Form_Client();
            c.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form_reservation r = new Form_reservation();

            r.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Width = 270;
            pictureBox2.Height = 160;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Width = 256;
            pictureBox2.Height = 141;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Width = 270;
            pictureBox1.Height = 160;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Width = 256;
            pictureBox1.Height = 141;
        }
    }
}
