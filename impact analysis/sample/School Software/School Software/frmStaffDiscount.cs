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
    public partial class frmStaffDiscount : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmStaffDiscount()
        {
            InitializeComponent();
        }
      
        private void frmStaffDiscount_Load(object sender, EventArgs e)
        {
           
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Sorry nothing to update..Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "Update Employee Set Discount=@d2 where Empid=@d1";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Prepare();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                 if (!row.IsNewRow)
                    {
                        cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@d2", Convert.ToDecimal(row.Cells[3].Value));
                        cmd.ExecuteNonQuery();
                       cmd.Parameters.Clear();
                    }
                }
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            auto();
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            auto();
            txtStaffName.Text = "";
            dataGridView1.Rows.Clear();
            btnUpdate_record.Enabled = false;
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            btnUpdate_record.Enabled = true;
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(EMPID),Rtrim(EMPMAXID),Rtrim(EmployeeName),Rtrim(Discount) FROM Employee where employeename like '%"+txtStaffName.Text+"%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
