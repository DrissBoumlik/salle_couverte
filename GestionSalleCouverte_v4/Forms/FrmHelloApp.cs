using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GestionSalleCouverte.Classes;
//using Microsoft.WindowsAPICodePack.Taskbar;


namespace GestionSalleCouverte.Forms
{
    public partial class FrmHelloApp : Form
    {
        public FrmHelloApp()
        {
            InitializeComponent();
            _GA.cnx = new SqlConnection(_GA.strCnx);
            progressBar1.Visible = true;
        }

        private int i = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                //if (!_GA.Open())
                //{
                //    timer1.Enabled = false;
                //}
                const int max = 100;

                if (i < max)
                {
                    progressBar1.Value += _GA.increment;
                    //TaskbarManager.Instance.SetProgressValue(i, max - _GA.increment, this.Handle);
                    System.Threading.Thread.Sleep(100);
                    i += _GA.increment;
                    if (i < 75)
                    {
                        if (label2.Text.Length <= 16)
                            label2.Text += " .";
                        else label2.Text = "Chargement .";
                    }
                    else label2.Text = "Donnée Chargés";
                }
                else
                {
                    //prog.SetProgressState(TaskbarProgressBarState.Normal);
                    timer1.Enabled = false;
                    this.Hide();
                    _GA.currentForm = new frmLogIn();
                    _GA.currentForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //_GA.CatchException(ex, "");
            }
        }
    }
}
