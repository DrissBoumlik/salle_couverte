using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using GestionSalleCouverte.Classes;

namespace GestionSalleCouverte.Forms
{
    public partial class frmTraceAdherent : Form
    {
        public frmTraceAdherent()
        {
            InitializeComponent();
            _GA.currentForm = this;
            if (_GA.cnx == null)
            {
                _GA.cnx = new SqlConnection(_GA.strCnx);
                _GA.cnx.Open();
            }
            else if (_GA.cnx.State == ConnectionState.Closed)
                _GA.cnx.Open();
        }

        private void frmTraceAdherent_Load(object sender, EventArgs e)
        {
            try
            {
                nmUpDwnYear.Value = DateTime.Now.Year;
                ds = new DataSet();
                _GA.da = new SqlDataAdapter("select * from discipline", _GA.cnx);
                _GA.da.Fill(ds, "discipline");
                cmBxDcpln.DataSource = ds.Tables["discipline"]; cmBxDcpln.ValueMember = cmBxDcpln.DisplayMember = ds.Tables["discipline"].Columns[0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private DataSet ds;


        #region Menu

        private void adhérantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdherent().Show();
        }

        private void recetteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmRecette().Show();
        }

        private void SeanceDisciplineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmParametre().Show();
        }
        private void pointageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmPointage().Show();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GA.Exit(this);
        }

        #endregion

        #region Methodes

        private DataTable DataTableForGridControl()
        {
            #region create table with 20 columns
            DataTable dt = new DataTable();
            dt.Columns.Add("Nbr");
            dt.Columns.Add("Nom");
            dt.Columns.Add("Prenom");
            dt.Columns.Add("CIN");
            dt.Columns.Add("DATE NAISSANCE");
            dt.Columns.Add("Telephone");
            dt.Columns.Add("DATE ADHESION");
            dt.Columns.Add("FRAIS ADHESION");
            dt.Columns.Add("JAN");
            dt.Columns.Add("FEV");
            dt.Columns.Add("MARS");
            dt.Columns.Add("AVR");
            dt.Columns.Add("MAI");
            dt.Columns.Add("JUIN");
            dt.Columns.Add("JUI");
            dt.Columns.Add("AOUT");
            dt.Columns.Add("SEPT");
            dt.Columns.Add("OCT");
            dt.Columns.Add("NOV");
            dt.Columns.Add("DEC");
            #endregion
            return dt;
        }

        void TraceAdherent(string discipline, string year)
        {
            //_GA.da = new SqlDataAdapter("select * from " + nomView + " where datepart(year,[DATE PAIEMENT]) = " + year, _GA.cnx);
            string query = "select * from V_Trace where Dcpln='" + discipline + "' " +
                           "and ((YEAR([DATE PAIEMENT])=" + year + "-1 and MONTH([DATE PAIEMENT]) + nbrMoisPay > 13) " +
                           "or YEAR([DATE PAIEMENT])=" + year + ")";
            //"select * from V_Trace where Dcpln = '" + discipline + "' and datepart(year,[DATE PAIEMENT]) = " + year
            _GA.da = new SqlDataAdapter(query, _GA.cnx);
            ds = new DataSet();
            _GA.da.Fill(ds, "trace");
            DataTable tmp = ds.Tables["trace"];

            DataTable dt = DataTableForGridControl();

            ArrayList ar_Ids_adh = new ArrayList();
            foreach (DataRow row in tmp.Rows)
            {
                if (!ar_Ids_adh.Contains(row[0]))
                {
                    //---------------------------------save member's datas
                    ar_Ids_adh.Add(row[0]);
                    object id_adh = row[0];
                    ArrayList ar_info_Adh = new ArrayList();
                    int i;
                    for (i = 1; i < 8; i++)
                    {
                        if (i == 4 || i == 6)
                            ar_info_Adh.Add(((DateTime)row[i]).ToShortDateString());
                        else
                            ar_info_Adh.Add(row[i]);
                    }

                    //----------------------------------- Extract month payments
                    DataRow[] tmpRows = tmp.Select("nbr = " + row[0]);
                    SortedList sl_Months = new SortedList();
                    //_GA.cnx.Open();
                    object cotis =
                        new SqlCommand("select cotisation from discipline where Id_Dcpln = '" + discipline + "'", _GA.cnx)
                            .ExecuteScalar();
                    //_GA.cnx.Close();
                    foreach (DataRow dr in tmpRows)
                    {
                        int year_pay = ((DateTime)dr[8]).Year;
                        int month_pay = ((DateTime)dr[8]).Month;
                        int nbr_mois = int.Parse(dr["nbrMoisPay"].ToString()) - 1;
                        if (year_pay == int.Parse(year))
                        {
                            //int index = i;
                            sl_Months[month_pay + 7] = dr[9];
                            //int nbr_mois = (int)(float.Parse(dr[9].ToString()) / float.Parse(cotis.ToString())) - 1;

                            while (nbr_mois > 0)
                            {
                                sl_Months[month_pay + 7 + nbr_mois] = "--";
                                nbr_mois--;
                            }
                        }
                        else
                        {
                            nbr_mois = month_pay + nbr_mois - 13;
                            month_pay = 0;
                            while (nbr_mois > 0)
                            {
                                sl_Months[month_pay + 7 + nbr_mois] = "--";
                                nbr_mois--;
                            }
                        }
                    }
                    DataRow rw = dt.NewRow();
                    int j;
                    rw[0] = id_adh; for (j = 0; j < ar_info_Adh.Count; j++)
                        rw[j + 1] = ar_info_Adh[j];
                    for (j = 8; j < dt.Columns.Count; j++)
                    {
                        rw[j] = sl_Months[j];
                    }
                    dt.Rows.Add(rw);
                }
            }
            gridControl1.DataSource = dt;
            gridView1.BestFitColumns(true);
        }

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                TraceAdherent(cmBxDcpln.Text, nmUpDwnYear.Value.ToString());
            }
            catch (Exception)
            {
                
            }
        }

        private void ajoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new addPointage().Show();

        }

        private void verouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _GA.logedIn = false;
            new frmLogIn().Show();
        }

        public static int an;
        private void btnShwChrt_Click(object sender, EventArgs e)
        {
            an = (int)nmUpDwnYear.Value;
            new frmChart().Show();
        }

        private void frmTraceAdherent_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                _GA.KeepDistance(splitContainer1, 70);
            }
            catch (Exception)
            {
                
            }
        }

    }
}
