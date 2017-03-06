using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace School_Software
{
    public partial class frmExamSchedule : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        DataTable table = new DataTable();
        int indexRow;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmExamSchedule()
        {
            InitializeComponent();
        }
      
       
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Examination Schedule' and Users.UserID='" + lblUser.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                lblsave.Text = rdr[0].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            if (lblsave.Text == "True")
                this.btnSave.Enabled = true;
            else
                this.btnSave.Enabled = false;

        }
      
       
       
        private void frmExamSchedule_Load(object sender, EventArgs e)
        {
            Reset();

        }

        private void cmbExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
         
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtSubjectCode.Text))
            {
                MessageBox.Show("Please retrieve subject code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtSubjectCode.Focus();
                return;
            }
            if ((txtStarttime.Value) >= (txtEndTime.Value))
            {
                MessageBox.Show("Start time can not be Greater than or Equal to End Time", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEndTime.Focus();
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add Exam Schedule in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT ExamSchedule.ExamID, ExamSchedule.School_ID, ExamSchedule.Session_ID, ExamSchedule.ClassSection_ID FROM ExamSchedule INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID where ExamID=@d1 and School_ID=@d2 and Session_ID=@d3 and ClassSection_ID=@d4";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamID.Text);
                cmd.Parameters.AddWithValue("@d2", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d4", txtClassSectionID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Exam Already Scheduled For This Batch", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                
                st1 = lblUser.Text;
                st2 = "Exam is Schedule  having ExamName'" + cmbExamName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Scheduled", "Exam Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Please add Exam Schedule in a datagrid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((txtExamID.Text) != (examid.Text) || (txtSchoolID.Text) != (Schoolid.Text) || (txtSessionID.Text) != (sessionid.Text) || (txtClassSectionID.Text) != (classsectionid.Text))
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT ExamSchedule.ExamID, ExamSchedule.School_ID, ExamSchedule.Session_ID, ExamSchedule.ClassSection_ID FROM ExamSchedule INNER JOIN Scheduling ON ExamSchedule.ScheduleID = Scheduling.Schedule_ID where ExamID=@d1 and School_ID=@d2 and Session_ID=@d3 and ClassSection_ID=@d4";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamID.Text);
                cmd.Parameters.AddWithValue("@d2", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d4", txtClassSectionID.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Exam Already Scheduled For This Batch", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "update  ExamSchedule set ExamID=@d2, School_ID=@d3, Session_ID=@d4, ClassSection_ID=@d5 where ScheduleID=@d1";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtScheduleID.Text);
                cmd.Parameters.AddWithValue("@d2", txtExamID.Text);
                cmd.Parameters.AddWithValue("@d3", txtSchoolID.Text);
                cmd.Parameters.AddWithValue("@d4", txtSessionID.Text);
                cmd.Parameters.AddWithValue("@d5", txtClassSectionID.Text);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from scheduling where Schedule_ID='" + txtScheduleID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
               st1 = lblUser.Text;
                st2 = "Scheduled Exam is Updated having ExamName'" + cmbExamName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Exam Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txtScheduleID.Text = "";
            txtExamID.Text = "";
          txtMaxMarks.Text = "";
            txtminMarks.Text = "";
            txtSubjectID.Text = "";
            txtSubjectname.Text = "";
            txtSubjectCode.Text = "";
          txtExamID.Text = "";
            txtScheduleID.Text = "";
            txtExamID.Text = "";
            txtScheduleID.Text = "";
            txtExamID.Text = "";
            DataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            cmbExamName.SelectedIndex = -1;
            cmbSchool.SelectedIndex = -1;
            cmbClass.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            txtSessionID.Text = "";
            txtSchoolID.Text = "";
            txtClassSectionID.Text = "";
            func();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnRemovelist.Enabled = false;
            BtnUpdatelist.Enabled = false;
        }
        private void delete_records()
        {
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            BtnUpdatelist.Enabled = true;
            btnRemovelist.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnRemovelist_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnUpdatelist_Click(object sender, EventArgs e)
        {
            DataGridViewRow newDataRow = DataGridView1.Rows[indexRow];
            newDataRow.Cells[0].Value = txtSubjectID.Text;
            newDataRow.Cells[1].Value = txtSubjectCode.Text;
            newDataRow.Cells[2].Value = txtSubjectname.Text;
            newDataRow.Cells[3].Value = txtExamDate.Value.Date;
            newDataRow.Cells[4].Value = txtMaxMarks.Text;
            newDataRow.Cells[5].Value = txtminMarks.Text;
            newDataRow.Cells[6].Value = txtStarttime.Text;
            newDataRow.Cells[7].Value = txtEndTime.Text;
            txtSubjectID.Text = "";
            txtSubjectname.Text = "";
            txtSubjectCode.Text = "";
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtStarttime.Text = System.DateTime.Now.ToShortTimeString();
            txtEndTime.Text = System.DateTime.Now.ToShortTimeString();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow dr = DataGridView1.Rows[indexRow];
            txtSubjectID.Text = dr.Cells[0].Value.ToString();
            txtSubjectCode.Text = dr.Cells[1].Value.ToString();
            txtSubjectname.Text = dr.Cells[2].Value.ToString();
            txtExamDate.Text = dr.Cells[3].Value.ToString();
            txtMaxMarks.Text = dr.Cells[4].Value.ToString();
            txtminMarks.Text = dr.Cells[5].Value.ToString();
            txtStarttime.Text = dr.Cells[6].Value.ToString();
            txtEndTime.Text = dr.Cells[7].Value.ToString();
        }
        public void refresh()
        {
            txtMaxMarks.Text = "";
            txtminMarks.Text = "";
            txtSubjectID.Text = "";
            txtSubjectname.Text = "";
            txtSubjectCode.Text = "";
            txtExamDate.Text = System.DateTime.Now.ToString();
            txtStarttime.Text = System.DateTime.Now.ToShortTimeString();
            txtEndTime.Text = System.DateTime.Now.ToShortTimeString();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void txtMaxMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtminMarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
               cmd.CommandText = "SELECT distinct Rtrim(ClasssectionID) FROM ClassSection,class,Section where ClassSection.Class_ID = Class.ClassID and ClassSection.Section_ID = Section.SectionID and Class.className = '" + cmbClass.Text + "' and Section.SectionName = '" + cmbSection.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassSectionID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(School.SchoolID)FROM School INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID WHERE SchoolName = '" + cmbSchool.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSchoolID.Text = rdr.GetValue(0).ToString().Trim();
                }
                if ((rdr != null))
                {
                    rdr.Close();
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
 
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
  
        }
    }
}
