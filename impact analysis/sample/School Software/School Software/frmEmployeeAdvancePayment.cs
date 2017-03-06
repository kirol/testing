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
    public partial class frmEmployeeAdvancePayment : Form
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
        public frmEmployeeAdvancePayment()
        {
            InitializeComponent();
        }
       
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Advance Payment' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmEmployeeAdvancePayment_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtmaxID.Text == "")
            {
                MessageBox.Show("Please retrieve staff info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmaxID.Focus();
                return;
            }
            if (txtAmount.Text =="")
            {
                MessageBox.Show("Please enter Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            try
            {
               con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into advanceentry(workingdate,StaffID,amount,deduction) VALUES (@d1," + txtStaffID.Text + "," + txtAmount.Text + ",0)";
                cmd = new SqlCommand(cb);
                cmd.Parameters.AddWithValue("@d1",txtEntryDate.Value);
                cmd.Connection = con;
                cmd.ExecuteReader();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
                st1 = lblUser.Text;
                st2 = "New Advance Payment is Taken By Staff on Date '"+txtEntryDate.Value.Date+"' having StaffID='" + txtmaxID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully saved", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (txtStaffID.Text=="")
            {
                MessageBox.Show("Please retrieve Staff info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStaffID.Focus();
                return;
            }
            if (txtAmount.Text=="")
            {
                MessageBox.Show("Please enter Amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            try
            {
               
                st1 = lblUser.Text;
                st2 = "Advance Payment is Taken By Staff on Date '" + txtEntryDate.Value.Date + "' is Updated For StaffID='" + txtmaxID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Entry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                con.Close();
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Reset()
        {
            txtStaffID.Text = "";
            txtStaffName.Text = "";
            txtAmount.Text = "";
            txtEntryDate.Text = System.DateTime.Now.ToString();
         
            btnDelete.Enabled = false;
            func();
            btnUpdate_record.Enabled = false;
            txtEntryDate.Enabled = true;
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtStaffID.Text = dr.Cells[0].Value.ToString();
                txtmaxID.Text = dr.Cells[1].Value.ToString();
                txtStaffName.Text = dr.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        private void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from AdvanceEntry where advanceid=" + txtID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Advance Payment is Taken By Staff on Date '" + txtEntryDate.Value.Date + "' is Deleted For StaffID='" + txtmaxID.Text + "'";
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

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
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

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            frmEmployeeAdvancePaymentList frm = new frmEmployeeAdvancePaymentList(this);
            frm.lblSet.Text = "R1";
            frm.lblUser.Text = lblUser.Text;
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteRecord();
            }
        }
    }
}
