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
    public partial class frmEmployeeReport : Form
    {
        DataTable dtable = new DataTable();
        DataTable dt = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        frmReport frm = new frmReport();
        SqlDataAdapter adp;
        DataSet ds;
        SqlDataReader rdr = null;
        Connectionstring cs = new Connectionstring();
        public frmEmployeeReport()
        {
            InitializeComponent();
        }
        public void School()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT Distinct Rtrim(School.SchoolName) FROM Employee INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSchool.Items.Clear();
                while (rdr.Read())
                {
                    txtSchool.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Reset()
        {
            txtSchool.SelectedIndex = -1;
            txtDesignation.SelectedIndex = -1;
            txtDepartment.SelectedIndex = -1;
          
            txtDesignation.Enabled = false;
            txtDepartment.Enabled = false;
            School();

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSchool.Text == "")
                {
                    MessageBox.Show("Please select school", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSchool.Focus();
                    return;
                }
                if (txtDepartment.Text == "")
                {
                    MessageBox.Show("Please Enter Session", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDepartment.Focus();
                    return;
                }
                if (txtDesignation.Text == "")
                {
                    MessageBox.Show("Please Enter Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDesignation.Focus();
                    return;
                }
               
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Timer1.Enabled = true;
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    cmd = new SqlCommand("SELECT Department.DepartmentName, Employee.EMPMAXID, Employee.EMPID, Employee.EmployeeName, Employee.Gender, Employee.DOB, Employee.FatherName, Employee.ContactNo, Employee.DateOfJoining,Employee.City, Employee.Country, Employee.Address, Employee.Salary, Employee.Status, Employee.BloodGroup, Employee.Religion, Employee.Photo, School.SchoolName, Designations.Designation FROM Employee INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID where SchoolName=@d1 and DepartmentName=@d2 and Designation=@d3 order by employeeName", con);
                    cmd.Parameters.AddWithValue("@d1", txtSchool.Text);
                    cmd.Parameters.AddWithValue("@d2", txtDepartment.Text);
                    cmd.Parameters.AddWithValue("@d3", txtDesignation.Text);
                    adp = new SqlDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adp.Fill(table);
                    ds = new DataSet();
                    con.Close();
                    ds.Tables.Add(table);
                    ds.WriteXmlSchema("Employee.xml");
                    RptEmployeeReport rpt = new RptEmployeeReport();
                    rpt.SetDataSource(ds);
                    frm.crystalReportViewer1.ReportSource = rpt;
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDepartment.Items.Clear();
                txtDepartment.Text = "";
                txtDepartment.Enabled = true;
                txtDepartment.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT Distinct Rtrim(Department.DepartmentName) FROM Employee INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID where School.schoolname='" + txtSchool.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtDepartment.Items.Clear();
                while (rdr.Read())
                {
                    txtDepartment.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtDesignation.Items.Clear();
                txtDesignation.Text = "";
                txtDesignation.Enabled = true;
                txtDesignation.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT Distinct Rtrim(Designations.Designation) FROM Employee INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID where Departmentname='" + txtDepartment.Text + "' and SchoolName='"+txtSchool.Text+"'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                 txtDesignation.Items.Clear();
                while (rdr.Read())
                {
                    txtDesignation.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEmployeeReport_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }
    }
}
