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
    public partial class frmExamEntry : Form
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
        public frmExamEntry()
        {
            InitializeComponent();
        }
        private void DeleteRecord()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ctm3 = "select ExamID from ExamSchedule where ExamID='" + txtExamID.Text + "'";
                cmd = new SqlCommand(ctm3);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this Exam using on ExamSchedule List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtExamID.Text = "";
                    Reset();
                    txtExamID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from ExamMaster where ExamID=" + txtExamID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    st1 = lblUser.Text;
                    st2 = "Exam'" + txtExamName.Text + "'";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Auto();
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

       
        public void Reset()
        {
         txtExamType.DropDownStyle = ComboBoxStyle.DropDownList;
            txtExamID.Text = "";
           txtExamName.Text = "";
           txtExamType.SelectedIndex = -1;
            btnSave.Enabled = true;
            btnUpdate_record.Enabled = false;
            btnDelete.Enabled = false;
        }
        private void frmSubjectsEntry_Load(object sender, EventArgs e)
        {
            
        }
      
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (txtExamName.Text == "")
                {
                    MessageBox.Show("Please Enter ExamName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtExamName.Focus();
                    return;
                }
                if (txtExamType.Text == "")
                {
                    MessageBox.Show("Please Select ExamType", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtExamType.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT Rtrim(ExamName) FROM ExamMaster where ExamName=@d1";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamName.Text);
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Exam Name Already Exist ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtExamName.Text = "";
                    txtExamName.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into ExamMaster(ExamName,ExamType) VALUES (@d1,@d2)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamName.Text);
                cmd.Parameters.AddWithValue("@d2", txtExamType.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "New Exam'"+txtExamName.Text+"'is Added";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                Auto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void frmExamGroups_Load(object sender, EventArgs e)
        {
         
        }

       private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteRecord();
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (txtExamName.Text == "")
                {
                    MessageBox.Show("Please Enter ExamName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtExamName.Focus();
                    return;
                }
                if (txtExamType.Text == "")
                {
                    MessageBox.Show("Please Select ExamType", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtExamType.Focus();
                    return;
                }
               
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update Exammaster set ExamName=@d1,ExamType=@d2 where ExamID=@d3";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtExamName.Text);
                cmd.Parameters.AddWithValue("@d2", txtExamType.Text);
                cmd.Parameters.AddWithValue("@d3", txtExamID.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Exam Group'" + txtExamName.Text + "'is Updated";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
                Auto();
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtExamID.Text = dr.Cells[0].Value.ToString();
                txtExamName.Text = dr.Cells[1].Value.ToString();
                txtExamType.Text = dr.Cells[2].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate_record.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        }
    }

