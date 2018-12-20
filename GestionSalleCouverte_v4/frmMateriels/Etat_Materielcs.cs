using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionSalleCouverte.Classes;
using System.Data.SqlClient;

namespace GestionSalleCouverte
{
    public partial class Etat_Materielcs : Form
    {
        public Etat_Materielcs()
        {
            InitializeComponent();
        }
        //SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\Gestion de Materiels\Gestion_Materiels.mdf;Integrated Security=True;User Instance=True");
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        int b;
        SqlCommand cmd;

        private void Etat_Materielcs_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //MessageBox.Show(""+Form1.nb_qt);
            if (Produit.nb_qt == 1) { label19.Visible = false; textBox1.Visible = false; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Visible == false) textBox1.Text = "1";
            if (textBox1.Text == null || textBox1.Text == "" || textBox1.Text == " " || textBox1.Text == "0") MessageBox.Show("Veuillez entrer une valeur");
            else
            {
                if (int.Parse(textBox1.Text) > Produit.nb_qt || int.Parse(textBox1.Text) > Produit.qt_encours) MessageBox.Show("Quantite invalide (Plus Grande que la quantite du Materiel ou la quantite en Cours d'utilisation)");
                else
                {
                    cmd = new SqlCommand("update Materiel set nb_mat_retrait=nb_mat_retrait+@ret,nb_mat_encours=nb_mat_encours-@encours where id_mat=@id", cn);

                    cmd.Parameters.AddWithValue("@id", Produit.id_mat);
                    cmd.Parameters.AddWithValue("@ret", textBox1.Text);
                    cmd.Parameters.AddWithValue("@encours", textBox1.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("insert into MatRetire values(@id,@qt,@date)", cn);
                    cmd.Parameters.AddWithValue("@id", Produit.id_mat);
                    cmd.Parameters.AddWithValue("@qt", textBox1.Text);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Changement d'Etat du Materiel effectué avec succès");
                    b = MenuApp.f.bg.Position;
                    MenuApp.f.clearload();
                    MenuApp.f.load();
                    MenuApp.f.bg.Position = b;
                    this.Hide();
                    
                }
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
