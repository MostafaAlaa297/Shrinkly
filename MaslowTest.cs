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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF
{
    public partial class MaslowTest : Form
    {
        ListDisease? listDisease;
        int patientId;
        private int flag = 0 ;
        int totalScore;
        string answers="";
        string phase = "";
        Maslow maslow = new Maslow();
        int stat=0 ;

        Label[] questionNumber = new Label[75];

        RadioButton[] yes = new RadioButton[75];
        RadioButton[] no = new RadioButton[75];
        RadioButton[] notSure = new RadioButton[75];

        Panel[] questionPanels = new Panel[75];

        Button submit = new Button();

        public MaslowTest(int aflag,int apatientId,int astat)
        {
            patientId = apatientId;
            flag = aflag;
            stat = astat;
            InitializeComponent();
            QuestionsSlots();
        }
   
        private void LabelProb(Label L)
        {
            L.RightToLeft = RightToLeft.Yes;
            L.AutoSize = true;
            L.Font = SystemFonts.DefaultFont;
            L.BackColor = Color.Transparent;
            L.TextAlign = ContentAlignment.MiddleRight;
            L.Dock = DockStyle.Right;
        }

        private void PanelProb(Panel P)
        {
            P.BackColor = Color.AliceBlue;
            P.BorderStyle = BorderStyle.Fixed3D;
            P.BringToFront();
            P.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
        }

        private void QuestionsSlots()
        {
            Program.WhiteButton(backBtn);
            int y = label2.Location.Y;
            for (int i = 0; i < maslow.TotalQuestions; i++)
            {
                questionPanels[i] = new Panel();
                PanelProb(questionPanels[i]);
                questionPanels[i].Location=new Point(16,y+20+(30*i));
                questionPanels[i].Size = new Size(750, 31);
                questionPanels[i].Validating += new System.ComponentModel.CancelEventHandler(this.YesNoValidation);

                questionNumber[i] = new Label();
                LabelProb(questionNumber[i]);
                questionNumber[i].BringToFront();
                questionNumber[i].Text = maslow.Questions[i].QuestionNum + "- " + maslow.Questions[i].Questions; 

                yes[i] = new RadioButton();
                yes[i].Size = new Size(16,13);
                yes[i].Tag = maslow.Questions[i].Yes;
                no[i] = new RadioButton();
                no[i].Size = new Size(16, 13);
                no[i].Tag = maslow.Questions[i].No;
                notSure[i] = new RadioButton();
                notSure[i].Size = new Size(16, 13);
                notSure[i].Tag = maslow.Questions[i].NotSure;

                questionPanels[i].Controls.Add(questionNumber[i]);
                questionPanels[i].Controls.Add(yes[i]);
                questionPanels[i].Controls.Add(no[i]);
                questionPanels[i].Controls.Add(notSure[i]);

                questionNumber[i].Location = new Point(500, 11);
                yes[i].Location = new Point(138, 11);
                no[i].Location = new Point(82, 11);
                notSure[i].Location = new Point(27, 11);

                this.Controls.Add(questionPanels[i]);
            }
            if(stat==1)
            {
                GettingAnswers();
            }
            submit.Text = "إرسال";
            Panel p = new Panel();
            p.BackColor = Color.Transparent;
            p.Location = new System.Drawing.Point(16, y+20 + (30 * maslow.TotalQuestions));
            p.Size = new Size(770, 50);
            submit.Size = new Size(113, 30);
            submit.AutoSize = false;
            int g = p.Size.Width;
            submit.Location = new System.Drawing.Point(g / 2, 10);
            submit.Anchor = (System.Windows.Forms.AnchorStyles.Top);
            p.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
            Program.BlueButton(submit);
            submit.Click += new EventHandler(Submit_Click);
            
            p.Controls.Add(submit);
            this.Controls.Add(p);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            totalScore = Score();
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                phase = maslow.DeclarePhase(totalScore);
                MessageBox.Show("الناتج الكلى " + totalScore + "\n" + "المرحلة " + phase);
                if (stat == 0)
                {
                    PatientRecord();
                }
                else if (stat ==1)
                {
                    UpdatePatientRecord();
                }
                flag = 0;
                listDisease = new ListDisease(1,patientId);
                listDisease.Show(this);
                Hide();
            }
            else
            {
                MessageBox.Show("الرجاء الاجابة على جميع الاسئلة","");
            }
        }

        private void UpdatePatientRecord()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute($"Update  Patient_Disease set Score = {totalScore} ,Phase ='{phase}' where Patient_Id= {patientId} and Disease_Id={maslow.Id}");
                cnn.Execute($"Update  Patient_Maslow set Answers = '{answers}' where PatientId= {patientId} and DiseaseId={maslow.Id}");
            }
        }

        private void PatientRecord()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into Patient_Disease(Patient_Id,Disease_Id,Score,Phase) values ({patientId},{maslow.Id},{totalScore},'{phase}')");
                cnn.Execute($"insert into Patient_Maslow(PatientId,DiseaseId,Answers) values ({patientId},{maslow.Id},'{answers}')");
            }
        }

        private string PatientAnswer()
        {

            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {

                var output = cnn.Query<string>($"select Answers from Patient_Maslow where PatientId={patientId} AND DiseaseId = {maslow.Id} ", new DynamicParameters());
                return output.ToList()[0];
            }

        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
   

        private int Score ()
        {
            int score = 0;
            answers = "";
            for ( int i = 0; i < maslow.TotalQuestions; i++)
            {
                if(yes[i].Checked==true)
                {
                    score += (int)yes[i].Tag;
                    answers = answers + "0";
                }
                else if (no[i].Checked == true)
                {
                    score += (int)no[i].Tag;
                    answers = answers + "1";
                }
                else if (notSure[i].Checked == true)
                {
                    score += (int)notSure[i].Tag;
                    answers = answers + "2";
                }
            }
            return score;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            flag = 0;
            listDisease = new ListDisease(1, patientId);
            listDisease.Show(this);
            Hide();
        }

        private void GettingAnswers()
        {
            string answer = PatientAnswer();
            char[] vs = answer.ToCharArray();
            for (int i = 0;i < vs.Length;i++)
            {
                if( vs[i]=='0')
                {
                    yes[i].Checked = true;
                }
                else if (vs[i]=='1')
                {
                    no[i].Checked = true;
                }
                else if ( vs[i]=='2')
                {
                    notSure[i].Checked = true;
                }
            }
        }

        private void MaslowTest_FormClosing(object sender, FormClosingEventArgs e)
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

        private void MaslowTest_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void MaslowTest_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
        }

        private void YesNoValidation(object sender, CancelEventArgs e)
        {
            int answered = 0;
            Panel RB = (Panel)sender;
            foreach (var c in RB.Controls)
            {
                if (c is RadioButton)
                {
                    if (((RadioButton)c).Checked == true)
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
