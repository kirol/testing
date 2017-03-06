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
    public partial class frmEmployeeAttendanceEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmEmployeeAttendanceEntry()
        {
            InitializeComponent();
        }
      
        public void auto()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT Rtrim(Employee.EMPID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName) FROM  Employee order by Empmaxid";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Attendance' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmEmployeeAttendanceEntry_Load(object sender, EventArgs e)
        {
            auto();
        }
        public void Reset()
        {
            tWorkingDate.Text = System .DateTime.Now.ToString();
            txtStaffID .Text = "";
            txtStaffName.Text = "";
            InTime.Text = System.DateTime.Now.ToString(); 
            OutTime.Text = System.DateTime.Now.ToString();
            txtStatus.SelectedIndex = -1;
            txtStaffName.Text = "";
            auto();
            btnDelete.Enabled = false;
            btnUpdate_record .Enabled = false;
            txtOutTime.Visible = false;
            txtInTime.Visible = false;
            func();
            tWorkingDate.Enabled = true;
            InTime.Enabled = false;
            OutTime.Enabled = false;
        }

        private void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from StaffAttendance where id=" + txtID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Staff Attendance is Deleted For Staff='" + txtStaffName.Text + "' having StaffID='" + txtmaxID.Text + "' and Working Date '" + tWorkingDate.Value.Date + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                   MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    auto();
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1 .SelectedRows[0];
                txtStaffID.Text = dr.Cells[0].Value.ToString();
                txtmaxID.Text = dr.Cells[1].Value.ToString();
                txtStaffName.Text = dr.Cells[2].Value.ToString();
          }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtStatus.Text == "P")
            {
                txtOutTime.Visible = false;
                txtInTime.Visible = false;
                InTime.Enabled = true;
                OutTime.Enabled = true;
                InTime.Text = System.DateTime.Now.ToString();
                OutTime.Text = System.DateTime.Now.ToString();

            }
            else if (txtStatus.Text == "A")
            {
                txtOutTime.Visible = true;
                txtInTime.Visible = true;
                txtOutTime.Text = "00:00:00";
                txtInTime.Text = "00:00:00";
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtmaxID.Text== "")
            {
                MessageBox.Show("Please retrieve Staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaxID.Focus();
                return;
            }
            if (txtStatus.Text== "")
            {
                MessageBox.Show("Please select Status", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStatus.Focus();
                return;
            }
            if (InTime.Value >= OutTime.Value)
            {
                MessageBox.Show("Out Time cannot be less than or equal to IN Time", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select StaffID,workingdate from StaffAttendance where StaffID=" + txtStaffID.Text + " and workingdate=@d1";
                cmd = new SqlCommand(ct);
                cmd.Parameters.AddWithValue("@d1", tWorkingDate.Value.Date);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Staff today's attendance is already saved", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                auto();
                con = new SqlConnection(cs.DBcon );
                con.Open();
                string cb = "insert into StaffAttendance(Workingdate,StaffID,status,intime,outtime) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", tWorkingDate.Value.Date);
                cmd.Parameters.AddWithValue("@d2", txtStaffID.Text);
                cmd.Parameters.AddWithValue("@d3", txtStatus.Text);
                if (txtStatus.Text == "P")
                {
                    cmd.Parameters.AddWithValue("@d4", InTime.Text);
                    cmd.Parameters.AddWithValue("@d5", OutTime.Text);
                }
                else if (txtStatus.Text == "A")
                {
                    cmd.Parameters.AddWithValue("@d4", txtInTime.Text);
                    cmd.Parameters.AddWithValue("@d5", txtOutTime.Text);
                }
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
                st1 = lblUser.Text;
                st2 = "Staff Attendance is Taken For Staff='" + txtStaffName.Text + "' having StaffID='" + txtmaxID.Text + "' and Working Date '" + tWorkingDate.Value.Date + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                con.Close();
              }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (txtmaxID.Text =="")
            {
                MessageBox.Show("Please retrieve Staff id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaxID.Focus();
                return;
            }
            if (txtStatus.Text== "")
            {
                MessageBox.Show("Please select Status", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStatus.Focus();
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update StaffAttendance set StaffID=@d2,status=@d3,intime=@d4,outtime=@d5 where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d2", txtStaffID.Text);
                cmd.Parameters.AddWithValue("@d3", txtStatus.Text);
                if (txtStatus.Text == "P")
                {
                    cmd.Parameters.AddWithValue("@d4", InTime.Text);
                    cmd.Parameters.AddWithValue("@d5", OutTime.Text);
                }
                else if (txtStatus.Text == "A")
                {
                    cmd.Parameters.AddWithValue("@d4", txtInTime.Text);
                    cmd.Parameters.AddWithValue("@d5", txtOutTime.Text);
                }
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
                st1 = lblUser.Text;
                st2 = "Staff Attendance is Updated For Staff='" + txtStaffName.Text + "' having StaffID='" + txtmaxID.Text + "' and Working Date '" + tWorkingDate.Value.Date + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                con.Close();
                auto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void btnGetData_Click(object sender, EventArgs e)
        {
           frmEmployeeAttendanceRecords frm = new frmEmployeeAttendanceRecords(this);
            frm.lblSet.Text = "R1";
            frm.lblUser.Text = lblUser.Text;
            frm.ShowDialog();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }


    }
}
