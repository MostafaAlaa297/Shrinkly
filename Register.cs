using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF
{
    public partial class Register : Form
    {
        Teast showPatient;
        Patient patient;
        string imageLocation = "";
        HomePage? home;
        private int flag = 0;
        private int currentId;
        List<int> count = new List<int>();
        string theBigString;
        int stats = 0;
        ListDisease? listDisease;

        Panel[] panal;
        Label[] header;
        TextBox[] notes;
        RadioButton[] yes;
        RadioButton[] no;
        CheckBox[] syndroms = new CheckBox[15];

        List<Diagnose> question = new List<Diagnose>();

        public Register(int aflag, int astats, int aid, Teast T)
        {
            flag = aflag;
            stats = astats;
            currentId = aid;
            showPatient = T;
            InitializeComponent();
            SetBoxes();
            LoadProfile();
            SetQuestions();

        }
        public Register(int aflag)
        {
            flag = aflag;
            InitializeComponent();
            SetBoxes();
            SetQuestions();

        }

        private void SetQuestions()
        {
            int x = statue.Location.Y;
            question = LoadDiagnoseQuestions();
            header = new Label[question.Count];
            notes = new TextBox[question.Count];
            yes = new RadioButton[question.Count];
            no = new RadioButton[question.Count];
            panal = new Panel[question.Count];
            int tableWidth = 0;
            for (int i = 0; i < question.Count; i++)
            {
                if (question[i].QuestionId == 28)
                {
                    header[i] = new Label();

                    header[i].RightToLeft = RightToLeft.Yes;
                    header[i].AutoSize = true;
                    header[i].Font = SystemFonts.DefaultFont;
                    header[i].BackColor = Color.Transparent;
                    header[i].TextAlign = ContentAlignment.MiddleRight;
                    header[i].Size = new System.Drawing.Size(92, 15);
                    header[i].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                    header[i].Location = new Point(500, x+30 + (80 * i));
                    header[i].Text = question[i].QuestionId + " " + question[i].Questions;
                    TableLayoutPanel T = new TableLayoutPanel();
                    SettingTable(T);
                    T.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
                    T.Location = new System.Drawing.Point(11, x+40 + (80 * i));
                    tableWidth = 150;
                    this.Controls.Add(header[i]);
                    this.Controls.Add(T);
                }
                else
                {
                    panal[i] = new Panel();
                    panal[i].Location = new System.Drawing.Point(11, x+30 + (80 * i) + tableWidth);
                    panal[i].Size = new System.Drawing.Size(790, 78);
                    panal[i].BackColor = Color.AliceBlue;
                    panal[i].BorderStyle = BorderStyle.Fixed3D;
                    panal[i].Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left);
                    header[i] = new Label();
                    SettingLabels(header[i]);
                    header[i].Text = question[i].QuestionId + " " + question[i].Questions;
                    notes[i] = new TextBox();
                    notes[i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.noteTextBox_KeyPress);
                    SettingTextBox(notes[i]);
                    panal[i].Controls.Add(header[i]);
                    panal[i].Controls.Add(notes[i]);
                    if (question[i].Yes_No == 1)
                    {
                        count.Add(question[i].QuestionId);
                        yes[i] = new RadioButton();
                        no[i] = new RadioButton();
                        SettingYes(yes[i]);
                        SettingNo(no[i]);
                        panal[i].Controls.Add(yes[i]);
                        panal[i].Controls.Add(no[i]);
                        if (question[i].QuestionId == 1)
                        {
                            yes[i].Text = "مع الاب والام";
                            no[i].Text = "غير ذلك";
                        }
                        if (question[i].QuestionId != 52 && question[i].QuestionId != 53)
                        {
                            panal[i].Validating += new System.ComponentModel.CancelEventHandler(this.YesNoValidation);
                        }
                    }
                    else
                    {      
                            notes[i].Validating += new System.ComponentModel.CancelEventHandler(this.AnswerTextValidating);                        
                    }
                    this.Controls.Add(panal[i]);
                    
                }

            }
            if (stats == 1)
            {
                FillAnswers();
                addLabel.Text = "تعديل بيانات مريض";
            }

            Panel p = new Panel();
            p.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left);
            p.Location = new System.Drawing.Point(11, x+25 + (80 * question.Count + 1) + tableWidth);
            p.BackColor = Color.Transparent;
            p.Size = new System.Drawing.Size(800, 50);
            Button submit = new Button();
            submit.Text = "تسجيل";
            submit.Size = new Size(113, 38);
            submit.AutoSize = false;
            if (stats == 1)
            {
                Button delete = new Button();
                int z = p.Size.Width;
                submit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                submit.Location = new System.Drawing.Point(z * 3 / 4, 10);
                //bruh.Dock = DockStyle.Left;
                delete.Location = new System.Drawing.Point(z / 4, 10);
                delete.Size = new Size(113, 38);
                delete.Text = "حذف";
                // delete.Dock=DockStyle.Right;
                delete.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left);
                delete.Click += new System.EventHandler(DeleteBtn_Click);
                Program.RedButton(delete);
                p.Controls.Add(delete);
            }
            else if (stats == 0)
            {
                int g = p.Size.Width;
                submit.Location = new System.Drawing.Point(g/2 , 10);
                submit.Anchor = (System.Windows.Forms.AnchorStyles.Top );
            }
            submit.Click += new System.EventHandler(this.SubmitBtn_Click);
            Program.BlueButton(submit);
            p.Controls.Add(submit);
            this.Controls.Add(p);
        }

        private void Records()
        {
            theBigString = "";
            for (int i = 0; i < question.Count; i++)
            {
                if (question[i].QuestionId == 28)
                {
                    theBigString = theBigString + "^";
                    for (int j = 0; j < syndroms.Length; j++)
                    {
                        if (syndroms[j].Checked == true)
                        {
                            theBigString = theBigString + "1";

                        }
                        else
                        {
                            theBigString = theBigString + "0";

                        }
                    }
                }
                else
                {
                    if (question[i].Yes_No == 1)
                    {
                        if (yes[i].Checked == true)
                        {
                            theBigString = theBigString + "`0";
                        }
                        else if (no[i].Checked == true)
                        {
                            theBigString = theBigString + "`1";
                        }
                        else
                        {
                            theBigString = theBigString + "`-1";
                        }    
                        theBigString = theBigString + "♣" + notes[i].Text;
                    }
                    else
                    {
                        theBigString = theBigString + notes[i].Text;
                    }
                }
                theBigString = theBigString + "~";
            }
            SavePatientRecords();
        }

        private void SetBoxes()
        {
            if (stats == 0)
            {
                GenderBox.SelectedIndex = 0;
                statue.SelectedIndex = 0;
            }
            else if ( stats ==1 )
            {
                GenderBox.DropDownStyle = ComboBoxStyle.DropDown;
                statue.DropDownStyle= ComboBoxStyle.DropDown;
            }
        }

        private void NewPatient()
        {
            Image selected;
            if (imageLocation == "")
            {
                selected = ImageBox.Image;
            }
            else
            {
                selected = new Bitmap(imageLocation);
                selected.PixelFormat.GetType();
            }
            byte[] patientPic = ImageToByte(selected, System.Drawing.Imaging.ImageFormat.Jpeg);
            patient = new Patient(nameTextBox.Text, ageTextBox.Text, GenderBox.Text, patientPic, nationalityTextBox.Text, statue.Text);
            SavePatient(patient);
        }

        private void UpdatePatinet()
        {
            Image image;
            if (imageLocation == "")
            {
                image = ImageBox.Image;
            }
            else
            {
                image = new Bitmap(imageLocation);
            }
            byte[] patientPic = ImageToByte(image, System.Drawing.Imaging.ImageFormat.Jpeg);

            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute($"Update Patient set Name='{nameTextBox.Text}', Age='{ageTextBox.Text}', Gender='{GenderBox.Text}', Image=@patientPic ,Nationality='{nationalityTextBox.Text}',Social_Status='{statue.Text}' Where PatientId={currentId}", new { patientPic });
            }
        }

        private void FillAnswers()
        {
            theBigString = FillBigString();
            string[] rec = theBigString.Split('~');
            for (int i = 0; i < rec.Length-1; i++)
            {
                if (rec[i].StartsWith('`'))
                {
                    string br = rec[i].Trim('`');
                    string[] ans = br.Split('♣');
                    if (ans[0] == "0")
                    {
                        yes[i].Checked = true;
                        notes[i].Text = ans[1];
                    }
                    else if (ans[0] == "1")
                    {
                        no[i].Checked = true;
                        notes[i].Text = ans[1];
                    }
                }
                else if (rec[i].StartsWith('^'))
                {
                    string bh = rec[i].Trim('^');
                    char[] vs = bh.ToCharArray();

                    for (int j = 0;j<vs.Length;j++)
                    {
                        if (vs[j] == '1')
                            syndroms[j].Checked = true;
                    }
                }
                else
                {
                    notes[i].Text = rec[i];
                }
            }
        }

            private string FillBigString()
            {

                using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
                {

                    var output = cnn.Query<string>($"select Answer from PatientRecords where PatientId={currentId} ", new DynamicParameters());
                    return output.ToList()[0];
                }
            }

            private static string LoadConnectionString(string id = "Default")
            {
                return ConfigurationManager.ConnectionStrings[id].ConnectionString;
            }

            public void SavePatient(Patient patient)
            {
                using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
                {
                    cnn.Execute("insert into Patient(Name,Age,Gender,Image,Nationality,Social_Status) values (@Name,@Age,@Gender,@Image,@Nationality,@Social_Status)", patient);
                    var output = cnn.Query<int>("SELECT PatientId from Patient order by ROWID DESC limit 1;");
                    currentId = output.ToList()[0];
                }
            }

            private void SubmitBtn_Click(object sender, EventArgs e)
            {
                try
                {
                if (ValidateChildren(ValidationConstraints.Enabled) )
                {
                    if (stats == 1)
                    {
                        UpdatePatinet();
                        MessageBox.Show("تم التعديل ");
                        Records();
                        this.Close();
                        showPatient.LoadGridViewData();
                    }
                    else if (stats == 0)
                    {
                        NewPatient();
                        MessageBox.Show("تم اضافة مريض جديد ");
                    
                    Records();

                    flag = 0;
                    listDisease = new ListDisease(1, currentId);
                    listDisease.Show(this);
                    Hide();
                         }
                }
                    
                    else
                    {
                        MessageBox.Show("الرجاء الاجابة على جميع الاسئلة");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("هل أنت متأكد بأنك تريد حذف المريض ؟", "حذف مريض", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                DeleteRecord();
                this.Close();
                MessageBox.Show("تم حذف المريض ");
                showPatient.LoadGridViewData();
            }

        }

        private void DeleteRecord()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute($"Delete FROM Patient where PatientId={currentId}");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
            {
            if (stats == 0)
               {
                this.Hide();
                flag = 0;
                home = new HomePage(1);
                home.Show(this);
                }
            else if ( stats ==1)
            {
                this.Close();
            }
            }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stats == 0)
            {
                if (flag == 1)
                {
                    if (MessageBox.Show("هل انت متأكد بأنك تريد الخروج من البرنامج ؟", "تأكيد خروج", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        flag = 0;
                        Application.Exit();
                    }
                }
            }
        }

            // اضافة صورة
            private void addPic_Click(object sender, EventArgs e)
            {
                try
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        imageLocation = dialog.FileName;
                        ImageBox.ImageLocation = imageLocation;
                        ImageBox.Image = new Bitmap(dialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An Error Occured " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public byte[] ImageToByte(Image image, System.Drawing.Imaging.ImageFormat format)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(ms, format);
                    byte[] imageBytes = ms.ToArray();
                    return imageBytes;
                }
            }

            public static List<string> GetTests()
            {
                using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<string>("select Name from Disease", new DynamicParameters());
                    return (List<string>)output;
                }
            }

            private void nameTextBox_Validating(object sender, CancelEventArgs e)
            {

                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    e.Cancel = true;
                    nameTextBox.Focus();
                    errorProvider1.SetError(nameTextBox, "الرجاء ادخال الإسم!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(nameTextBox, "");
                }
            }

            private void ageTextBox_Validating(object sender, CancelEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(ageTextBox.Text))
                {
                    e.Cancel = true;
                    nameTextBox.Focus();
                    errorProvider1.SetError(ageTextBox, "الرجاء ادخال العمر");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(ageTextBox, "");
                }
            }

            private void AnswerTextValidating(object sender, CancelEventArgs e)
            {
                TextBox txtbox = (TextBox)sender;
                if (string.IsNullOrWhiteSpace(txtbox.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtbox, "الرجاء الإجابة على السؤال");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(txtbox, "");
                }
            }

            private void YesNoValidation(object sender, CancelEventArgs e)
            {
            int answered = 0;
            Panel RB = (Panel)sender;
            foreach( var c in RB.Controls)
            {
                if (c is RadioButton)
                {
                    if(((RadioButton)c).Checked == true)
                    answered++;
                }
            }

            if (answered == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(RB, "الرجاء الإجابة على السؤال");

            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(RB, "");
            }
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                var regex = new Regex(@"[^\u0621-\u064A\u0660-\u0669-a-zA-Z\s\b]");
                if (regex.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }

            private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                var regex = new Regex(@"[^Z0-9\b]");

                if (regex.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }
            }
            private void noteTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex("[`~^♣]");

            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }


        public static List<Diagnose> LoadDiagnoseQuestions()
            {
                using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<Diagnose>("select * from PatientDiagnose", new DynamicParameters());
                    return output.ToList();
                }
            }

            private void SettingTextBox(TextBox T)
            {

                T.Location = new System.Drawing.Point(96, 42);
                T.Multiline = true;
                T.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                T.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                T.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
                T.Size = new System.Drawing.Size(680, 36);
                T.TabIndex = 3;
        }
            private void SettingLabels(Label L)
            {
                L.RightToLeft = RightToLeft.Yes;
                L.AutoSize = true;
                L.Font = SystemFonts.DefaultFont;
                L.BackColor = Color.Transparent;
                L.TextAlign = ContentAlignment.MiddleRight;
                L.Dock = DockStyle.Right;
                L.Location = new System.Drawing.Point(689, 12);
                L.Size = new System.Drawing.Size(92, 15);
            }
            private void SettingYes(RadioButton R)
            {
                R.AutoSize = true;
                R.Location = new System.Drawing.Point(300, 10);
                R.Size = new System.Drawing.Size(43, 19);
                R.TabIndex = 1;
                R.TabStop = true;
                R.Text = "نعم";
                R.UseVisualStyleBackColor = true;
            }
            private void SettingNo(RadioButton R)
            {
                R.AutoSize = true;
                R.Location = new System.Drawing.Point(200, 10);
                R.Size = new System.Drawing.Size(32, 19);
                R.TabIndex = 2;
                R.TabStop = true;
                R.Text = "لا";
                R.UseVisualStyleBackColor = true;
            }
            private void SettingTable(TableLayoutPanel T)
            {
            T.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
                for (int i = 0; i < syndroms.Length; i++)
                {
                    syndroms[i] = new CheckBox();
                    int locCounter = 0;
                    int counter = 0;
                    if (i % 3 == 1)
                    {
                        counter++;
                        locCounter = 0;
                    }
                    syndroms[i].Location = new System.Drawing.Point(41 + (300 * locCounter), 12 + (44 * counter));
                    syndroms[i].Anchor = AnchorStyles.Top | AnchorStyles.Right;
                    syndroms[i].AutoSize = true;
                    syndroms[i].RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                    syndroms[i].TabIndex = i;
                    syndroms[i].UseVisualStyleBackColor = true;
                    locCounter++;
                }
                T.AutoSize = true;
                T.BackColor = Color.AliceBlue;
                T.BorderStyle = BorderStyle.Fixed3D;
                T.ColumnCount = 3;
                T.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                T.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                T.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
                T.RowCount = 5;
                T.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
                T.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
                T.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
                T.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
                T.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
                T.Size = new System.Drawing.Size(792, 220);
                T.Controls.Add(syndroms[14], 2, 4);
                T.Controls.Add(syndroms[13], 1, 4);
                T.Controls.Add(syndroms[12], 0, 4);
                T.Controls.Add(syndroms[11], 2, 3);
                T.Controls.Add(syndroms[10], 1, 3);
                T.Controls.Add(syndroms[9], 0, 3);
                T.Controls.Add(syndroms[8], 2, 2);
                T.Controls.Add(syndroms[7], 1, 2);
                T.Controls.Add(syndroms[6], 0, 2);
                T.Controls.Add(syndroms[5], 2, 1);
                T.Controls.Add(syndroms[4], 1, 1);
                T.Controls.Add(syndroms[3], 0, 1);
                T.Controls.Add(syndroms[2], 2, 0);
                T.Controls.Add(syndroms[1], 1, 0);
                T.Controls.Add(syndroms[0], 0, 0);

            syndroms[0].Text = "انخفاض الإهتمام بمعظم الأشياء";
            syndroms[1].Text = "قلق";

            syndroms[2].Text = "عصبية زائدة";

            syndroms[3].Text = " انخفاض/ زيادة الوزن ";

            syndroms[4].Text = " مشاكل في الشهية";

            syndroms[5].Text = "نقص في الطاقة";

            syndroms[6].Text = "  الشعور بعدم األهمية وفقدان الامل";

            syndroms[7].Text = "أفكار غير عادية ";

            syndroms[8].Text = " أرق/ نوم زائد ";

            syndroms[9].Text = "نعزال من الأصدقاء والعائلة";

            syndroms[10].Text = "مشاكل في التركيز";

            syndroms[11].Text = " انشغال ذهني بأمور كثيرة";

            syndroms[12].Text = " نشاط حركي زائد أو عدم الحركة";

            syndroms[13].Text = "مزاج اكتئابي";

            syndroms[14].Text = " نسيان/ مشاكل في الذاكرة";
        }
        private void SavePatientRecords()
            {

            if (stats == 0)
            {
                using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
                {
                    cnn.Execute($"insert into PatientRecords(PatientId,Answer) values ({currentId},'{theBigString}')");
                }
            }
            else if(stats ==1)
            {
                using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
                {
                    cnn.Execute($"update PatientRecords set Answer ='{theBigString}' where PatientId={currentId}");
                }
            }

            }


            public void LoadProfile()
            {
                patient = GetPatient();
                nameTextBox.Text = patient.Name;
                ageTextBox.Text = patient.Age;
                GenderBox.Text = patient.Gender;
                statue.Text = patient.Social_Status;
                GenderBox.DropDownStyle = ComboBoxStyle.DropDownList;
                statue.DropDownStyle=ComboBoxStyle.DropDownList;
                byte[] a = patient.Image;
                ImageBox.Image = ByteToImage(a);
                nationalityTextBox.Text = patient.Nationality;
            }

            private Patient GetPatient()
            {
                using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<Patient>($"select * from Patient Where PatientId = {currentId}", new DynamicParameters());
                    return output.ToList()[0];
                }
            }
            public Image ByteToImage(byte[] imageBytes)
            {
                // Convert byte[] to Image
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                ms.Write(imageBytes, 0, imageBytes.Length);
                Image image = new Bitmap(ms);
                return image;
            }

            private void nationalityTextBox_Validating(object sender, CancelEventArgs e)
            {

                if (string.IsNullOrWhiteSpace(nationalityTextBox.Text))
                {
                    e.Cancel = true;
                    nameTextBox.Focus();
                    errorProvider1.SetError(nationalityTextBox, "الرجاء ادخال الجنسية");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(nationalityTextBox, "");
                }

            }

            private void nationalityTextBox_KeyPress(object sender, KeyPressEventArgs e)
            {
                var regex = new Regex(@"[^\u0621-\u064A\u0660-\u0669-a-zA-Z\s\b]");
                if (regex.IsMatch(e.KeyChar.ToString()))
                {
                    e.Handled = true;
                }

            }

          private void Register_ResizeEnd(object sender, EventArgs e)
          {
              this.ResumeLayout();
          }
          private void Register_ResizeBegin(object sender, EventArgs e)
          {          
            this.SuspendLayout();
          }

        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;

        protected override void WndProc(ref Message m)
        {
            if ((m.Msg == WM_HSCROLL || m.Msg == WM_VSCROLL)
            && (((int)m.WParam & 0xFFFF) == 5))
            {
                // Change SB_THUMBTRACK to SB_THUMBPOSITION
                m.WParam = (IntPtr)(((int)m.WParam & ~0xFFFF) | 4);
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
    }
 }
