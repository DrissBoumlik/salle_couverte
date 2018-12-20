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

namespace GestionSalleCouverte
{
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            _GA.cnx = new SqlConnection(_GA.strCnx);
        }

        private DataSet ds = new DataSet();
        DataTable dttotal = new DataTable();
        int nbrinscri=0, nbrreinscri=0;
        double mtcoti = 0, mtadh = 0, tt = 0, tt2=0;
        double totalmat, totalprod, totaldep;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Finance_Load(object sender, EventArgs e)
        {
            _GA.cnx.Open();
            comboBox6.SelectedIndex = 0; comboBox7.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0; comboBox5.SelectedIndex = 0; comboBox3.SelectedIndex = 0; comboBox4.SelectedIndex = 0;
            _GA.da = new SqlDataAdapter("select Id_Dcpln from Discipline", _GA.cnx);
            _GA.da.Fill(ds, "ds");
            DataRow r1 = ds.Tables["ds"].NewRow();
            DataRow r2 = ds.Tables["ds"].NewRow();
            DataRow r3 = ds.Tables["ds"].NewRow();
            r1[0] = "Mini-Foot";
            r2[0] = "Basket";
            r3[0] = "TOUS";
            ds.Tables["ds"].Rows.Add(r1);
            ds.Tables["ds"].Rows.Add(r2);
            ds.Tables["ds"].Rows.Add(r3);
            comboBox2.DisplayMember = "Id_Dcpln";
            comboBox2.ValueMember = "Id_Dcpln";
            comboBox2.DataSource = ds.Tables["ds"];
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            Crec();
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            { comboBox5.Visible = true; label18.Text = "Statistique Globale du Mois "; }
            else
            { comboBox5.Visible = false; label18.Text = "Statistique Globale de L'annee "; }

            Crec();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CMat();
        }

        private void CMat()
        {

            try { ds.Tables["Mat"].Clear(); }
            catch { }
            try { ds.Tables["Prod"].Clear(); }
            catch { }
            if (comboBox3.SelectedIndex == 0)
            {
                _GA.da = new SqlDataAdapter("select sum(quantite),sum(prix_achat * quantite) from Materiel where MONTH(Materiel.date_dacqui)=@m and year( Materiel.date_dacqui)=@an", _GA.cnx);
                _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox4.SelectedIndex + 1);
                _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown2.Value);
                _GA.da.Fill(ds, "Mat");
                label13.Text = ds.Tables["Mat"].Rows[0][0].ToString();
                if (ds.Tables["Mat"].Rows[0][1] != DBNull.Value)
                totalmat = double.Parse(ds.Tables["Mat"].Rows[0][1].ToString());

               else { totalmat = 0; } label2.Text = totalmat + " DH";
                _GA.da = new SqlDataAdapter("select sum(prix_achat) from Produit where MONTH(Produit.date_dacqui)=@m and year( Produit.date_dacqui)=@an", _GA.cnx);
                _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox4.SelectedIndex + 1);
                _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown2.Value);
                _GA.da.Fill(ds, "Prod");
                if (ds.Tables["Prod"].Rows[0][0] != DBNull.Value)
                totalprod = double.Parse(ds.Tables["Prod"].Rows[0][0].ToString());
               else totalprod = 0;
                label26.Text = totalprod + " DH";
                    totaldep = totalmat + totalprod;
                label28.Text = totaldep+ " DH";
            }
            else if (comboBox3.SelectedIndex == 1)
            {

                _GA.da = new SqlDataAdapter("select sum(quantite),sum(prix_achat * quantite) from Materiel where year( Materiel.date_dacqui)=@an", _GA.cnx);
                //  _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox4.SelectedIndex + 1);
                _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown2.Value);
                _GA.da.Fill(ds, "Mat");
                label13.Text = ds.Tables["Mat"].Rows[0][0].ToString();
                if (ds.Tables["Mat"].Rows[0][1] != DBNull.Value)
                    totalmat = double.Parse(ds.Tables["Mat"].Rows[0][1].ToString());

                else { totalmat = 0; } label2.Text = totalmat + " DH";
                _GA.da = new SqlDataAdapter("select sum(prix_achat) from Produit where year( Produit.date_dacqui)=@an", _GA.cnx);
               // _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox4.SelectedIndex + 1);
                _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown2.Value);
                _GA.da.Fill(ds, "Prod");
                if (ds.Tables["Prod"].Rows[0][0] != DBNull.Value)
                    totalprod = double.Parse(ds.Tables["Prod"].Rows[0][0].ToString());
                else totalprod = 0;
                label26.Text = totalprod + " DH";
                totaldep = totalmat + totalprod;
                label28.Text = totaldep + " DH";


            }
        
        
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == 0) comboBox4.Visible = true;
            else comboBox4.Visible = false;
            CMat();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            CMat();
        }

        private void Crec()
        {
            nbrinscri = 0; nbrreinscri = 0;
            mtcoti = 0; mtadh = 0;
            try { ds.Tables["Dsf"].Clear();  }
            catch { }
            try { ds.Tables["DsAn"].Clear(); }
            catch { }
            if (comboBox2.SelectedValue == "TOUS")
                label17.Text = total2().ToString()+" DH";
            else
            {
              
                groupBox5.Visible = false;
                nbrinscri = 0; nbrreinscri = 0;
                mtcoti = 0; mtadh = 0;
              
                    if (comboBox1.SelectedIndex == 0)
                    {

                        if (comboBox2.SelectedValue == "Mini-Foot" || comboBox2.SelectedValue == "Basket")
                        {
                            groupBox1.Visible = false; groupBox2.Visible = false; groupBox3.Visible = true; 
                            _GA.da = new SqlDataAdapter("select count(num_reserv),sum(montant) from Reservation where MONTH( Reservation.date_reserv)=@m and type_reserv=@id_dcpln and year( Reservation.date_reserv)=@an", _GA.cnx);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@id_dcpln", comboBox2.SelectedValue);
                            try { _GA.da.Fill(ds, "Dsf"); }
                            catch { }
                         
                                label11.Text = ds.Tables["Dsf"].Rows[0][0].ToString();
                                label9.Text = ds.Tables["Dsf"].Rows[0][1].ToString() + " DH";
                            

                        }
                        else
                        {
                            groupBox1.Visible = true; groupBox2.Visible = true; groupBox3.Visible = false;
                            _GA.da = new SqlDataAdapter("select * from V_Recette where MONTH([DATE PAIEMENT])=@m and YEAR([DATE PAIEMENT])=@an and [Dcpln]=@id_dcpln", _GA.cnx);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@id_dcpln", comboBox2.SelectedValue);
                            try { _GA.da.Fill(ds, "DsAn"); }
                            catch { }
                            //dataGridView1.DataSource = ds.Tables["DsAn"];
                            try
                            {
                                if (ds.Tables["DsAn"].Rows.Count > 0)
                                {
                                    foreach (DataRow r in ds.Tables["DsAn"].Rows)
                                    {
                                        mtcoti += double.Parse(r["cotisation"].ToString());
                                        mtadh += double.Parse(r["FRAIS ADHESION"].ToString());
                                        if (r["critere"].ToString() == "Inscription") { nbrinscri++; }
                                        else nbrreinscri++;

                                    }
                                }
                            }
                            catch{}
                            //else { lblTotAdh.Text=""; lblMtAdhs.Text=""; lblMtTot.Text=""; lblIns.Text=""; lblTotAdh.Text=""; lblReIns.Text="";}
                         

                            lblMtCotis.Text = mtcoti.ToString() + " DH";
                            lblMtAdhs.Text = mtadh.ToString() + " DH";
                            lblMtTot.Text = (mtcoti + mtadh).ToString() + " DH";
                            lblIns.Text = nbrinscri.ToString();
                            lblReIns.Text = nbrreinscri.ToString();
                            lblTotAdh.Text = (nbrinscri + nbrreinscri).ToString();
                        }
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {

                        if (comboBox2.SelectedValue == "Mini-Foot" || comboBox2.SelectedValue == "Basket")
                        {
                            groupBox1.Visible = false; groupBox2.Visible = false; groupBox3.Visible = true;
                            _GA.da = new SqlDataAdapter("select count(num_reserv),sum(montant) from Reservation where type_reserv=@id_dcpln and year( Reservation.date_reserv)=@an", _GA.cnx);
                            // _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@id_dcpln", comboBox2.SelectedValue);
                            try { _GA.da.Fill(ds, "Dsf"); }
                            catch { }
                            label11.Text = ds.Tables["Dsf"].Rows[0][0].ToString();
                            label9.Text = ds.Tables["Dsf"].Rows[0][1].ToString() + " DH";

                        }
                        else
                        {
                            groupBox1.Visible = true; groupBox2.Visible = true; groupBox3.Visible = false;
                            _GA.da = new SqlDataAdapter("select * from V_Recette where YEAR([DATE PAIEMENT])=@an and [Dcpln]=@id_dcpln", _GA.cnx);
                            // _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                            _GA.da.SelectCommand.Parameters.AddWithValue("@id_dcpln", comboBox2.SelectedValue);
                            try { _GA.da.Fill(ds, "DsAn"); }
                            catch { }
                            //  dataGridView1.DataSource = ds.Tables["DsAn"];
                            if (ds.Tables["DsAn"].Rows.Count > 0)
                            {
                                foreach (DataRow r in ds.Tables["DsAn"].Rows)
                                {
                                    mtcoti += double.Parse(r["cotisation"].ToString());
                                    mtadh += double.Parse(r["FRAIS ADHESION"].ToString());
                                    if (r["critere"].ToString() == "Inscription") { nbrinscri++; }
                                    else nbrreinscri++;

                                }
                            }
                           // else { lblTotAdh.Text=""; lblMtAdhs.Text=""; lblMtTot.Text=""; lblIns.Text=""; lblTotAdh.Text=""; lblReIns.Text="";}
                            lblMtCotis.Text = mtcoti.ToString() + " DH";
                            lblMtAdhs.Text = mtadh.ToString() + " DH";
                            lblMtTot.Text = (mtcoti + mtadh).ToString() + " DH";
                            lblIns.Text = nbrinscri.ToString();
                            lblReIns.Text = nbrreinscri.ToString();
                            lblTotAdh.Text = (nbrinscri + nbrreinscri).ToString();
                        }
                          
                        }
                    


               

            
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Crec();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Crec();
        }
        object tot;
        private double DepenceTotal()
        {
            try { ds.Tables["Mat"].Clear(); }
            catch { }
            try { ds.Tables["Prod"].Clear(); }
            catch { }
            if (comboBox6.SelectedIndex == 0)
            {
                _GA.da = new SqlDataAdapter("select sum(quantite),sum(prix_achat * quantite) from Materiel where MONTH(Materiel.date_dacqui)=@m and year( Materiel.date_dacqui)=@an", _GA.cnx);
                _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox7.SelectedIndex + 1);
                _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown3.Value);
                _GA.da.Fill(ds, "Mat");
                label13.Text = ds.Tables["Mat"].Rows[0][0].ToString();
                if (ds.Tables["Mat"].Rows[0][1] != DBNull.Value)
                    totalmat = double.Parse(ds.Tables["Mat"].Rows[0][1].ToString());

                else { totalmat = 0; } 
                //label2.Text = totalmat + " DH";
                _GA.da = new SqlDataAdapter("select sum(prix_achat) from Produit where MONTH(Produit.date_dacqui)=@m and year( Produit.date_dacqui)=@an", _GA.cnx);
                _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox7.SelectedIndex + 1);
                _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown3.Value);
                _GA.da.Fill(ds, "Prod");
                if (ds.Tables["Prod"].Rows[0][0] != DBNull.Value)
                    totalprod = double.Parse(ds.Tables["Prod"].Rows[0][0].ToString());
                else totalprod = 0;
               // label26.Text = totalprod + " DH";
                totaldep = totalmat + totalprod;
               // label28.Text = totaldep + " DH";
            }
            else if (comboBox6.SelectedIndex == 1)
            {

                _GA.da = new SqlDataAdapter("select sum(quantite),sum(prix_achat * quantite) from Materiel where year( Materiel.date_dacqui)=@an", _GA.cnx);
                //  _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox4.SelectedIndex + 1);
                _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown3.Value);
                _GA.da.Fill(ds, "Mat");
               // label13.Text = ds.Tables["Mat"].Rows[0][0].ToString();
                if (ds.Tables["Mat"].Rows[0][1] != DBNull.Value)
                    totalmat = double.Parse(ds.Tables["Mat"].Rows[0][1].ToString());

                else { totalmat = 0; } 
                //label2.Text = totalmat + " DH";
                _GA.da = new SqlDataAdapter("select sum(prix_achat) from Produit where year( Produit.date_dacqui)=@an", _GA.cnx);
                // _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox4.SelectedIndex + 1);
                _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown3.Value);
                _GA.da.Fill(ds, "Prod");
                if (ds.Tables["Prod"].Rows[0][0] != DBNull.Value)
                    totalprod = double.Parse(ds.Tables["Prod"].Rows[0][0].ToString());
                else totalprod = 0;
              //  label26.Text = totalprod + " DH";
                totaldep = totalmat + totalprod;
               // label28.Text = totaldep + " DH";


            }
            return totaldep;
        }
        private double RecetTotal()
        {

            if (comboBox6.SelectedIndex == 0)
            {
                _GA.cmd = new SqlCommand("select sum(Montant) from charan where idmois=@m and An=@an", _GA.cnx);
                _GA.cmd.Parameters.AddWithValue("@m", comboBox7.SelectedIndex + 1);
                _GA.cmd.Parameters.AddWithValue("@an", numericUpDown3.Value);
                tot = _GA.cmd.ExecuteScalar();
                if (tot != DBNull.Value) tt2 = double.Parse(tot.ToString());
                else tt2 = 0;

            }
            else if (comboBox6.SelectedIndex == 1)
            {
                _GA.cmd = new SqlCommand("select sum(Montant) from charan where An=@an", _GA.cnx);
                // _GA.cmd.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                _GA.cmd.Parameters.AddWithValue("@an", numericUpDown3.Value);
                tot = _GA.cmd.ExecuteScalar();
                if (tot != DBNull.Value) tt2 = double.Parse(tot.ToString());
                else tt2 = 0;
               
            }
            return tt2;
        }
        private double total2()
        {
          //  dttotal.Clear();
            groupBox1.Visible = false; groupBox2.Visible = false; groupBox3.Visible = false; groupBox5.Visible = true;
            if (comboBox1.SelectedIndex == 0)
            {
                _GA.cmd = new SqlCommand("select sum(Montant) from charan where idmois=@m and An=@an", _GA.cnx);
                _GA.cmd.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                _GA.cmd.Parameters.AddWithValue("@an", numericUpDown1.Value);
                tot=  _GA.cmd.ExecuteScalar();
                if (tot != DBNull.Value) tt2 = double.Parse(tot.ToString());
                else tt2 = 0;

                //_GA.da = new SqlDataAdapter("select sum(Montant) from charan where idmois=@m and An=@an", _GA.cnx);
                //_GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                //_GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                //_GA.da.Fill(dttotal);
                //if (dttotal.Rows.Count > 0) tt2 = double.Parse(dttotal.Rows[0][0].ToString());
                //else tt2 = 0;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                _GA.cmd = new SqlCommand("select sum(Montant) from charan where An=@an", _GA.cnx);
               // _GA.cmd.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                _GA.cmd.Parameters.AddWithValue("@an", numericUpDown1.Value);
                tot = _GA.cmd.ExecuteScalar();
                if (tot != DBNull.Value) tt2 = double.Parse(tot.ToString());
                else tt2 = 0;
                //_GA.da = new SqlDataAdapter("select sum(Montant) from charan where An=@an", _GA.cnx);
                ////_GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                //_GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                //_GA.da.Fill(dttotal);
                //if (dttotal.Rows.Count > 0) tt2 = double.Parse(dttotal.Rows[0][0].ToString());
                //else tt2 = 0;
            }
            return tt2;
        }

        private double total()
        {tt=0;
            nbrinscri=0; nbrreinscri=0;
            mtcoti = 0; mtadh = 0;
            try { ds.Tables["Dsf"].Clear(); }
            catch { }
            try { ds.Tables["DsAn"].Clear(); }
            catch { }

            groupBox1.Visible = false; groupBox2.Visible = false; groupBox3.Visible = false; groupBox5.Visible = true;
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    _GA.da = new SqlDataAdapter("select count(num_reserv),sum(montant) from Reservation where MONTH( Reservation.date_reserv)=@m and year( Reservation.date_reserv)=@an", _GA.cnx);
                    _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                    _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                    //  _GA.da.SelectCommand.Parameters.AddWithValue("@id_dcpln", comboBox2.SelectedValue);
                    try { _GA.da.Fill(ds, "Dsf"); }
                    catch { }
                    if (ds.Tables["Dsf"].Rows.Count > 0)
                    {
                        // label11.Text = ds.Tables["Dsf"].Rows[0][0].ToString();
                        tt += double.Parse(ds.Tables["Dsf"].Rows[0][1].ToString());
                    }
                    _GA.da = new SqlDataAdapter("select * from V_Recette where MONTH([DATE PAIEMENT])=@m and YEAR([DATE PAIEMENT])=@an", _GA.cnx);
                    _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                    _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                    //  _GA.da.SelectCommand.Parameters.AddWithValue("@id_dcpln", comboBox2.SelectedValue);
                    try { _GA.da.Fill(ds, "DsAn"); }
                    catch { }
                    //dataGridView1.DataSource = ds.Tables["DsAn"];
                    if (ds.Tables["DsAn"].Rows.Count > 0)
                    {
                        foreach (DataRow r in ds.Tables["DsAn"].Rows)
                        {
                            mtcoti += double.Parse(r["cotisation"].ToString());
                            mtadh += double.Parse(r["FRAIS ADHESION"].ToString());
                            if (r["critere"].ToString() == "Inscription") { nbrinscri++; }
                            else nbrreinscri++;

                        }
                    }


                    tt += (mtcoti + mtadh);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    _GA.da = new SqlDataAdapter("select count(num_reserv),sum(montant) from Reservation where year( Reservation.date_reserv)=@an", _GA.cnx);
                    // _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                    _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                    // _GA.da.SelectCommand.Parameters.AddWithValue("@id_dcpln", comboBox2.SelectedValue);
                    try { _GA.da.Fill(ds, "Dsf"); }
                    catch { }
                    tt += double.Parse(ds.Tables["Dsf"].Rows[0][1].ToString());

                    _GA.da = new SqlDataAdapter("select * from V_Recette where YEAR([DATE PAIEMENT])=@an", _GA.cnx);
                    // _GA.da.SelectCommand.Parameters.AddWithValue("@m", comboBox5.SelectedIndex + 1);
                    _GA.da.SelectCommand.Parameters.AddWithValue("@an", numericUpDown1.Value);
                    //  _GA.da.SelectCommand.Parameters.AddWithValue("@id_dcpln", comboBox2.SelectedValue);
                    try { _GA.da.Fill(ds, "DsAn"); }
                    catch { }
                    //  dataGridView1.DataSource = ds.Tables["DsAn"];
                    if (ds.Tables["DsAn"].Rows.Count > 0)
                    {
                        foreach (DataRow r in ds.Tables["DsAn"].Rows)
                        {
                            mtcoti += double.Parse(r["cotisation"].ToString());
                            mtadh += double.Parse(r["FRAIS ADHESION"].ToString());
                            if (r["critere"].ToString() == "Inscription") { nbrinscri++; }
                            else nbrreinscri++;

                        }
                    }


                    tt += (mtcoti + mtadh);
                }
            }
            catch { };
            return tt;
        }


        ChartYr c;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            { c = new ChartYr(0, int.Parse(numericUpDown1.Value.ToString())); 
            //ChartYr c = new ChartYr(); c.Show();
            }
            else if (comboBox1.SelectedIndex == 0)
            { c = new ChartYr(comboBox5.SelectedIndex + 1, int.Parse(numericUpDown1.Value.ToString())); }

            c.Show();

          

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                c = new ChartYr(0, int.Parse(numericUpDown1.Value.ToString()));
                //ChartYr c = new ChartYr(); c.Show();
            }
            else if (comboBox1.SelectedIndex == 0)
            { c = new ChartYr(comboBox5.SelectedIndex + 1, int.Parse(numericUpDown1.Value.ToString())); }

            c.Show();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(145, 145);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(138, 138);
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedIndex == 0) comboBox7.Visible = true;
            else comboBox7.Visible = false;
            label21.Text = RecetTotal() - DepenceTotal() + " DH";
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            label21.Text = RecetTotal() - DepenceTotal() + " DH";
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            label21.Text = RecetTotal() - DepenceTotal() + " DH";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
