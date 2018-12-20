using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting.Native;
using GestionSalleCouverte.Classes;
using GestionSalleCouverte.Forms;

namespace GestionSalleCouverte.Forms
{
    public partial class frmAdherent : Form
    {
        public frmAdherent()
        {
            InitializeComponent();
            if (_GA.cnx == null)
            {
                _GA.cnx = new SqlConnection(_GA.strCnx);
                _GA.cnx.Open();
            }
            else if (_GA.cnx.State == ConnectionState.Closed)
                _GA.cnx.Open();
            gridView1.OptionsSelection.MultiSelect = true;
            _GA.currentForm = this;
        }


        private void frmAdherent_Load(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ChargerAdherentsNames(cmBxNomPrn, cmBxAdh2, cmBxAdh3);
                //ChargerDiscipline(cmBxDcpln2, cmBxDcpln3, cmBxDcpln4);
                ChargerDiscipline(cmBxDcpln2, cmBxDcpln3);

            }
            catch (Exception)
            {
            }
        }

        private string path = "";
        private string src = "";

        #region tbPgAddAdh_1

        private void btnAddAdh_Click(object sender, EventArgs e)
        {
            if (!_GA.CheckField(grpBxAdh))
            {
                MessageBox.Show("Champ(s) manquant(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            try
            {
                var cmd = new SqlCommand("CheckAdherent", _GA.cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cin", txtBxCin.Text);
                cmd.Parameters.Add("@ok", SqlDbType.Int);
                var p = cmd.Parameters[cmd.Parameters.Count - 1];
                p.Direction = ParameterDirection.ReturnValue;
                var dr = cmd.ExecuteReader();
                dr.Close();
                if (-1 == (int)p.Value)
                {
                    MessageBox.Show("le CIN entré éxiste déjà", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    if ((ex as SqlException).Number == 50000)
                    {
                        MessageBox.Show("le CIN entré éxiste déjà", "Attention", MessageBoxButtons.OK,
                           MessageBoxIcon.Asterisk);
                        return;
                    }
            }

            FileStream fs;
            try
            {
                fs = new FileStream(path + src, FileMode.Open, FileAccess.Read);
            }
            catch
            {
                MessageBox.Show("Vous devez choisir une image", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            try
            {
                BinaryReader br = new BinaryReader(fs);
                byte[] img = br.ReadBytes((int)fs.Length);
                fs.Close();
                string sexe = (rdBtnMale.Checked) ? "M" : "F";
                var cmd = new SqlCommand("Adherent_INSERT", _GA.cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nom", SqlDbType.VarChar, 30).Value = txtBxNom.Text;
                cmd.Parameters.Add("@prenom", SqlDbType.VarChar, 30).Value = txtBxPrenom.Text;
                cmd.Parameters.Add("@cin", SqlDbType.VarChar, 10).Value = txtBxCin.Text;
                cmd.Parameters.Add("@naiss", SqlDbType.Date).Value = dtPickDtNaiss.Text;
                cmd.Parameters.Add("@sexe", SqlDbType.VarChar, 1).Value = sexe;
                cmd.Parameters.Add("@telephone", SqlDbType.VarChar, 20).Value = txtBxTel.Text;
                cmd.Parameters.Add("@adresse", SqlDbType.VarChar, 100).Value = txtBxAdrss.Text;
                cmd.Parameters.Add("@cp", SqlDbType.VarChar, 10).Value = txtBxCp.Text;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtBxEmail.Text;
                cmd.Parameters.Add("@ville", SqlDbType.VarChar, 30).Value = txtBxVille.Text;
                cmd.Parameters.Add(new SqlParameter("@img", img));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Opération Términée", "Opération", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChargerAdherentsNames(cmBxNomPrn, cmBxAdh2, cmBxAdh3);
            }
            catch { }
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Choisissez votre photo ";
            if (file.ShowDialog() == DialogResult.OK)
            {
                pcBxPhoto.ImageLocation = file.FileName;
                src = file.FileName.Substring(file.FileName.LastIndexOf('\\') + 1);
                path = file.FileName.TrimEnd(src.ToArray());
            }
        }


        #endregion

        #region tbPgAdhs_2

        private DataSet ds;
        private void btnAddAdhs2_Click(object sender, EventArgs e)
        {
            if (!_GA.CheckField(grpBxAdhs2))
            {
                MessageBox.Show("Champ(s) manquant(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                var cmd = new SqlCommand("Adhesion_INSERT", _GA.cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id_Adh", SqlDbType.Int).Value = cmBxAdh2.SelectedValue;
                cmd.Parameters.Add("@Id_Dcpln", SqlDbType.VarChar, 30).Value = cmBxDcpln2.Text;
                cmd.Parameters.Add("@date_Adh", SqlDbType.Date).Value = dtPickAdhs2.Value.ToShortDateString();
                cmd.Parameters.Add("@critere", SqlDbType.VarChar, 30).Value = cmBxCrtr2.Text;
                cmd.Parameters.Add("@observation", SqlDbType.VarChar, 100).Value = txtBxObsrv2.Text;
                cmd.Parameters.Add("@bnfci_reduc", SqlDbType.Bit).Value = rdBtnRducYes2.Checked ? true : false;
                cmd.Parameters.Add("@Frais_adh", SqlDbType.Float).Value = txtBxFrAdh2.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Opération Términée", "Opération", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region tbPgPay_3

        public static DataSet1 tmp = new DataSet1();
        private void btnAddPay3_Click(object sender, EventArgs e)
        {
            if (!_GA.CheckField(grpBxPay3))
            {
                MessageBox.Show("Champ(s) manquant(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                var cmd = new SqlCommand("Paiment_INSERT", _GA.cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id_Adh", SqlDbType.Int).Value = cmBxAdh3.SelectedValue;
                cmd.Parameters.Add("@Id_Dcpln", SqlDbType.VarChar, 30).Value = cmBxDcpln3.Text;
                cmd.Parameters.Add("@date_pay", SqlDbType.Date).Value = dtPickPay3.Value.ToShortDateString();

                //try
                //{
                //    object num_recu = -1;
                //    var tmpCmd = new SqlCommand("Get_NumRecu", _GA.cnx);
                //    tmpCmd.CommandType = CommandType.StoredProcedure;
                //    tmpCmd.Parameters.Add(new SqlParameter("@num_recu", num_recu));
                //    tmpCmd.Parameters[0].Direction = ParameterDirection.Output;
                //    tmpCmd.ExecuteScalar();
                //    cmd.Parameters.Add("@num_recu", SqlDbType.Int).Value = tmpCmd.Parameters[0].Value;
                //}
                //catch
                //{ }
                cmd.Parameters.Add("@cotisation", SqlDbType.Float).Value = int.Parse(txtBxCotis3.Text) * nmUpDwnNbrMois.Value;//txtBxCotis3.Text;
                //var cotisation =
                //    new SqlCommand("select cotisation from Discipline where Id_Dcpln = '" + cmBxDcpln3.Text + "'", _GA.cnx)
                //        .ExecuteScalar();
                cmd.Parameters.Add("@nbrMoisPay", SqlDbType.Int).Value = nmUpDwnNbrMois.Value; //(int)(int.Parse(txtBxCotis3.Text) / ((double)cotisation));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Opération Términée");//" - Un apérçu du reçu va apparaître", "Opération", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tmp.Tables[0].Rows.Clear();
                DataRow rw = tmp.Tables[0].NewRow();
                rw[0] = cmBxAdh3.Text.ToString().Split(' ')[0];
                rw[1] = cmBxAdh3.Text.ToString().Split(' ')[1];
                rw[2] = ds.Tables["adherent"].Select("Id_Adh = " + cmBxAdh3.SelectedValue)[0][4];
                rw[3] = dtPickPay3.Value.ToShortDateString();
                rw[4] = new SqlCommand("select top 1 num_recu from paiment where year(date_pay) = " + dtPickPay3.Value.Year + " order by num_recu desc", _GA.cnx).ExecuteScalar();
                rw[5] = int.Parse(txtBxCotis3.Text) * nmUpDwnNbrMois.Value;//txtBxCotis3.Text;
                rw[6] = ds.Tables["adherent"].Select("Id_Adh = " + cmBxAdh3.SelectedValue)[0][7]; //telephone
                rw[7] = cmBxDcpln3.Text == "MIXTE" ? "FITNESS" : cmBxDcpln3.Text;
                rw[8] = nmUpDwnNbrMois.Value;   //(int.Parse(txtBxCotis3.Text) / ((double)cotisation));
                tmp.Tables[0].Rows.Add(rw);
                //MessageBox.Show(tmp.Tables[0].Rows.Count + "");
                new frmApercu().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("déjà éxiste");
            }
        }

        #endregion

        #region Methodes

        private void ChargerAdherentsNames(params ComboBox[] cmBxs)
        {
            _GA.da = new SqlDataAdapter("select Id_Adh,nom+' '+prenom,nom,prenom,cin,date_naiss,sexe,telephone,adresse,code_postal,email,ville,photo from Adherent", _GA.cnx);
            try
            {
                ds.Tables["adherent"].Clear();
            }
            catch { }
            _GA.da.Fill(ds, "adherent");
            foreach (ComboBox c in cmBxs)
            {
                c.DataSource = ds.Tables["adherent"];
                c.ValueMember = ds.Tables["adherent"].Columns[0].ToString();
                c.DisplayMember = ds.Tables["adherent"].Columns[1].ToString();
            }

        }

        private void ChargerDiscipline(params ComboBox[] cmBxs)
        {
            _GA.da = new SqlDataAdapter("select * from Discipline", _GA.cnx);
            _GA.da.Fill(ds, "Discipline");
            foreach (ComboBox c in cmBxs)
            {
                c.DataSource = ds.Tables["Discipline"];
                c.ValueMember = ds.Tables["Discipline"].Columns[0].ToString();
            }
        }
        #endregion

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
        private void pointageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void cmBxNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmBxNomPrn.ContainsFocus)
            {
                try
                {
                    DataRow[] rows = ds.Tables["adherent"].Select("Id_Adh = " + cmBxNomPrn.SelectedValue);

                    txtBxNom.Text = rows[0][2].ToString();
                    txtBxPrenom.Text = rows[0][3].ToString();
                    txtBxCin.Text = rows[0][4].ToString();
                    dtPickDtNaiss.Value = DateTime.Parse(rows[0][5].ToString());
                    if (rows[0][6].ToString() == "M") rdBtnMale.Checked = true;
                    else rdBtnFemale.Checked = true;

                    txtBxTel.Text = rows[0][7].ToString();
                    txtBxAdrss.Text = rows[0][8].ToString();
                    txtBxCp.Text = rows[0][9].ToString();
                    txtBxEmail.Text = rows[0][10].ToString();
                    txtBxVille.Text = rows[0][11].ToString();
                    byte[] img = (byte[])rows[0][12];
                    MemoryStream ms = new MemoryStream(img);
                    pcBxPhoto.Image = Image.FromStream(ms);

                }
                catch (Exception)
                {
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cmBxCat4.Text == "")
            {
                MessageBox.Show("Champ(s) manquant(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            try
            {
                var query = "";
                if (cmBxCat4.Text.ToLower() == "tous")
                    query = "select * from V_AdherentInfo";
                else
                {
                    switch (cmBxCat4.Text)
                    {
                        case "Date Naissance":
                            query = "select * from V_AdherentInfo where Datepart(yyyy,[" + cmBxCat4.Text + "]) = '" + cmBxChx4.Text + "'";
                            break;
                        default: query = "select * from V_AdherentInfo where [" + cmBxCat4.Text + "] like '" + cmBxChx4.Text + "%'";
                            break;
                    }
                }

                _GA.da = new SqlDataAdapter(query, _GA.cnx);
                try
                {
                    ds.Tables.Remove("AdherentInfo");
                }
                catch { }
                _GA.da.Fill(ds, "AdherentInfo");
                ds.Tables["AdherentInfo"].Columns.Remove("Discipline");
                ds.Tables["AdherentInfo"].Columns.Remove("critere");

                gridControl1.DataSource = ds.Tables["AdherentInfo"];
                //ds.Tables["AdherentInfo"].Columns.Remove("photo");
                gridView1.Columns[11].Visible = false;
                foreach (GridColumn cl in gridView1.Columns)
                {
                    if (cl.Name.Contains("photo"))
                        continue;
                    cl.Width = gridView1.CalcColumnBestWidth(cl);
                }
            }
            catch (Exception ex) { }
        }

        private DataRowView row;
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView currentRow = (DataRowView)gridView1.GetFocusedRow();
                if (currentRow != row)
                {
                    var rows = ds.Tables["AdherentInfo"].Select("NBR = '" + currentRow[0] + "'");
                    byte[] img = (byte[])rows[0]["photo"];   //dt2.Rows[0][0];
                    MemoryStream ms = new MemoryStream(img);
                    pcBxPhoto4.Image = Image.FromStream(ms);
                    row = currentRow;
                }
            }
            catch (Exception)
            { }
        }

        private void btnUpdAdh_Click(object sender, EventArgs e)
        {
            if (pcBxPhoto.Image == null)
            {
                MessageBox.Show("Vous devez choisir une image", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            try
            {
                if (DialogResult.Yes == MessageBox.Show("Etes-vous sûr", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string sexe = (rdBtnMale.Checked) ? "M" : "F";
                    var cmd = new SqlCommand("Adherent_Update", _GA.cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id_adh", SqlDbType.Int).Value = cmBxNomPrn.SelectedValue;
                    cmd.Parameters.Add("@nom", SqlDbType.VarChar, 30).Value = txtBxNom.Text;
                    cmd.Parameters.Add("@prenom", SqlDbType.VarChar, 30).Value = txtBxPrenom.Text;
                    cmd.Parameters.Add("@cin", SqlDbType.VarChar, 10).Value = txtBxCin.Text;
                    cmd.Parameters.Add("@naiss", SqlDbType.Date).Value = dtPickDtNaiss.Text;
                    cmd.Parameters.Add("@sexe", SqlDbType.VarChar, 1).Value = sexe;
                    cmd.Parameters.Add("@telephone", SqlDbType.VarChar, 20).Value = txtBxTel.Text;
                    cmd.Parameters.Add("@adresse", SqlDbType.VarChar, 100).Value = txtBxAdrss.Text;
                    cmd.Parameters.Add("@cp", SqlDbType.VarChar, 10).Value = txtBxCp.Text;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = txtBxEmail.Text;
                    cmd.Parameters.Add("@ville", SqlDbType.VarChar, 30).Value = txtBxVille.Text;

                    FileStream fs;
                    byte[] img;
                    try
                    {
                        fs = new FileStream(path + src, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        img = br.ReadBytes((int)fs.Length);
                        fs.Close();
                        //cmd.Parameters.Add(new SqlParameter("@img", img));
                    }
                    catch
                    {
                        img = (byte[])ds.Tables["adherent"].Rows[cmBxNomPrn.SelectedIndex][12];
                        MemoryStream ms = new MemoryStream(img);
                        pcBxPhoto.Image = Image.FromStream(ms);
                    }
                    cmd.Parameters.Add(new SqlParameter("@img", img));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Opération Términée", "Opération", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ChargerAdherentsNames(cmBxNomPrn, cmBxAdh2, cmBxAdh3);
                }
            }
            catch (Exception)
            {
            }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            _GA.Clear(grpBxAdh.Controls);
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            _GA.Clear(grpBxAdhs2.Controls);
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            _GA.Clear(grpBxPay3.Controls);
        }

        private void cmBxAdh2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { cmBxDcpln2.Text = _GA.GetDcpln(cmBxAdh2.SelectedValue.ToString()).ToString(); }
            catch { }
        }

        private void cmBxAdh3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { cmBxDcpln3.Text = _GA.GetDcpln(cmBxAdh3.SelectedValue.ToString()).ToString(); }
            catch { }
        }

        private void frmAdherent_SizeChanged(object sender, EventArgs e)
        {
            _GA.KeepDistance(splitContainer2, 60);
        }

        private void txtBxTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }



        private void cmBxCat4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dr = null;
            try
            {
                cmBxChx4.Items.Clear();

                switch (cmBxCat4.Text)
                {
                    case "Critere":
                        cmBxChx4.Items.AddRange(new object[] { "Inscription", "Réinscription" });
                        break;
                    case "Discipline":
                        dr = new SqlCommand("select Id_dcpln from discipline", _GA.cnx).ExecuteReader();
                        while (dr.Read())
                        {
                            cmBxChx4.Items.Add(dr[0]);
                        }
                        break;
                    case "Sexe":
                        cmBxChx4.Items.AddRange(new object[] { "M", "F" });
                        break;
                    case "Ville":
                        dr = new SqlCommand("select ville from adherent", _GA.cnx).ExecuteReader();
                        while (dr.Read())
                        {
                            if (!cmBxChx4.Items.Contains(dr[0].ToString().ToLower()))
                                cmBxChx4.Items.Add(dr[0].ToString().ToLower());
                        }
                        break;
                    case "Date Naissance":
                        dr = new SqlCommand("select datepart(yy,date_naiss) from adherent", _GA.cnx).ExecuteReader();
                        while (dr.Read())
                        {
                            if (!cmBxChx4.Items.Contains(dr[0].ToString()))
                                cmBxChx4.Items.Add(dr[0].ToString());
                        }
                        break;
                }
            }
            catch (Exception)
            {
            }
            if (dr != null)
                dr.Close();
        }

        private void txtBxFrAdh2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void cmBxDcpln3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //charger le montant a payer - Cotisation
            if (cmBxDcpln3.ContainsFocus)
            {
                txtBxCotis3.Text = new SqlCommand("select cotisation from discipline where id_dcpln = '" + cmBxDcpln3.SelectedValue + "'", _GA.cnx).ExecuteScalar().ToString();

            }
        }
    }
}
