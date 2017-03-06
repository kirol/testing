using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace School_Software
{
    public partial class frmEmployeeEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        string txtStatus = null;
        string txtStatus1 = null;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        Connectionstring cs = new Connectionstring();
        public frmEmployeeEntry()
        {
            InitializeComponent();
        }
       
        public void Reset()
        {
           txtCountry.Text = "";
            txtCity.Text = "";
            txtmotherName.Text = "";
            txtFatherName.Text = "";
            txtReligion.Text = "";
            txtDOB.Text = "";
            txtEmployeeName.Text = "";
            txtEmployeeMAX.Text= "";
            func();
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            txtEmployeeName.Focus();
        }
      
        private void func()
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT RTRIM(Saves) from UserGrants inner join Users on UserGrants.UserId=Users.ID where Forms='Employee Registration' and Users.UserID='" + lblUser.Text + "' ";
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
        private void frmEmployeeEntry_Load(object sender, EventArgs e)
        {
           
        }
      
        private void txtSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(School.SchoolID) FROM School Where School.SchoolName = '" + txtSchoolName.Text + "'";
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

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            try
            {

                if ((radioButton1.Checked == false & radioButton2.Checked == false))
                {
                    MessageBox.Show("Please select Gender", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if ((radioButton1.Checked == true))
                {
                    txtStatus = radioButton1.Text;
                }
                if ((radioButton2.Checked == true))
                {
                    txtStatus = radioButton2.Text;
                }
                if ((txtcheckBox.Checked == true))
                {
                    txtStatus1 = txtcheckBox.Text;
                }
                if ((txtcheckBox.Checked == false))
                {
                    txtStatus1 = "Inactive";
                }
                if (txtEmployeeName.Text == "")
                {
                    MessageBox.Show("Please enter Employee name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeName.Focus();
                    return;
                }
                if (!txtDOB.MaskFull)
                {
                    MessageBox.Show("Please Enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDOB.Focus();
                    return;
                }
                if (DOB.Text == "")
                {
                    MessageBox.Show("Please enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DOB.Focus();
                    return;
                }
                if (txtFatherName.Text == "")
                {
                    MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtCity.Text == "")
                {
                    MessageBox.Show("Please enter City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCity.Focus();
                    return;
                }
                if (txtCountry.Text == "")
                {
                    MessageBox.Show("Please enter Country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCountry.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }

                if (txtDepartment.Text == "")
                {
                    MessageBox.Show("Please select department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDepartment.Focus();
                    return;
                }
                if (txtBloodGroup.Text == "")
                {
                    MessageBox.Show("Please Select Blood Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBloodGroup.Focus();
                    return;
                }

                if (txtDesignation.Text == "")
                {
                    MessageBox.Show("Please enter staff designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesignation.Focus();
                    return;
                }
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                if (txtBasicSalary.Text == "")
                {
                    MessageBox.Show("Please enter basic salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBasicSalary.Focus();
                    return;
                }

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please browse & select photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Browse.Focus();
                    return;
                }
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please Select School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
               st1 = lblUser.Text;
                st2 = "Added the New Employee'" + txtEmployeeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
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

        private void btnUpdate_record_Click_1(object sender, EventArgs e)
        {
            try
            {
              
                if ((radioButton1.Checked == true))
                {
                    txtStatus = radioButton1.Text;
                }
                if ((radioButton2.Checked == true))
                {
                    txtStatus = radioButton2.Text;
                }
                if ((txtcheckBox.Checked == true))
                {
                    txtStatus1 = txtcheckBox.Text;
                }
                if ((txtcheckBox.Checked == false))
                {
                    txtStatus1 = "Inactive";
                }
                if (txtEmployeeName.Text == "")
                {
                    MessageBox.Show("Please enter Employee name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmployeeName.Focus();
                    return;
                }
                if (!txtDOB.MaskFull)
                {
                    MessageBox.Show("Please Enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDOB.Focus();
                    return;
                }
                if (DOB.Text == "")
                {
                    MessageBox.Show("Please enter DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DOB.Focus();
                    return;
                }
                if (txtFatherName.Text == "")
                {
                    MessageBox.Show("Please enter father's name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtCity.Text == "")
                {
                    MessageBox.Show("Please enter City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCity.Focus();
                    return;
                }
                if (txtCountry.Text == "")
                {
                    MessageBox.Show("Please enter Country.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCountry.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter Contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }

                if (txtDepartment.Text == "")
                {
                    MessageBox.Show("Please select department", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDepartment.Focus();
                    return;
                }
                if (txtBloodGroup.Text == "")
                {
                    MessageBox.Show("Please Select Blood Group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBloodGroup.Focus();
                    return;
                }

                if (txtDesignation.Text == "")
                {
                    MessageBox.Show("Please enter staff designation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDesignation.Focus();
                    return;
                }
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }
                if (txtBasicSalary.Text == "")
                {
                    MessageBox.Show("Please enter basic salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBasicSalary.Focus();
                    return;
                }

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Please browse & select photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Browse.Focus();
                    return;
                }
                if (txtSchoolName.Text == "")
                {
                    MessageBox.Show("Please Select School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                st1 = lblUser.Text;
                st2 = "Updated the Staff'" + txtEmployeeName.Text + "' having EmployeeID '" + txtEmployeeID.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDepartment_SelectedIndexChanged_1(object sender, EventArgs e)
        {
           
        }

        private void txtDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Browse_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = School_Software.Properties.Resources.photo;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
               
            }
        }

        private void btnGetData_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
