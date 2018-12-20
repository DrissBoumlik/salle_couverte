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
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void about_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Menus.b = null;
            
          
        }

        private void about_Deactivate(object sender, EventArgs e)
        {
            //Menus.b = null;
        }

        private void about_Leave(object sender, EventArgs e)
        {
           // Menus.b = null;
        }

        private void about_VisibleChanged(object sender, EventArgs e)
        {
          if(this.Visible==false)  MenuApp.b = null;
        }

        private void about_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
