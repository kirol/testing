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
    public partial class frmBookIssueReportStudent : Form
    {
        DataTable dtable = new DataTable();
        frmReport frm = new frmReport();
        DataSet ds = new DataSet();
        Connectionstring cs = new Connectionstring();
        public frmBookIssueReportStudent()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                RptBookIssueReportStudent rpt = new RptBookIssueReportStudent();
                SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                DataSet  myDS = new DataSet();
                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;
                MyCommand.CommandText = "SELECT * FROM BookIssue_Student INNER JOIN Book ON BookIssue_Student.AccessionNo = Book.AccessionNo INNER JOIN Student ON BookIssue_Student.AdmissionNo = Student.AdmissionNo INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID  INNER JOIN   Section ON ClassSection.Section_ID = Section.SectionID where BookIssue_Student.IssueDate between @d1 and @d2 order by IssueDate";
                MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "IssueDate").Value = dtpDateFrom.Value.Date;
                MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "IssueDate").Value = dtpDateTo.Value.Date;
                MyCommand.CommandType = CommandType.Text;
                myDA.SelectCommand = MyCommand;
                myDA.Fill(myDS, "BookIssue_Student");
                myDA.Fill(myDS, "Book");
                myDA.Fill(myDS, "Student");
                myDA.Fill(myDS, "ClassSection");
                myDA.Fill(myDS, "class");
                myDA.Fill(myDS, "Section");
                myDA.Fill(myDS, "School");
                rpt.SetDataSource(myDS);
                crystalReportViewer1.ReportSource = rpt;
           }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmBookIssueReportStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
