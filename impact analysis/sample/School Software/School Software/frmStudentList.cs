using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace School_Software
{
    public partial class frmStudentList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmStudentRegistration frm = null;
        frmBusHolderStudents frmBusholder = null;
       frmStudentsIdentityCards frmCards = null;
      frmMainmenu main = null;
        public frmStudentList(frmStudentRegistration par)
        {
            frm = par;
            InitializeComponent();
        }
       
        public frmStudentList(frmStudentsIdentityCards par8)
        {
            frmCards = par8;
            InitializeComponent();
        }
       
        public frmStudentList()
        {
          InitializeComponent();
        }
        public frmStudentList(frmMainmenu pars)
        {
            main = pars;
            InitializeComponent();
        }
       public frmStudentList(frmBusHolderStudents par1)
        {
            frmBusholder = par1;
            InitializeComponent();
        }
        public void auto()
        {
           
        }
        private void frmStudentList_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (lblSET.Text == "R1")
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frmBusholder.Show();
                frmBusholder.txtSchoolName.Text = dr.Cells[1].Value.ToString();
                frmBusholder.txtSession.Text = dr.Cells[3].Value.ToString();
                frmBusholder.txtAdmissionNo.Text = dr.Cells[4].Value.ToString();
                frmBusholder.txtStudentName.Text = dr.Cells[6].Value.ToString();
                frmBusholder.txtClass.Text = dr.Cells[9].Value.ToString();
                frmBusholder.txtSection.Text = dr.Cells[10].Value.ToString();
            }
           
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
           
           
        }

        private void txtAdmissionNo_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
              
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where Sessions.session= @d2 and schoolname= @d1";
                cmd = new SqlCommand(ct1);
                cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSection.Items.Clear();
            txtSection.Text = "";
            txtSection.Enabled = true;
            txtSection.Focus();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID  and SchoolName=@d1 and Session=@d2 and class.className =@d3";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                cmd.Parameters.AddWithValue("@d2", txtSession.Text);
                cmd.Parameters.AddWithValue("@d3", txtClass.Text);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSection.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
        }
        public void Reset()
        {
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            txtStudentName.Text = "";
            txtSchool.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            txtAdmissionNo.Text = "";
            DataGridView1.Rows.Clear();
         }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void dtpDateTo_Validating(object sender, CancelEventArgs e)
        {
            if ((dtpDateFrom.Value.Date) > (dtpDateTo.Value.Date))
            {
                MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTo.Focus();
            }
        }

        private void cmbSchoolSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 }
}
