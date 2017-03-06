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
    public partial class frmStaffAdvanceEntryReport : Form
    {
        DataTable dtable = new DataTable();
        frmReport frm = new frmReport();
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        public frmStaffAdvanceEntryReport()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                RptStaffAdvanceEntry rpt = new RptStaffAdvanceEntry();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT Employee.EMPMAXID, Employee.EmployeeName, School.SchoolName, Designations.Designation, Department.DepartmentName, AdvanceEntry.Amount, AdvanceEntry.StaffID, AdvanceEntry.AdvanceID,AdvanceEntry.Deduction, AdvanceEntry.WorkingDate FROM AdvanceEntry INNER JOIN Employee ON AdvanceEntry.StaffID = Employee.EMPID INNER JOIN School ON Employee.SchoolID = School.SchoolID INNER JOIN Designations ON Employee.Designation_ID = Designations.DesignationID INNER JOIN Department ON Employee.Department_ID = Department.DepartmentID where WorkingDate between @d1 and @d2 and Amount > 0 order by WorkingDate";
               MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
               frm.ShowDialog();
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

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStaffAdvanceEntryReport_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
        }
    }
}
