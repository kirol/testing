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
    public partial class frmLocationEntry : Form
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
        public frmLocationEntry()
        {
            InitializeComponent();
        }
        public void auto()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                String sql = "SELECT Rtrim(LocationID),Rtrim(Location) from Locations order by Location";
                cmd = new SqlCommand(sql, con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Reset()
        {
            txtlocationID.Text = "";
            txtlocation.Text = "";
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            txtlocation.Focus();
        }
        private void d2()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cm5 = "select Location from BusFeesPayment where Location=@find";
                cmd = new SqlCommand(cm5);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 150, "Location"));
                cmd.Parameters["@find"].Value = txtlocation.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already Use in BusFeesPayment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cm6 = "select Location from StaffBusFeesPayment where Location=@find";
                cmd = new SqlCommand(cm6);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.NChar, 150, "Location"));
                cmd.Parameters["@find"].Value = txtlocation.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Unable to delete..Already Use in StaffBusFeesPayment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from Locations where LocationID=" + txtlocationID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    Reset();
                    st1 = lblUser.Text;
                    st2 = "Location '" + txtlocation.Text + "' is Deleted Successfully";
                    cf.LogFunc(st1, System.DateTime.Now, st2);
                    MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtlocation.Text == "")
                {
                    MessageBox.Show("Please enter Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtlocation.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "select Location from Locations where Location='" + txtlocation.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Location Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtlocation.Text = "";
                    txtlocation.Focus();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
               
                btnSave.Enabled = false;
                st1 = lblUser.Text;
                st2 = "New Location '" + txtlocation.Text + "' is Added Successfully";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                auto();
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
                d2();
                auto();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
               
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "update BusFeesPayment set Location=@d1 where Location=@d2";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtlocation.Text);
                cmd.Parameters.AddWithValue("@d2", textBox1.Text);
                cmd.ExecuteReader();

                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb2 = "update StaffBusFeesPayment set Location=@d1 where Location=@d2";
                cmd = new SqlCommand(cb2);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtlocation.Text);
                cmd.Parameters.AddWithValue("@d2", textBox1.Text);
                cmd.ExecuteReader();
                st1 = lblUser.Text;
                st2 = "Location '" + txtlocation.Text + "' is Updated Successfully";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Location Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
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

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                txtlocationID.Text = dr.Cells[0].Value.ToString();
                txtlocation.Text = dr.Cells[1].Value.ToString();
                textBox1.Text = dr.Cells[1].Value.ToString();
                btnDelete.Enabled = true;
                txtlocation.Focus();
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
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

        private void frmLocationEntry_Load(object sender, EventArgs e)
        {
            auto();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
