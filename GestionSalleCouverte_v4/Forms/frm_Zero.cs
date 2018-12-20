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

namespace GestionSalleCouverte.Forms
{
    public partial class frm_Zero : Form
    {
        public frm_Zero()
        {
            InitializeComponent();
        }

        private void btnPntg_Click(object sender, EventArgs e)
        {
            new frmPointage().Show();
        }

        private void btnMony_Click(object sender, EventArgs e)
        {
            new frm_Welcome().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _GA.Exit();
        }
    }
}
