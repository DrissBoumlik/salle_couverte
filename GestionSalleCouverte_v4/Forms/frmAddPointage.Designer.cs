namespace GestionSalleCouverte.Forms
{
    partial class addPointage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addPointage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adhérantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recetteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeanceDisciplineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpBxAdd = new System.Windows.Forms.GroupBox();
            this.btnClear3 = new System.Windows.Forms.Button();
            this.btnDelPnt = new System.Windows.Forms.Button();
            this.btnAddPnt = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPickDtPntg = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmBxSnc = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmBxAdh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmBxDcpln = new System.Windows.Forms.ComboBox();
            this.grpBxUpd = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmBxSncNew = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtPickDtPntgNew = new System.Windows.Forms.DateTimePicker();
            this.btnUpdPnt = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.grpBxAdd.SuspendLayout();
            this.grpBxUpd.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adhérantsToolStripMenuItem,
            this.pointageToolStripMenuItem,
            this.recetteToolStripMenuItem,
            this.traceToolStripMenuItem,
            this.SeanceDisciplineToolStripMenuItem,
            this.verouToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1027, 38);
            this.menuStrip1.TabIndex = 39;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adhérantsToolStripMenuItem
            // 
            this.adhérantsToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.adhérantsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.adhérantsToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.adhérantsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adhérantsToolStripMenuItem.Image")));
            this.adhérantsToolStripMenuItem.Name = "adhérantsToolStripMenuItem";
            this.adhérantsToolStripMenuItem.Size = new System.Drawing.Size(140, 34);
            this.adhérantsToolStripMenuItem.Text = "Adhérants";
            this.adhérantsToolStripMenuItem.Click += new System.EventHandler(this.adhérantsToolStripMenuItem_Click);
            // 
            // pointageToolStripMenuItem
            // 
            this.pointageToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.pointageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.affichageToolStripMenuItem});
            this.pointageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pointageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pointageToolStripMenuItem.Image")));
            this.pointageToolStripMenuItem.Name = "pointageToolStripMenuItem";
            this.pointageToolStripMenuItem.Size = new System.Drawing.Size(129, 34);
            this.pointageToolStripMenuItem.Text = "Pointage";
            // 
            // affichageToolStripMenuItem
            // 
            this.affichageToolStripMenuItem.BackColor = System.Drawing.Color.DarkCyan;
            this.affichageToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.affichageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("affichageToolStripMenuItem.Image")));
            this.affichageToolStripMenuItem.Name = "affichageToolStripMenuItem";
            this.affichageToolStripMenuItem.Size = new System.Drawing.Size(178, 36);
            this.affichageToolStripMenuItem.Text = "Affichage";
            this.affichageToolStripMenuItem.Click += new System.EventHandler(this.affichageToolStripMenuItem_Click);
            // 
            // recetteToolStripMenuItem
            // 
            this.recetteToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.recetteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("recetteToolStripMenuItem.Image")));
            this.recetteToolStripMenuItem.Name = "recetteToolStripMenuItem";
            this.recetteToolStripMenuItem.Size = new System.Drawing.Size(116, 34);
            this.recetteToolStripMenuItem.Text = "Recette";
            this.recetteToolStripMenuItem.Click += new System.EventHandler(this.recetteToolStripMenuItem_Click);
            // 
            // traceToolStripMenuItem
            // 
            this.traceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.traceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("traceToolStripMenuItem.Image")));
            this.traceToolStripMenuItem.Name = "traceToolStripMenuItem";
            this.traceToolStripMenuItem.Size = new System.Drawing.Size(100, 34);
            this.traceToolStripMenuItem.Text = "Trace";
            this.traceToolStripMenuItem.Click += new System.EventHandler(this.traceToolStripMenuItem_Click);
            // 
            // SeanceDisciplineToolStripMenuItem
            // 
            this.SeanceDisciplineToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.SeanceDisciplineToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SeanceDisciplineToolStripMenuItem.Image")));
            this.SeanceDisciplineToolStripMenuItem.Name = "SeanceDisciplineToolStripMenuItem";
            this.SeanceDisciplineToolStripMenuItem.Size = new System.Drawing.Size(149, 34);
            this.SeanceDisciplineToolStripMenuItem.Text = "Paramètres";
            this.SeanceDisciplineToolStripMenuItem.Click += new System.EventHandler(this.SeanceDisciplineToolStripMenuItem_Click);
            // 
            // verouToolStripMenuItem
            // 
            this.verouToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.verouToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.verouToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verouToolStripMenuItem.Image")));
            this.verouToolStripMenuItem.Name = "verouToolStripMenuItem";
            this.verouToolStripMenuItem.Size = new System.Drawing.Size(144, 34);
            this.verouToolStripMenuItem.Text = "Verrouiller";
            this.verouToolStripMenuItem.Visible = false;
            this.verouToolStripMenuItem.Click += new System.EventHandler(this.verouToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.quitterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitterToolStripMenuItem.Image")));
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(113, 34);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // grpBxAdd
            // 
            this.grpBxAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpBxAdd.Controls.Add(this.btnClear3);
            this.grpBxAdd.Controls.Add(this.btnDelPnt);
            this.grpBxAdd.Controls.Add(this.btnAddPnt);
            this.grpBxAdd.Controls.Add(this.label3);
            this.grpBxAdd.Controls.Add(this.dtPickDtPntg);
            this.grpBxAdd.Controls.Add(this.label1);
            this.grpBxAdd.Controls.Add(this.cmBxSnc);
            this.grpBxAdd.Controls.Add(this.label19);
            this.grpBxAdd.Controls.Add(this.cmBxAdh);
            this.grpBxAdd.Controls.Add(this.label2);
            this.grpBxAdd.Controls.Add(this.cmBxDcpln);
            this.grpBxAdd.ForeColor = System.Drawing.Color.White;
            this.grpBxAdd.Location = new System.Drawing.Point(61, 87);
            this.grpBxAdd.Name = "grpBxAdd";
            this.grpBxAdd.Size = new System.Drawing.Size(499, 400);
            this.grpBxAdd.TabIndex = 40;
            this.grpBxAdd.TabStop = false;
            this.grpBxAdd.Text = "Ajouter";
            // 
            // btnClear3
            // 
            this.btnClear3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClear3.BackgroundImage")));
            this.btnClear3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear3.FlatAppearance.BorderSize = 0;
            this.btnClear3.Location = new System.Drawing.Point(277, 249);
            this.btnClear3.Name = "btnClear3";
            this.btnClear3.Size = new System.Drawing.Size(58, 54);
            this.btnClear3.TabIndex = 92;
            this.btnClear3.UseVisualStyleBackColor = true;
            this.btnClear3.Click += new System.EventHandler(this.btnClear3_Click);
            // 
            // btnDelPnt
            // 
            this.btnDelPnt.BackColor = System.Drawing.Color.SkyBlue;
            this.btnDelPnt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelPnt.BackgroundImage")));
            this.btnDelPnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelPnt.FlatAppearance.BorderSize = 0;
            this.btnDelPnt.Location = new System.Drawing.Point(367, 249);
            this.btnDelPnt.Name = "btnDelPnt";
            this.btnDelPnt.Size = new System.Drawing.Size(58, 54);
            this.btnDelPnt.TabIndex = 89;
            this.btnDelPnt.UseVisualStyleBackColor = false;
            this.btnDelPnt.Click += new System.EventHandler(this.btnDelPnt_Click);
            // 
            // btnAddPnt
            // 
            this.btnAddPnt.BackColor = System.Drawing.Color.SkyBlue;
            this.btnAddPnt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddPnt.BackgroundImage")));
            this.btnAddPnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddPnt.FlatAppearance.BorderSize = 0;
            this.btnAddPnt.Location = new System.Drawing.Point(190, 249);
            this.btnAddPnt.Name = "btnAddPnt";
            this.btnAddPnt.Size = new System.Drawing.Size(58, 54);
            this.btnAddPnt.TabIndex = 85;
            this.btnAddPnt.UseVisualStyleBackColor = false;
            this.btnAddPnt.Click += new System.EventHandler(this.btnAddPnt_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(37, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 23);
            this.label3.TabIndex = 83;
            this.label3.Text = "Date :";
            // 
            // dtPickDtPntg
            // 
            this.dtPickDtPntg.Location = new System.Drawing.Point(158, 191);
            this.dtPickDtPntg.Name = "dtPickDtPntg";
            this.dtPickDtPntg.Size = new System.Drawing.Size(294, 30);
            this.dtPickDtPntg.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 82;
            this.label1.Text = "Séance :";
            // 
            // cmBxSnc
            // 
            this.cmBxSnc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmBxSnc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmBxSnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxSnc.FormattingEnabled = true;
            this.cmBxSnc.Location = new System.Drawing.Point(158, 144);
            this.cmBxSnc.Name = "cmBxSnc";
            this.cmBxSnc.Size = new System.Drawing.Size(294, 31);
            this.cmBxSnc.TabIndex = 81;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(37, 54);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(100, 23);
            this.label19.TabIndex = 80;
            this.label19.Text = "Adhérent :";
            // 
            // cmBxAdh
            // 
            this.cmBxAdh.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmBxAdh.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmBxAdh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxAdh.FormattingEnabled = true;
            this.cmBxAdh.Location = new System.Drawing.Point(158, 51);
            this.cmBxAdh.Name = "cmBxAdh";
            this.cmBxAdh.Size = new System.Drawing.Size(294, 31);
            this.cmBxAdh.TabIndex = 79;
            this.cmBxAdh.SelectedIndexChanged += new System.EventHandler(this.cmBxAdh_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 78;
            this.label2.Text = "Discipline :";
            // 
            // cmBxDcpln
            // 
            this.cmBxDcpln.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmBxDcpln.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmBxDcpln.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxDcpln.FormattingEnabled = true;
            this.cmBxDcpln.Location = new System.Drawing.Point(158, 98);
            this.cmBxDcpln.Name = "cmBxDcpln";
            this.cmBxDcpln.Size = new System.Drawing.Size(294, 31);
            this.cmBxDcpln.TabIndex = 77;
            this.cmBxDcpln.SelectedIndexChanged += new System.EventHandler(this.cmBxDcpln_SelectedIndexChanged);
            // 
            // grpBxUpd
            // 
            this.grpBxUpd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpBxUpd.Controls.Add(this.label5);
            this.grpBxUpd.Controls.Add(this.cmBxSncNew);
            this.grpBxUpd.Controls.Add(this.label4);
            this.grpBxUpd.Controls.Add(this.dtPickDtPntgNew);
            this.grpBxUpd.Controls.Add(this.btnUpdPnt);
            this.grpBxUpd.ForeColor = System.Drawing.Color.White;
            this.grpBxUpd.Location = new System.Drawing.Point(580, 87);
            this.grpBxUpd.Name = "grpBxUpd";
            this.grpBxUpd.Size = new System.Drawing.Size(391, 400);
            this.grpBxUpd.TabIndex = 41;
            this.grpBxUpd.TabStop = false;
            this.grpBxUpd.Text = "Mise à Jour";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(126, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 23);
            this.label5.TabIndex = 96;
            this.label5.Text = "Nouvelle séance :";
            // 
            // cmBxSncNew
            // 
            this.cmBxSncNew.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmBxSncNew.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmBxSncNew.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxSncNew.FormattingEnabled = true;
            this.cmBxSncNew.Location = new System.Drawing.Point(50, 131);
            this.cmBxSncNew.Name = "cmBxSncNew";
            this.cmBxSncNew.Size = new System.Drawing.Size(294, 31);
            this.cmBxSncNew.TabIndex = 95;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(126, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 23);
            this.label4.TabIndex = 94;
            this.label4.Text = "Nouvelle date :";
            // 
            // dtPickDtPntgNew
            // 
            this.dtPickDtPntgNew.Location = new System.Drawing.Point(50, 191);
            this.dtPickDtPntgNew.Name = "dtPickDtPntgNew";
            this.dtPickDtPntgNew.Size = new System.Drawing.Size(294, 30);
            this.dtPickDtPntgNew.TabIndex = 93;
            // 
            // btnUpdPnt
            // 
            this.btnUpdPnt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdPnt.BackgroundImage")));
            this.btnUpdPnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdPnt.FlatAppearance.BorderSize = 0;
            this.btnUpdPnt.Location = new System.Drawing.Point(167, 249);
            this.btnUpdPnt.Name = "btnUpdPnt";
            this.btnUpdPnt.Size = new System.Drawing.Size(58, 54);
            this.btnUpdPnt.TabIndex = 92;
            this.btnUpdPnt.UseVisualStyleBackColor = true;
            this.btnUpdPnt.Click += new System.EventHandler(this.btnUpdPnt_Click);
            // 
            // addPointage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1027, 542);
            this.Controls.Add(this.grpBxUpd);
            this.Controls.Add(this.grpBxAdd);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "addPointage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pointage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.addPointage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpBxAdd.ResumeLayout(false);
            this.grpBxAdd.PerformLayout();
            this.grpBxUpd.ResumeLayout(false);
            this.grpBxUpd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adhérantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recetteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SeanceDisciplineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verouToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpBxAdd;
        private System.Windows.Forms.Button btnClear3;
        private System.Windows.Forms.Button btnDelPnt;
        private System.Windows.Forms.Button btnAddPnt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPickDtPntg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmBxSnc;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmBxAdh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmBxDcpln;
        private System.Windows.Forms.GroupBox grpBxUpd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmBxSncNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtPickDtPntgNew;
        private System.Windows.Forms.Button btnUpdPnt;
    }
}