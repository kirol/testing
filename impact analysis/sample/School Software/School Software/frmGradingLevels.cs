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
    public partial class frmGradingLevels : Form
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
        public frmGradingLevels()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtGradeID.Text = "";
            txtGradeName.Text = "";
            txtGradePoint.Text = "";
            txtTo.Text = "";
            txtminScore.Text = "";
            txtRemark.Text = "";
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate_record.Enabled = false;
        }
        private void delete_records()
        {
            
        }
        
        private void frmGradingLevels_Load(object sender, EventArgs e)
        {
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into Grades(Grade,ScoreFrom,ScoreTo,GradePoint,Remark) VALUES (@d1,@d2,@d3,@d4,@d5)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "added New  Grade  '" + txtGradeName.Text + "'";
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
                if (txtGradeName.Text == "")
                {
                    MessageBox.Show("Please enter Grade", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGradeName.Focus();
                    return;
                }
                if (txtminScore.Text == "")
                {
                    MessageBox.Show("Please enter MinScore ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtminScore.Focus();
                    return;
                }
                if (txtTo.Text == "")
                {
                    MessageBox.Show("Please enter Marks To ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTo.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update Grades set Grade=@d1,ScoreFrom=@d2,ScoreTo=@d3,GradePoint=@d4,Remark=@d5 where GradeID=@d6";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
               cmd.Parameters.AddWithValue("@d1", txtGradePoint.Text);
                cmd.Parameters.AddWithValue("@d2", txtRemark.Text);
                cmd.Parameters.AddWithValue("@d3", txtGradeID.Text);
                cmd.ExecuteReader();
                con.Close();
          
                st1 = lblUser.Text;
                st2 = "Updated Grade  '" + txtGradeName.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully Updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtGradeID.Text = dr.Cells[0].Value.ToString();
                txtGradeName.Text = dr.Cells[1].Value.ToString();
               txtRemark.Text = dr.Cells[5].Value.ToString();
                btnSave.Enabled = false;
                btnUpdate_record.Enabled = true;
                btnDelete.Enabled =true;
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

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
