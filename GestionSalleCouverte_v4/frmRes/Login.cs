using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace App_Gestion_Reservation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(@"Data Source=.\cartouche;Initial Catalog=salle_couverte;Integrated Security=True");
        SqlCommand cmd;
        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new SqlCommand("", cn);
            cn.Close();
        }
    }
}
