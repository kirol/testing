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
    public partial class frmUserGrants : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmMainmenu frm1 = new frmMainmenu();
        bool IsHeaderCheckBoxClicked = false;
        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        CheckBox HeaderCheckBox1 = null;
        CheckBox HeaderCheckBox2 = null;
        CheckBox HeaderCheckBox3 = null;
        CheckBox HeaderCheckBox4 = null;
        
      
        public frmUserGrants()
        {
            InitializeComponent();
        }

        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);


            this.dgvSelectAll.Controls.Add(HeaderCheckBox);


        }
       

        private void dgvSelectAll_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (!IsHeaderCheckBoxClicked)
            //    RowCheckBoxClick((DataGridViewCheckBoxCell)dgvSelectAll[e.ColumnIndex, e.RowIndex]);
        }
      

        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
           
        }


        private void dgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSelectAll.CurrentCell is DataGridViewCheckBoxCell)
                dgvSelectAll.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        //********* click on header checkbox

        

    //************************************************************** locations*********

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)  //for cell painting event
        {

            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            HeaderCheckBox.Location = oPoint;
        }
       
       private void ResetHeaderCheckBoxLocation1(int ColumnIndex, int RowIndex)
        {

            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point();
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox1.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox1.Height) / 2 + 1;
            HeaderCheckBox1.Location = oPoint;
        }
        private void ResetHeaderCheckBoxLocation2(int ColumnIndex, int RowIndex)
        {
            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point();
            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox2.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox2.Height) / 2 + 1;
            HeaderCheckBox2.Location = oPoint;
        }
        private void ResetHeaderCheckBoxLocation3(int ColumnIndex, int RowIndex)
        {

            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox3.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox3.Height) / 2 + 1;
            HeaderCheckBox3.Location = oPoint;
        }
        private void ResetHeaderCheckBoxLocation4(int ColumnIndex, int RowIndex)
        {

            Rectangle oRectangle = this.dgvSelectAll.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox4.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox4.Height) / 2 + 1;
            HeaderCheckBox4.Location = oPoint;
        }
        public void Filluser()
        {
            try
            { con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(UserID) FROM Users";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtUserID.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void refresh()
        {

        
          }
        private void frmUserGrants_Load(object sender, EventArgs e)
        {
          
            Filluser();
            refresh();
        }


        public void setting()
        {
            dgvSelectAll.Rows[1].Cells[2].Selected =false;
            dgvSelectAll.Rows[2].Cells[3].Selected = false;
            dgvSelectAll.Rows[3].Cells[1].Selected = false;
            dgvSelectAll.Rows[1].Cells[5].ReadOnly = true;
        }
        public void getrecord()
        {
           
            con = new SqlConnection(cs.DBcon);
            con.Open();
            cmd = new SqlCommand("SELECT RTRIM(UserGrants.Forms), RTRIM(UserGrants.ViewRecord),RTRIM(UserGrants.Saves), RTRIM(UserGrants.Updates), RTRIM(UserGrants.Deletes), RTRIM(UserGrants.Getdata) FROM  Users INNER JOIN UserGrants ON Users.ID = UserGrants.UserID  where Usergrants.userID = '" + txtID.Text + "'", con);
            rdr = cmd.ExecuteReader();
            dgvSelectAll.Rows.Clear();
            while (rdr.Read())
            {
                dgvSelectAll.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
            }
            con.Close();
           btnUpdate.Enabled = true;
        
         }

        private void btnSave_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(cs.DBcon);
            con.Open();
            string ct = "SELECT RTRIM(UserGrants.Forms), RTRIM(UserGrants.ViewRecord), RTRIM(UserGrants.Saves), RTRIM(UserGrants.Updates), RTRIM(UserGrants.Deletes), RTRIM(UserGrants.Getdata) FROM  Users INNER JOIN UserGrants ON Users.ID = UserGrants.UserID  where Users.ID = '" + txtID.Text + "'";
            cmd = new SqlCommand(ct);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                MessageBox.Show("Permissions already saved for this user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtUserID.Text = "";
                designation.Text = "";
               txtID.Text = "";
                dgvSelectAll.Rows.Clear();

                if ((rdr != null))
                {
                    rdr.Close();
                }
                return;
            }
           
        }
        
        private void btnGetdatas_Click(object sender, EventArgs e)
        {
            try
            {
                getrecord();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT distinct UserID FROM Usergrants where UserID = '" + txtID.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    btnSave.Enabled = false;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    refresh();
                    btnSave.Enabled = true;
                    btnUpdate.Enabled = false;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (designation.Text == "Super Admin")
                {
                    MessageBox.Show("Super Admin Account can not be updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "Delete from usergrants where UserID=" + txtID.Text + "";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.ExecuteReader();
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb3 = "insert into Usergrants(Forms,viewRecord,Saves,updates,Deletes,Getdata,UserID) VALUES (@d1,@d2,@d3,@d4,@d5,@d6," + txtID.Text + ")";
                cmd = new SqlCommand(cb3);
                cmd.Connection = con;
               cmd.Prepare();
               foreach (DataGridViewRow row in dgvSelectAll.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["chkBxSelect"].Value) == false)
                        row.Cells["chkBxSelect"].Value = false;
                    else
                        row.Cells["chkBxSelect"].Value = true;

                    if (Convert.ToBoolean(row.Cells["chkBxSelect1"].Value) == false)
                        row.Cells["chkBxSelect1"].Value = false;
                    else
                        row.Cells["chkBxSelect1"].Value = true;

                    if (Convert.ToBoolean(row.Cells["chkBxSelect2"].Value) == false)
                        row.Cells["chkBxSelect2"].Value = false;
                    else
                        row.Cells["chkBxSelect2"].Value = true;

                    if (Convert.ToBoolean(row.Cells["chkBxSelect3"].Value) == false)
                        row.Cells["chkBxSelect3"].Value = false;
                    else
                        row.Cells["chkBxSelect3"].Value = true;

                    if (Convert.ToBoolean(row.Cells["chkBxSelect4"].Value) == false)
                        row.Cells["chkBxSelect4"].Value = false;
                    else
                        row.Cells["chkBxSelect4"].Value = true;

                    if (!row.IsNewRow)
                    {
                        cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@d2", row.Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@d3", row.Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@d4", row.Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@d5", row.Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@d6", row.Cells[5].Value.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                
                }

                MessageBox.Show("Successfully Updated", "User Rights", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvSelectAll_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
             string strRowNumber = (e.RowIndex + 1).ToString();
        SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
        if (dgvSelectAll.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
        {
            dgvSelectAll.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
        }
        Brush b = SystemBrushes.ButtonHighlight;
        e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
    
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dgvSelectAll.Rows.Clear();
          
        }

       

        private void txtUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT rtrim(Users.ID), rtrim(Users.Name),Rtrim(Designations.Designation) FROM Users INNER JOIN Designations ON Users.Designation_ID = Designations.DesignationID WHERE users.UserID = '" + txtUserID.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtID.Text = rdr.GetValue(0).ToString().Trim();
                    txtName.Text = rdr.GetValue(1).ToString().Trim();
                    designation.Text = rdr.GetValue(2).ToString().Trim();
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

        private void dgvSelectAll_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            if (dgvSelectAll.CurrentCell is DataGridViewCheckBoxCell)
              dgvSelectAll.CommitEdit(DataGridViewDataErrorContexts.Commit); 
        }

        private void lblMasterentry_TextChanged(object sender, EventArgs e)
        {
          

            
        }

        private void frmUserGrants_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMainmenu frm = new frmMainmenu();
            frm.UserType.Text = lblUserType.Text;
            frm.User.Text = lblUser.Text;
            frm.Show();
        }

     }
}
