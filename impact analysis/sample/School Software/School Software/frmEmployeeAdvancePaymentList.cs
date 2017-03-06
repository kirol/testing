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
    public partial class frmEmployeeAdvancePaymentList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmEmployeeAdvancePayment frm = null;
        public frmEmployeeAdvancePaymentList()
        {
            InitializeComponent();
        }
        public frmEmployeeAdvancePaymentList(frmEmployeeAdvancePayment par)
        {
            frm = par;
            InitializeComponent();
        }
        public void Auto()
        {
           
        }
        private void frmEmployeeAdvancePaymentList_Load(object sender, EventArgs e)
        {
            Auto();
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
           
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(AdvanceEntry.AdvanceID), AdvanceEntry.WorkingDate, Rtrim(AdvanceEntry.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(AdvanceEntry.Amount) FROM AdvanceEntry INNER JOIN Employee ON AdvanceEntry.StaffID = Employee.EMPID Where EmployeeName like'%" + txtEmployeeName.Text + "%'", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
                }
                con.Close();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(AdvanceEntry.AdvanceID), AdvanceEntry.WorkingDate, Rtrim(AdvanceEntry.StaffID),Rtrim(Employee.EMPMAXID),Rtrim(Employee.EmployeeName),Rtrim(AdvanceEntry.Amount) FROM AdvanceEntry INNER JOIN Employee ON AdvanceEntry.StaffID = Employee.EMPID Where WorkingDate Between @date1 and @Date2", con);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                DataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    DataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3], rdr[4], rdr[5]);
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
            txtEmployeeName.Text = "";
            DataGridView1.Rows.Clear();
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
            Auto();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
