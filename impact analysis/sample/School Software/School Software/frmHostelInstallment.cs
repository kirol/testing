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
    public partial class frmHostelInstallment : Form
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
        public frmHostelInstallment()
        {
            InitializeComponent();
        }
     
        private void frmHostelInstallment_Load(object sender, EventArgs e)
        {
            
        }

        private void txtSchoolName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
       
        private void txtHostel_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
      public void Reset()
      {
        txtInstallment.Text = "";
        txtHostel.SelectedIndex = -1;
        txtClass.SelectedIndex = -1;
        txtSchoolName.SelectedIndex = -1;
        txtSearchByClass.Text = "";
        txtCharges.Text = "";
        txtSchoolID.Text = "";
        txthostelID.Text = "";
        txtClassID.Text = "";
        txtIHID.Text = "";
        txtInstallment.Focus();
        btnSave.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
 
         }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInstallment.Text == "")
            {
                MessageBox.Show("Please enter Installment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInstallment.Focus();
                return;
            }
            if (txtHostel.Text == "")
            {
                MessageBox.Show("Please enter Hostel Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHostel.Focus();
                return;
            }
            if (txtSchoolName.Text == "")
            {
                MessageBox.Show("Please enter School", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSchoolName.Focus();
                return;
            }
            if (txtClass.Text == "")
            {
                MessageBox.Show("Please enter Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClass.Focus();
                return;
            }
          st1 = lblUser.Text;
          st2 = "Added New HostelInstallment'" + txtInstallment.Text + "' having SchoolName'" + txtSchoolName.Text + "' and Class'" + txtClass.Text + "' and Hostel'" + txtHostel.Text + "'";
          cf.LogFunc(st1, System.DateTime.Now, st2);
           MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSave.Enabled = false;
        }

        private void txtSearchByClass_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtsearchBySchool_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb2 = "update HostelFeesPayment set Installment=@d1 where Installment=@d4";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtInstallment.Text);
                cmd.ExecuteReader();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
