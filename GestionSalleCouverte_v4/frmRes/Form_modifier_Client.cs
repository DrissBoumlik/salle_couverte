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
    public partial class Form_modifier_Client : Form
    {
        public Form_modifier_Client()
        {
            InitializeComponent();
        }
        //delclaration
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        
        private void Form_modifier_Client_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select * from Client where num_client="+Form_Client.x+"", cn);
            sda.Fill(ds, "T1");
            textBox1.Text = ds.Tables["T1"].Rows[0][1].ToString();
            textBox2.Text = ds.Tables["T1"].Rows[0][2].ToString();
            textBox3.Text = ds.Tables["T1"].Rows[0][3].ToString();
        }
        SqlCommand cmd;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("update Client set nom='" + textBox1.Text + "',prenom='" + textBox2.Text + "',telephone='" + textBox3.Text + "' where num_client=" + Form_Client.x + " ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("terminer");
            cn.Close();
        }
    }
}
