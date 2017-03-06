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
    public partial class frmStudentAttendance : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        SqlDataAdapter adp;
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        string status = null;
        public frmStudentAttendance()
        {
            InitializeComponent();
        }
        public void FillSchool()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT Distinct Rtrim(School.SchoolName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbSchoolSearch.Items.Clear();
                while (rdr.Read())
                {
                    cmbSchoolSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fillStaffName()
        {
            try
            {
                con = new SqlConnection(cs.DBcon );
                con.Open();
                adp = new SqlDataAdapter();
                adp.SelectCommand = new SqlCommand("SELECT Rtrim(Employee.EmployeeName) FROM Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID WHERE (Designations.Designation = 'Teacher')", con);
                ds = new DataSet("ds");
                adp.Fill(ds);
                dtable = ds.Tables[0];
                cmbStaffName.Items.Clear();
                foreach (DataRow drow in dtable.Rows)
                {
                    cmbStaffName.Items.Add(drow[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Reset()
        {
            cmbSchoolSearch .SelectedIndex = -1;
            CmbClassSearch.SelectedIndex = -1;
            cmbBatchSearch.SelectedIndex = -1;
            txtSubjectCode.Text = "";
            listView1.Items.Clear();
            cmbBatchSearch .Enabled = false;
            CmbClassSearch.Enabled = false;
            btnUpdate_record.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            listView1.Items.Clear();
            cmbSubjectName.SelectedIndex = -1;
            cmbSubjectName.Enabled = false;
            dtpDate.Text = System.DateTime.Now.ToString();
            cmbStaffName.Text = "";
            txtStaffID.Text = "";
            txtEmployeeID.Text = "";
            FillSchool();
            fillStaffName();
          
        }

        private void frmStudentAttendance_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void cmbSchoolSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBatchSearch.Items.Clear();
                cmbBatchSearch.Text = "";
                cmbBatchSearch.Enabled = true;
                cmbBatchSearch.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Sessions.Session) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where School.SchoolName='" + cmbSchoolSearch.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbBatchSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBatchSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbClassSearch.Items.Clear();
                CmbClassSearch.Text = "";
                CmbClassSearch.Enabled = true;
                CmbClassSearch.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID where School.SchoolName=@d1 and Sessions.Session=@d2";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchoolSearch.Text);
                cmd.Parameters.AddWithValue("@d2", cmbBatchSearch.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CmbClassSearch.Items.Add(rdr[0]);
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

        private void cmbSubjectName_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void cmbStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Rtrim(Employee.EMPMAXID),Rtrim(Employee.EMPID) FROM Employee INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID WHERE (Designations.Designation = 'Teacher') and EmployeeName=@d1 order by 1";
                cmd.Parameters.AddWithValue("@d1", cmbStaffName .Text);
               rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtStaffID.Text = rdr.GetValue(0).ToString();
                    txtEmployeeID.Text = rdr.GetValue(1).ToString();
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
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchoolSearch .Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchoolSearch.Focus();
                    return;
                }
                if (cmbBatchSearch .Text== "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBatchSearch.Focus();
                    return;
                }
                if (CmbClassSearch.Text== "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbClassSearch.Focus();
                    return;
                }
                if (cmbSubjectName.Text== "")
                {
                    MessageBox.Show("Please select subject name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubjectName.Focus();
                    return;
                }
                if (cmbStaffName.Text == "")
                {
                    MessageBox.Show("Please select staff name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStaffName.Focus();
                    return;
                }
                if (txtStaffID.Text == "")
                {
                    MessageBox.Show("Please retrieve staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStaffID.Focus();
                    return;
                }
               
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("Sorry nothing to save.. Please retrieve data in listview", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                con = new SqlConnection(cs.DBcon);
                con.Open();
               string cd = "Insert Into AttendanceMaster(AttendanceID,StaffID,AttendanceDate,SubjectID) Values(@d1,@d2,@d3,@d4)";
                cmd = new SqlCommand(cd);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtAttendanceID.Text);
                cmd.Parameters.AddWithValue("@d2", txtEmployeeID.Text);
                cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date);
                cmd.Parameters.AddWithValue("@d4", txtSubjectID.Text);
               cmd.ExecuteNonQuery();
                con.Close();
        
               MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtSubjectCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct Rtrim(Subject.SubjectID) FROM Subject INNER JOIN School ON Subject.SchoolID = School.SchoolID INNER JOIN Class ON Subject.ClassID = Class.ClassID INNER JOIN Sessions ON Subject.SessionID = Sessions.SessionID  where Sessions.Session=@d1 and Class.ClassName=@d2 and School.SchoolName=@d3 and Subjectcode=@d4 order by 1";
                cmd.Parameters.AddWithValue("@d1", cmbBatchSearch.Text);
                cmd.Parameters.AddWithValue("@d2", CmbClassSearch.Text);
                cmd.Parameters.AddWithValue("@d3", cmbSchoolSearch.Text);
                cmd.Parameters.AddWithValue("@d4", txtSubjectCode.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSubjectID.Text = rdr.GetValue(0).ToString();
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
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from Attendance where AttendanceID='" + txtAttendanceID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                   MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                }
                else
                {
                    MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
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
        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchoolSearch.Text == "")
                {
                    MessageBox.Show("Please select school name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchoolSearch.Focus();
                    return;
                }
                if (cmbBatchSearch.Text == "")
                {
                    MessageBox.Show("Please select session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBatchSearch.Focus();
                    return;
                }
                if (CmbClassSearch.Text == "")
                {
                    MessageBox.Show("Please select class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbClassSearch.Focus();
                    return;
                }
                if (cmbSubjectName.Text == "")
                {
                    MessageBox.Show("Please select subject name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSubjectName.Focus();
                    return;
                }
                if (cmbStaffName.Text == "")
                {
                    MessageBox.Show("Please select staff name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbStaffName.Focus();
                    return;
                }
                if (txtStaffID.Text == "")
                {
                    MessageBox.Show("Please retrieve staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStaffID.Focus();
                    return;
                }

                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("Sorry nothing to save.. Please retrieve data in listview", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cd = "Update Set AttendanceMaster SetStaffID=@d2,AttendanceDate=@d3,SubjectID=@d4 where AttendanceID=@d1";
                cmd = new SqlCommand(cd);
                cmd.Parameters.AddWithValue("@d1", txtAttendanceID.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from Attendance where Attendance_ID='" + txtAttendanceID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
               
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAttendanceList frm = new frmAttendanceList(this);
            frm.lblSET.Text = "R1";
            frm.ShowDialog();
        }
    }
}
