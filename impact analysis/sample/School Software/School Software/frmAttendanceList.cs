using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmAttendanceList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
     Connectionstring cs = new Connectionstring();
        frmStudentAttendance frm = null;
        public frmAttendanceList()
        {
            InitializeComponent();
        }
        public frmAttendanceList(frmStudentAttendance par)
        {
            frm = par;
            InitializeComponent();
        }
       
        public void Reset()
        {
            dataGridView2.Rows.Clear();
            txtSchool.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSession.SelectedIndex = -1;
           cmbSchool.SelectedIndex = -1;
            cmbClass.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            DataGridView1.Rows.Clear();
            cmbSession.Enabled = false;
            cmbClass.Enabled = false;
            cmbSubjectName.SelectedIndex = -1;
            cmbSubjectName.Enabled = false;
           txtSubjectCode.Text = "";
            lblTotalClasses.Visible = false;
        }

        private void frmAttendanceList_Load(object sender, EventArgs e)
        {
            Reset();
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSchool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSchool.Focus();
                    return;
                }
                if (txtSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSession.Focus();
                    return;
                }
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClass.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(AttendanceMaster.AttendanceID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(Subject.SubjectCode),Rtrim(Subject.SubjectName),Rtrim(Attendance.Admission_No),Rtrim(Student.StudentName),AttendanceMaster.AttendanceDate,Rtrim(Attendance.Status) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN Employee ON AttendanceMaster.StaffID = Employee.EMPID INNER JOIN Student ON Student.AdmissionNo = Attendance.Admission_No  Where Session=@d1 and classname=@d2 and SchoolName=@d3 ORDER BY AttendanceMaster.AttendanceDate", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView2.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView2.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void btnSearchList_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchool.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClass.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("Select distinct RTRIM(student.AdmissionNo),RTRIM(Student.StudentName),Count(Attendance.Status),(Count(Attendance.Status) * 100)/(Select Count(distinct Attendance.Attendance_ID) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No Where Session=@d1 and classname=@d2 and SchoolName=@d3 and AttendanceDate between @date1 and @date2) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No Where Session=@d1 and classname=@d2 and SchoolName=@d3 and Attendance.Status='P' and AttendanceDate between @date1 and @date2 group by Student.AdmissionNo,Student.StudentName ", con);
                rdr = cmd.ExecuteReader();
                DataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                lblTotalClasses.Visible = true;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchool.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchool.Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbClass.Focus();
                    return;
                }
                if (cmbSubjectName.Text == "")
                {
                    MessageBox.Show("Please select Subject", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubjectName.Focus();
                    return;
                }


                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("Select distinct RTRIM(student.AdmissionNo),RTRIM(Student.StudentName),Count(Attendance.Status),(Count(Attendance.Status) * 100)/(Select Count(distinct Attendance.Attendance_ID) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No Where Session=@d1 and classname=@d2 and SchoolName=@d3 and SubjectName=@d4 and AttendanceDate between @date1 and @date2) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No Where Session=@d1 and classname=@d2 and SchoolName=@d3 and SubjectName=@d4 and Attendance.Status='P' and AttendanceDate between @date1 and @date2 group by Student.AdmissionNo,Student.StudentName ", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AttendanceDate").Value = txtFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AttendanceDate").Value = txtTo.Value.Date;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSubjectName.Text);
                rdr = cmd.ExecuteReader();
                DataGridView1.Rows.Clear();
                while (rdr.Read())
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                lblTotalClasses.Visible = true;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("Select Count(distinct Attendance.Attendance_ID) FROM Attendance INNER JOIN AttendanceMaster ON Attendance.Attendance_ID = AttendanceMaster.AttendanceID INNER JOIN Subject ON AttendanceMaster.SubjectID = Subject.SubjectID INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID INNER JOIN  Student ON Student.AdmissionNo = Attendance.Admission_No and Session=@d1 and classname=@d2 and SchoolName=@d3 and SubjectName=@d4 and AttendanceDate between @date1 and @date2", con);
                cmd.Parameters.Add("@date1", SqlDbType.DateTime, 30, "AttendanceDate").Value = txtFrom.Value.Date;
                cmd.Parameters.Add("@date2", SqlDbType.DateTime, 30, "AttendanceDate").Value = txtTo.Value.Date;
                cmd.Parameters.AddWithValue("@d1", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d2", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSubjectName.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    lblTotalClasses.Text = rdr.GetValue(0).ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

      }
}
