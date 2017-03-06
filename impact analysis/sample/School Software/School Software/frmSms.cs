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
    public partial class frmSms : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        string St1, St2;
        public frmSms()
        {
            InitializeComponent();
        }

        private void frmSms_Load(object sender, EventArgs e)
        {

        }
        public void GetData()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT RTRIM(ID), RTRIM(Apiurl),RTRIM(ISdefault),RTRIM(ISEnabled) from smssetting order by id ", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
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
                if (chkIsDefault.Checked == true)
                {
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string ct = "select IsDefault from SMSSetting where IsDefault='Yes'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        MessageBox.Show("Other HTTP API is already set as default", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if ((rdr != null))
                        {
                            rdr.Close();
                        }
                        return;
                    }
                }
                if (chkIsDefault.Checked == true)
                {
                    St1 = "Yes";
                }
                else
                {
                    St1 = "No";
                }
                if (chkisEnabled.Checked == true)
                {
                    St2 = "Yes";
                }
                else
                {
                    St2 = "No";
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "insert into SmsSetting(Apiurl,Isdefault,isenabled) VALUES (@d1,@d2,@d3)";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtApi.Text);
                cmd.Parameters.AddWithValue("@d2", St1);
                cmd.Parameters.AddWithValue("@d3", St2);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetData();
                btnSave.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            if (txtApi.Text == "")
            {
                MessageBox.Show("Please enter API URL", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApi.Focus();
                return;
            }
            try
            {
                if (chkIsDefault.Checked == true)
                {
                    con = new SqlConnection(cs.DBcon);
                    con.Open();
                    string ct = "Update SMSSetting set IsDefault='No'";
                    cmd = new SqlCommand(ct);
                    cmd.Connection = con;
                    cmd.ExecuteReader();
                }
                if (chkIsDefault.Checked == true)
                {
                    St1 = "Yes";
                }
                else
                {
                    St1 = "No";
                }
                if (chkisEnabled.Checked == true)
                {
                    St2 = "Yes";
                }
                else
                {
                    St2 = "No";
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "Update SMSSetting set APIURL=@d1,IsDefault=@d2,IsEnabled=@d3 where ID=" + txtID.Text + "";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", txtApi.Text);
                cmd.Parameters.AddWithValue("@d2", St1);
                cmd.Parameters.AddWithValue("@d3", St2);
                cmd.ExecuteReader();
                con.Close();
                MessageBox.Show("Successfully updated", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                GetData();
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
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cq1 = "delete from SmsSetting where ID='" + txtID.Text + "'";
                cmd = new SqlCommand(cq1);
                cmd.Connection = con;
                RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
               if (RowsAffected > 0)
                {
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
                GetData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txtApi.Text = "";
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnUpdate_record.Enabled = false;
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (DataGridView1.Rows.Count > 0)
                {
                    DataGridViewRow dr = DataGridView1.SelectedRows[0];
                    txtID.Text = dr.Cells[0].Value.ToString();
                    txtApi.Text = dr.Cells[1].Value.ToString();
                    if (dr.Cells[2].Value.ToString() == "Yes")
                    {
                        chkIsDefault.Checked = true;
                    }
                    else
                    {
                        chkIsDefault.Checked = false;
                    }
                    if (dr.Cells[3].Value.ToString() == "Yes")
                    {
                        chkisEnabled.Checked = true;
                    }
                    else
                    {
                        chkisEnabled.Checked = false;
                    }
                    btnUpdate_record.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSave.Enabled = false;
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
    }
}
