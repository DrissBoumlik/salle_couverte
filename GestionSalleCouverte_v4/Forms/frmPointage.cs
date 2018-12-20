using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Threading;
using DevExpress.XtraGrid.Views.BandedGrid;
using GestionSalleCouverte.Classes;

namespace GestionSalleCouverte.Forms
{
    public partial class frmPointage : Form
    {
        public frmPointage()
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
            bandedGridView1.RowCellStyle += (sender, e) =>
            {
                try
                {
                    BandedGridView bandedGridView = sender as BandedGridView;
                    //if (!deja_fait)
                    switch (e.Column.FieldName)
                    {
                        case "DATE PAIEMENT":
                            DateTime date_pay = DateTime.Parse(bandedGridView.GetRowCellDisplayText(e.RowHandle, bandedGridView.Columns["DATE PAIEMENT"]));
                            if ((DateTime.Now - date_pay).Days > 30)
                            {
                                e.Appearance.BackColor = Color.Red;
                                e.Appearance.ForeColor = Color.White;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                { }

            };
        }

        private DataSet ds;
        private void frmPointage_Load(object sender, EventArgs e)
        {
            mnthEdtMonth.Month = DateTime.Now.Month;
            nmUpDwnYear.Value = DateTime.Now.Year;
            ds = new DataSet();
            _GA.da = new SqlDataAdapter("select * from discipline", _GA.cnx);
            _GA.da.Fill(ds, "discipline");
            cmBxDcpln.DataSource = ds.Tables["discipline"];
            cmBxDcpln.ValueMember = cmBxDcpln.DisplayMember = ds.Tables["discipline"].Columns[0].ToString();
        }

        private void cmBxDcpln_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBxDcpln.ContainsFocus)
            {
                //switch (cmBxDcpln.SelectedText)
                //{
                //    case "MUSCULATION":
                //        nmUpDwnYear.Value = DateTime.Now.Year;
                //        year = DateTime.Now.Year.ToString();
                //        mnthEdtMonth.Month = DateTime.Now.Month;
                //        month = mnthEdtMonth.Month.ToString();
                //        PointageAdherent("Musculation", "Pointage_Muscl", gridControl1, gridView1, year, month);
                //        //gridView1_SelectionChanged(sender, e as SelectionChangedEventArgs);
                //    case "FITNESS":
                //        year = txtBxYear.Text.Split('/')[1];
                //        month = txtBxYearMixt.Text.Split('/')[0];
                //        PointageAdherent("Mixte", "Pointage_Mixte", gridControl2, gridView2, year, month);
                //        gridView2_SelectionChanged(sender, e as SelectionChangedEventArgs);

                //    case "MIXTE":
                //        txtBxYearFtnss.Text = DateTime.Now.Month + "/" + DateTime.Now.Year;
                //        year = txtBxYearFtnss.Text.Split('/')[1];
                //        month = txtBxYearFtnss.Text.Split('/')[0];
                //        PointageFitness(int.Parse(year), int.Parse(month));
                //        bandedGridView1_SelectionChanged(sender, e as SelectionChangedEventArgs);
                //}
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            LoadPointage(cmBxDcpln.Text, (int)nmUpDwnYear.Value, (int)mnthEdtMonth.Month);
        }

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

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GA.Exit(this);
        }

        private void traceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmTraceAdherent().Show();
        }

        #endregion
        #region Methodes

        private void LoadPointage(string discipline, int year, int month)
        {
            try
            {
                Thread thread = new Thread(() =>
                    {
                        new WaitForm1().ShowDialog();
                    });
                thread.IsBackground = true;
                thread.Start();
                thread.Join();

                bandedGridView1.Columns.Clear();
                for (int t = 4; t < bandedGridView1.Bands.Count; )
                    bandedGridView1.Bands.RemoveAt(t);
                #region create table
                DataTable dt = new DataTable();
                dt.Columns.Add("Nbr");
                dt.Columns.Add("Nom");
                dt.Columns.Add("Prenom");
                dt.Columns.Add("DATE PAIEMENT");
                //dt.Columns.Add("Etat");
                int nbrGridBands = 4;
                #region load discipline_days
                _GA.da = new SqlDataAdapter("select id_jour from JourDcpln where id_dcpln='" + discipline + "'", _GA.cnx);
                var tmpDays = new DataTable();
                _GA.da.Fill(tmpDays);
                #endregion

                #region Load seances
                //charger les heures debuts des Seances
                _GA.da = new SqlDataAdapter("select hr_debut from Seance where id_dcpln='" + discipline + "'", _GA.cnx);
                var Seances = new DataTable();
                _GA.da.Fill(Seances);

                var nbrSeances = Seances.Rows.Count;
                SortedList sl_seances = new SortedList();
                var tmp_index = 0;
                foreach (DataRow r in Seances.Rows)
                    sl_seances[r[0]] = tmp_index++;
                #endregion

                #region Load days
                int days = DateTime.DaysInMonth(year, month);
                for (int i = 1; i <= days; i++)
                {
                    DateTime date = new DateTime(year, month, i);
                    string dayOfWeek = "";
                    switch (date.DayOfWeek)
                    {
                        case DayOfWeek.Monday: dayOfWeek = "LUNDI"; break;
                        case DayOfWeek.Tuesday: dayOfWeek = "MARDI"; break;
                        case DayOfWeek.Wednesday: dayOfWeek = "MERCREDI"; break;
                        case DayOfWeek.Thursday: dayOfWeek = "JEUDI"; break;
                        case DayOfWeek.Friday: dayOfWeek = "VENDREDI"; break;
                        case DayOfWeek.Saturday: dayOfWeek = "SAMEDI"; break;
                        case DayOfWeek.Sunday: dayOfWeek = "DIMANCHE"; break;
                    }

                    //foreach (DataRow r in tmpDays.Rows)
                    //    if (r[0].ToString() == dayOfWeek)
                    //        dt.Columns.Add(dayOfWeek.Substring(0, 3) + "\n" + date.Day);
                    bool exist = false;
                    foreach (DataRow r in tmpDays.Rows)
                    {
                        if (r[0].ToString() == dayOfWeek)
                            exist = true;
                    }
                    if (exist)
                    {
                        nbrGridBands++;
                        GridBand gb1 = new GridBand();
                        gb1.Name = "gb" + i;
                        gb1.Caption = dayOfWeek.Substring(0, 3) + " " + date.Day;
                        bandedGridView1.Bands.Add(gb1);
                        foreach (DataRow row in Seances.Rows)
                            dt.Columns.Add(dayOfWeek + " " + date.Day + "\n" + row[0]);
                    }
                    else
                        foreach (DataRow row in Seances.Rows)
                            dt.Columns.Add("--" + date.Day + "\n" + row[0]);
                }
                #endregion

                #endregion

                #region Fill DataTable
                _GA.da = new SqlDataAdapter("sp_Pointage", _GA.cnx);
                _GA.da.SelectCommand.CommandType = CommandType.StoredProcedure;
                _GA.da.SelectCommand.Parameters.Add(new SqlParameter("@Id_Dcpln", discipline));
                _GA.da.SelectCommand.Parameters.Add(new SqlParameter("@year", year));
                _GA.da.SelectCommand.Parameters.Add(new SqlParameter("@month", month));
                DataTable tmp = new DataTable();
                _GA.da.Fill(tmp);
                ArrayList ar_Ids_adh = new ArrayList();
                foreach (DataRow row in tmp.Rows)
                {
                    if (!ar_Ids_adh.Contains(row[0]))
                    {
                        #region save member's datas
                        //---------------------------------save member's datas
                        ar_Ids_adh.Add(row[0]);
                        object id_adh = row[0];
                        ArrayList ar_info_Adh = new ArrayList();
                        int i;
                        for (i = 1; i < 4; i++)
                        {
                            if (i == 3)
                                ar_info_Adh.Add(((DateTime)row[i]).ToShortDateString());
                            else
                                ar_info_Adh.Add(row[i]);
                        }
                        #endregion

                        #region Reste of Data
                        DataRow[] tmpRows = tmp.Select("nbr = " + row[0]);
                        SortedList sl_days = new SortedList();

                        foreach (DataRow dr in tmpRows)
                        {
                            int offset = (((DateTime)dr[5]).Day - 1) * nbrSeances + 4 + (int)sl_seances[dr[4]];
                            sl_days[offset] = "x";
                        }
                        DataRow rw = dt.NewRow();
                        int z;
                        rw[0] = id_adh;
                        for (z = 0; z < ar_info_Adh.Count; z++)
                            rw[z + 1] = ar_info_Adh[z];
                        for (z = 4; z < dt.Columns.Count; z++)
                        {
                            rw[z] = sl_days[z];
                            //if (z == 48)
                            //    id_adh = 0;
                        }
                        dt.Rows.Add(rw);
                        #endregion
                    }
                }
                #endregion

                #region Delete_--_Columns
                for (var i = 0; i < dt.Columns.Count; )
                    if (dt.Columns[i].ColumnName.Contains("--"))
                        dt.Columns.RemoveAt(i);
                    else i++;
                #endregion

                gridControl3.DataSource = dt;
                //gridControl3.ForeColor = Color.Red;
                #region Grid_takes_Columns
                gridBand2.Columns.Add(gridBand1.Columns[1]);
                gridBand3.Columns.Add(gridBand1.Columns[1]);
                gridBand4.Columns.Add(gridBand1.Columns[1]);
                //gridBand5.Columns.Add(gridBand1.Columns[1]);
                for (int i = 4; i < bandedGridView1.Bands.Count; i++)
                {
                    for (int k = 0; k < Seances.Rows.Count; k++)
                    {
                        bandedGridView1.Bands[i].Columns.Add(gridBand1.Columns[1]);
                        int length = bandedGridView1.Bands[i].Columns.Count - 1;
                        BandedGridColumn cln = bandedGridView1.Bands[i].Columns[length];
                        cln.Caption = Seances.Rows[k][0].ToString().Substring(0, 5);
                    }
                }
                #endregion

                bandedGridView1.BestFitColumns(true);

            }
            catch (Exception)
            {
                
            }
        }
        #endregion


        private void affichageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //new frmPointage().Show();
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

        private void frmPointage_SizeChanged(object sender, EventArgs e)
        {
            _GA.KeepDistance(splitContainer1, 70);
        }

    }
}
