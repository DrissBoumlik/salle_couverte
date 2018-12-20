using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections;
using System.Linq.Expressions;
using GestionSalleCouverte.Classes;
using DevExpress.XtraScheduler.UI;

namespace GestionSalleCouverte.Forms
{
    public partial class frmRecette : Form
    {
        public frmRecette()
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
            gridView1.RowCellStyle += gridView1_RowCellStyle;
        }

        private DataSet ds;
        private void frmRecette_Load(object sender, EventArgs e)
        {
            try
            {
                nmUpDwnYear.Value = DateTime.Now.Year;
                mnthEdtMonth.EditValue = DateTime.Now.Month;

                ds = new DataSet();
                _GA.da = new SqlDataAdapter("Select * from Discipline", _GA.cnx);
                _GA.da.Fill(ds, "discipline");
                /*cmBxDcpln2.DataSource = cmBxDcpln3.DataSource =*/
                cmBxDcpln.DataSource = ds.Tables["discipline"];
                cmBxDcpln.ValueMember /*= cmBxDcpln.DisplayMember = cmBxDcpln3.DisplayMember*/ = ds.Tables["discipline"].Columns[0].ToString();
                cmBxDcpln.ValueMember /*= cmBxDcpln2.DisplayMember = cmBxDcpln3.ValueMember*/ = ds.Tables["discipline"].Columns[0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private double mt_total;
        private double mt_cotis;
        private double mt_adhs;
        private int nbrAdh;
        private int nbrIns;
        private int nbrReIns;
        //private bool deja_fait;

        //private int cotisation, nbrMois;
        private ArrayList ar_nbrMoisPay;
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                //if (!deja_fait)
                switch (e.Column.FieldName)
                {
                    case "DATE PAIEMENT":
                        DateTime tmp = DateTime.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["DATE PAIEMENT"]));
                        DateTime date_pay = DateTime.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["DATE PAIEMENT"]));

                        int nbrMoisPay = int.Parse(ar_nbrMoisPay[e.RowHandle].ToString());
                        if (nbrMoisPay + tmp.Month >= 12)
                            break;
                        //DateTime date_pay = DateTime.Now;//new DateTime(tmp.Year, tmp.Month + int.Parse(ar_nbrMoisPay[e.RowHandle].ToString()) - 1, tmp.Day);
                        if ((DateTime.Now - date_pay).Days > 30)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                        }
                        break;
                    case "M. TOTAL":
                        if (nbrAdh > 0)
                            mt_total += double.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["M. TOTAL"]));
                        break;
                    case "FRAIS ADHESION":
                        if (nbrAdh > 0)
                            mt_adhs += double.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["FRAIS ADHESION"]));
                        break;
                    case "cotisation":
                        if (nbrAdh > 0)
                            mt_cotis += double.Parse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["cotisation"]));
                        break;
                    case "critere":
                        if (nbrAdh > 0)
                        {
                            var critere = View.GetRowCellDisplayText(e.RowHandle, View.Columns["critere"]);
                            if (critere == "Inscription")
                                nbrIns++;
                            else nbrReIns++;
                            nbrAdh--;
                        }

                        break;
                }
            }
            catch { }
        }

        #region Menu

        private void adhérantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdherent().Show();
        }


        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GA.Exit(this);
        }

        private void traceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmTraceAdherent().Show();
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

        private void affichageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmPointage().Show();
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

        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            //mnthEdtMonth2.EditValue = mnthEdtMonth.EditValue;
            //nmUpDwnYear2.Value = nmUpDwnYear.Value;
            ChargerRecette(cmBxDcpln, mnthEdtMonth, nmUpDwnYear);
        }

        //private void btnOk2_Click(object sender, EventArgs e)
        //{
        //    mnthEdtMonth.EditValue = mnthEdtMonth2.EditValue;
        //    nmUpDwnYear.Value = nmUpDwnYear2.Value;
        //    ChargerRecette(cmBxDcpln2, mnthEdtMonth2, nmUpDwnYear);
        //}

        private void ChargerRecette(ComboBox cmBx, MonthEdit mnth, NumericUpDown nmUpDw)
        {
            //deja_fait = false;
            mt_total = mt_adhs = mt_cotis = 0;
            nbrAdh = nbrIns = nbrReIns = 0;
            nbrAdh = 0;
            string str = "select * from V_Recette where dcpln = '" + cmBx.SelectedValue + "' " +
                         "and (DATEPART(yy,[DATE PAIEMENT]) = " + nmUpDw.Value + ") " +
                         "and (DATEPART(mm,[DATE PAIEMENT]) = " + mnth.EditValue + ") " +
                         "and date_Adh = (select MAX(date_Adh) from Adhesion where Id_Adh = Nbr)";
            //string str = "select * from V_Recette where dcpln = '" + cmBx.SelectedValue + "' " +
            //              " and (DATEPART(yy,[DATE PAIEMENT]) = " + nmUpDw.Value +
            //              //" or DATEPART(yy,date_adh) = " + nmUpDw.Value +
            //              ") and  (DATEPART(mm,[DATE PAIEMENT]) = " + mnth.EditValue +
            //              " or  DATEPART(mm,[DATE PAIEMENT]) < " + mnth.EditValue +
            //              " and DATEPART(mm,[DATE PAIEMENT])+nbrMoisPay	 > " + mnth.EditValue + ")";
            //string str2="select * from V_Recette where dcpln = '" + cmBx.SelectedValue + "'" +
            //            " and (DATEPART(yy,[DATE PAIEMENT]) = " + nmUpDw.Value +
            //            //" and DATEPART(yy,date_adh) = " + nmUpDw.Value +
            //            " and  (DATEPART(mm,[DATE PAIEMENT]) = " + mnth.EditValue +
            //            " or (DATEPART(mm,[DATE PAIEMENT]) < " + mnth.EditValue +
            //            " and DATEPART(mm,[DATE PAIEMENT])+nbrMoisPay > " + mnth.EditValue + "))" +
            //            " or (DATEPART(yy,[DATE PAIEMENT]) = " + nmUpDw.Value + "-1 AND DATEPART(mm,[DATE PAIEMENT])+nbrMoisPay > 11+DATEPART(mm,[DATE PAIEMENT]))"
            _GA.da = new SqlDataAdapter(str, _GA.cnx);
            try
            {
                ds.Tables.Remove("V_Recette");
            }
            catch
            { }

            try
            {
                _GA.da.Fill(ds, "V_Recette");
                //cotisation = int.Parse(ds.Tables["V_Recette"].Rows[0]["cotisation"].ToString());
                ar_nbrMoisPay = new ArrayList();
                foreach (DataRow r in ds.Tables["V_Recette"].Rows)
                    ar_nbrMoisPay.Add(r["nbrMoisPay"]);
                //nbrMois = int.Parse(ds.Tables["V_Recette"].Rows[0]["nbrMoisPay"].ToString());

                ds.Tables["V_Recette"].Columns.Remove("dcpln");
                ds.Tables["V_Recette"].Columns.Remove("_Cotis");
                ds.Tables["V_Recette"].Columns.Remove("nbrMoisPay");
                nbrAdh = ds.Tables["V_Recette"].Rows.Count;
                //lblTotAdh.Text = nbrAdh.ToString();
                ds.Tables["V_Recette"].Columns.RemoveAt(ds.Tables["V_Recette"].Columns.Count - 1);
                gridControl1.DataSource = ds.Tables["V_Recette"];
                //deja_fait = true;
                gridView1.BestFitColumns(true);

                //lblMtTot.Text = mt_total.ToString();
                //lblMtAdhs.Text = mt_adhs.ToString();lblMtCotis.Text = mt_cotis.ToString();

                //lblIns.Text = nbrIns.ToString();
                //lblReIns.Text = nbrReIns.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show(e.Message);
            }
        }

        //private void btnOk3_Click(object sender, EventArgs e)
        //{
        //    _GA.da = new SqlDataAdapter("sp_stat_par_an", _GA.cnx);
        //    _GA.da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    _GA.da.SelectCommand.Parameters.Add("@an", SqlDbType.Int).Value = nmUpDwnYear3.Value;
        //    _GA.da.SelectCommand.Parameters.Add("@id_dcpln", SqlDbType.VarChar, 30).Value = cmBxDcpln3.SelectedValue;
        //    DataTable dt = new DataTable();
        //    _GA.da.Fill(dt);
        //    int ins, reIns, cotisTot, fraisTot;
        //    ins = reIns = fraisTot = cotisTot = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        cotisTot += int.Parse(dr[2].ToString());
        //        fraisTot += int.Parse(dr[3].ToString());
        //        if (dr[5].ToString() == "Inscription")
        //            ins++;
        //        else reIns++;
        //    }
        //    lblMtCotis3.Text = cotisTot.ToString();
        //    lblMtAdhs3.Text = fraisTot.ToString();
        //    lblMtTot3.Text = (cotisTot + fraisTot).ToString();

        //    lblIns3.Text = ins.ToString();
        //    lblReIns3.Text = reIns.ToString();
        //    lblTotAdh3.Text = (ins + reIns).ToString();
        //    //MessageBox.Show(dt.Rows.Count + "");
        //}

        private void frmRecette_SizeChanged(object sender, EventArgs e)
        {
            _GA.KeepDistance(splitContainer1, 70);
        }

        private void btnOk2_Click(object sender, EventArgs e)
        {

        }

        private void btnOk3_Click(object sender, EventArgs e)
        {

        }
    }
}
