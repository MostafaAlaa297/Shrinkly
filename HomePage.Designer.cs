namespace WF
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.searchPatient = new System.Windows.Forms.Button();
            this.addPatient = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // searchPatient
            // 
            this.searchPatient.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchPatient.BackColor = System.Drawing.Color.Navy;
            this.searchPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.searchPatient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.searchPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchPatient.ForeColor = System.Drawing.Color.White;
            this.searchPatient.Location = new System.Drawing.Point(556, 335);
            this.searchPatient.Name = "searchPatient";
            this.searchPatient.Size = new System.Drawing.Size(175, 54);
            this.searchPatient.TabIndex = 0;
            this.searchPatient.Text = "بحث عن حالة";
            this.searchPatient.UseVisualStyleBackColor = false;
            this.searchPatient.Click += new System.EventHandler(this.search_Click);
            // 
            // addPatient
            // 
            this.addPatient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addPatient.BackColor = System.Drawing.Color.White;
            this.addPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.addPatient.ForeColor = System.Drawing.Color.Navy;
            this.addPatient.Location = new System.Drawing.Point(74, 335);
            this.addPatient.Name = "addPatient";
            this.addPatient.Size = new System.Drawing.Size(175, 54);
            this.addPatient.TabIndex = 1;
            this.addPatient.Text = "إضافة حالة";
            this.addPatient.UseVisualStyleBackColor = false;
            this.addPatient.Click += new System.EventHandler(this.add_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Bradley Hand ITC", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleLabel.Location = new System.Drawing.Point(251, 92);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(303, 79);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Shrinkly";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.BackgroundImage = global::WF.Properties.Resources._5a1ee190_9423_4b11_9aed_14dd99e8dd84;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.addPatient);
            this.Controls.Add(this.searchPatient);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HomePage_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.HomePage_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.HomePage_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button searchPatient;
        private Button addPatient;
        private Label titleLabel;
    }
}