using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionSalleCouverte.Classes;

namespace GestionSalleCouverte._Finance.Annuel_Dcpln
{
    public partial class frm_An_Dcpln : Form
    {
        public frm_An_Dcpln()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nmUpDwnYear.Value = DateTime.Now.Year;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _GA.cnx = new SqlConnection(_GA.strCnx);
            _GA.da = new SqlDataAdapter("sp_totSal1_an_dcpln", _GA.cnx);
            _GA.da.SelectCommand.CommandType = CommandType.StoredProcedure;
            _GA.da.SelectCommand.Parameters.AddWithValue("@an", nmUpDwnYear.Value);
            DataSet1 ds = new DataSet1();


            //ArrayList ar = new ArrayList();
            //ar.AddRange(new object[]
            //{
            //    "FITNESS", "MIXTE", "MUSCULATION"
            //});

            //for (int i = 0; i < ar.Count; i++)
            //{
            //    DataRow dr = ds.Tables["sp_totSal1_an_dcpln"].NewRow();
            //    dr[0] = 0.0;
            //    dr[1] = ar[i];
            //    ds.Tables["sp_totSal1_an_dcpln"].Rows.Add(dr);
            //}


            //var dt = new DataTable();
            //_GA.da.Fill(dt);
            //int i = 0;
            //foreach (DataRow r in dt.Rows)
            //{
            //    foreach (DataRow t in ds.Tables["sp_totSal1_an_dcpln"].Rows)
            //    {
            //        if (r[1].ToString().ToLower() == t[1].ToString().ToLower())
            //        {
            //            t[0] = double.Parse(r[0].ToString());
            //            ar.Remove(r[1].ToString().ToUpper()); break;
            //        }
            //    }
            //}
            //for (int j = 0; j < ar.Count; )
            //{
            //    foreach (DataRow t in ds.Tables["sp_totSal1_an_dcpln"].Rows)
            //    {
            //        if (ar[j].ToString() == t[1].ToString().ToUpper())
            //        {
            //            t[0] = 0;
            //            ar.RemoveAt(j);
            //            break;
            //        }
            //    }
            //}
            _GA.da.Fill(ds.Tables["sp_totSal1_an_dcpln"]);
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds.Tables["sp_totSal1_an_dcpln"]);
            crystalReportViewer1.ReportSource = cr;

            lblTotal.Text = "Total : " + _GA.GetTotalYear("sp_totSal1_mois_dcpln",nmUpDwnYear.Value);

        }

    }
}
