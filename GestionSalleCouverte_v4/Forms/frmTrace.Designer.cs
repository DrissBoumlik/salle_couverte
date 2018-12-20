namespace GestionSalleCouverte.Forms
{
    partial class frmTraceAdherent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTraceAdherent));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adhérantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recetteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SeanceDisciplineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nmUpDwnYear = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmBxDcpln = new System.Windows.Forms.ComboBox();
            this.btnShwChrt = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDwnYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adhérantsToolStripMenuItem,
            this.pointageToolStripMenuItem,
            this.recetteToolStripMenuItem,
            this.SeanceDisciplineToolStripMenuItem,
            this.verouToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1020, 38);
            this.menuStrip1.TabIndex = 36;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adhérantsToolStripMenuItem
            // 
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
            this.affichageToolStripMenuItem,
            this.ajoutToolStripMenuItem});
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
            this.affichageToolStripMenuItem.Click += new System.EventHandler(this.pointageToolStripMenuItem_Click);
            // 
            // ajoutToolStripMenuItem
            // 
            this.ajoutToolStripMenuItem.BackColor = System.Drawing.Color.DarkCyan;
            this.ajoutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.ajoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ajoutToolStripMenuItem.Image")));
            this.ajoutToolStripMenuItem.Name = "ajoutToolStripMenuItem";
            this.ajoutToolStripMenuItem.Size = new System.Drawing.Size(178, 36);
            this.ajoutToolStripMenuItem.Text = "Ajout";
            this.ajoutToolStripMenuItem.Click += new System.EventHandler(this.ajoutToolStripMenuItem_Click);
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
            // gridControl1
            // 
            this.gridControl1.AllowRestoreSelectionAndFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1020, 418);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.ColumnFilterButton.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.gridView1.Appearance.EvenRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.FixedLine.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FixedLine.Options.UseFont = true;
            this.gridView1.Appearance.FixedLine.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.GroupPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView1.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseTextOptions = true;
            this.gridView1.Appearance.SelectedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.SelectedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsDetail.EnableDetailToolTip = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // nmUpDwnYear
            // 
            this.nmUpDwnYear.Location = new System.Drawing.Point(567, 29);
            this.nmUpDwnYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nmUpDwnYear.Minimum = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            this.nmUpDwnYear.Name = "nmUpDwnYear";
            this.nmUpDwnYear.Size = new System.Drawing.Size(136, 30);
            this.nmUpDwnYear.TabIndex = 62;
            this.nmUpDwnYear.Value = new decimal(new int[] {
            1990,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOk.BackgroundImage")));
            this.btnOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.Location = new System.Drawing.Point(722, 15);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(55, 55);
            this.btnOk.TabIndex = 60;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(472, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 59;
            this.label1.Text = "Année :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(93, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 23);
            this.label2.TabIndex = 65;
            this.label2.Text = "Discipline :";
            // 
            // cmBxDcpln
            // 
            this.cmBxDcpln.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmBxDcpln.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmBxDcpln.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBxDcpln.FormattingEnabled = true;
            this.cmBxDcpln.Location = new System.Drawing.Point(200, 28);
            this.cmBxDcpln.Name = "cmBxDcpln";
            this.cmBxDcpln.Size = new System.Drawing.Size(226, 31);
            this.cmBxDcpln.TabIndex = 64;
            // 
            // btnShwChrt
            // 
            this.btnShwChrt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShwChrt.BackgroundImage")));
            this.btnShwChrt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShwChrt.FlatAppearance.BorderSize = 0;
            this.btnShwChrt.Location = new System.Drawing.Point(783, 15);
            this.btnShwChrt.Name = "btnShwChrt";
            this.btnShwChrt.Size = new System.Drawing.Size(55, 55);
            this.btnShwChrt.TabIndex = 67;
            this.btnShwChrt.UseVisualStyleBackColor = true;
            this.btnShwChrt.Visible = false;
            this.btnShwChrt.Click += new System.EventHandler(this.btnShwChrt_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 38);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.splitContainer1.Panel1.Controls.Add(this.btnShwChrt);
            this.splitContainer1.Panel1.Controls.Add(this.cmBxDcpln);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnOk);
            this.splitContainer1.Panel1.Controls.Add(this.nmUpDwnYear);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 504);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 1;
            // 
            // frmTraceAdherent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(57)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1020, 542);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmTraceAdherent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRACE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTraceAdherent_Load);
            this.SizeChanged += new System.EventHandler(this.frmTraceAdherent_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDwnYear)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adhérantsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recetteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SeanceDisciplineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.NumericUpDown nmUpDwnYear;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmBxDcpln;
        private System.Windows.Forms.ToolStripMenuItem affichageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verouToolStripMenuItem;
        private System.Windows.Forms.Button btnShwChrt;
        private System.Windows.Forms.SplitContainer splitContainer1;

    }
}