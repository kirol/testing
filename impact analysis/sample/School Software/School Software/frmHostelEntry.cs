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
    public partial class frmHostelEntry : Form
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
        public frmHostelEntry()
        {
            InitializeComponent();
        }
        public void Reset()
        {
        txtAddress.Text = "";
        txtIncharge.Text = "";
        txtMobile.Text = "";
        txtPhoneNo.Text = "";
        txthostelID.Text = "";
        txtHostelName.Text = "";
        txtHostelName.Focus();
        btnSave.Enabled = true;
        btnUpdate.Enabled = false;
        btnDelete.Enabled = false;
    }
       
        private void delete_records()
        {
          try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cm5 = "select Hostel from HostelFeesPayment where Hostel=@find";
                cmd = new SqlCommand(cm5);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 150, "Hostel"));
                cmd.Parameters["@find"].Value = txtHostelName.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already Use in HostelFeesPayment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
               
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted Hostel  '" + txtHostelName.Text + "'";
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
        private void frmHostelEntry_Load(object sender, EventArgs e)
        {
      
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHostelName.Text == "")
                {
                    MessageBox.Show("Please enter hostel name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtHostelName.Focus();
                    return;
                }
                if (txtPhoneNo.Text == "")
                {
                    MessageBox.Show("Please enter Phone Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNo.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPhoneNo.Focus();
                    return;
                }
               con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into Hostel(HostelName,Address,incharge,Phone,mobile) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtHostelName.Text);
                cmd.Parameters.AddWithValue("@d2", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d4", txtIncharge.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "added New  Hostel  '" + txtHostelName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

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
               
               con = new SqlConnection(cs.DBcon);
               con.Open();
               string cb3 = "Update HostelFeesPayment set Hostel= '" + txtHostelName.Text + "' where Hostel='" + textBox1.Text + "'";
               cmd = new SqlCommand(cb3);
               cmd.ExecuteReader();
               st1 = lblUser.Text;
               st2 = "Updated Hostel  '" + txtHostelName.Text + "'";
               cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully updated", "Hostel Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnUpdate.Enabled = false;
               con.Close();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
             if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
              
            } 
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txthostelID.Text = dr.Cells[0].Value.ToString();
                txtHostelName.Text = dr.Cells[1].Value.ToString();
                textBox1.Text = dr.Cells[1].Value.ToString();
                txtAddress.Text = dr.Cells[2].Value.ToString();
                btnSave.Enabled = false;
                 btnUpdate.Enabled = true;
                 btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
