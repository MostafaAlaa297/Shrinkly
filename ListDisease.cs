using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Configuration;
using System.Data.SqlClient;

namespace WF
{
    public partial class ListDisease : Form
    {
        Teast teast;
        HomePage? home;
        MaslowTest? maslowTest;
        PersonalityType? personality;
        Patient patient;
        int flag = 0;
        int id;
        SqliteConnection con = new SqliteConnection(LoadConnectionString());
        SqliteCommand cmd;
        List<int > participated= new List<int>();

        public ListDisease(int aflag, int aid)
        {
            id = aid;
            flag = aflag;
            InitializeComponent();
            SettingDataGridView();
        }
        private void SettingDataGridView()
        {
            int spacing = label1.Location.Y;
            dataGridView1.Location = new Point(0, spacing + 30);
            dataGridView1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
            Program.WhiteButton(button2);

        }

        public void LoadGridViewData()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            cmd = new SqliteCommand($"Select Disease_Id,Score,Phase From Patient_Disease Where Patient_Id={id}", con);
            FillRows();

            con.Close();
            checkExist();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void FillRows()
        {
            using (SqliteDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    string name = GetDieaseName(read.GetInt32(0));
                    participated.Add(read.GetInt32(0));
                    _ = dataGridView1.Rows.Add(new object[] {
                         read.GetValue(read.GetOrdinal("Phase")),
                         read.GetValue(read.GetOrdinal("Score")),
                         name,
                         read.GetValue(read.GetOrdinal("Disease_Id"))
                    });
                }
            }

        }

        private void checkExist()
        {
            List<int> allIds = new List<int>();
            allIds = GetDiseaseIds();
            List<int> remainingIds = allIds.Except(participated).ToList();
            
            for(int i =0; i<remainingIds.Count; i++)
            {
                string name = GetDieaseName(remainingIds[i]);
                _ = dataGridView1.Rows.Add(new object[] {
                         "لا يوجد",
                         "لا يوجد",
                         name,
                         remainingIds[i]
                         }); 
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = 0;
            teast = new Teast(1);
            teast.Show(this);
            Hide();
        }

        private void ListDisease_FormClosing(object sender, FormClosingEventArgs e)
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
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

        private void ListDisease_Shown(object sender, EventArgs e)
        {
            patient = GetPatient();
            label1.Text = patient.Name;
            label1.AutoSize = true;
            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.HeaderText = "Action";
            bc.Text = "تفاصيل";
            bc.Name = "تفاصيل";
            bc.UseColumnTextForButtonValue = true;
            bc.Width = 50;
            bc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns.Add(bc);
            LoadGridViewData();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                int type = 0;
                int ptnID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                string phase = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if ( phase =="لا يوجد")
                {
                    type = 0;
                }
                else
                {
                    type = 1;
                }
                switch (ptnID)
                {
                    case 1:
                        this.Hide();
                        flag = 0;
                        maslowTest = new MaslowTest(1, patient.PatientId, type);
                        maslowTest.Show();
                        break;

                    case 4:
                        this.Hide();
                        flag = 0;
                        personality = new PersonalityType(1, patient.PatientId,type);
                        personality.Show();
                        break;

                }

            }
        }
        private Patient GetPatient()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Patient>($"select * from Patient Where PatientId = {id}", new DynamicParameters());
                return output.ToList()[0];
            }
        }

        private string GetDieaseName(int DiseaseId)
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<string>($"select Name from Disease Where Id = {DiseaseId}");
                return output.ToList()[0];
            }
        }

        private List<int> GetDiseaseIds()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>($"select Id from Disease ");
                return output.ToList();
            }
        }

        private void ListDisease_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void ListDisease_ResizeEnd(object sender, EventArgs e)
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
