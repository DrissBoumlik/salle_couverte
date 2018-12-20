using System;
using System.Windows.Forms;
using GestionSalleCouverte.Classes;
using System.Data.SqlClient;
using System.Data;

namespace GestionSalleCouverte.Forms
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
            _GA.currentForm = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _GA.Exit(this);
            new frmParametre().Show();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                var cmd = new SqlCommand("Is_Admin", _GA.cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nom", txtBxUser.Text);
                cmd.Parameters.AddWithValue("@mot_pass", txtBxMdp.Text);
                cmd.Parameters.Add("@ok", SqlDbType.Int);
                var p = cmd.Parameters[cmd.Parameters.Count - 1];
                p.Direction = ParameterDirection.ReturnValue;
                var rd = cmd.ExecuteReader();
                rd.Close();
                if (1 != (int)p.Value)
                {
                    MessageBox.Show("Données Incorrectes", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                _GA.allowed = true;
                this.Hide();
                new frmParametre().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            txtBxUser.Text = txtBxMdp.Text = "";
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GA.Exit(this);
        }
        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            //notifyIcon1.Icon = new Icon(@"C:\Users\CarToUchE\_ME\Projects\C# Projects\C# DB Projects\Tmp_C#_SalleCouverte\_______\Info3.ico");
            //aProposToolStripMenuItem.Image = imageList1.Images[0];
        }

        private void verouillerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
