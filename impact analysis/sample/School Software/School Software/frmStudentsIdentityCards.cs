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
    public partial class frmStudentsIdentityCards : Form
    {
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        frmReport frm = new frmReport();
        SqlDataAdapter adp;
        DataSet ds;
        Connectionstring cs = new Connectionstring();
        public frmStudentsIdentityCards()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmStudentList frm = new frmStudentList(this);
            frm.lblSET.Text = "V5";
            frm.Show();
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAdmissionNo.Text))
                {
                    MessageBox.Show("Please retrieve Admission No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAdmissionNo.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Student.AdmissionNo, Student.EnrollmentNo, Student.StudentName, Student.DOB, Student.Gender, Student.FatherName, Student.MotherName, Student.ContactNo, Student.Photo, School.SchoolName,School.Address, School.ContactNo AS Expr1, School.Email, School.Fax, School.Website, School.City, School.Photo AS Expr2, Class.ClassName, Section.SectionName, Sessions.Session FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID Where Student.AdmissionNo=@d1", con);
                cmd.Parameters.AddWithValue("@d1", txtAdmissionNo.Text);
                adp = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adp.Fill(table);
                ds = new DataSet();
                con.Close();
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

        private void Button2_MouseHover(object sender, EventArgs e)
        {
            ToolTip1.IsBalloon = true;
            ToolTip1.UseAnimation = true;
            ToolTip1.ToolTipTitle = "";
            ToolTip1.SetToolTip(Button2, "Retrieve Student's Info from Student's List");
        }

        private void frmStudentsIdentityCards_Load(object sender, EventArgs e)
        {

        }
    }
}
