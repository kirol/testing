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
    public partial class frmHostelFeesPayment : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        frmReport frm = new frmReport();
        Connectionstring cs = new Connectionstring();
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmHostelFeesPayment()
        {
            InitializeComponent();
        }
      
        private void Button2_Click(object sender, EventArgs e)
        {
            
        }
      
        private void btnGetFeeList_Click(object sender, EventArgs e)
        {
            
        }
       
        public void Reset()
        {
            txtHFPID.Text = "";
            txtHostelerID.Text = "";
            txtFeePaymentID.Text = "";
            dtpPaymentDate.Text = System.DateTime.Now.ToString();
           txtPaymentMode.SelectedIndex = -1;
            txtPaymentModeDetails.Text = "";
            txtStudentName.Text = "";
            txtSection.Text = "";
            txtSession.Text = "";
            txtHostelerID.Text = "";
           btnUpdate_record.Enabled = false;
            Button2.Enabled = true;
            btnPrint.Enabled = false;
            btnDelete.Enabled = false;
            txtAdmissionNo.Focus();
        }
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Hostel Fees Payment' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmHostelFeesPayment_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtFine_TextChanged(object sender, EventArgs e)
        {
          
        }
       
        private void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {
          
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted HostelFeesPayment  having Student'" + txtStudentName + "' and AdmissionNo'" + txtAdmissionNo.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
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
        private void txtTotalPaid_Validating(object sender, CancelEventArgs e)
        {
            int val1 = 0;
            int val3 = 0;
            int.TryParse(txtGrandTotal.Text, out val1);
            int.TryParse(txtTotalPaid.Text, out val3);
            if (val3 > val1)
            {
                MessageBox.Show("Total Paid can not be more than Grand Total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTotalPaid.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                MessageBox.Show("Please retrieve Hosteler's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
      
            if (txtFine.Text == "")
            {
                MessageBox.Show("Please enter Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFine.Focus();
                return;
            }
            if (txtPaymentMode.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter  total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }

            if (Convert.ToDecimal(txtTotalPaid.Text) < 0)
            {
                MessageBox.Show("Total paid must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalPaid.Focus();
                return;
            }
            if (Convert.ToDecimal(txtBalance.Text) < 0)
            {
                MessageBox.Show("Balance is not possible less than zero", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select Session,Hosteler_ID,Installment from HostelFeesPayment where Session=@d1 and Hosteler_ID=@d2 and Installment=@d3";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Already paid", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                st1 = lblUser.Text;
                st2 = "Added new HostelFeesPayment For Student'" + txtStudentName + "' and AdmissionNo'" + txtAdmissionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully paid", "Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAdmissionNo.Text))
            {
                MessageBox.Show("Please retrieve Hosteler's info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdmissionNo.Focus();
                return;
            }
          
            if (txtFine.Text == "")
            {
                MessageBox.Show("Please enter Fine", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFine.Focus();
                return;
            }
            if (txtPaymentMode.Text == "")
            {
                MessageBox.Show("Please enter Payment Mode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
            if (txtTotalPaid.Text == "")
            {
                MessageBox.Show("Please enter  total paid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPaymentMode.Focus();
                return;
            }
            try
            {
                st1 = lblUser.Text;
                st2 = "Updated HostelFeesPayment  having Student'" + txtStudentName + "' and AdmissionNo'" + txtAdmissionNo.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated paid", "Fee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

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

        private void btnGetData_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
             SqlConnection myConnection = default(SqlConnection);
                SqlCommand MyCommand = new SqlCommand();
                SqlCommand MyCommand1 = new SqlCommand();
                SqlDataAdapter myDA = new SqlDataAdapter();
                SqlDataAdapter myDA1 = new SqlDataAdapter();
                DataSet myDS = new DataSet();
                myConnection = new SqlConnection(cs.DBcon);
                MyCommand.Connection = myConnection;
                MyCommand1.Connection = myConnection;
                MyCommand.CommandText = "SELECT * FROM HostelFeesPayment INNER JOIN Hosteler ON HostelFeesPayment.Hosteler_ID = Hosteler.HostelerID INNER JOIN Student ON Hosteler.Admission_No = Student.AdmissionNo where HostelFeesPayment.maxid='" + txtFeePaymentID.Text + "'";
                myDA.Fill(myDS, "HostelFeesPayment");
                myDA.Fill(myDS, "Hosteler");
                myDA.Fill(myDS, "Student");
                myDA1.Fill(myDS, "School");
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
            ToolTip1.SetToolTip(Button2, "Retrieve Student's Info from Hostler's List");
        }

        private void txtInstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}
