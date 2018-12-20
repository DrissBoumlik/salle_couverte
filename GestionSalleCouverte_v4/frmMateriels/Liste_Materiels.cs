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

using System.IO;
namespace GestionSalleCouverte
{
    public partial class Liste_Materiels : Form
    {
        public Liste_Materiels()
        {
            InitializeComponent();
        }
        //SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\Gestion de Materiels\Gestion_Materiels.mdf;Integrated Security=True;User Instance=True");
        SqlConnection cn = new SqlConnection(_GA.strCnx); 
        SqlDataAdapter da;
        byte[] img;
        
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        private void Liste_Materiels_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            da = new SqlDataAdapter("select * from Emplacement", cn);
            da.Fill(ds,"Emplacement");
            comboBox3.DisplayMember = "emplac";
            comboBox3.ValueMember = "id_emp";
            comboBox3.DataSource = ds.Tables["Emplacement"];
            //categorie
            da = new SqlDataAdapter("select * from Categorie", cn);
            da.Fill(ds, "Categorie");
            comboBox2.DisplayMember = "cat";
            comboBox2.ValueMember = "id_cat";
            comboBox2.DataSource = ds.Tables["Categorie"];
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox5.SelectedIndex = 0;
            da = new SqlDataAdapter("select * from Materiel", cn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns.Remove("img");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           // dt.Clear();
            if (comboBox1.Focused)
            {
                dt.Clear();
                dt2.Clear();
                if (comboBox1.SelectedIndex == 1) comboBox2.Enabled = true;
                else comboBox2.Enabled = false;
                if (comboBox1.SelectedIndex == 2) comboBox3.Enabled = true;
                else comboBox3.Enabled = false;
                if (comboBox1.SelectedIndex == 0)
                {
                    da = new SqlDataAdapter("select * from Materiel", cn);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //  dataGridView1.Columns.Remove("img");
                }
                if (comboBox1.SelectedIndex == 3)
                {
                 //   da = new SqlDataAdapter("select * from Materiel where nb_mat_retrait>0", cn);
                    da = new SqlDataAdapter(@"SELECT  dbo.MatRetire.id_mat, dbo.MatRetire.qt_ret AS [Quantite Retirée],
                    dbo.MatRetire.date_retrait AS [Date Retrait],
                    dbo.Materiel.nom_element, dbo.Materiel.description_mat, dbo.Materiel.fabriquant,
                    dbo.Materiel.modele, dbo.Materiel.img
                       FROM   dbo.Materiel INNER JOIN
                      dbo.MatRetire ON dbo.Materiel.id_mat = dbo.MatRetire.id_mat", cn);
                    da.Fill(dt2);
                    dataGridView1.DataSource = dt2;

                    dataGridView1.Columns.Remove("img");
                }
                if (comboBox1.SelectedIndex == 4)
                { comboBox5.Enabled = true; numericUpDown1.Enabled = true; }
                else { comboBox5.Enabled = false; numericUpDown1.Enabled = false; }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Focused)
            {
                dt.Clear();
                da = new SqlDataAdapter("select * from Materiel where id_cat=@cat", cn);
                da.SelectCommand.Parameters.AddWithValue("@cat", comboBox2.SelectedValue);
                da.Fill(dt);
               // dt.Columns.Remove("img");
                dataGridView1.DataSource = dt;
                //dataGridView1.Columns.Remove("img");
               // ((DataGridViewImageColumn)dataGridView1.Columns["img"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Focused)
            {
                dt.Clear();
                da = new SqlDataAdapter("select * from Materiel where id_emp=@emp", cn);
                da.SelectCommand.Parameters.AddWithValue("@emp", comboBox3.SelectedValue);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
               // dataGridView1.Columns.Remove("img");
            }
        }
        DataView dv;
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(dt);
            if (comboBox1.SelectedIndex == 3)
            { dv = new DataView(dt2); }
            string w = "nom_element like '" + textBox8.Text + "%'";
            dv.RowFilter = w;
            dataGridView1.DataSource = dv;
           // dataGridView1.Columns.Remove("img");
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dt.Clear();
            da = new SqlDataAdapter("select * from Materiel where datepart(month,date_dacqui)=@cat and datepart(year,date_dacqui)=@cat2", cn);
            da.SelectCommand.Parameters.AddWithValue("@cat", comboBox5.SelectedIndex + 1);
            da.SelectCommand.Parameters.AddWithValue("@cat2", numericUpDown1.Value);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           // dataGridView1.Columns.Remove("img");
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Focused)
            {
                dt.Clear();
                da = new SqlDataAdapter("select * from Materiel where datepart(month,date_dacqui)=@cat and datepart(year,date_dacqui)=@cat2", cn);
                da.SelectCommand.Parameters.AddWithValue("@cat", comboBox5.SelectedIndex + 1);
                da.SelectCommand.Parameters.AddWithValue("@cat2", numericUpDown1.Value);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
               // dataGridView1.Columns.Remove("img");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                
         
        }

        private void Liste_Materiels_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuApp.l = null;
        }
        DataRow[] m;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            
            try {// img = (byte[])dt.Rows[dataGridView1.CurrentRow.Index]["img"];
                m = dt.Select("id_mat=" + dataGridView1.CurrentRow.Cells[0].Value.ToString());
                img = (byte[])m[0]["img"];
           }
            catch {  }
            try {  dt3 = dv.ToTable();
            if (dt3.Rows.Count > 0)
            {
               // img = (byte[])dt3.Rows[dataGridView1.CurrentRow.Index]["img"];
                m = dt3.Select("id_mat=" + dataGridView1.CurrentRow.Cells[0].Value.ToString());
                img = (byte[])m[0]["img"];
            }
            }
            catch { }
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
          
         
        }
        //Bitmap bitmap;
        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(bitmap, 0, 0);
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.printDocument1.DefaultPageSettings.Landscape = true;
        //    //Resize DataGridView to full height.
        //    int height = dataGridView1.Height;
        //    dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;

        //    //Create a Bitmap and draw the DataGridView on it.
        //    bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
        //    dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

        //    //Resize DataGridView back to original height.
        //    dataGridView1.Height = height;

        //    //Show the Print Preview Dialog.
        //    printPreviewDialog1.Document = printDocument1;
        //    printPreviewDialog1.PrintPreviewControl.Zoom = 1;
        //    printPreviewDialog1.ShowDialog();
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            try { dataGridView1.Columns.Remove("id_emp"); dataGridView1.Columns.Remove("id_cat"); }
            catch { }
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Liste de Materiels";

            printer.SubTitle = comboBox1.Text;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "جمعية الرعاية والاسعاف - سلا";

            printer.FooterSpacing = 15;

            printer.PageSettings.Landscape=true;

            printer.PrintDataGridView(dataGridView1);

        }
    }
}
