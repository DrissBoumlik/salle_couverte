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

namespace GestionSalleCouverte._Finance.Mensuel
{
    public partial class frm_Mth : Form
    {
        public frm_Mth()
        {
            InitializeComponent();
        }

        private void frm_Mth_Load(object sender, EventArgs e)
        {
            nmUpDwnYear.Value = DateTime.Now.Year;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            _GA.cnx = new SqlConnection(_GA.strCnx);
            _GA.da = new SqlDataAdapter("sp_totSal1_mois", _GA.cnx);
            _GA.da.SelectCommand.CommandType = CommandType.StoredProcedure;
            _GA.da.SelectCommand.Parameters.AddWithValue("@an", nmUpDwnYear.Value);
            DataSet1 ds = new DataSet1();
            _GA.da.Fill(ds.Tables["sp_totSal1_mois"]);

            //ArrayList ar = new ArrayList();
            //ar.AddRange(new object[]
            //{
            //    "Janvier", "Février", "Mars", "Avril", "Mai", "Juin",
            //    "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Décembre"
            //}
            //    );

            //for (int i = 0; i < ar.Count; i++)
            //{
            //    DataRow r = ds.Tables["sp_totSal1_mois"].NewRow();
            //    r[0] = 0.0;
            //    r[1] = ar[i];
            //    r[2] = i + 1;
            //    ds.Tables["sp_totSal1_mois"].Rows.Add(r);
            //}

            //var dt = new DataTable();
            //_GA.da.Fill(dt);
            //foreach (DataRow r in dt.Rows)
            //{
            //    foreach (DataRow t in ds.Tables["sp_totSal1_mois"].Rows)
            //    {
            //        if (r[1].ToString() == t[1].ToString())
            //        {
            //            t[0] = double.Parse(r[0].ToString());
            //            ar.Remove(r[1].ToString()); break;
            //        }
            //    }
            //}
            //for (int j = 0; j < ar.Count; )
            //{
            //    foreach (DataRow t in ds.Tables["sp_totSal1_mois"].Rows)
            //    {
            //        if (ar[j].ToString() == t[1].ToString())
            //        {
            //            t[0] = 0;
            //            ar.RemoveAt(j);
            //            break;
            //        }
            //    }
            //}

            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds.Tables["sp_totSal1_mois"]);
            crystalReportViewer1.ReportSource = cr;

            lblTotal.Text = "Total : " + _GA.GetTotalYear("sp_totSal1_mois_dcpln",nmUpDwnYear.Value);
        
        }
    }
}
