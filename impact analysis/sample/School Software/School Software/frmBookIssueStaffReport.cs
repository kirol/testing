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
    public partial class frmBookIssueStaffReport : Form
    {
        DataTable dtable = new DataTable();
        frmReport frm = new frmReport();
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        public frmBookIssueStaffReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
              RptBookIssueStaffReport rpt = new RptBookIssueStaffReport();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
             DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT  * FROM BookIssue_Staff INNER JOIN Book ON BookIssue_Staff.AccessionNo = Book.AccessionNo INNER JOIN Employee ON BookIssue_Staff.StaffID = Employee.EMPID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID where BookIssue_Staff.IssueDate between @d1 and @d2 order by IssueDate";
                MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "IssueDate").Value = dtpDateFrom.Value.Date;
                MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "IssueDate").Value = dtpDateTo.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "BookIssue_Staff");
                myDA.Fill(myDS, "Book");
                myDA.Fill(myDS, "Employee");
                myDA.Fill(myDS, "Department");
                myDA.Fill(myDS, "Designations");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
