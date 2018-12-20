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
    public partial class planning : Form
    {
        public planning()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        private void Form_rechercheReserv_Load(object sender, EventArgs e)
        {
            domainUpDown1.Text = "2016";
            for (int i = 2016; i < 2999; i++)
            {
                domainUpDown1.Items.Add(i);
            }
                
            sda = new SqlDataAdapter("select * from Mois", cn);
            sda.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember="nom_mois";
            comboBox1.ValueMember="id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds.Tables.Clear();
            if (textBox1.Text == "")
            {
                
                /*string str;
                str = comboBox1.SelectedValue.ToString();
                MessageBox.Show(str);*/

                sda = new SqlDataAdapter("select num_reserv Numero,nom,prenom,date_reserv 'Date Reservation',date_match 'Date de match',heur_debut 'Heur debut',heur_fin 'heur fin',type_reserv 'Type' ,observation,montant,Reservation.num_client from Reservation join Client on Reservation.num_client=Client.num_client where DATEPART(MONTH,date_reserv)=" + comboBox1.SelectedValue + " and DATEPART(YEAR,date_reserv)=" + domainUpDown1.Text + "", cn);
                sda.Fill(ds, "T1");
                dataGridView1.DataSource = ds.Tables["T1"];
                label4.Text = dataGridView1.Rows.Count.ToString();
                //sda = new SqlDataAdapter("select count(*) from Reservation where DATEPART(MONTH,date_reserv)=" + comboBox1.SelectedValue + " and DATEPART(YEAR,date_reserv)=" + domainUpDown1.Text + " ", cn);
                //sda.Fill(ds, "T2");
                //label4.Text = ds.Tables["T2"].Rows[0][0].ToString();
            }
            else
            {
                
                sda = new SqlDataAdapter("select num_reserv,nom,prenom,date_reserv,date_match,heur_debut,heur_fin,type_reserv,observation,montant,Reservation.num_client from Reservation join Client on Reservation.num_client=Client.num_client where DATEPART(MONTH,date_reserv)=" + comboBox1.SelectedValue + " and DATEPART(YEAR,date_reserv)=" + domainUpDown1.Text + " and Client.nom='" + textBox1.Text + "'", cn);
                sda.Fill(ds, "T2");
                dataGridView1.DataSource = ds.Tables["T2"];
                label4.Text = dataGridView1.Rows.Count.ToString();
            }
            
        }
    }
}
