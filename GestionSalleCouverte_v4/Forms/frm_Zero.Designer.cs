namespace GestionSalleCouverte.Forms
{
    partial class frm_Zero
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Zero));
            this.btnMony = new System.Windows.Forms.Button();
            this.btnPntg = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMony
            // 
            this.btnMony.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.btnMony.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMony.BackgroundImage")));
            this.btnMony.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMony.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMony.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMony.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.btnMony.Location = new System.Drawing.Point(273, 41);
            this.btnMony.Name = "btnMony";
            this.btnMony.Size = new System.Drawing.Size(125, 125);
            this.btnMony.TabIndex = 3;
            this.btnMony.UseVisualStyleBackColor = false;
            this.btnMony.Click += new System.EventHandler(this.btnMony_Click);
            // 
            // btnPntg
            // 
            this.btnPntg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.btnPntg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPntg.BackgroundImage")));
            this.btnPntg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPntg.FlatAppearance.BorderSize = 0;
            this.btnPntg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPntg.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPntg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.btnPntg.Location = new System.Drawing.Point(99, 41);
            this.btnPntg.Name = "btnPntg";
            this.btnPntg.Size = new System.Drawing.Size(125, 125);
            this.btnPntg.TabIndex = 2;
            this.btnPntg.UseVisualStyleBackColor = false;
            this.btnPntg.Click += new System.EventHandler(this.btnPntg_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tempus Sans ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.button1.Location = new System.Drawing.Point(605, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 50);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_Zero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(45)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(663, 210);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMony);
            this.Controls.Add(this.btnPntg);
            this.Font = new System.Drawing.Font("Tahoma", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frm_Zero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Zero";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMony;
        private System.Windows.Forms.Button btnPntg;
        private System.Windows.Forms.Button button1;

    }
}