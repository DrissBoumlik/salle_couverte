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
    public partial class Form_reservation : Form
    {
        public Form_reservation()
        {
            InitializeComponent();
        }
        //delclaration
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlDataAdapter sda;
        DataTable dt_client = new DataTable();
        DataSet ds = new DataSet();
        SqlCommand cmd;

        //Def de methode Afficher
        public static void Afficher(DataGridView dr ,SqlConnection cn)
        {
            dr.DataSource = null;
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            sda = new SqlDataAdapter("select num_reserv 'Numero',date_reserv 'Date Reservation',date_match 'Date Match',heur_debut 'Heur Debut',heur_fin 'Heur Fin',type_reserv 'Type',observation,montant,Reservation.num_client,nom,prenom from Reservation join Client on Reservation.num_client=Client.num_client", cn);
            sda.Fill(dt);
            dr.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Hide();
            sda = new SqlDataAdapter("select num_client from Client",cn);
            sda.Fill(dt_client);
            comboBox1.DataSource = dt_client;
            comboBox1.ValueMember = "num_client";
            comboBox2.Items.Add("mini-foot");
            comboBox2.Items.Add("basket");
            
            //affichage de les reservation
            Afficher(dataGridView1, cn);
            //sda = new SqlDataAdapter("select num_reserv,date_reserv,date_match,heur_debut,heur_fin,type_reserv,observation,montant,Reservation.num_client,nom,prenom from Reservation join Client on Reservation.num_client=Client.num_client", cn);
            //sda.Fill(ds, "R2");
            //dataGridView1.DataSource = ds.Tables["R2"];

        }
        //SqlCommand cmd;
        public static DataSet3 d = new DataSet3();
        private void button2_Click(object sender, EventArgs e)
        {
            ds.Tables["R2"].Clear();
            cn.Open();
            cmd = new SqlCommand("InsertRes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter p1 = new SqlParameter("@D_match", SqlDbType.DateTime);
            p1.Value = dateTimePicker1.Value.ToShortDateString();
            cmd.Parameters.Add(p1);
            SqlParameter p2 = new SqlParameter("@h_d", SqlDbType.Time);
            //p2.Value = textBox1.Text;//heur_debut
            p2.Value = numericUpDown1.Value.ToString() + ":" + numericUpDown2.Value.ToString();
            cmd.Parameters.Add(p2);
            SqlParameter p3 = new SqlParameter("@h_f", SqlDbType.Time);
            //p3.Value = textBox2.Text;//heur_fin
            p3.Value = numericUpDown3.Value.ToString() + ":" + numericUpDown4.Value.ToString();
            cmd.Parameters.Add(p3);
            SqlParameter p4 = new SqlParameter("@type_res", SqlDbType.VarChar);
            p4.Value = comboBox2.Text;
            cmd.Parameters.Add(p4);
            SqlParameter p5 = new SqlParameter("@observation", SqlDbType.VarChar);
            p5.Value = textBox3.Text;
            cmd.Parameters.Add(p5);
            SqlParameter p6 = new SqlParameter("@m", SqlDbType.Float);
            p6.Value = textBox4.Text;
            cmd.Parameters.Add(p6);
            SqlParameter p7 = new SqlParameter("@num_client", SqlDbType.Int);
            p7.Value = comboBox1.Text;
            cmd.Parameters.Add(p7);

            SqlParameter p8 = new SqlParameter("@v",SqlDbType.Int);
            p8.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(p8);

            cmd.ExecuteNonQuery();
            int c;
            c = int.Parse(p8.Value.ToString());
            if (c == 1)
            {
                MessageBox.Show("Reservation bien ajouter","Ajouter",MessageBoxButtons.OK,MessageBoxIcon.Information);
                //dt.Columns.Add("1");
                //dt.Columns.Add("2");
                //dt.Columns.Add("3");
                //dt.Columns.Add("4");
                //dt.Columns.Add("5");
                //dt.Columns.Add("6");
                //dt.Columns.Add("7");
                //dt.Columns.Add("8");

                d.Tables[0].Clear();
                sda = new SqlDataAdapter("select nom from Client where num_client="+comboBox1.Text+"",cn);
                sda.Fill(ds, "T2");
                DataRow drw =d.Tables[0].NewRow();
                drw[8] = ds.Tables["T2"].Rows[0][0];
                drw[0] = DateTime.Now;
                drw[1] = dateTimePicker1.Value.ToShortDateString();
                drw[2] = numericUpDown1.Value.ToString() + ":" + numericUpDown2.Value.ToString();
                drw[3] = numericUpDown3.Value.ToString() + ":" + numericUpDown4.Value.ToString();
                drw[4] = comboBox2.Text;
                drw[5] = textBox3.Text;
                drw[6] = textBox4.Text;
                drw[7] = comboBox1.Text;
                //cn.Open();
                drw[9] = new SqlCommand("select top 1 num_reserv from Reservation order by num_reserv desc ", cn).ExecuteScalar();
                d.Tables[0].Rows.Add(drw);
                cn.Close();
                new Form_recu().Show();
            }
            else
            {
                MessageBox.Show("la place n'est pas vide","desole",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }

            cn.Close();
            Afficher(dataGridView1, cn);

            /*
            ds.Tables["R2"].Clear();
            sda = new SqlDataAdapter("select * from Reservation", cn);
            sda.Fill(ds, "R1");
            DataRow dr = ds.Tables["R1"].NewRow();
            dr[1] = DateTime.Now.ToString();
            dr[2] = dateTimePicker1.Text;
            dr[3] = textBox1.Text;
            dr[4] = textBox2.Text;
            dr[5] = comboBox2.Text;
            dr[6] = textBox3.Text;
            dr[7] = textBox4.Text;
            dr[8] = comboBox1.Text;
            ds.Tables["R1"].Rows.Add(dr);
            SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
            sda.Update(ds.Tables["R1"]);
            MessageBox.Show("terminer");
            //affichage de les reservation
            sda = new SqlDataAdapter("select * from Reservation", cn);
            sda.Fill(ds, "R2");
            dataGridView1.DataSource = ds.Tables["R2"];
             * */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Clear();
            //textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Focus();
        }

        private void rECHERCHEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            planning r = new planning();
            r.Show();
        }

        private void modifierReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_modifier_dateMatchRese.dgv = dataGridView1;
            Form_modifier_dateMatchRese a = new Form_modifier_dateMatchRese();
            Form_modifier_dateMatchRese m1 = new Form_modifier_dateMatchRese();
            m1.Show();
        }

        private void Form_reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Hide();
            //Form_Menu r = new Form_Menu();
            //r.Show();
        }

        private void supprimerReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_sup.dgv = dataGridView1;
            Form_sup s = new Form_sup();
            s.Show();

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar!=8)
            {
                e.Handled = true;
            }
        }

        private void numericUpDown3_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (int.Parse(e.KeyChar.ToString()) < int.Parse(numericUpDown1.Value.ToString()))
            {
                MessageBox.Show("error");
            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (check() == true )
            {
                //ds.Tables["R2"].Clear();
                cn.Open();
                cmd = new SqlCommand("InsertRes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = new SqlParameter("@D_match", SqlDbType.DateTime);
                p1.Value = dateTimePicker1.Value.ToShortDateString();
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@h_d", SqlDbType.Time);
                //p2.Value = textBox1.Text;//heur_debut
                p2.Value = numericUpDown1.Value.ToString() + ":" + numericUpDown2.Value.ToString();
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@h_f", SqlDbType.Time);
                //p3.Value = textBox2.Text;//heur_fin
                p3.Value = numericUpDown3.Value.ToString() + ":" + numericUpDown4.Value.ToString();
                cmd.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@type_res", SqlDbType.VarChar);
                p4.Value = comboBox2.Text;
                cmd.Parameters.Add(p4);
                SqlParameter p5 = new SqlParameter("@observation", SqlDbType.VarChar);
                p5.Value = textBox3.Text;
                cmd.Parameters.Add(p5);
                SqlParameter p6 = new SqlParameter("@m", SqlDbType.Float);
                p6.Value = textBox4.Text;
                cmd.Parameters.Add(p6);
                SqlParameter p7 = new SqlParameter("@num_client", SqlDbType.Int);
                p7.Value = comboBox1.Text;
                cmd.Parameters.Add(p7);

                SqlParameter p8 = new SqlParameter("@v", SqlDbType.Int);
                p8.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(p8);

                cmd.ExecuteNonQuery();
                int c;
                c = int.Parse(p8.Value.ToString());
                if (c == 1)
                {
                    MessageBox.Show("Reservation bien ajouter , Clique OK Pour Afficher Le Recu", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //dt.Columns.Add("1");
                    //dt.Columns.Add("2");
                    //dt.Columns.Add("3");
                    //dt.Columns.Add("4");
                    //dt.Columns.Add("5");
                    //dt.Columns.Add("6");
                    //dt.Columns.Add("7");
                    //dt.Columns.Add("8");

                    d.Tables[0].Clear();
                    sda = new SqlDataAdapter("select nom from Client where num_client=" + comboBox1.Text + "", cn);
                    sda.Fill(ds, "T2");
                    DataRow drw = d.Tables[0].NewRow();
                    drw[8] = ds.Tables["T2"].Rows[0][0];
                    drw[0] = DateTime.Now;
                    drw[1] = dateTimePicker1.Value.ToShortDateString();
                    drw[2] = numericUpDown1.Value.ToString() + ":" + numericUpDown2.Value.ToString();
                    drw[3] = numericUpDown3.Value.ToString() + ":" + numericUpDown4.Value.ToString();
                    drw[4] = comboBox2.Text;
                    drw[5] = textBox3.Text;
                    drw[6] = textBox4.Text;
                    drw[7] = comboBox1.Text;
                    //cn.Open();
                    drw[9] = new SqlCommand("select top 1 num_reserv from Reservation order by num_reserv desc ", cn).ExecuteScalar();
                    d.Tables[0].Rows.Add(drw);
                    cn.Close();
                    new Form_recu().Show();
                }
                else
                {
                    MessageBox.Show("la place n'est pas vide", "desole", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                cn.Close();
                Afficher(dataGridView1, cn);
                /*
                ds.Tables["R2"].Clear();
                sda = new SqlDataAdapter("select * from Reservation", cn);
                sda.Fill(ds, "R1");
                DataRow dr = ds.Tables["R1"].NewRow();
                dr[1] = DateTime.Now.ToString();
                dr[2] = dateTimePicker1.Text;
                dr[3] = textBox1.Text;
                dr[4] = textBox2.Text;
                dr[5] = comboBox2.Text;
                dr[6] = textBox3.Text;
                dr[7] = textBox4.Text;
                dr[8] = comboBox1.Text;
                ds.Tables["R1"].Rows.Add(dr);
                SqlCommandBuilder cmb = new SqlCommandBuilder(sda);
                sda.Update(ds.Tables["R1"]);
                MessageBox.Show("terminer");
                //affichage de les reservation
                sda = new SqlDataAdapter("select * from Reservation", cn);
                sda.Fill(ds, "R2");
                dataGridView1.DataSource = ds.Tables["R2"];
                 * */
            }
            else
            {
                MessageBox.Show("Veuillez vérifier votre saisie et réessayer");
            }
            
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_modiReservation.dgv = dataGridView1;
            Form_modiReservation a = new Form_modiReservation();
            a.Show();
        }

        public bool check()
        {
            if (comboBox1.Text == "" || comboBox2.Text == "" || textBox4.Text=="")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            comboBox2.Text = "";
            comboBox1.Text = "";
            comboBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sda = new SqlDataAdapter("select * from client ", cn);
                sda.Fill(ds, "w1");
                DataView vx = new DataView(ds.Tables["w1"]);
                vx.RowFilter = "num_client = " + comboBox1.Text + "";
                label19.Text = vx[0][1].ToString() +" "+ vx[0][2].ToString();
                

            }
            catch
            {
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
