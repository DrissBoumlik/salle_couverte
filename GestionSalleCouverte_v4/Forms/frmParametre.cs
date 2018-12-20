using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using GestionSalleCouverte.Classes;
using System.Collections;
using DevExpress.XtraCharts;

namespace GestionSalleCouverte.Forms
{
    public partial class frmParametre : Form
    {
        public frmParametre()
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

        private DataSet ds;

        #region tbPgScn

        private void frmParametre_Load(object sender, EventArgs e)
        {
            try
            {
                #region Charger disciplines tabPage 2 & 3

                ds = new DataSet();
                _GA.da = new SqlDataAdapter("select * from discipline", _GA.cnx);
                _GA.da.Fill(ds, "discipline");

                ds.Tables["discipline"].Columns[0].ColumnName = "Discipline";
                ds.Tables["discipline"].Columns[1].ColumnName += " /Mois";
                ds.Tables["discipline"].Columns[2].ColumnName = "Frais d'adhésion /An";

                cmBxDcpln3.DataSource = dgvDcpln2.DataSource = cmBxDcpln.DataSource = ds.Tables["discipline"];

                cmBxDcpln.ValueMember = ds.Tables["discipline"].Columns[0].ToString();
                cmBxDcpln3.ValueMember = ds.Tables["discipline"].Columns[0].ToString();

                #endregion
            }
            catch{}
        }

        private void cmBxDcpln_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBxDcpln.ContainsFocus)
            {
                _GA.da = new SqlDataAdapter("select * from seance where Id_Dcpln = '" + cmBxDcpln.SelectedValue + "'", _GA.cnx);
                if (ds.Tables.Contains("Seance"))
                    ds.Tables.Remove("Seance");
                _GA.da.Fill(ds, "Seance");
                dgvScn.DataSource = ds.Tables["Seance"];
                dgvScn.Columns[0].HeaderText = "Séance";
                dgvScn.Columns[2].HeaderText = "Durée";
                dgvScn.Columns[1].Visible = false;
            }
        }

        private void btnAddScn_Click(object sender, EventArgs e)
        {
            if (!_GA.CheckField(grpBxScn))
            {
                MessageBox.Show("Champ(s) manquant(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                var cmd = new SqlCommand("insert Seance values('" + timeEdtStrt.Text + "','" + cmBxDcpln.SelectedValue + "','" + timeEdtDuree.Text + "')", _GA.cnx);
                var row = ds.Tables["Seance"].NewRow();
                row[0] = timeEdtStrt.Text;
                row[1] = cmBxDcpln.SelectedValue;
                row[2] = timeEdtDuree.Text;
                ds.Tables["Seance"].Rows.Add(row);
                _GA.da.InsertCommand = cmd;
                _GA.da.Update(ds.Tables["Seance"]);
            }
            catch (Exception)
            {
            }
        }

        private void btnDelScn_Click(object sender, EventArgs e)
        {
            //verifier le login Admin
            try
            {
                var cmd = new SqlCommand("Is_Admin", _GA.cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom", _GA.user);
                cmd.Parameters.AddWithValue("@mot_pass", _GA.mdpass);
                cmd.Parameters.Add("@ok", SqlDbType.Int);
                var p = cmd.Parameters[cmd.Parameters.Count - 1];
                p.Direction = ParameterDirection.ReturnValue;
                var rd = cmd.ExecuteReader();
                rd.Close();
                if (!_GA.allowed)
                    if (1 != (int)p.Value)
                    {
                        MessageBox.Show("Vous n'êtes pas autorisé a faire cette opération\nVous devez se connecté en tant qu'Admin", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.Hide();
                        new frmLogIn().Show();
                        return;
                    }
            }
            catch (Exception ex) { ; }
        allowd:
            if (DialogResult.Yes == MessageBox.Show("êtes vous sûr", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                try
                {
                    if (dgvScn.CurrentRow != null)
                    {
                        var cmd =
                            new SqlCommand(
                                "delete from seance where hr_debut = '" + dgvScn.CurrentRow.Cells[0].Value +
                                "' and id_dcpln = '" + cmBxDcpln.SelectedValue + "'", _GA.cnx);
                        dgvScn.Rows.Remove(dgvScn.CurrentRow);
                        _GA.da.DeleteCommand = cmd;
                        _GA.da.Update(ds.Tables["Seance"]);
                    }
                    else MessageBox.Show("pas de séléction", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch { }
        }

        private void btnUpdtScn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvScn.CurrentRow != null)
                {
                    var cmd = new SqlCommand("update seance set hr_debut = '" + timeEdtStrt.Text + "',duree_sn = '" + timeEdtDuree.Text + "'" +
                                                 "where hr_debut = '" + dgvScn.CurrentRow.Cells[0].Value + "' and id_dcpln = '" + cmBxDcpln.SelectedValue + "'", _GA.cnx);

                    var tmp = ds.Tables["Seance"];
                    tmp.Rows[dgvScn.CurrentRow.Index][0] = timeEdtStrt.Text;
                    tmp.Rows[dgvScn.CurrentRow.Index][2] = timeEdtDuree.Text;

                    _GA.da.UpdateCommand = cmd;
                    _GA.da.Update(ds.Tables["Seance"]);
                }
                else MessageBox.Show("pas de séléction", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region tbPgDcpln

        private bool CheckField()
        {
            if (nmUpDwnCotis2.Text != "" && txtBxDscpln2.Text != "" && nmUpDwnFrsAdh2.Text != "")
                return true;
            else return false;
        }

        private void btnAddDscpln2_Click(object sender, EventArgs e)
        {
            if (!_GA.CheckField(grpBxDcpln))
            {
                MessageBox.Show("Champ(s) manquant(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                if (CheckField())
                {
                    var cmd = new SqlCommand("insert Discipline values('" + txtBxDscpln2.Text + "','" + nmUpDwnCotis2.Value + "','" + nmUpDwnFrsAdh2.Value + "')", _GA.cnx);
                    var row = ds.Tables["discipline"].NewRow();
                    row[0] = txtBxDscpln2.Text;
                    row[1] = nmUpDwnCotis2.Value;
                    row[2] = nmUpDwnFrsAdh2.Value;
                    ds.Tables["discipline"].Rows.Add(row);
                    _GA.da.InsertCommand = cmd;
                    _GA.da.Update(ds.Tables["discipline"]);
                }
                else MessageBox.Show("Champ(s) vide", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
            }
        }
        private void btnUpdtDscpln2_Click(object sender, EventArgs e)
        {
            //if (CheckField())
            try
            {
                var cmd =
                    new SqlCommand(
                        "update Discipline set cotisation = '" + nmUpDwnCotis2.Value + "',Frais_adh = '" +
                        nmUpDwnFrsAdh2.Value + "'" +
                        "where id_dcpln = '" + dgvDcpln2.CurrentRow.Cells[0].Value + "'", _GA.cnx);

                var tmp = ds.Tables["discipline"];
                tmp.Rows[dgvDcpln2.CurrentRow.Index][1] = nmUpDwnCotis2.Text;
                tmp.Rows[dgvDcpln2.CurrentRow.Index][2] = nmUpDwnFrsAdh2.Text;

                _GA.da.UpdateCommand = cmd;
                _GA.da.Update(ds.Tables["discipline"]);
            }
            catch { }
            //else MessageBox.Show("Champ(s) vide", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDelDscpln2_Click(object sender, EventArgs e)
        {
            //if (CheckField())
            try
            {
                if (DialogResult.Yes == MessageBox.Show("êtes vous sûr", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    var cmd =
                        new SqlCommand(
                            "delete from discipline where id_dcpln = '" + dgvDcpln2.CurrentRow.Cells[0].Value + "'", _GA.cnx);

                    dgvDcpln2.Rows.Remove(dgvDcpln2.CurrentRow);
                    _GA.da.DeleteCommand = cmd;
                    _GA.da.Update(ds.Tables["discipline"]);
                }
            }
            catch (Exception)
            {
            }
            //else MessageBox.Show(nmUpDwnFrsAdh2.Text + "Champ(s) vide", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region Jour Discipline

        private void cmBxDcpln3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBxDcpln3.ContainsFocus)
            {
                try
                {
                    dgvWeek3.Rows.Clear();
                    //SortedList sl_week = new SortedList();
                    var days = new string[] { "LUNDI", "MARDI", "MERCREDI", "JEUDI", "VENDREDI", "SAMEDI", "DIMANCHE" };

                    //for (int i = 0; i < 7; i++)
                    //    sl_week.Add(i, days[i]);
                    if (ds.Tables.Contains("jourDcpln"))
                        ds.Tables.Remove("jourDcpln");
                    _GA.da = new SqlDataAdapter("select Id_dcpln,Id_jour from JourDcpln where Id_Dcpln = '" + cmBxDcpln3.SelectedValue + "'", _GA.cnx);
                    _GA.da.Fill(ds, "jourDcpln");

                    dgvDays3.DataSource = ds.Tables["jourDcpln"];
                    dgvDays3.Columns[0].Visible = false; dgvDays3.Columns["Id_jour"].HeaderText = "Jours";

                    //ListToTable( ds.Tables["jourDcpln"]);

                    bool exist;
                    foreach (string s in days)
                    {
                        exist = false;
                        foreach (DataGridViewRow rw in dgvDays3.Rows)
                        {
                            if (rw.Cells[1].Value.ToString() == s)
                            {
                                exist = true;
                                break;
                            }
                        }
                        if (!exist)
                            dgvWeek3.Rows.Add(s);
                    }
                }
                catch { }
            }
        }
        private void btnAddDay3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvWeek3.CurrentRow != null)
                {
                    var cmd =
                        new SqlCommand(
                            "insert JourDcpln values('" + cmBxDcpln3.SelectedValue + "','" +
                            dgvWeek3.CurrentRow.Cells[0].Value + "')", _GA.cnx);
                    var row = ds.Tables["jourDcpln"].NewRow();
                    row[0] = cmBxDcpln3.SelectedValue;
                    row[1] = dgvWeek3.CurrentRow.Cells[0].Value;
                    ds.Tables["jourDcpln"].Rows.Add(row);
                    //ListToTable( ds.Tables["jourDcpln"]);

                    _GA.da.InsertCommand = cmd;
                    _GA.da.Update(ds.Tables["jourDcpln"]);
                    dgvWeek3.Rows.Remove(dgvWeek3.CurrentRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //void ListToTable( DataTable dt)
        //{
        //    try
        //    {
        //        SortedList sl = new SortedList();
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            sl.Add(_GA.GetNumDay(row[1].ToString()), row[1]);
        //        }
        //        dt.Rows.Clear();
        //        foreach (object o in sl.Values)
        //        {
        //            dt.Rows.Add(cmBxDcpln3.SelectedValue, o);
        //        }
        //        dgvDays3.DataSource = dt;
        //        dgvDays3.Columns[0].Visible = false;
        //    }
        //    catch { }
        //}

        private void btnDelDay3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDays3.CurrentRow != null)
                {
                    var cmd =
                        new SqlCommand(
                            "Delete from JourDcpln where Id_Dcpln = '" + cmBxDcpln3.SelectedValue + "' and id_jour = '" +
                            dgvDays3.CurrentRow.Cells[1].Value + "'", _GA.cnx);
                    dgvWeek3.Rows.Add(dgvDays3.CurrentRow.Cells[1].Value);
                    dgvDays3.Rows.Remove(dgvDays3.CurrentRow);
                    _GA.da.DeleteCommand = cmd;
                    _GA.da.Update(ds.Tables["jourDcpln"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Menu

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

        private void adhérantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmAdherent().Show();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GA.Exit(this);
        }

        private void recetteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmRecette().Show();
        }

        private void traceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmTraceAdherent().Show();
        }

        private void pointageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmPointage().Show();
        }
        #endregion
    }

    static class SortDataTable
    {
        public static void Sort_dt_Days(this DataTable dt, params string[] days)
        {
            //DataRow dr;
            //foreach (DataRow tmp in dt.Rows)
            //{

            //}
        }
    }
}