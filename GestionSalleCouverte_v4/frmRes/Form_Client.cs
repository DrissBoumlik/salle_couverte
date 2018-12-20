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
    public partial class Form_Client : Form
    {
        public Form_Client()
        {
            InitializeComponent();
        }
        //delclaration
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlDataAdapter sda;
        DataSet ds = new DataSet();
        private void Form_Client_Load(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("select * from client", cn);
            sda.Fill(ds,"T1");
            dataGridView1.DataSource = ds.Tables["T1"];
            button1.Hide();
        }

        public Boolean check()
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
                return false;
            else
                return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (check() == true)
            {
                ds.Tables["T1"].Clear();
                sda = new SqlDataAdapter("select * from client", cn);
                sda.Fill(ds, "T2");
                DataRow dr = ds.Tables["T2"].NewRow();
                dr[1] = textBox1.Text;
                dr[2] = textBox2.Text;
                dr[3] = textBox3.Text;
                ds.Tables["T2"].Rows.Add(dr);
                SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
                sda.Update(ds.Tables["T2"]);
                MessageBox.Show("bien ajouter");
                sda = new SqlDataAdapter("select * from client", cn);
                sda.Fill(ds, "T1");
                dataGridView1.DataSource = ds.Tables["T1"];
            }
            else
            {
                MessageBox.Show("remplire les champs slvp");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(ds.Tables["T1"]);
                
            if (radioButton1.Checked == true)
            {
                dv.RowFilter = "num_client = " + textBox4.Text + "  ";
                dataGridView1.DataSource = dv;
            }
            if (radioButton2.Checked == true)
            {
                dv.RowFilter = "nom Like '" + textBox4.Text + "'  ";
                dataGridView1.DataSource = dv;
            }
            if (radioButton3.Checked == true)
            {
                dv.RowFilter = "prenom Like '" + textBox4.Text + "'  ";
                dataGridView1.DataSource = dv;
            }
        }
        DataTable dt = new DataTable();
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                sda = new SqlDataAdapter("select * from Client", cn);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                sda = new SqlDataAdapter("select * from Client", cn);
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            
        }
        public static int x;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            x = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["num_client"].Value.ToString());
            //MessageBox.Show(x.ToString());
            Form_modifier_Client m = new Form_modifier_Client();
            m.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (check() == true)
            {
                ds.Tables["T1"].Clear();
                sda = new SqlDataAdapter("select * from client", cn);
                sda.Fill(ds, "T2");
                DataRow dr = ds.Tables["T2"].NewRow();
                dr[1] = textBox1.Text;
                dr[2] = textBox2.Text;
                dr[3] = textBox3.Text;
                ds.Tables["T2"].Rows.Add(dr);
                SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
                sda.Update(ds.Tables["T2"]);
                MessageBox.Show("bien ajouter");
                sda = new SqlDataAdapter("select * from client", cn);
                sda.Fill(ds, "T1");
                dataGridView1.DataSource = ds.Tables["T1"];
            }
            else
            {
                MessageBox.Show("remplire les champs");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
    }
}
