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
    public partial class PersonalityType : Form
    {
        ListDisease? listDisease;
        Personality personality = new Personality();
        int patientId;
        HomePage? home;
        string answers;
        private int flag = 0;
        int totalScore;
        string phase = "";
        int stat = 0;

        Label[] lowQuestions;
        Label[] highQuestions;

        Panel[] questionPanels;
        TrackBar[] trackBar;

        Button submit = new Button();

        public PersonalityType(int aflag, int apatientId, int astat)
        {
            stat = astat;
            flag = aflag;
            patientId = apatientId;
            InitializeComponent();
            QuestionSlots();
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

        private void TrackProb(TrackBar t)
        {
            t.RightToLeft = RightToLeft.Yes;
            t.RightToLeftLayout = true;
            t.Size = new Size(780, 45);
            t.TabIndex = 0;
            t.LargeChange = 0;
            t.Location = new Point(3, 27);
            t.Maximum = 8;
            t.Minimum = 1;
            t.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
        }

        private void QuestionSlots()
        {
            questionPanels = new Panel[personality.TotalQuestions];
            lowQuestions = new Label[personality.TotalQuestions];
            highQuestions = new Label[personality.TotalQuestions];
            trackBar = new TrackBar[personality.TotalQuestions];
            Label[] vl = new Label[8];
            Program.WhiteButton(backBtn);
            for (int i = 0; i < personality.TotalQuestions; i++)
            {
                questionPanels[i] = new Panel();
                PanelProb(questionPanels[i]);
                questionPanels[i].Location = new Point(12, 88 + (90 * i));
                questionPanels[i].Size = new Size(780, 86);
                int x = questionPanels[i].Location.X;
                int y = questionPanels[i].Location.Y;

                trackBar[i] = new TrackBar();
                TrackProb(trackBar[i]);
                trackBar[i].MouseDown += new System.Windows.Forms.MouseEventHandler(trackBar_MouseDown);

                vl[0] = new Label();
                vl[0].Location = new Point(763, 70);
                vl[0].Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
                vl[0].Text = "1";
                vl[0].TabIndex = 31;
                vl[0].Size = new System.Drawing.Size(13, 15);
                /*vl[1] = new Label();
                vl[1].Location = new Point(654, 70);
                vl[1].Anchor = (System.Windows.Forms.AnchorStyles.Bottom|System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right );
                vl[1].Text = "2";
                vl[1].TabIndex = 32;
                vl[1].Size = new System.Drawing.Size(13, 15);
                vl[2] = new Label();
                vl[2].Location = new Point(546, 70);
                vl[2].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right )));
                vl[2].Text = "3";
                vl[2].TabIndex = 33;
                vl[2].Size = new System.Drawing.Size(13, 15);
                vl[3] = new Label();
                vl[3].Location = new Point(439, 70);
                vl[3].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right )));
                vl[3].Text = "4";
                vl[3].TabIndex = 34;
                vl[3].Size = new System.Drawing.Size(13, 15);
                vl[4] = new Label();
                vl[4].Location = new Point(331, 70);
                vl[4].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right )));
                vl[4].Text = "5";
                vl[4].TabIndex = 35;
                vl[4].Size = new System.Drawing.Size(13, 15);
                vl[5] = new Label();
                vl[5].Location = new Point(224, 70);
                vl[5].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
                vl[5].Text = "6";
                vl[5].TabIndex = 36;
                vl[5].Size = new System.Drawing.Size(13, 15);
                vl[6] = new Label();
                vl[6].Location = new Point(115, 70);
                vl[6].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right )));
                vl[6].Text = "7";
                vl[6].TabIndex = 37;
                vl[6].Size = new System.Drawing.Size(13, 15);*/
                vl[7] = new Label();
                vl[7].Location = new Point(12, 70);
                vl[7].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )));
                vl[7].Text = "8";
                vl[7].TabIndex = 38;
                vl[7].Size = new System.Drawing.Size(13, 15);

                highQuestions[i] = new Label();
                LabelProb(highQuestions[i]);
                highQuestions[i].Location = new Point(738, 9);
                highQuestions[i].Text = personality.Questions[i].QuestionNum + "- " + personality.Questions[i].HighQuestion;
                lowQuestions[i] = new Label();
                LabelProb(lowQuestions[i]);
                lowQuestions[i].Location = new Point(12, 9);
                lowQuestions[i].Text = personality.Questions[i].LowQuestion;
                lowQuestions[i].Dock = DockStyle.Left;


                questionPanels[i].Controls.Add(trackBar[i]);
                questionPanels[i].Controls.Add(highQuestions[i]);
                questionPanels[i].Controls.Add(lowQuestions[i]);
                questionPanels[i].Controls.Add(vl[0]);
               /* questionPanels[i].Controls.Add(vl[1]);
                questionPanels[i].Controls.Add(vl[2]);
                questionPanels[i].Controls.Add(vl[3]);
                questionPanels[i].Controls.Add(vl[4]);
                questionPanels[i].Controls.Add(vl[5]);
                questionPanels[i].Controls.Add(vl[6]);*/
                questionPanels[i].Controls.Add(vl[7]);

                this.Controls.Add(questionPanels[i]);
            }
            if (stat == 1)
            {
                GettingAnswers();
            }

            submit.Text = "إرسال";
            Panel p = new Panel();
            p.Location = new System.Drawing.Point(12, 88 + (90 * personality.TotalQuestions));
            p.Size = new Size(780, 50);
            submit.Size = new Size(113, 30);
            submit.AutoSize = false;
            p.BackColor = Color.Transparent;
            int g = p.Size.Width;
            submit.Location = new System.Drawing.Point(g / 2, 10);
            submit.Anchor = (System.Windows.Forms.AnchorStyles.Top);
            p.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Left)));
            Program.BlueButton(submit);
            submit.Click += new EventHandler(Submit_Click);

            p.Controls.Add(submit);
            this.Controls.Add(p);
        }


        private void trackBar_MouseDown(object sender, MouseEventArgs e)
        {
            TrackBar track = (TrackBar)sender;
            double dblValue;
            // Jump to the clicked location
            dblValue = ((double)e.X / (double)track.Width) * (track.Maximum - track.Minimum);
            track.Value = Convert.ToInt32(dblValue + 1);
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            totalScore = Score();

            phase = personality.DeclarePhase(totalScore);
            MessageBox.Show("الناتج الكلى " + totalScore + "\n" + "المرحلة " + phase);
            if (stat == 0)
            {
                PatientRecord();

            }
            else if (stat == 1 )
            {
                UpdatePatientRecord();
            }
            flag = 0;
            listDisease = new ListDisease(1, patientId);
            listDisease.Show(this);
            Hide();

        }
        private void PatientRecord()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute($"insert into Patient_Disease(Patient_Id,Disease_Id,Score,Phase) values ({patientId},{personality.Id},{totalScore},'{phase}')");
                cnn.Execute($"insert into Patient_Maslow(PatientId,DiseaseId,Answers) values ({patientId},{personality.Id},'{answers}')");
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private int Score()
        {
            int score = 0;
            answers = "";

            for (int i = 0; i < personality.TotalQuestions; i++)
            {
                score = score + trackBar[i].Value;
                answers = answers + trackBar[i].Value.ToString();
            }
            return score * 3;
        }

        private void PersonalityType_FormClosing(object sender, FormClosingEventArgs e)
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

        private void backBtn_Click_1(object sender, EventArgs e)
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
             for (int i = 0; i < vs.Length; i++)
             {
                
                trackBar[i].Value = (int)Char.GetNumericValue(vs[i]); 
             }
        }

        private string PatientAnswer()
        {

            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {

                var output = cnn.Query<string>($"select Answers from Patient_Maslow where PatientId={patientId} AND DiseaseId = {personality.Id} ", new DynamicParameters());
                return output.ToList()[0];
            }
        }

        private void UpdatePatientRecord()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute($"Update  Patient_Disease set Score = {totalScore} ,Phase ='{phase}' where Patient_Id= {patientId} and Disease_Id={personality.Id}");
                cnn.Execute($"Update  Patient_Maslow set Answers = '{answers}' where PatientId= {patientId} and DiseaseId={personality.Id}");
            }
        }

        private void PersonalityType_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void PersonalityType_ResizeEnd(object sender, EventArgs e)
        {
            this.ResumeLayout();
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
