namespace WF
{
    partial class PersonalityType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalityType));
            this.maslowLabel = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // maslowLabel
            // 
            this.maslowLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.maslowLabel.AutoSize = true;
            this.maslowLabel.BackColor = System.Drawing.Color.Transparent;
            this.maslowLabel.Font = new System.Drawing.Font("Nirmala UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.maslowLabel.Location = new System.Drawing.Point(259, 9);
            this.maslowLabel.Name = "maslowLabel";
            this.maslowLabel.Size = new System.Drawing.Size(265, 32);
            this.maslowLabel.TabIndex = 1;
            this.maslowLabel.Text = "التعرف على نمط الشخصية";
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 9);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(53, 22);
            this.backBtn.TabIndex = 30;
            this.backBtn.Text = "تراجع";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click_1);
            // 
            // PersonalityType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = global::WF.Properties.Resources._5a1ee190_9423_4b11_9aed_14dd99e8dd84;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.maslowLabel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PersonalityType";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "PersonalityType";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonalityType_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.PersonalityType_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.PersonalityType_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private Label maslowLabel;
        private Button backBtn;
    }
}