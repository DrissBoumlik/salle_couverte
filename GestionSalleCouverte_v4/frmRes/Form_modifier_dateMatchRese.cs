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
    public partial class Form_modifier_dateMatchRese : Form
    {
        public Form_modifier_dateMatchRese()
        {
            InitializeComponent();
        }
        //delclaration
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        private void Form_modifierRes_Load(object sender, EventArgs e)
        {
            label11.Text = "";
        }
        public static DataGridView dgv;

        //def de methode check
        public bool check()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text == "")
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
                textBox6.Text = dv[0][8].ToString();//numClient
                if (dv[0][5].ToString() == "mini-foot")
                {
                    radioButton1.Checked = true;
                }
                else
                {
                    radioButton2.Checked = true;
                }
                dateTimePicker1.Value = DateTime.Parse(dv[0][2].ToString());
                textBox5.Text = dv[0][3].ToString();
                textBox2.Text = dv[0][4].ToString();
                textBox3.Text = dv[0][6].ToString();
                textBox4.Text = dv[0][7].ToString();
                sda = new SqlDataAdapter("select * from Client", cn);
                sda.Fill(ds, "T2");
                DataView dv2 = new DataView(ds.Tables["T2"]);
                dv2.RowFilter = "num_client = " + dv[0][8].ToString() + " ";
                label11.Text = dv2[0][1].ToString() + " " + dv2[0][2].ToString();

            }
            catch { MessageBox.Show("Aucun Enregistrement Avec Ce Numero !"); }



        }
        SqlCommand cmd;
        private void button2_Click(object sender, EventArgs e)
        {
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            cmd = new SqlCommand("Verification3", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@D_match", SqlDbType.DateTime);
            p1.Value = dateTimePicker1.Value.ToShortDateString();
            cmd.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@h_d", SqlDbType.Time);
            p2.Value = textBox5.Text;
            cmd.Parameters.Add(p2);
            SqlParameter p10 = new SqlParameter("@h_f", SqlDbType.Time);
            p10.Value = textBox2.Text;
            cmd.Parameters.Add(p10);

            SqlParameter p8 = new SqlParameter("@v", SqlDbType.Int);
            p8.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p8);

            cmd.ExecuteNonQuery();
            int c;
            string x;
            c = int.Parse(p8.Value.ToString());
            if (c == 1)//place 5awya
            {

                if (radioButton1.Checked == true)
                {
                    x = "mini-foot";
                }
                else
                {
                    x = "basket";
                }
                cmd = new SqlCommand("update Reservation set date_match='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year + "',heur_debut='" + textBox5.Text + "',heur_fin='" + textBox2.Text + "',type_reserv='" + x + "',observation='" + textBox3.Text + "',montant=" + textBox4.Text + ",num_client=" + textBox6.Text + " where num_reserv = " + textBox1.Text + "  ", cn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" modification terminer !!");

                /*sda = new SqlDataAdapter("select * from Reservation where num_reserv = " + textBox1.Text + "", cn);
                sda.Fill(ds, "T2");
                ds.Tables["T2"].Rows[0][8] = textBox6.Text;
                if (radioButton1.Checked == true)
                {
                    ds.Tables["T2"].Rows[0][5] = "mini-foot";
                }
                else
                {
                    ds.Tables["T2"].Rows[0][5] = "basket";
                }
                ds.Tables["T2"].Rows[0][2] = dateTimePicker1.Value.ToShortDateString();
                ds.Tables["T2"].Rows[0][3] = textBox5.Text;
                ds.Tables["T2"].Rows[0][4] = textBox2.Text;
                ds.Tables["T2"].Rows[0][6] = textBox3.Text;
                ds.Tables["T2"].Rows[0][7] = textBox4.Text;
                SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
                sda.Update(ds.Tables["T2"]);*/
                
            }
            else//place 3amra 
            {
                MessageBox.Show("Place Indisponible");
            }


            cn.Close();




        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (check() == true)
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
                cmd = new SqlCommand("Verification3", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@D_match", SqlDbType.DateTime);
                p1.Value = dateTimePicker1.Value.ToShortDateString();
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@h_d", SqlDbType.Time);
                p2.Value = textBox5.Text;
                cmd.Parameters.Add(p2);
                SqlParameter p10 = new SqlParameter("@h_f", SqlDbType.Time);
                p10.Value = textBox2.Text;
                cmd.Parameters.Add(p10);

                SqlParameter p8 = new SqlParameter("@v", SqlDbType.Int);
                p8.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p8);

                cmd.ExecuteNonQuery();
                int c;
                string x;
                c = int.Parse(p8.Value.ToString());
                if (c == 1)//place 5awya
                {

                    if (radioButton1.Checked == true)
                    {
                        x = "mini-foot";
                    }
                    else
                    {
                        x = "basket";
                    }
                    cmd = new SqlCommand("update Reservation set date_match='" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Year + "',heur_debut='" + textBox5.Text + "',heur_fin='" + textBox2.Text + "',type_reserv='" + x + "',observation='" + textBox3.Text + "',montant=" + textBox4.Text + ",num_client=" + textBox6.Text + " where num_reserv = " + textBox1.Text + "  ", cn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" modification terminer :D");
                    Form_reservation.Afficher(dgv, cn);

                    /*sda = new SqlDataAdapter("select * from Reservation where num_reserv = " + textBox1.Text + "", cn);
                    sda.Fill(ds, "T2");
                    ds.Tables["T2"].Rows[0][8] = textBox6.Text;
                    if (radioButton1.Checked == true)
                    {
                        ds.Tables["T2"].Rows[0][5] = "mini-foot";
                    }
                    else
                    {
                        ds.Tables["T2"].Rows[0][5] = "basket";
                    }
                    ds.Tables["T2"].Rows[0][2] = dateTimePicker1.Value.ToShortDateString();
                    ds.Tables["T2"].Rows[0][3] = textBox5.Text;
                    ds.Tables["T2"].Rows[0][4] = textBox2.Text;
                    ds.Tables["T2"].Rows[0][6] = textBox3.Text;
                    ds.Tables["T2"].Rows[0][7] = textBox4.Text;
                    SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
                    sda.Update(ds.Tables["T2"]);*/

                }
                else//place 3amra 
                {
                    MessageBox.Show("Place indisponible");
                }


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
