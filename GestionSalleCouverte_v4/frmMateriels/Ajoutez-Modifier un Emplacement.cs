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
    public partial class Ajoutez_Modifier_un_emplacement : Form
    {
        public Ajoutez_Modifier_un_emplacement()
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
            label1.Text = "Entrez votre nouveau Emplacement";
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
            da = new SqlDataAdapter("select * from Emplacement", cn);
            da.Fill(dt);
            comboBox1.DisplayMember = "emplac";
            comboBox1.ValueMember = "id_emp";
            comboBox1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox1.Text == " ") MessageBox.Show("Veuillez entrer un nom");
            else
            {
                cmd = new SqlCommand("update Emplacement set emplac=@emp where id_emp=@id", cn);
                cmd.Parameters.AddWithValue("@emp", textBox1.Text);
                cmd.Parameters.AddWithValue("@id", comboBox1.SelectedValue);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Votre Emplacement a été bien modifié");
                cn.Close();
                textBox1.Clear();
                load();
                if (MenuApp.f != null) MenuApp.f.combo();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox1.Text == " ") MessageBox.Show("Veuillez entrer un nom");
            else
            {
                cmd = new SqlCommand("insert into Emplacement values(@emp)", cn);
                cmd.Parameters.AddWithValue("@emp", textBox1.Text);

                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Votre Emplacement a été bien Ajouté");
                cn.Close();
                textBox1.Clear();
                load();
                if (MenuApp.f != null) MenuApp.f.combo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button2.Visible = true;
            button1.Visible = false;
            button7.Visible = true;
            label1.Text = "Nouveau Nom de cet Emplacement";
            
        }

        private void Ajoutez_Modifier_un_emplacement_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuApp.p = null;
        }
    }
}
