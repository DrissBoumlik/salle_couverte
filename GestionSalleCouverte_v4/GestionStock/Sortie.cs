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
    public partial class Sortie : Form
    {
        public Sortie()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        int b;
        SqlCommand cmd;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox1.Text == " " || textBox1.Text == "0") MessageBox.Show("Veuillez entrer une valeur");
            else
            {
                if (float.Parse(textBox1.Text) > Produits.nb_qt) MessageBox.Show("Quantite invalide (Plus Grande que la quantite du Produit)");
                else
                {
                    cmd = new SqlCommand("update Produit set quantite=quantite-@qt where id_prod=@id", cn);
                    cmd.Parameters.AddWithValue("@id", Produits.id_prod);
                    cmd.Parameters.AddWithValue("@qt", textBox1.Text);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("insert into SortieProd values (@id,@qt,@date,@liv,@obse)", cn);
                    cmd.Parameters.AddWithValue("@id", Produits.id_prod);
                    cmd.Parameters.AddWithValue("@qt", textBox1.Text);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@liv", textBox2.Text);
                    cmd.Parameters.AddWithValue("@obse", textBox3.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();

                    MessageBox.Show("Votre quantite sortie a ete bien enregistré");
                    b = GestionStock.f.bg.Position;
                    GestionStock.f.clearload();
                    GestionStock.f.load();
                    GestionStock.f.bg.Position = b;
                    this.Hide();


                }
            
            }
        }

        private void Sortie_KeyPress(object sender, KeyPressEventArgs e)
        {
             

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Sortie_Load(object sender, EventArgs e)
        {

        }
    }
}
