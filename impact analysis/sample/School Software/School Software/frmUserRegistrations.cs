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
    public partial class frmUserRegistrations : Form
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
        public frmUserRegistrations()
        {
            InitializeComponent();
        }
        public void FillDesignation()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Designation) FROM Designations ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
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
        public void GetData()
        {
           
        }
        private void frmUserRegistrations_Load(object sender, EventArgs e)
        {
           
        }

        private void txtDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Please enter userID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
                return;
            }
            if (txtDesignation.Text == "")
            {
                MessageBox.Show("Please select user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserID.Focus();
                return;
            }
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
         
            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please enter contact no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContactNo.Focus();
                return;
            }
            if (txtEmail_Address.Text == "")
            {
                MessageBox.Show("Please enter email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail_Address.Focus();
                return;
            }
            con = new SqlConnection(cs.DBcon);
            con.Open();
            string ct = "SELECT Rtrim(Users.Designation_ID) FROM Users INNER JOIN Designations ON Users.Designation_ID = Designations.DesignationID where Designations.Designation_ID ='"+txtDesignationID.Text+"'";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("Super Admin Already Exists", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if ((rdr != null))
                {
                    rdr.Close();
                }
                return;
            }
              
                btnSave.Enabled = false;
                st1 = lblUser.Text;
                st2 = "New User '" + txtName.Text + "' is Registered  Successfully";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Registered", "User", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txtUserID.Text = "";
            txtName.Text = "";
            txtDesignationID.Text = "";
            txtID.Text = "";
            txtPassword.Text = "";
            txtContactNo.Text = "";
            txtUserID.Text = "";
            txtEmail_Address.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            txtDesignation.Text = "";
            GetData();
        }
        private void delete_records()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from Users where ID='" + txtID.Text + "'";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "User '" + txtName.Text + "' is Deleted  Successfully";
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDesignation.Text == "Super Admin")
            {
                MessageBox.Show(" Super Admin Account can not be deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
                GetData();
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
           txtID.Text = dr.Cells[0].Value.ToString();
            txtUserID.Text = dr.Cells[1].Value.ToString();
            txtDesignationID.Text = dr.Cells[2].Value.ToString();
           txtDesignation.Text = dr.Cells[3].Value.ToString();
           txtPassword.Text = dr.Cells[4].Value.ToString();
            txtName.Text = dr.Cells[5].Value.ToString();
            txtContactNo.Text = dr.Cells[6].Value.ToString();
            txtEmail_Address.Text = dr.Cells[7].Value.ToString();
            lblUser.Text = lblUser.Text;
            lblUserType.Text = lblUserType.Text;
            btnDelete.Enabled = true;
            btnUpdate_record.Enabled = true;
            btnSave.Enabled = false;
            txtUserID.Focus();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
            if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
            {
                dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
            }
            Brush b = SystemBrushes.ButtonHighlight;
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        
        }

    }
}
