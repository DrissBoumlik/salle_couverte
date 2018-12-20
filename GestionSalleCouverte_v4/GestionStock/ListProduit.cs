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
    public partial class ListProduit : Form
    {
        public ListProduit()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(_GA.strCnx);
        SqlDataAdapter da;
        byte[] img;
        DataView dv;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        private void ListProduit_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //categorie
            da = new SqlDataAdapter("select * from ProdCategorie", cn);
            da.Fill(ds, "Categorie");
            comboBox2.DisplayMember = "cat";
            comboBox2.ValueMember = "id_cat";
            comboBox2.DataSource = ds.Tables["Categorie"];
            comboBox2.Enabled = false;
           
            comboBox5.SelectedIndex = 0;
            da = new SqlDataAdapter("select * from Produit", cn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns.Remove("img");

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            dv = new DataView(dt);
            if (comboBox1.SelectedIndex == 3 || comboBox1.SelectedIndex == 2)
            { dv = new DataView(dt2); }
            string w = "nom_element like '" + textBox8.Text + "%'";
            dv.RowFilter = w;
            dataGridView1.DataSource = dv;
            dataGridView1.Columns.Remove("img");

        }
        DataRow[] m;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
               // img = (byte[])dt.Rows[dataGridView1.CurrentRow.Index]["img"];
                m = dt.Select("id_prod=" + dataGridView1.CurrentRow.Cells[0].Value.ToString());
                img = (byte[])m[0]["img"];
            }
            catch { }
            try
            {
                dt3 = dv.ToTable();
                if (dt3.Rows.Count > 0)
                //dataGridView1.CurrentRow.Cells[0].Value.ToString()
                {
                    m = dt3.Select("id_prod=" + dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    img = (byte[])m[0]["img"];
                }
                  //  img = (byte[])dt3.Rows[dataGridView1.CurrentRow.Cells[0]]["img"];
            }
            catch { }
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Focused)
            {
                
                if (comboBox1.SelectedIndex == 1) { numericUpDown1.Enabled = false; comboBox5.Enabled = false; comboBox2.Enabled = true; }
              //  else comboBox2.Enabled = false;
                else if (comboBox1.SelectedIndex == 3) { numericUpDown1.Enabled = true; comboBox5.Enabled = true; comboBox2.Enabled = false; }
                else {numericUpDown1.Enabled = false; comboBox5.Enabled = false; comboBox2.Enabled = false;}
                if (comboBox1.SelectedIndex == 2) {
                    dt2.Clear();
                    da = new SqlDataAdapter(@"SELECT dbo.SortieProd.id_prod, dbo.Produit.nom_element, dbo.Produit.descri_prod, dbo.SortieProd.qt_sortie AS [Quantite Sortie], dbo.Produit.unit, dbo.SortieProd.date_sortie AS [Date Sortie], 
                      dbo.SortieProd.livreur, dbo.SortieProd.observation, dbo.Produit.img FROM dbo.SortieProd INNER JOIN dbo.Produit ON dbo.SortieProd.id_prod = dbo.Produit.id_prod", cn);
                    da.Fill(dt2);
                    dataGridView1.DataSource = dt2;
                    try { dataGridView1.Columns.Remove("img"); }
                    catch { }
                }
                if (comboBox1.SelectedIndex == 0) {
                    dt.Clear();
                    da = new SqlDataAdapter("select * from Produit", cn);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    try { dataGridView1.Columns.Remove("img"); }
                    catch { }
                }
            
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Focused)
            {
                dt.Clear();
                da = new SqlDataAdapter("select * from Produit where id_cat=@cat", cn);
                da.SelectCommand.Parameters.AddWithValue("@cat", comboBox2.SelectedValue);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.Focused) {
                dt2.Clear();
                da = new SqlDataAdapter(@"SELECT dbo.SortieProd.id_prod, dbo.Produit.nom_element, dbo.Produit.descri_prod, dbo.SortieProd.qt_sortie AS [Quantite Sortie], dbo.Produit.unit, dbo.SortieProd.date_sortie AS [Date Sortie], 
                      dbo.SortieProd.livreur, dbo.SortieProd.observation, dbo.Produit.img FROM dbo.SortieProd INNER JOIN dbo.Produit ON dbo.SortieProd.id_prod = dbo.Produit.id_prod
where datepart(month,date_sortie)=@cat and datepart(year,date_sortie)=@cat2", cn);
                da.SelectCommand.Parameters.AddWithValue("@cat", comboBox5.SelectedIndex + 1);
                da.SelectCommand.Parameters.AddWithValue("@cat2", numericUpDown1.Value);
                da.Fill(dt2);
                dataGridView1.DataSource = dt2;
                try { dataGridView1.Columns.Remove("img"); }
                catch { }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dt2.Clear();
            da = new SqlDataAdapter(@"SELECT dbo.SortieProd.id_prod, dbo.Produit.nom_element, dbo.Produit.descri_prod, dbo.SortieProd.qt_sortie AS [Quantite Sortie], dbo.Produit.unit, dbo.SortieProd.date_sortie AS [Date Sortie], 
                      dbo.SortieProd.livreur, dbo.SortieProd.observation, dbo.Produit.img FROM dbo.SortieProd INNER JOIN dbo.Produit ON dbo.SortieProd.id_prod = dbo.Produit.id_prod
where datepart(month,date_sortie)=@cat and datepart(year,date_sortie)=@cat2", cn);
            da.SelectCommand.Parameters.AddWithValue("@cat", comboBox5.SelectedIndex + 1);
            da.SelectCommand.Parameters.AddWithValue("@cat2", numericUpDown1.Value);
            da.Fill(dt2);
            dataGridView1.DataSource = dt2;
            //dataGridView1.Columns.Remove("img");
        }

        private void ListProduit_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestionStock.l = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try { dataGridView1.Columns.Remove("id_emp"); dataGridView1.Columns.Remove("id_cat"); }
            //catch { }
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "Liste de Produits";

            printer.SubTitle = comboBox1.Text;

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                                          StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "جمعية الرعاية والاسعاف - سلا";

            printer.FooterSpacing = 15;

            printer.PageSettings.Landscape = true;

            printer.PrintDataGridView(dataGridView1);

        }
    }
}
