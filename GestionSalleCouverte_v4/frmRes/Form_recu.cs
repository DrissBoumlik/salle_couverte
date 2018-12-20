using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionSalleCouverte.frmRes;

namespace App_Gestion_Reservation
{
    public partial class Form_recu : Form
    {
        public Form_recu()
        {
            InitializeComponent();
        }
        
        private void Form_recu_Load(object sender, EventArgs e)
        {

            //d.Tables.Add(Form_reservation.dt);
            CrystalReport3 cr = new CrystalReport3();
            cr.SetDataSource(Form_reservation.d.Tables[0]);
            crystalReportViewer1.ReportSource = cr;
        }
    }
}
