using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GestionSalleCouverte.Classes;
using GestionSalleCouverte.Forms;
using GestionSalleCouverte.Financee;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
namespace GestionSalleCouverte
{
    public partial class ChartYr : Form
    { 
        public ChartYr()
        {
            InitializeComponent();
        } Dtsxsd ds;
        int m, yr;
        double sum;
        DataRow p,p2;
        List<DataRow> li=new List<DataRow> ();
        string idmois;
        public ChartYr(int m, int yr)
        {
            InitializeComponent();
            this.m = m; this.yr = yr; 
        }
        private void ChartYr_Load(object sender, EventArgs e)
        {
          
            try { ds.Tables["ch"].Clear(); }
            catch { }
            if (this.m != 0)
            {
                _GA.da = new SqlDataAdapter("select * from charan where An=" + this.yr + " and idmois=" + this.m, _GA.cnx);
                ds = new Dtsxsd();
                _GA.da.Fill(ds, "ch");
                try
                {
                    removemixte();
                }
                catch 
                {
                    
                   
                }
                // charyr cr = new charyr();
                ReportDocument n = new ReportDocument();
                n.Load(@"C:\Users\Simo\Desktop\_______________\Salle_Couverte -solutionrar\GestionSalleCouverte_v4\Financee\Crmonth.rpt");
                n.SetDataSource(ds.Tables["ch"]); 
                //Crmonth cr = new Crmonth();
                //cr.SetDataSource(ds.Tables["ch"]);
                //crystalReportViewer1.ReportSource = cr;
                crystalReportViewer1.ReportSource = n;
            }
            else if (this.m == 0)
            {
                _GA.da = new SqlDataAdapter("select * from charan where An=" + this.yr, _GA.cnx);
                ds = new Dtsxsd();
                _GA.da.Fill(ds, "ch");
                foreach (DataRow r in ds.Tables["ch"].Rows)
                {
                    if (r["Dcpln"].ToString() == "MIXTE")
                    {
                        idmois = r["idmois"].ToString();
                        sum = double.Parse(r["Montant"].ToString());
                        foreach (DataRow c in ds.Tables["ch"].Rows)
                        { 
                         if (c["Dcpln"].ToString() == "FITNESS" && c["idmois"].ToString()==idmois)
                             c["Montant"] = double.Parse(c["Montant"].ToString()) + sum;

                        }
                 
                        li.Add(r);
                       // sum = double.Parse(r["Montant"].ToString());

                    }
                }
              foreach(DataRow r in li)
                {
                ds.Tables["ch"].Rows.Remove(r);
                }

               // removemixte();
                charyr cr = new charyr();
                cr.SetDataSource(ds.Tables["ch"]);
                crystalReportViewer1.ReportSource = cr;
            
            
            
            
            }
        }
        private void removemixte()
        {
            foreach (DataRow r in ds.Tables["ch"].Rows)
            {
                if (r["Dcpln"].ToString() == "MIXTE")
                {
                    p2 = r;
                    sum = double.Parse(r["Montant"].ToString());
                    foreach (DataRow c in ds.Tables["ch"].Rows)
                    {
                        if (c["Dcpln"].ToString() == "FITNESS") { c["Montant"] = double.Parse(c["Montant"].ToString()) + sum; }
                    }
                }
            }
            ds.Tables["ch"].Rows.Remove(p2);
           
        }
    }
}
