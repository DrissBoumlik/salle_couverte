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

namespace GestionSalleCouverte
{
    public partial class CategorieProd : Form
    {
        public CategorieProd()
        {
            InitializeComponent();
        }   
        //SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\Gestion de Materiels\Gestion_Materiels.mdf;Integrated Security=True;User Instance=True");
        SqlConnection cn = new SqlConnection(_GA.strCnx);
 
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt = new DataTable();

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "Entrez votre nouvelle Categorie";
            button2.Visible = false;
            button1.Visible = true;
            button3.Visible = true;
            button7.Visible = false;
        }

        private void Ajoutez_Modifier_une_Categorie_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            dt.Clear();
            da = new SqlDataAdapter("select * from ProdCategorie", cn);
            da.Fill(dt);
            comboBox1.DisplayMember = "cat";
            comboBox1.ValueMember = "id_cat";
            comboBox1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox1.Text == " ") MessageBox.Show("Veuillez entrer un nom");
            else
            {
                cmd = new SqlCommand("update ProdCategorie set cat=@cat where id_cat=@id", cn);
                cmd.Parameters.AddWithValue("@cat", textBox1.Text);
                cmd.Parameters.AddWithValue("@id", comboBox1.SelectedValue);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Votre Categorie a été bien modifié");
                cn.Close();
                textBox1.Clear();
                load();
                if (GestionStock.f != null) GestionStock.f.combo();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox1.Text == " ") MessageBox.Show("Veuillez entrer un nom");
            else
            {
                cmd = new SqlCommand("insert into ProdCategorie values(@cat)", cn);
                cmd.Parameters.AddWithValue("@cat", textBox1.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Votre Categorie a été bien Ajouté");
                cn.Close();
                textBox1.Clear();
                load();
                if (GestionStock.f != null) GestionStock.f.combo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button2.Visible = true;
            button1.Visible = false;
            button7.Visible = true;
            label1.Text = "Nouveau Nom de cette Categorie";
            
        }

        private void Ajoutez_Modifier_une_Categorie_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestionStock.p = null;
        }
    }
}
