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
    public partial class Produit : Form
    {
        public Produit()
        {
            InitializeComponent();

        }
       // string str = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
        //SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString() + @"\Gestion de Materiels\Gestion_Materiels.mdf;Integrated Security=True;User Instance=True");
        SqlConnection cn = new SqlConnection(_GA.strCnx);

        SqlDataAdapter da;
        SqlCommand cmd;
       public static int nb_qt,id_mat,qt_encours;
        string imgloc;
        DataSet ds=new DataSet ();
        public BindingManagerBase bg;
        private void Form1_Load(object sender, EventArgs e)
        {
          // MessageBox.Show( Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString());
            load();
        }

        //public static void r() {  this.Refresh();   }
        public void load()
        {

            //categorie
            da = new SqlDataAdapter("select * from Categorie", cn);
            try { da.Fill(ds, "Categorie"); }
            catch { MessageBox.Show("Veuillez Redemarer votre Application");}
            comboBox1.DisplayMember = "cat";
            comboBox1.ValueMember = "id_cat";
            comboBox1.DataSource = ds.Tables["Categorie"];
            ////emplacement
            da = new SqlDataAdapter("select * from Emplacement", cn);
            da.Fill(ds, "Emplacement");
            comboBox3.DisplayMember = "emplac";
            comboBox3.ValueMember = "id_emp";
            comboBox3.DataSource = ds.Tables["Emplacement"];

            comboBox2.SelectedIndex = 0;
            //binding
            da = new SqlDataAdapter("select * from Materiel", cn);
            da.Fill(ds, "Materiel");
            bg = this.BindingContext[ds.Tables["Materiel"]];
            textBox1.DataBindings.Add("Text", ds.Tables["Materiel"], "nom_element");
            textBox2.DataBindings.Add("Text", ds.Tables["Materiel"], "description_mat");
            comboBox1.DataBindings.Add("SelectedValue", ds.Tables["Materiel"], "id_cat");
            comboBox2.DataBindings.Add("Text", ds.Tables["Materiel"], "condition");
            dateTimePicker1.DataBindings.Add("Value", ds.Tables["Materiel"], "date_dacqui");
            textBox3.DataBindings.Add("Text", ds.Tables["Materiel"], "prix_achat");
            textBox4.DataBindings.Add("Text", ds.Tables["Materiel"], "quantite");
            comboBox3.DataBindings.Add("SelectedValue", ds.Tables["Materiel"], "id_emp");
            textBox5.DataBindings.Add("Text", ds.Tables["Materiel"], "fabriquant");
            textBox6.DataBindings.Add("Text", ds.Tables["Materiel"], "modele");
            textBox7.DataBindings.Add("Text", ds.Tables["Materiel"], "commentaire");
            pictureBox1.DataBindings.Add("Image", ds.Tables["Materiel"], "img", true);
            label14.DataBindings.Add("Text", ds.Tables["Materiel"], "nb_mat_encours");
            label16.DataBindings.Add("Text", ds.Tables["Materiel"], "nb_mat_retrait");
            label19.DataBindings.Add("Text", ds.Tables["Materiel"], "id_mat");
            textBox10.DataBindings.Add("Text", ds.Tables["Materiel"], "ref_facture");
            textBox9.DataBindings.Add("Text", ds.Tables["Materiel"], "fournisseur");
            dateTimePicker2.DataBindings.Add("Value", ds.Tables["Materiel"], "date_paiement");


            if (label14.Text == "0") button3.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.gif, *.png, *.bmp) | *.jpg; *.jpeg; *.jpe; *.gif; *.png; *bmp";
            of.Title = "Selectionnez votre image";
            if (of.ShowDialog() == DialogResult.OK)
            {
                imgloc = of.FileName.ToString();
                pictureBox1.ImageLocation = imgloc;
            
            
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox4.Text == null || textBox4.Text == "" || textBox4.Text=="0") MessageBox.Show("Veulliez entrer le nom de votre Produit et son Quantite");
            else
            {
                byte[] img = null;
                if (pictureBox1.Image == null) MessageBox.Show("Vous devez choisir une image");
                else
                {
                  DialogResult dr = MessageBox.Show("Voulez-vous vraiment ajouter ce Materiel ?","Attention!", MessageBoxButtons.YesNo);
                  if (dr == DialogResult.Yes)
                  {
                      FileStream fs = new FileStream(imgloc, FileMode.OpenOrCreate, FileAccess.Read);
                      BinaryReader br = new BinaryReader(fs);
                      img = br.ReadBytes((int)fs.Length);

                      cmd = new SqlCommand("insert into Materiel values(@nom,@des,@cat,@condi,@date,@prix,@qt,@emplac,@fabri,@modele,@com,@nb_ret,@nb_encours,@img,@four,@datep,@ref)", cn);
                      cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                      cmd.Parameters.AddWithValue("@des", textBox2.Text);
                      cmd.Parameters.AddWithValue("@cat", comboBox1.SelectedValue);
                      cmd.Parameters.AddWithValue("@condi", comboBox2.SelectedItem.ToString());
                      cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                      cmd.Parameters.AddWithValue("@prix", textBox3.Text);
                      cmd.Parameters.AddWithValue("@qt", textBox4.Text);
                      cmd.Parameters.AddWithValue("@emplac", comboBox3.SelectedValue);
                      cmd.Parameters.AddWithValue("@fabri", textBox5.Text);
                      cmd.Parameters.AddWithValue("@modele", textBox6.Text);
                      cmd.Parameters.AddWithValue("@com", textBox7.Text);
                      cmd.Parameters.AddWithValue("@nb_ret", 0);
                      cmd.Parameters.AddWithValue("@nb_encours", textBox4.Text);
                      cmd.Parameters.AddWithValue("@img", img);
                      cmd.Parameters.AddWithValue("@datep", dateTimePicker2.Value);
                      cmd.Parameters.AddWithValue("@four", textBox9.Text);
                      cmd.Parameters.AddWithValue("@ref", textBox10.Text);

                      cn.Open();
                      cmd.ExecuteNonQuery();
                      cn.Close();
                      MessageBox.Show("Votre Nouveau(x) Materiel(s) a/ont été bien enregistré");
                      textBox10.Clear(); textBox9.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); dateTimePicker1.Value = DateTime.Now;
                      pictureBox1.ImageLocation = null;
                      pictureBox1.Image = null;
                  }
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bg.Position++;
            if (label14.Text == "0") button3.Visible = false;
            else button3.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bg.Position--;
            if (label14.Text == "0") button3.Visible = false;
            else button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

                nb_qt = int.Parse(textBox4.Text);
                id_mat = int.Parse(label19.Text);
                qt_encours = int.Parse(label14.Text);
                Etat_Materielcs fd = new Etat_Materielcs();
                fd.Show();
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(ds.Tables["Materiel"]);
            string w = "nom_element like '" + textBox8.Text + "%'";
            dv.RowFilter = w;
          //  clearload();
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            label14.DataBindings.Clear();
            label16.DataBindings.Clear();
            label19.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox10.DataBindings.Clear();
            textBox9.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            dateTimePicker2.DataBindings.Clear();
            comboBox3.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
            comboBox2.DataBindings.Clear();
            textBox1.DataBindings.Add("Text", dv, "nom_element");
            textBox2.DataBindings.Add("Text", dv, "description_mat");
            textBox10.DataBindings.Add("Text", dv, "ref_facture");
            textBox9.DataBindings.Add("Text", dv, "fournisseur");
            comboBox1.DataBindings.Add("SelectedValue", dv, "id_cat");
            comboBox2.DataBindings.Add("Text", dv, "condition");
            dateTimePicker1.DataBindings.Add("Value", dv, "date_dacqui");
            dateTimePicker2.DataBindings.Add("Value", dv, "date_paiement");
            textBox3.DataBindings.Add("Text", dv, "prix_achat");
            textBox4.DataBindings.Add("Text", dv, "quantite");
            comboBox3.DataBindings.Add("SelectedValue", dv, "id_emp");
            textBox5.DataBindings.Add("Text", dv, "fabriquant");
            textBox6.DataBindings.Add("Text", dv, "modele");
            textBox7.DataBindings.Add("Text", dv, "commentaire");
            pictureBox1.DataBindings.Add("Image", dv, "img", true);
            label14.DataBindings.Add("Text", dv, "nb_mat_encours");
            label16.DataBindings.Add("Text", dv, "nb_mat_retrait");
            label19.DataBindings.Add("Text", dv, "id_mat");
            bg = this.BindingContext[dv];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Voulez-vous vraiment annuler ? tous les champs seront effaccés","Attention!", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); dateTimePicker1.Value = DateTime.Now;
                pictureBox1.ImageLocation = null;
                textBox10.Clear(); textBox9.Clear();

                pictureBox1.Image = null;
            }
        }

        private void ajouterUnNouveauMaterielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            button3.Visible = false;
            textBox4.Enabled = true;
            textBox1.Focus();
            button8.Visible = false;
            label13.Visible = true; button1.Visible = true; button4.Visible = true; button2.Visible = true; label19.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = true;
            textBox10.Clear(); textBox9.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear(); textBox7.Clear(); dateTimePicker1.Value = DateTime.Now;
            pictureBox1.ImageLocation = null;
            label14.Text = ""; label16.Text = "";
            pictureBox1.Image = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            label13.Visible = false; button1.Visible = false; button4.Visible = false; button2.Visible = false; label19.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = false;
            //bg.Position = 1;
            textBox4.Enabled = true;
            button8.Visible = false;
            clearload();
            load();
        }

        private void modifierUnMaterielToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Enabled = false;
            button3.Visible = true;
            label13.Visible = true; button1.Visible = true;
            button4.Visible = false; button2.Visible = false; label19.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox1.Text == "" || textBox4.Text == null || textBox4.Text == "") MessageBox.Show("Veulliez entrer le nom de votre Produit et son Quantite");
            else
            {
                 DialogResult dr = MessageBox.Show("Voulez-vous vraiment modifier ?","Attention!", MessageBoxButtons.YesNo);
                 if (dr == DialogResult.Yes)
                 {
                     if (pictureBox1.ImageLocation == null)
                         cmd = new SqlCommand("update Materiel set nom_element=@nom,description_mat=@des,id_cat=@cat,condition=@condi,date_dacqui=@date,prix_achat=@prix,id_emp=@emplac,fabriquant=@fabri,modele=@modele,commentaire=@com,fournisseur=@four,date_paiement=@datep,ref_facture=@ref where id_mat=@id", cn);
                     else
                     {
                         cmd = new SqlCommand("update Materiel set nom_element=@nom,description_mat=@des,id_cat=@cat,condition=@condi,date_dacqui=@date,prix_achat=@prix,id_emp=@emplac,fabriquant=@fabri,modele=@modele,commentaire=@com,img=@img,fournisseur=@four,date_paiement=@datep,ref_facture=@ref where id_mat=@id", cn);
                         byte[] img = null;
                         FileStream fs = new FileStream(imgloc, FileMode.OpenOrCreate, FileAccess.Read);
                         BinaryReader br = new BinaryReader(fs);
                         img = br.ReadBytes((int)fs.Length);
                         cmd.Parameters.AddWithValue("@img", img);

                     }
                     cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                     cmd.Parameters.AddWithValue("@id", label19.Text);
                     cmd.Parameters.AddWithValue("@des", textBox2.Text);
                     cmd.Parameters.AddWithValue("@cat", comboBox1.SelectedValue);
                     cmd.Parameters.AddWithValue("@condi", comboBox2.SelectedItem.ToString());
                     cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                     cmd.Parameters.AddWithValue("@prix", textBox3.Text);

                     cmd.Parameters.AddWithValue("@emplac", comboBox3.SelectedValue);
                     cmd.Parameters.AddWithValue("@fabri", textBox5.Text);
                     cmd.Parameters.AddWithValue("@modele", textBox6.Text);
                     cmd.Parameters.AddWithValue("@com", textBox7.Text);
                     cmd.Parameters.AddWithValue("@datep", dateTimePicker2.Value);
                     cmd.Parameters.AddWithValue("@four", textBox9.Text);
                     cmd.Parameters.AddWithValue("@ref", textBox10.Text);
                     cn.Open();
                     cmd.ExecuteNonQuery();
                     cn.Close();
                     MessageBox.Show("Votre Nouveau(x) Materiel(s) a/ont été bien Modifiés");
                 }
            }
           // textBox4.Enabled = true;
               
        }

        private void ajoutezModifierUneCategorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ajoutez_Modifier_une_Categorie aj = new Ajoutez_Modifier_une_Categorie();
            aj.Show();
        }

        private void ajoutezModifierUnEmplacementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ajoutez_Modifier_un_emplacement d = new Ajoutez_Modifier_un_emplacement();
            d.Show();
        }

        private void listeDesMaterielsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Liste_Materiels l = new Liste_Materiels();
            l.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void clearload()
        {
            textBox9.DataBindings.Clear();
            textBox10.DataBindings.Clear();
            dateTimePicker2.DataBindings.Clear();
            textBox1.DataBindings.Clear();
            textBox2.DataBindings.Clear();
            textBox3.DataBindings.Clear();
            label14.DataBindings.Clear();
            label16.DataBindings.Clear();
            label19.DataBindings.Clear();
            textBox4.DataBindings.Clear();
            textBox5.DataBindings.Clear();
            textBox6.DataBindings.Clear();
            textBox7.DataBindings.Clear();
            pictureBox1.DataBindings.Clear();
            dateTimePicker1.DataBindings.Clear();
            comboBox3.DataBindings.Clear();
            comboBox1.DataBindings.Clear();
            comboBox2.DataBindings.Clear();
            ds.Tables["Materiel"].Clear();
            ds.Tables["Emplacement"].Clear();
            ds.Tables["Categorie"].Clear();
        }

        public void combo() {

            ds.Tables["Emplacement"].Clear();
            ds.Tables["Categorie"].Clear();

            da = new SqlDataAdapter("select * from Categorie", cn);
            try { da.Fill(ds, "Categorie"); }
            catch { MessageBox.Show("Veuillez Redemarer votre Application"); }
            comboBox1.DisplayMember = "cat";
            comboBox1.ValueMember = "id_cat";
            comboBox1.DataSource = ds.Tables["Categorie"];
            ////emplacement
            da = new SqlDataAdapter("select * from Emplacement", cn);
            da.Fill(ds, "Emplacement");
            comboBox3.DisplayMember = "emplac";
            comboBox3.ValueMember = "id_emp";
            comboBox3.DataSource = ds.Tables["Emplacement"];

            comboBox2.SelectedIndex = 0;
        
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //about b = new about();
            //b.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuApp.f = null;
        }

        //private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Up) bg.Position++;
        //}
       

       
    }
}
