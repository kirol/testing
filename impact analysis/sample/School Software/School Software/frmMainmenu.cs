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
    public partial class frmMainmenu : Form
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

        public frmMainmenu()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           TIME.Text = DateTime.Now.ToString();
            timer1.Start();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

       private void schoolEntryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           frmSchoolEntry frm = new frmSchoolEntry(this);
            frm.ShowDialog();
        }

        private void subjectEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void frmMainmenu_Load(object sender, EventArgs e)
        {
           

           
            }
        

        private void schoolTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSchoolType frm = new frmSchoolType(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void classEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClassEntry frm = new frmClassEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void sectionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSectionEntry frm = new frmSectionEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmClassSection frm = new frmClassSection();
            frm.ShowDialog();
        }

        private void sessionEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSessionEntry frm = new frmSessionEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void employeeDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeDepartment frm = new frmEmployeeDepartment();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void employeeDesignationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmEmployeeDesignations frm = new frmEmployeeDesignations();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void feeTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFeeTypes frm = new frmFeeTypes();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void schoolFeesEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmSchoolFeesEntry frm = new frmSchoolFeesEntry();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void busEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void locationEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocationEntry frm = new frmLocationEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void busInstallmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void hostelEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmHostelEntry frm = new frmHostelEntry();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void hostelInstallmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHostelInstallment frm = new frmHostelInstallment();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void gradingLevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradingLevels frm = new frmGradingLevels();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void examGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExamEntry frm = new frmExamEntry();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksEntry frm = new frmBooksEntry(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void bookSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBookSuppliersEntry frm = new frmBookSuppliersEntry();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void journalAndMagazinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJournalAndMagazines frm = new frmJournalAndMagazines(this);
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void studentDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void userRegistrationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistrations frm = new frmUserRegistrations();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void userGrantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmUserGrants frm = new frmUserGrants();
            frm.lblUser.Text = User.Text;
            frm.lblUserType.Text = UserType.Text;
            frm.ShowDialog();
        }

        private void studentRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmStudentRegistration frm = new frmStudentRegistration();
           frm.lblUser.Text = User.Text;
           con = new SqlConnection(cs.DBcon);
           con.Open();
           cmd = con.CreateCommand();
           cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student Registration' and Users.UserID='" + User.Text + "' ";
           rdr = cmd.ExecuteReader();
           if (rdr.Read())
           {
               frm.lblsave.Text = rdr[0].ToString().Trim();
               frm.lblview.Text = rdr[1].ToString().Trim();
           }
           if ((rdr != null))
           {
               rdr.Close();
           }
           if (con.State == ConnectionState.Open)
           {
               con.Close();
           }

           if (frm.lblsave.Text == "True")
               frm.btnSave.Enabled = true;
           else
               frm.btnSave.Enabled = false;

           if (frm.lblview.Text == "True")
               frm.btnGetData.Enabled = true;
           else
               frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void studentDiscountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentDiscount frm = new frmStudentDiscount();
            frm.ShowDialog();
        }

        private void hostelersEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void busHoldersEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusHolderStudents frm = new frmBusHolderStudents();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Student BusHolder Entry' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblSave.Text = rdr[0].ToString().Trim();
                frm.lblGetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblSave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblGetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void examScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void employeeRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void employeeDiscountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStaffDiscount frm = new frmStaffDiscount();
            frm.ShowDialog();
        }

        private void booksClassificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmBooksClassifications frm = new frmBooksClassifications();
           frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksSubcategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksSubCategory frm = new frmBooksSubCategory();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void employeeAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAttendanceEntry frm = new frmEmployeeAttendanceEntry();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Attendance' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void employeeAdvancePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAdvancePayment frm = new frmEmployeeAdvancePayment();
            frm.lblUser.Text = User.Text;
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves),RTRIM(Getdata)  from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Advance Payment' and Users.UserID='" + User.Text + "' ";
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                frm.lblsave.Text = rdr[0].ToString().Trim();
                frm.lblgetdata.Text = rdr[1].ToString().Trim();
            }
            if ((rdr != null))
            {
                rdr.Close();
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            if (frm.lblsave.Text == "True")
                frm.btnSave.Enabled = true;
            else
                frm.btnSave.Enabled = false;

            if (frm.lblgetdata.Text == "True")
                frm.btnGetData.Enabled = true;
            else
                frm.btnGetData.Enabled = false;
            frm.ShowDialog();
        }

        private void salaryPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void schoolFeesPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void hostelFeesPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void busFeesPaymentStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void busFeesPaymentStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void booksRandomBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRandomBarcodeGenerator frm = new frmRandomBarcodeGenerator();
            frm.ShowDialog();
        }

        private void booksBarcodeGenratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcodeGeneration frm = new frmBarcodeGeneration();
           frm.ShowDialog();
        }

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogs frm = new frmLogs();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void sMSSettingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSms frm = new frmSms();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void booksFineSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void staffBookReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void studentBookIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void journalAndMagazinesBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentList frm = new frmStudentList();
            frm.ShowDialog();
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void schoolFeesListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmSchoolFeesList frm = new frmSchoolFeesList();
            frm.ShowDialog();
        }

        private void schoolFeesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void hostelersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void hostelFeesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void busHolderStudentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusHolderStudentList frm = new frmBusHolderStudentList();
            frm.ShowDialog();
        }

        private void busFeesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBusFeesPaymentStudent frm = new frmBusFeesPaymentStudent();
            frm.ShowDialog();
        }

        private void busHolderStaffListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void busFeesPaymentListStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void employeeAttendanceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAttendanceRecords frm = new frmEmployeeAttendanceRecords();
            frm.ShowDialog();
        }

        private void employeeAdvancePaymentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeAdvancePaymentList frm = new frmEmployeeAdvancePaymentList();
            frm.ShowDialog();
        }

        private void salaryPaymentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void bookSupplierListToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void booksClassifiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksList frm = new frmBooksList();
            frm.ShowDialog();
        }

        private void booksReservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void booksIssueListStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueListStudent frm = new frmBookIssueListStudent();
            frm.ShowDialog();
        }

        private void booksIssueListStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueListStaff frm = new frmBookIssueListStaff();
            frm.ShowDialog();
        }

        private void booksReturnListStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookReturnListStudent frm = new frmBookReturnListStudent();
            frm.ShowDialog();
        }

        private void booksReturnListStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksReturnListStaff frm = new frmBooksReturnListStaff();
            frm.ShowDialog();
        }

        private void subjectListToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void examScheduleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        public void Logout()
        {
            st1 = User.Text;
            st2 = "Successfully logged out";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.Show();
            frm.UserID.Text = "";
            frm.Password.Text = "";
            frm.progressBar1.Visible = false;
            frm.UserID.Focus();
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
           try
            {
                if (MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Backup();
                        Logout();
                    }
                    else
                    {
                        Logout();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Backup()
        {
          
        }
        private void dataBaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentAttendance frm = new frmStudentAttendance();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void classPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentClassPromotion frm = new frmStudentClassPromotion();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer2.Enabled = false;
        }

        private void examResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void marksLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarksLedger frm = new frmMarksLedger();
            frm.ShowDialog();
        }

        private void studentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentReport frm = new frmStudentReport();
            frm.ShowDialog();
        }

        private void identityCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentsIdentityCards frm = new frmStudentsIdentityCards();
            frm.ShowDialog();
        }

        private void feesDueListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void employeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeReport frm = new frmEmployeeReport();
            frm.ShowDialog();
        }

        private void bookReservationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksReservationReport frm = new frmBooksReservationReport();
            frm.ShowDialog();
        }

        private void bookIssueReportStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueReportStudent frm = new frmBookIssueReportStudent();
            frm.ShowDialog();
        }

        private void bookIssueReportsStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookIssueStaffReport frm = new frmBookIssueStaffReport();
            frm.ShowDialog();
        }

        private void bookReturnReportStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void booksFineCollectionReportStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBooksFineStudentReports frm = new frmBooksFineStudentReports();
            frm.ShowDialog();
        }

        private void booksFineCollectionReportStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmStaffBooksFineReport frm = new frmStaffBooksFineReport();
            frm.ShowDialog();
        }

        private void finalMarksLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarksLedger frm = new frmMarksLedger();
            frm.ShowDialog();
        }

        private void employeeBusHoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AboutBox frm = new AboutBox();
            frm.ShowDialog();
        }
        public void DBrecovery()
        {
           

        }
        private void Recovery_Click(object sender, EventArgs e)
        {
            DBrecovery();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Notepad.exe");
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("TaskMgr.exe");
        }

        private void mSWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Winword.exe");
        }

        private void wordpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Wordpad.exe");
        }

        private void usersSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserRegistrations frm = new frmUserRegistrations();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void studentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void schoolFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void busFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void hostelFeePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void salaryPaymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void feesDueListToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void randomBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRandomBarcodeGenerator frm = new frmRandomBarcodeGenerator();
            frm.ShowDialog();
        }

        private void booksBarcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBarcodeGeneration frm = new frmBarcodeGeneration();
            frm.ShowDialog();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup();
        }

        private void recoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBrecovery();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmContactMe frm = new frmContactMe();
            frm.ShowDialog();
        }

        private void sMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSms frm = new frmSms();
            frm.lblUser.Text = User.Text;
            frm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you really want to logout from application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (MessageBox.Show("Do you want backup database before logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Backup();
                        Logout();
                    }
                    else
                    {
                        Logout();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       }
}

