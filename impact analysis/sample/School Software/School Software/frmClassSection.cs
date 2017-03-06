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
    public partial class frmClassSection : Form
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
        public frmClassSection()
        {
            InitializeComponent();
        }
       
      
        private void frmClassSection_Load(object sender, EventArgs e)
        {
           
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ClassID FROM Class where ClassName = '" + txtClass.Text + "'";
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

        private void txtSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT SectionID FROM Section where SectionName = '" + txtSection.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtSectionID.Text = rdr.GetInt32(0).ToString().Trim();
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
        private void delete_records()
        {
            try
            {

                int RowsAffected = 0;
                string ctm2 = "select Class_ID from ExamSchedule where ClassSection_ID='" + txtClassID.Text + "'";
                cmd = new SqlCommand(ctm2);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class and Section using on ExamSchedule List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClass.Text = "";
                    Reset();
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                string ctm3 = "select Class_ID from Student where ClassSection_ID='" + txtClassID.Text + "'";
                cmd = new SqlCommand(ctm3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Class and Section using on Student List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtClass.Text = "";
                    Reset();
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from Classsection where ClasssectionID='" + txtClassSectionID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Deleted the  Section '"+txtSection.Text+"' For Class'" + txtClass.Text + "'";
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
        private void Reset()
        {
          txtClassSectionID.Text = "";
          txtSection.Text = "";
          txtSectionID.Text = "";
          txtClassID.Text = "";
         btnDelete.Enabled = false;
         btnUpdate_record.Enabled = false;
         btnSave.Enabled = true;
         }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClass.Text == "")
                {
                    MessageBox.Show("Please Enter Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Focus();
                    return;
                }
                if (txtSection.Text == "")
                {
                    MessageBox.Show("Please enter section.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSection.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT Class_ID, Section_ID FROM ClassSection where class_ID='" + txtClassID.Text + "' and section_ID='" + txtSectionID.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Text = "";
                    Reset();
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
               GetData();
                st1 = lblUser.Text;
                st2 = "Added the New Section '" + txtSection.Text + "' For Class'" + txtClass.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb2 = "Update classSection set Class_ID= '" + txtClassID.Text + "',Section_ID= '" + txtSectionID.Text + "' where classsectionID='" + txtClassSectionID.Text + "'";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
         
                st1 = lblUser.Text;
                st2 = "Updated the  Section '" + txtSection.Text + "' For Class'" + txtClass.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
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
                txtClassSectionID.Text = dr.Cells[0].Value.ToString();
                txtClassID.Text = dr.Cells[1].Value.ToString();
                txtClass.Text = dr.Cells[2].Value.ToString();
                txtSectionID.Text = dr.Cells[3].Value.ToString();
                txtSection.Text = dr.Cells[4].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate_record.Enabled = true;
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

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
