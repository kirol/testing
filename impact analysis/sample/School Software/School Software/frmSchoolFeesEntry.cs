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
    public partial class frmSchoolFeesEntry : Form
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
        public frmSchoolFeesEntry()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClass.Focus();
                    return;
                }
                if (cmbFeeName.Text == "")
                {
                    MessageBox.Show("Please select Fee Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFeeName.Focus();
                    return;
                }
                if (cmbMonth.Text == "")
                {
                    MessageBox.Show("Please select Month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMonth.Focus();
                    return;
                }
                if (txtFee.Text == "")
                {
                    MessageBox.Show("Please Enter Fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFee.Focus();
                    return;
                }
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please Enter School Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select distinct SchoolFees.class_ID ,FeeID,Month,School_ID  from Schoolfees,class,fee where class.ClassID=SchoolFees.Class_ID and Fee.ID=SchoolFees.FeeID and  class.classname='" + cmbClass.Text + "' and Fee.feename='" + cmbFeeName.Text + "' and  Month='" + cmbMonth.Text + "' and School_ID=" + txtSchoolID.Text + "";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClass.Text = "";
                    Reset();
                    cmbClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                st1 = lblUser.Text;
                st2 = "Added the New School Fees having Class='" + cmbClass.Text + "' and FeeName='" + cmbFeeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        private void Reset()
        {
            cmbClass.SelectedIndex = -1;
            cmbFeeName.SelectedIndex = -1;
            txtSchooFeesID.Text = "";
            txtFee.Text = "";
            txtFeeID.Text = "";
            txtClassID.Text = "";
            txtSchoolName.SelectedIndex = -1;
            txtSchoolID.Text = "";
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            cmbMonth.SelectedIndex = -1;
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from SchoolFees where schoolFeeID='" + txtSchooFeesID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
               if (RowsAffected > 0)
                {
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    st1 = lblUser.Text;
                    st2 = "Deleted the School Fee having Class='" + cmbClass.Text + "' and FeeName='" + cmbFeeName.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please select Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClass.Focus();
                    return;
                }
                if (cmbFeeName.Text == "")
                {
                    MessageBox.Show("Please select Fee Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFeeName.Focus();
                    return;
                }
                if (cmbMonth.Text == "")
                {
                    MessageBox.Show("Please select Month", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbMonth.Focus();
                    return;
                }
                if (txtFee.Text == "")
                {
                    MessageBox.Show("Please Enter Fee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFee.Focus();
                    return;
                }
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please Enter School Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                st1 = lblUser.Text;
                st2 = "Updated the School Fee having Class='" + cmbClass.Text + "' and FeeName='" + cmbFeeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
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
        public void FillClass()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(ClassName) FROM class";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillFee()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT distinct RTRIM(FeeName) FROM Fee";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbFeeName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillSchool()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT distinct RTRIM(SchoolName) FROM School";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSchoolName.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void frmSchoolFeesEntry_Load(object sender, EventArgs e)
        {
            FillClass();
            FillFee();
            FillSchool();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ClassID FROM Class where ClassName = '" + cmbClass.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassID.Text = rdr.GetInt32(0).ToString().Trim();
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

        private void btnGetData_Click(object sender, EventArgs e)
        {
           frmSchoolFeesList frm = new frmSchoolFeesList(this);
            frm.lblSET.Text = "R1";
            frm.ShowDialog();
        }

        private void txtSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(SchoolID) FROM School where SchoolName = '" + txtSchoolName.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSchoolID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
