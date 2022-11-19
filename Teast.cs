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
    public partial class Teast : Form
    {
        ListDisease? listDisease;
        Register prof;
        private int flag = 0;
        HomePage? home;
        SqliteConnection con = new SqliteConnection(LoadConnectionString());
        SqliteCommand cmd;

        public Teast()
        {
        }

        public Teast(int aflag)
        {
            flag = aflag;
            InitializeComponent();
            SettingDataGridView();
        }

        
        private void btnClick1_Click(object sender, EventArgs e)
        {
            try
            {
                FindPatientName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadGridViewData()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            cmd = new SqliteCommand("Select * From Patient", con);
            FillRows();
            
            con.Close();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        public void FindPatientName()
        {
            dataGridView1.Rows.Clear();
            con.Open();

            cmd = new SqliteCommand($"Select * From Patient WHERE Name like '%{textBox1.Text}%'", con);
            FillRows();
            }

        private void SettingDataGridView()
        {
            int spacing = textBox1.Location.Y;
            dataGridView1.Location = new Point(0, spacing + 30);
            dataGridView1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;
            Program.WhiteButton(button2);
        }

        private void Teast_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
            LoadGridViewData();
            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.HeaderText = "Action";
            bc.Text = "Details";
            bc.Name = "Details";
            bc.UseColumnTextForButtonValue = true;
            bc.Width = 50;
            dataGridView1.Columns.Add(bc);

        }
        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            {
                int ptnID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                prof = new Register(1,1,ptnID , this);
                prof.StartPosition = FormStartPosition.Manual;
                Rectangle pos = Screen.PrimaryScreen.Bounds;
                prof.ShowDialog();

            }
            else if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                int ptnID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                int row = 0;
                row = RowCount(ptnID);
                flag = 0;
                listDisease = new ListDisease(1, ptnID);
                listDisease.Show(this);
                Hide();
            }

        }
        
        private void Teast_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            flag = 0;
            home = new HomePage(1);
            home.Show(this);
            Hide();
        }

        private void FillRows()
        {
            using (SqliteDataReader read = cmd.ExecuteReader())
            {
                while (read.Read())
                {
                    _ = dataGridView1.Rows.Add(new object[] {
                        "الاختبارات",
                        read.GetValue(read.GetOrdinal("Gender")),
                        read.GetValue(read.GetOrdinal("Age")),
                        read.GetValue(read.GetOrdinal("Name")),
                        read.GetValue(read.GetOrdinal("PatientId"))
                        });
                }
            }

        }
        private int RowCount(int id )
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<int>($"select count(Patient_Id) from Patient_Disease Where Patient_Id = {id} ");
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

        private void Teast_ResizeBegin(object sender, EventArgs e)
        {
            this.SuspendLayout();
        }

        private void Teast_ResizeEnd(object sender, EventArgs e)
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
