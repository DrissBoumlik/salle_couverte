using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionSalleCouverte.Classes;

namespace GestionSalleCouverte.Forms
{
    public partial class frmChart : Form
    {
        public frmChart()
        {
            InitializeComponent();
        }

        private void frmChart_Load(object sender, EventArgs e)
        {
            try
            {
                _GA.da = new SqlDataAdapter("sp_stat_Total", _GA.cnx);
                _GA.da.SelectCommand.CommandType = CommandType.StoredProcedure;
                _GA.da.SelectCommand.Parameters.Add("@an", SqlDbType.Int).Value = frmTraceAdherent.an;

                GestionSalleCouverte.Rapport.DataSet2 ds = new GestionSalleCouverte.Rapport.DataSet2();
                _GA.da.Fill(ds.Tables[0]);
                CrystalReport2 cr = new CrystalReport2();
                cr.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = cr;
            }
            catch { }

        }
    }
}
