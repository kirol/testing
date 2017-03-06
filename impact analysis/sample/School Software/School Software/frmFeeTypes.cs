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
    public partial class frmFeeTypes : Form
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
        public frmFeeTypes()
        {
            InitializeComponent();
        }
        
        private void frmFeeTypes_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeName.Text == "")
                {
                    MessageBox.Show("Please enter Fee name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFeeName.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select FeeName from Fee where FeeName='" + txtFeeName.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    MessageBox.Show("Fee Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFeeName.Text = "";
                    txtFeeName.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
              st1 = lblUser.Text;
                 st2 = "added New  FeeType  '" + txtFeeName.Text + "'";
                 cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtID.Text = dr.Cells[0].Value.ToString();
              
                 btnSave.Enabled = false;
                 btnUpdate.Enabled = true;
                 btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
          txtID.Text = "";
           txtFeeName.Text = "";
          btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
         }
         private void delete_records()
         {
             try
             {
                 int RowsAffected = 0;
                 con = new SqlConnection(cs.DBcon);
                 con.Open();
                 string ctm1 = "select FeeId from CourseFeePayment_Join where FeeId='" + txtID.Text + "'";
                 cmd = new SqlCommand(ctm1);
                 cmd.Connection = con;
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     MessageBox.Show("Action can't be Completed Because this Fee using on School Fee Payment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     txtFeeName.Text = "";
                     Reset();
                     txtFeeName.Focus();

                     if ((rdr != null))
                     {
                         rdr.Close();
                     }
                     return;
                 }
                 con = new SqlConnection(cs.DBcon);
                 con.Open();
                 string ctm2 = "select FeeId from SchoolFees where FeeId='" + txtID.Text + "'";
                 cmd = new SqlCommand(ctm2);
                 cmd.Connection = con;
                 rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     MessageBox.Show("Action can't be Completed Because this Fee using on School Fee Payment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     txtFeeName.Text = "";
                     Reset();
                     txtFeeName.Focus();

                     if ((rdr != null))
                     {
                         rdr.Close();
                     }
                     return;
                 }
                 
                 con = new SqlConnection(cs.DBcon);
                 con.Open();
                 string cq1 = "delete from Fee where Id='" + txtID.Text + "'";
                 cmd = new SqlCommand(cq1);
                 cmd.Connection = con;
                 RowsAffected = cmd.ExecuteNonQuery();
                 con.Close();

                 if (RowsAffected > 0)
                 {
                     MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     st1 = lblUser.Text;
                     st2 = "Deleted the Fee Type'" + txtFeeName.Text + "'";
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                delete_records();
           
            } 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select ID from Fee where ID='" + txtID.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                con = new SqlConnection(cs.DBcon);
                st1 = lblUser.Text;
                st2 = "Updated the Feename '" + txtFeeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;

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
    }
}
