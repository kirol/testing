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
    public partial class frmClassEntry : Form
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
        public frmClassEntry()
        {
            InitializeComponent();
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
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select className from class where className='" + txtClass.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Record Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClass.Text = "";
                  
                    txtClass.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
               st1 = lblUser.Text;
                st2 = "Added the New Class='" + txtClass.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
               MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtClassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT ClassTypeID FROM ClassTypes WHERE ClassType = '" + txtClassType.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtClassTypeID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
               
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb3 = "Update BusFeesPayment set Classname= '" + txtClass.Text + "' where classname='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb4 = "Update HostelFeesPayment set Classname= '" + txtClass.Text + "' where Classname='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb4);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb5 = "Update SchoolFeesPayment set Classname= '" + txtClass.Text + "' where Classname='" + textBox1.Text + "'";
                cmd = new SqlCommand(cb5);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                st1 = lblUser.Text;
                st2 = "Updated the Class='" + txtClass.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnUpdate_record.Enabled = false;
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

      private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
      {
          try
          {
              DataGridViewRow dr = DataGridView1.SelectedRows[0];
              txtClassID.Text = dr.Cells[0].Value.ToString();
              txtClass.Text = dr.Cells[1].Value.ToString();
             btnSave.Enabled = false;
              btnUpdate_record.Enabled = true;
              btnDelete.Enabled = true;
          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
      }

      private void btnDelete_Click(object sender, EventArgs e)
      {
         
      }
    }
}
