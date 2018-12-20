using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GestionSalleCouverte.Forms
{
    public partial class frmApercu : Form
    {
        public frmApercu()
        {
            InitializeComponent();
        }

        private void frmApercu_Load(object sender, EventArgs e)
        {
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(frmAdherent.tmp.Tables [0]);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
