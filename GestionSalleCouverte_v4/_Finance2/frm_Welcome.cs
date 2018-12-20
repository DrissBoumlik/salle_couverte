using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionSalleCouverte._Finance2.Annuel_Dcpln;
using GestionSalleCouverte._Finance2.Mensuel;
using GestionSalleCouverte._Finance2.Mensuel_Dcpln;

namespace GestionSalleCouverte._Finance2
{
    public partial class frm_Welcome : Form
    {
        public frm_Welcome()
        {
            InitializeComponent();
        }

        private void btnAn_Click(object sender, EventArgs e)
        {
            new frm_An_Dcpln().Show();
        }

        private void btnMth_Click(object sender, EventArgs e)
        {
            new frm_Mth().Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void btnDcplnDiag_Click(object sender, EventArgs e)
        {
            new frm_Mth_Dcpln().Show();
        }

        private void btnDcplnTab_Click(object sender, EventArgs e)
        {
            new frm_Mth_Dcpln_tab().Show();
        }
    }
}
