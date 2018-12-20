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
namespace App_Gestion_Reservation
{
    public partial class Form_sup : Form
    {
        public Form_sup()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        public static DataGridView dgv;
        private void Form_sup_Load(object sender, EventArgs e)
        {
            
            //dt.Clear();
            sda = new SqlDataAdapter("select num_reserv from Reservation", cn);
            sda.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "num_reserv";
            comboBox1.ValueMember = "num_reserv";
        }
        
                
         

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dt2.Clear();
                if (comboBox1.ContainsFocus)
                {
                    sda = new SqlDataAdapter("select num_reserv,date_reserv,date_match,heur_debut,heur_fin,type_reserv,observation,montant,Reservation.num_client,nom,prenom from Reservation join Client on Reservation.num_client=Client.num_client", cn);
                    sda.Fill(dt2);
                    DataView dv = new DataView(dt2);
                    dv.RowFilter = "num_reserv = " + comboBox1.SelectedValue + "";
                    //dv[0][8].ToString();//numClient
                    dataGridView1.DataSource = dv;
                }
            }
            catch { }
            
            
        }
        SqlCommand cmd;
        private void button1_Click(object sender, EventArgs e)
        {
            
            cn.Open();
            if (DialogResult.OK == MessageBox.Show("voulez-vous vraiment supprimer cette reservation", "supprimer", MessageBoxButtons.OKCancel))
            {
                cmd = new SqlCommand("delete from Reservation where num_reserv = " + comboBox1.SelectedValue + "", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("terminer");
                dt2.Clear();
            }
            cn.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cn.Open();
            if (DialogResult.OK == MessageBox.Show("voulez-vous vraiment supprimer cette reservation", "supprimer", MessageBoxButtons.OKCancel))
            {
                cmd = new SqlCommand("delete from Reservation where num_reserv = " + comboBox1.SelectedValue + "", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("terminer");
                dt2.Clear();
                Form_reservation.Afficher(dgv, cn);
                DataTable dt3 = new DataTable();
                comboBox1.DataSource = null;
                sda = new SqlDataAdapter("select num_reserv from Reservation", cn);
                sda.Fill(dt3);
                comboBox1.DataSource = dt3;
                comboBox1.DisplayMember = "num_reserv";
                comboBox1.ValueMember = "num_reserv";
                
            }
            cn.Close();
            

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
