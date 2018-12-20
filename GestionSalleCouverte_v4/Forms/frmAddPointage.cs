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
    public partial class addPointage : Form
    {
        public addPointage()
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

        private void addPointage_Load(object sender, EventArgs e)
        {
            try
            {
                _GA.da = new SqlDataAdapter("select nom+' '+prenom,* from Adherent", _GA.cnx);
                DataTable dtAdh = new DataTable();
                _GA.da.Fill((dtAdh));
                cmBxAdh.DataSource = dtAdh;
                cmBxAdh.ValueMember = dtAdh.Columns[1].ToString();
                cmBxAdh.DisplayMember = dtAdh.Columns[0].ToString();

                _GA.da = new SqlDataAdapter("select * from Discipline", _GA.cnx);
                DataTable dtDcpln = new DataTable();
                _GA.da.Fill((dtDcpln));
                cmBxDcpln.DataSource = dtDcpln;
                cmBxDcpln.ValueMember = cmBxDcpln.DisplayMember = dtDcpln.Columns[0].ToString();

            }
            catch (Exception)
            {
            }
        }

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

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GA.Exit(this);
        }

        private void cmBxDcpln_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBxDcpln.ContainsFocus)
            {
                try
                {
                    _GA.da = new SqlDataAdapter("select * from seance where id_dcpln = '" + cmBxDcpln.SelectedValue + "'", _GA.cnx);
                    DataTable dtSnc = new DataTable();
                    _GA.da.Fill((dtSnc));
                    cmBxSnc.DataSource = dtSnc;
                    cmBxSnc.ValueMember = cmBxSnc.DisplayMember = dtSnc.Columns[0].ToString();

                    cmBxSncNew.Items.Clear();
                    foreach (DataRow dr in dtSnc.Rows)
                        cmBxSncNew.Items.Add(dr[0]);

                }
                catch (Exception)
                {
                }
            }
        }
        private void btnAddPnt_Click(object sender, EventArgs e)
        {
            if (!_GA.CheckField(grpBxAdd))
            {
                MessageBox.Show("Champ(s) manquant(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                //Vérifier l'appartenance du jour à la discipline
                var da = new SqlDataAdapter("select id_Jour from JourDcpln where Id_Dcpln = '" + cmBxDcpln.SelectedValue + "'", _GA.cnx);
                var dt = new DataTable();
                da.Fill(dt);
                var day_exist = false;
                
                foreach (DataRow row in dt.Rows)
                {
                    if (row[0].ToString() == _GA.EngDayToFr(dtPickDtPntg.Value.DayOfWeek))
                    {
                        day_exist = true;
                        break;
                    }
                }
                if (!day_exist)
                {
                    MessageBox.Show(cmBxDcpln.SelectedValue + " est fermée ce jour là", "Attention");
                    return;
                }

               // var cmd = new SqlCommand("insert pointage values(" + cmBxAdh.SelectedValue + ",'" + cmBxSnc.SelectedValue + "','" + cmBxDcpln.SelectedValue + "','" + dtPickDtPntg.Value.Month + "/" + dtPickDtPntg.Value.Day + "/" + dtPickDtPntg.Value.Year + "')", _GA.cnx);
                var cmd = new SqlCommand("insert pointage values(" + cmBxAdh.SelectedValue + ",'" + cmBxSnc.SelectedValue + "','" + cmBxDcpln.SelectedValue + "',@dt)", _GA.cnx);
                cmd.Parameters.AddWithValue("@dt", dtPickDtPntg.Value.Date);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Términer");
            }
            catch (Exception)
            {
                MessageBox.Show("Déjà Ajouté", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void affichageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmPointage().Show();
        }

        private void btnUpdPnt_Click(object sender, EventArgs e)
        {
            if (!_GA.CheckField(grpBxUpd))
            {
                MessageBox.Show("Champ(s) manquant(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                if (DialogResult.Yes ==
                    MessageBox.Show("Etes-vous sûr ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //string str = "update pointage set hr_debut = '" + cmBxSncNew.Text + "',date_pntg = '" +
                    //             dtPickDtPntgNew.Value.Month + "/" + dtPickDtPntgNew.Value.Day + "/" +
                    //             dtPickDtPntgNew.Value.Year + "'" +
                    //             " where Id_Adh = " + cmBxAdh.SelectedValue + " and hr_debut = '" +
                    //             cmBxSnc.SelectedValue + "' and Id_Dcpln = '" + cmBxDcpln.SelectedValue + "' " +
                    //             "and date_pntg = '" + dtPickDtPntg.Value.Month + "/" + dtPickDtPntg.Value.Day + "/" +
                    //             dtPickDtPntg.Value.Year + "'";
                    string str = "update pointage set hr_debut = '" + cmBxSncNew.Text + "',date_pntg = @dtnew" +
                                 " where Id_Adh = " + cmBxAdh.SelectedValue + " and hr_debut = '" +
                                 cmBxSnc.SelectedValue + "' and Id_Dcpln = '" + cmBxDcpln.SelectedValue + "' " +
                                 "and date_pntg = @dt";
                    var cmd = new SqlCommand(str, _GA.cnx);
                    cmd.Parameters.AddWithValue("@dt", dtPickDtPntg.Value.Date);
                    cmd.Parameters.AddWithValue("@dtnew", dtPickDtPntgNew.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Términer");
                }
            }
            catch { }
        }

        private void btnDelPnt_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Etes-vous sûr ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    //string str = "delete from pointage where Id_Adh = " + cmBxAdh.SelectedValue + " and hr_debut = '" + cmBxSnc.SelectedValue + "' and Id_Dcpln = '" + cmBxDcpln.SelectedValue + "' " +
                    //                "and date_pntg = '" + dtPickDtPntg.Value.Month + "/" + dtPickDtPntg.Value.Day + "/" + dtPickDtPntg.Value.Year + "'";
                    string str = "delete from pointage where Id_Adh = " + cmBxAdh.SelectedValue + " and hr_debut = '" + cmBxSnc.SelectedValue + "' and Id_Dcpln = '" + cmBxDcpln.SelectedValue + "' " +
                                    "and date_pntg = @dt";
                   
                    var cmd = new SqlCommand(str, _GA.cnx);
                    cmd.Parameters.AddWithValue("@dt", dtPickDtPntg.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Términer");
                }
            }
            catch (Exception)
            {
            }
        }

        private void verouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            _GA.logedIn = false;
            new frmLogIn().Show();
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            _GA.Clear(Controls);
        }

        private void cmBxAdh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { cmBxDcpln.Text = _GA.GetDcpln(cmBxAdh.SelectedValue.ToString()).ToString(); }
            catch { }
        }


    }
}
