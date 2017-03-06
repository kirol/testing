using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace School_Software
{
    public partial class frmSchoolEntry : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmMainmenu frm = null;
        clsFunc cf = new clsFunc();
        string st1;
        string st2;
        public frmSchoolEntry()
        {
            InitializeComponent();
        }
        public frmSchoolEntry(frmMainmenu par)
        {
            frm = par;
            InitializeComponent();
        }
        public void FillCategory()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(SchoolType) FROM SchoolTypes ";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                txtSchoolType.Items.Clear();
                 while (rdr.Read())
                {
                    txtSchoolType.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
        private void frmSchoolEntry_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtSchoolType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandText = "SELECT CategoryID FROM SchoolTypes WHERE SchoolType = '" + txtSchoolType.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    txtCategoryID.Text = rdr.GetValue(0).ToString().Trim();
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

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
             if (txtSchoolName.Text== "")
                {
                    MessageBox.Show("Please Enter SchoolName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (txtcity.Text == "")
                {
                    MessageBox.Show("Please Enter City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (txtCountry.Text == "")
                {
                    MessageBox.Show("Please Select Country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter ContactNo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtEmailID.Text == "")
                {
                    MessageBox.Show("Please enter Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailID.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into school(SchoolName,Category_ID,Address,ContactNo,Email,Fax,Website,City,Country,Photo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSchoolName.Text);
                cmd.Parameters.AddWithValue("@d2", txtCategoryID.Text);
                cmd.Parameters.AddWithValue("@d3", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d4",txtContactNo.Text );
                cmd.Parameters.AddWithValue("@d5", txtEmailID.Text);
                cmd.Parameters.AddWithValue("@d6", txtFax.Text);
                cmd.Parameters.AddWithValue("@d7",txtWebsite.Text);
                cmd.Parameters.AddWithValue("@d8", txtcity.Text);
                cmd.Parameters.AddWithValue("@d9", txtCountry.Text);
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d10", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteReader();
                con.Close();
               GetData();
                st1 = lblUser.Text;
                st2 = "Added the New School '"+txtSchoolName.Text+"' having SchoolType='" + txtSchoolType.Text + "'";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully saved", "School Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(School.SchoolID),rtrim(School.SchoolName),rtrim(School.Category_ID),rtrim(SchoolTypes.SchoolType),rtrim(School.City),rtrim(School.Country),rtrim(School.Address),rtrim(School.ContactNo),rtrim(School.Fax),rtrim(School.Email),rtrim(School.Website),Photo FROM School INNER JOIN SchoolTypes ON School.Category_ID = SchoolTypes.CategoryID", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5], rdr[6], rdr[7], rdr[8], rdr[9], rdr[10], rdr[11]);
                }
                con.Close();
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
             if (txtSchoolName.Text== "")
                {
                    MessageBox.Show("Please Enter SchoolName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (txtcity.Text == "")
                {
                    MessageBox.Show("Please Enter City", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (txtCountry.Text == "")
                {
                    MessageBox.Show("Please Select Country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSchoolName.Focus();
                    return;
                }
                if (txtContactNo.Text == "")
                {
                    MessageBox.Show("Please enter ContactNo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }
                if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please enter Address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
                if (txtEmailID.Text == "")
                {
                    MessageBox.Show("Please enter Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmailID.Focus();
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update school set SchoolName=@d1,Category_ID=@d2,Address=@d3,ContactNo=@d4,Email=@d5,Fax=@d6,Website=@d7,City=@d8,Country=@d9,Photo=@d10 Where SchoolID=@d11";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtSchoolName.Text);
                cmd.Parameters.AddWithValue("@d2", txtCategoryID.Text);
                cmd.Parameters.AddWithValue("@d3", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d4",txtContactNo.Text );
                cmd.Parameters.AddWithValue("@d5", txtEmailID.Text);
                cmd.Parameters.AddWithValue("@d6", txtFax.Text);
                cmd.Parameters.AddWithValue("@d7",txtWebsite.Text);
                cmd.Parameters.AddWithValue("@d8", txtcity.Text);
                cmd.Parameters.AddWithValue("@d9", txtCountry.Text);
                cmd.Parameters.AddWithValue("@d11", txtSchoolID.Text);
                MemoryStream ms = new MemoryStream();
                Bitmap bmpImage = new Bitmap(pictureBox1.Image);
                bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] data = ms.GetBuffer();
                SqlParameter p = new SqlParameter("@d10", SqlDbType.Image);
                p.Value = data;
                cmd.Parameters.Add(p);
                cmd.ExecuteReader();
                con.Close();
               GetData();
               con = new SqlConnection(cs.DBcon);
               con.Open();
               string cb1 = "update HostelFeesPayment set School='" + txtSchoolName.Text + "' where School='" + textBox1.Text + "'";
               cmd = new SqlCommand(cb1);
               cmd.Connection = con;
               cmd.ExecuteReader();
               if (con.State == ConnectionState.Open)
               {
                   con.Close();
               }
               con.Close();

               con = new SqlConnection(cs.DBcon);
               con.Open();
               string cb2 = "update BusFeesPayment set School='" + txtSchoolName.Text + "' where School='" + textBox1.Text + "'";
               cmd = new SqlCommand(cb2);
               cmd.Connection = con;
               cmd.ExecuteReader();
               if (con.State == ConnectionState.Open)
               {
                   con.Close();
               }
               con.Close();
               con = new SqlConnection(cs.DBcon);
               con.Open();
               string cb3 = "update SchoolFeesPayment set School='" + txtSchoolName.Text + "' where School='" + textBox1.Text + "'";
               cmd = new SqlCommand(cb3);
               cmd.Connection = con;
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
            st1 = lblUser.Text;
            st2 = "Updated the School '" + txtSchoolName.Text + "' having SchoolType='" + txtSchoolType.Text + "'";
            cf.LogFunc(st1, System.DateTime.Now, st2);
            MessageBox.Show("Successfully updated", "School Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnUpdate_record.Enabled = false;
        }
        
        private void Reset()
        {
            txtSchoolName.Text = "";
            txtCategoryID.Text = "";
            txtEmailID.Text = "";
            txtcity.Text = "";
            txtCountry.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtSchoolID.Text= "";
            txtWebsite.Text = "";
            txtSchoolType .Text = "";
            txtFax.Text = "";
            pictureBox1.Image = School_Software.Properties.Resources.download;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate_record.Enabled = false;
            FillCategory();
            GetData();
        }
        private void d2()
        {
            try
            {
                int RowsAffected = 0;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ctm4 = "select School_ID from ExamSchedule where School_ID='" + txtSchoolID.Text + "'";
                cmd = new SqlCommand(ctm4);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this School using on Exam Schedule List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSchoolID.Text = "";
                    Reset();
                    txtSchoolID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ctm5 = "select School_ID from Student where School_ID='" + txtSchoolID.Text + "'";
                cmd = new SqlCommand(ctm5);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this School using on Student List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSchoolID.Text = "";
                    Reset();
                    txtSchoolID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ctm6 = "select SchoolID from Subject where SchoolID='" + txtSchoolID.Text + "'";
                cmd = new SqlCommand(ctm6);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this School using on Subject List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSchoolID.Text = "";
                    Reset();
                    txtSchoolID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ctm7 = "select School_ID from HostelInstallment where School_ID='" + txtSchoolID.Text + "'";
                cmd = new SqlCommand(ctm7);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this School using on Subject List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSchoolID.Text = "";
                    Reset();
                    txtSchoolID.Focus();

                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cm5 = "select School from BusFeesPayment where School=@find";
                cmd = new SqlCommand(cm5);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.VarChar, 250, "School"));
                cmd.Parameters["@find"].Value = txtSchoolName.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this School using on BusFeesPayment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cm1 = "select School from HostelFeesPayment where School=@find";
                cmd = new SqlCommand(cm1);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.VarChar, 250, "School"));
                cmd.Parameters["@find"].Value = txtSchoolName.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this School using on HostelFeesPayment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cm9 = "select School from SchoolFeesPayment where School=@find";
                cmd = new SqlCommand(cm9);
                cmd.Connection = con;
                cmd.Parameters.Add(new SqlParameter("@find", System.Data.SqlDbType.VarChar, 250, "School"));
                cmd.Parameters["@find"].Value = txtSchoolName.Text;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    MessageBox.Show("Action can't be Completed Because this School using on SchoolFeesPayment List Form..!!", "Record In Use", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset();
                    if ((rdr != null))
                    {
                        rdr.Close();
                    }
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq = "delete from School where SchoolID=" + txtSchoolID.Text + "";
                cmd = new SqlCommand(cq);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                {
                    Reset();
                    st1 = lblUser.Text;
                    st2 = "Deleted the School '" + txtSchoolName.Text + "' having SchoolType='" + txtSchoolType.Text + "'";
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                d2();
                GetData();
            } 
               
          }

        private void Browse_Click(object sender, EventArgs e)
        {
           
            //Clear the file name
            OpenFileDialog1.FileName = "";
            if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName);
            }
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow dr = DataGridView1.SelectedRows[0];
            txtContactNo.Text = dr.Cells[1].Value.ToString();
            txtFax.Text = dr.Cells[2].Value.ToString();
            txtEmailID.Text = dr.Cells[3].Value.ToString();
            txtWebsite.Text = dr.Cells[10].Value.ToString();
            byte[] data = (byte[])dr.Cells[11].Value;
            MemoryStream ms = new MemoryStream(data);
            pictureBox1.Image = Image.FromStream(ms);
            lblUser.Text = lblUser.Text;
            lblUserType.Text = lblUserType.Text;
            btnSave.Enabled = false;
            btnUpdate_record.Enabled = true;
            btnDelete.Enabled = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = School_Software.Properties.Resources.download;
        }
    }
}
