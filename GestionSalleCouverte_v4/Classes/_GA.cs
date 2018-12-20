using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GestionSalleCouverte.Classes
{
    static class _GA
    {
        public static bool allowed=false;
        public static string user;
        public static string mdpass;
        public static bool logedIn = false;
        private const string server = ".\\cartouche";
        private const string database = "Salle_Couverte";
        public static string strCnx = @"  Data Source=DESKTOP-OKUFAJ3\SIMO;Initial Catalog=Salle_Couverte;Integrated Security=True";
       // public static string strCnx = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\Salle Couverte\Salle__Couverte.mdf;Integrated Security=True;User Instance=True";
        public static SqlConnection cnx;
        public static SqlCommand cmd;
        public static SqlDataAdapter da;
        //public static DataSet ds;

        public const int increment = 10;
        public static Form oldForm = null;
        public static Form currentForm = null;

        public static bool CheckRdBtn(GroupBox grpBx)
        {
            foreach (Control ctrl in grpBx.Controls)
            {
                if (ctrl is RadioButton)
                    return true;
            }
            return false;
        }

        public static bool CheckField(GroupBox grpBx)
        {
            bool valide = false;


            foreach (Control ctrl in grpBx.Controls)
            {
                if (ctrl is RadioButton)
                    if ((ctrl as RadioButton).Checked)
                    {
                        valide = true;
                        break;
                    }
            }


            if (valide || !CheckRdBtn(grpBx))
                foreach (Control ctrl in grpBx.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        if (ctrl.Text == "" && ctrl.Name != "txtBxObsrv2" && ctrl.Name != "cmBxChx4")
                            return false;
                    }
                    else if (ctrl is PictureBox)
                        if ((ctrl as PictureBox).Image == null)
                            return false;
                }
            else return false;
            return true;
        }

        public static bool Open()
        {
            try
            {
                cnx.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
                //throw;
            }
        }

        public static void Exit()
        {
            DialogResult answer = MessageBox.Show("Voulez vous quitter", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (answer == DialogResult.Yes)
                Application.Exit();
        }
        public static void Exit(Form f)
        {
            f.Hide();
        }

        public static void Clear(Control.ControlCollection ctrls)
        {
            foreach (Control c in ctrls)
            {
                switch (c.GetType().Name)
                {
                    case "TextBox":
                    case "ComboBox":
                        c.Text = "";
                        break;
                    case "RadioButton":
                        (c as RadioButton).Checked = false;
                        break;
                    case "PictureBox":
                        (c as PictureBox).Image = null;
                        break;

                }
            }
        }

        public static int GetNumDay(string dayOfWeek)
        {
            switch (dayOfWeek.ToUpper())
            {
                case "LUNDI": return 1;
                case "MARDI": return 2;
                case "MERCREDI": return 3;
                case "JEUDI": return 4;
                case "VENDREDI": return 5;
                case "SAMEDI": return 6;
                case "DIMANCHE": return 7;
                default: return 0;
            }
        }

        public static string EngDayToFr(DayOfWeek day)
        {
            switch ((day))
            {
                case DayOfWeek.Monday:
                    return "LUNDI";
                case DayOfWeek.Tuesday:
                    return "MARDI";
                case DayOfWeek.Wednesday:
                    return "MERCREDI";
                case DayOfWeek.Thursday:
                    return "JEUDI";
                case DayOfWeek.Friday:
                    return "VENDREDI";
                case DayOfWeek.Saturday:
                    return "SAMEDI";
                default:
                    return "DIMANCHE";
            }
        }

        public static object GetDcpln(string Id_Adh)
        {
            var cmd = new SqlCommand("select Id_dcpln from Adhesion where Id_adh = " + Id_Adh, cnx);
            return cmd.ExecuteScalar();
        }

        public static void KeepDistance(SplitContainer spl, int distance)
        {
            try
            {
                spl.SplitterDistance = distance;
            }
            catch (Exception)
            {
            }
        }

        public static object GetTotalYear(string ps, object year)
        {
            cmd = new SqlCommand(ps, _GA.cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@an", year);
            SqlParameter p = new SqlParameter("@SUM", SqlDbType.Int);
            p.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(p);
            cnx.Open();
            cmd.ExecuteScalar();
            cnx.Close();
            return p.Value;
        }
    }
}
