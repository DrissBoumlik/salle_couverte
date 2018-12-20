using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using GestionSalleCouverte.Classes;

namespace GestionSalleCouverte._Finance.Mensuel_Dcpln
{
    public partial class frm_Mth_Dcpln : Form
    {
        public frm_Mth_Dcpln()
        {
            InitializeComponent();
        }
        ArrayList ar_mth = new ArrayList();
        ArrayList ar_dcpln = new ArrayList();
        ArrayList ar = new ArrayList();
        private void frm_Mth_Dcpln_Load(object sender, EventArgs e)
        {
            nmUpDwnYear.Value = DateTime.Now.Year;

            //ar_mth.AddRange(new object[]
            //{
            //    "Janvier", "Février", "Mars", "Avril", "Mai", "Juin",
            //    "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Décembre"
            //}
            //    );
            //ar_dcpln.AddRange(new object[]
            //{
            //    "FITNESS", "MIXTE", "MUSCULATION"
            //});
            //for (int i = 0; i < ar_dcpln.Count; i++)
            //    for (int j = 0; j < ar_mth.Count; j++)
            //    {
            //        ar.Add(ar_dcpln[i] + "." + ar_mth[j]);
            //    }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _GA.cnx = new SqlConnection(_GA.strCnx);
            _GA.da = new SqlDataAdapter("sp_totSal1_mois_dcpln", _GA.cnx);
            _GA.da.SelectCommand.CommandType = CommandType.StoredProcedure;
            _GA.da.SelectCommand.Parameters.AddWithValue("@an", nmUpDwnYear.Value);
            DataSet1 ds = new DataSet1();

            //for (int i = 0; i < ar_dcpln.Count; i++)
            //{
            //    for (int j = 0; j < ar_mth.Count; j++)
            //    {
            //        DataRow r = ds.Tables["sp_totSal1_mois_dcpln"].NewRow();
            //        r[0] = 0.0;
            //        r[1] = ar_dcpln[i];
            //        r[2] = ar_mth[j];
            //        r[3] = j + 1;
            //        ds.Tables["sp_totSal1_mois_dcpln"].Rows.Add(r);
            //    }
            //}
            //var dt = new DataTable();
            _GA.da.Fill(ds.Tables["sp_totSal1_mois_dcpln"]);
            //_GA.da.Fill(dt);//foreach (DataRow r in dt.Rows)
            //{
            //    foreach (DataRow t in ds.Tables["sp_totSal1_mois_dcpln"].Rows)
            //    {
            //        if (r[1].ToString() == t[1].ToString() && r[2].ToString() == t[2].ToString())
            //        {
            //            t[0] = double.Parse(r[0].ToString());
            //            ar.Remove(r[1] + "." + r[2]); break;
            //        }
            //    }
            //}

            //for (int j = 0; j < ar.Count; )
            //{
            //    foreach (DataRow t in ds.Tables["sp_totSal1_mois_dcpln"].Rows)
            //    {
            //        string dcpln_mnth = ar[j].ToString();
            //        if (dcpln_mnth.Split('.')[0] == t[1].ToString() && dcpln_mnth.Split('.')[1] == t[2].ToString())
            //        {
            //            t[0] = 0;
            //            ar.RemoveAt(j);
            //            break;
            //        }
            //    }
            //}

            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds.Tables["sp_totSal1_mois_dcpln"]);
            crystalReportViewer1.ReportSource = cr;

            lblTotal.Text = "Total : " + _GA.GetTotalYear("sp_totSal1_mois_dcpln",nmUpDwnYear.Value);
        }
    }
}
