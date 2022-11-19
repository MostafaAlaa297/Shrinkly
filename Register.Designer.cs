namespace WF
{
    partial class Register
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.addLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.ageLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.GenderBox = new System.Windows.Forms.ComboBox();
            this.gendreLabel = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.nationalityTextBox = new System.Windows.Forms.TextBox();
            this.الجنسية = new System.Windows.Forms.Label();
            this.الحالة = new System.Windows.Forms.Label();
            this.statue = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageBox
            // 
            this.ImageBox.Image = global::WF.Properties.Resources.download;
            this.ImageBox.Location = new System.Drawing.Point(11, 108);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(195, 168);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Navy;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(63, 291);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "إضافة صورة";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.addPic_Click);
            // 
            // addLabel
            // 
            this.addLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addLabel.AutoSize = true;
            this.addLabel.BackColor = System.Drawing.Color.Transparent;
            this.addLabel.Font = new System.Drawing.Font("Nirmala UI", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.addLabel.Location = new System.Drawing.Point(276, 17);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(208, 46);
            this.addLabel.TabIndex = 3;
            this.addLabel.Text = "إضافة مريض ";
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(769, 72);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(34, 15);
            this.nameLabel.TabIndex = 4;
            this.nameLabel.Text = "الاسم";
            // 
            // ageLabel
            // 
            this.ageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ageLabel.AutoSize = true;
            this.ageLabel.BackColor = System.Drawing.Color.Transparent;
            this.ageLabel.Location = new System.Drawing.Point(769, 126);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(33, 15);
            this.ageLabel.TabIndex = 5;
            this.ageLabel.Text = "العمر";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(461, 97);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nameTextBox.Size = new System.Drawing.Size(343, 23);
            this.nameTextBox.TabIndex = 8;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameTextBox_KeyPress);
            this.nameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nameTextBox_Validating);
            // 
            // ageTextBox
            // 
            this.ageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ageTextBox.Location = new System.Drawing.Point(705, 147);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ageTextBox.Size = new System.Drawing.Size(100, 23);
            this.ageTextBox.TabIndex = 9;
            this.ageTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ageTextBox_KeyPress);
            this.ageTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.ageTextBox_Validating);
            // 
            // GenderBox
            // 
            this.GenderBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GenderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderBox.ForeColor = System.Drawing.Color.Navy;
            this.GenderBox.FormattingEnabled = true;
            this.GenderBox.Items.AddRange(new object[] {
            "ذكر",
            "انثى"});
            this.GenderBox.Location = new System.Drawing.Point(683, 209);
            this.GenderBox.Name = "GenderBox";
            this.GenderBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GenderBox.Size = new System.Drawing.Size(121, 23);
            this.GenderBox.TabIndex = 10;
            // 
            // gendreLabel
            // 
            this.gendreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gendreLabel.AutoSize = true;
            this.gendreLabel.BackColor = System.Drawing.Color.Transparent;
            this.gendreLabel.Location = new System.Drawing.Point(768, 181);
            this.gendreLabel.Name = "gendreLabel";
            this.gendreLabel.Size = new System.Drawing.Size(31, 15);
            this.gendreLabel.TabIndex = 12;
            this.gendreLabel.Text = "النوع";
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.White;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backBtn.ForeColor = System.Drawing.Color.Navy;
            this.backBtn.Location = new System.Drawing.Point(11, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(88, 26);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "رجوع";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // nationalityTextBox
            // 
            this.nationalityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nationalityTextBox.Location = new System.Drawing.Point(683, 267);
            this.nationalityTextBox.Name = "nationalityTextBox";
            this.nationalityTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nationalityTextBox.Size = new System.Drawing.Size(123, 23);
            this.nationalityTextBox.TabIndex = 30;
            this.nationalityTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nationalityTextBox_KeyPress);
            this.nationalityTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.nationalityTextBox_Validating);
            // 
            // الجنسية
            // 
            this.الجنسية.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.الجنسية.AutoSize = true;
            this.الجنسية.BackColor = System.Drawing.Color.Transparent;
            this.الجنسية.Location = new System.Drawing.Point(751, 241);
            this.الجنسية.Name = "الجنسية";
            this.الجنسية.Size = new System.Drawing.Size(45, 15);
            this.الجنسية.TabIndex = 29;
            this.الجنسية.Text = "الجنسية";
            // 
            // الحالة
            // 
            this.الحالة.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.الحالة.AutoSize = true;
            this.الحالة.BackColor = System.Drawing.Color.Transparent;
            this.الحالة.Location = new System.Drawing.Point(709, 305);
            this.الحالة.Name = "الحالة";
            this.الحالة.Size = new System.Drawing.Size(85, 15);
            this.الحالة.TabIndex = 32;
            this.الحالة.Text = "الحالة الاجتماعية";
            // 
            // statue
            // 
            this.statue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statue.BackColor = System.Drawing.SystemColors.Window;
            this.statue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statue.ForeColor = System.Drawing.Color.Navy;
            this.statue.FormattingEnabled = true;
            this.statue.Items.AddRange(new object[] {
            "متزوج",
            "أرمل",
            "مطلق",
            "خاطب",
            "منفصل",
            "غير مرتبط"});
            this.statue.Location = new System.Drawing.Point(663, 335);
            this.statue.Name = "statue";
            this.statue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statue.Size = new System.Drawing.Size(140, 23);
            this.statue.TabIndex = 31;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImage = global::WF.Properties.Resources._5a1ee190_9423_4b11_9aed_14dd99e8dd84;
            this.ClientSize = new System.Drawing.Size(814, 468);
            this.Controls.Add(this.الحالة);
            this.Controls.Add(this.statue);
            this.Controls.Add(this.nationalityTextBox);
            this.Controls.Add(this.الجنسية);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.gendreLabel);
            this.Controls.Add(this.GenderBox);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.addLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ImageBox);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Register";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Register_FormClosing);
            this.ResizeBegin += new System.EventHandler(this.Register_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Register_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox ImageBox;
        private Button button1;
        private Label addLabel;
        private Label nameLabel;
        private Label ageLabel;
        private TextBox nameTextBox;
        private TextBox ageTextBox;
        private ComboBox GenderBox;
        private Label gendreLabel;
        private Button backBtn;
        private ErrorProvider errorProvider1;
        private TextBox nationalityTextBox;
        private Label الجنسية;
        private Label الحالة;
        private ComboBox statue;
    }
}