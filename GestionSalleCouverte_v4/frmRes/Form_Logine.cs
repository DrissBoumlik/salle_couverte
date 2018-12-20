using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using GestionSalleCouverte;
using GestionSalleCouverte.Classes;

namespace App_Gestion_Reservation
{
    public partial class Form_Logine : Form
    {
        public Form_Logine()
        {
            InitializeComponent();
        }
        //int r;
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlCommand cmd;
        private void Form_Logine_Load(object sender, EventArgs e)
        {
            try { cn.Open(); }
            catch (Exception ex) { MessageBox.Show("Probleme au niveau du Serveur,Veuillez le verifier"); Application.Exit(); }
            textBox1.Select();
            Button b = new Button();
            b.Click += pictureBox1_Click;
            this.AcceptButton = b;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
                this.Hide();
                //Form_Menu m = new Form_Menu(); 
                Mapp m = new Mapp(); 
                m.Show(); 
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            connexionbutton();
          
        }
        private void connexionbutton()
        {
            cmd = new SqlCommand("P_log2", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@Nom", SqlDbType.VarChar);
            p1.Value = textBox1.Text;
            cmd.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@mot_pass", SqlDbType.VarChar);
            p2.Value = textBox2.Text;
            SqlParameter re = new SqlParameter("re", SqlDbType.Int);
            re.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(re);
            cmd.Parameters.Add(p2);
            cmd.ExecuteScalar();
            if ((int)re.Value != 0)
            {
                _GA.user = textBox1.Text;
                _GA.mdpass = textBox2.Text;

                var cmd1 = new SqlCommand("Is_Admin", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Nom", _GA.user);
                cmd1.Parameters.AddWithValue("@mot_pass", _GA.mdpass);
                cmd1.Parameters.Add("@ok", SqlDbType.Int);
                var p = cmd1.Parameters[cmd1.Parameters.Count - 1];
                p.Direction = ParameterDirection.ReturnValue;
                var rd = cmd1.ExecuteReader();
                rd.Close();
                if ((int)p.Value == 1)
                    _GA.allowed = true;
                this.timer1.Start(); 
            
            }

            else MessageBox.Show("Nom d'utilisateur Et/Ou Mot de passe incorrect");// + re.Value);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _GA.Exit();
        }

   

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
