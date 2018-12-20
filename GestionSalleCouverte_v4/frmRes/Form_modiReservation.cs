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
    public partial class Form_modiReservation : Form
    {
        public Form_modiReservation()
        {
            InitializeComponent();
        }
        //delclaration
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        

        private void Form_modiReservation_Load(object sender, EventArgs e)
        {
            label11.Text = "";
        }
        public bool check()
        {
            if (textBox1.Text == "")
                return false;
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sda = new SqlDataAdapter("select * from Reservation", cn);
                sda.Fill(ds, "T1");
                DataView dv = new DataView(ds.Tables["T1"]);
                dv.RowFilter = "num_reserv = " + textBox1.Text + "";
                if (dv[0][5].ToString() == "mini-foot")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                textBox3.Text = dv[0][6].ToString();
                textBox4.Text = dv[0][7].ToString();
                sda = new SqlDataAdapter("select * from Client", cn);
                sda.Fill(ds, "T2");
                DataView dv2 = new DataView(ds.Tables["T2"]);
                dv2.RowFilter = "num_client = " + dv[0][8].ToString() + " ";
                label11.Text = dv2[0][1].ToString() + " " + dv2[0][2].ToString();
            }
            catch { MessageBox.Show("aucun enregistremet avec ce numero !! "); }
            
        }
        SqlCommand cmd;
        string x;
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                x = "mini-foot";
            }
            else
            {
                x = "basket";
            }
            cn.Open();
            cmd = new SqlCommand("update Reservation set type_reserv='" + x + "',observation='"+textBox3.Text+"',montant=" + textBox4.Text + " where num_reserv = " + textBox1.Text + " ", cn);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" modification terminer !!");
            cn.Close();
        }
        public static DataGridView dgv;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (check() == true)
            {
                if (radioButton1.Checked == true)
                {
                    x = "mini-foot";
                }
                else
                {
                    x = "basket";
                }
                cn.Open();
                cmd = new SqlCommand("update Reservation set type_reserv='" + x + "',observation='" + textBox3.Text + "',montant=" + textBox4.Text + " where num_reserv = " + textBox1.Text + " ", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" modification terminer !!");
                Form_reservation.Afficher(dgv, cn);
                cn.Close();
            }
            else
            {
                MessageBox.Show("Veuillez vérifier votre saisie et réessayer");
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
