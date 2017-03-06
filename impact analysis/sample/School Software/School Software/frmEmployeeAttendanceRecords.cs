using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Software
{
    public partial class frmEmployeeAttendanceRecords : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmEmployeeAttendanceEntry frm = null;
        public frmEmployeeAttendanceRecords()
        {
            InitializeComponent();
        }
        public frmEmployeeAttendanceRecords(frmEmployeeAttendanceEntry  par)
        {
            frm = par;
            InitializeComponent();
        }
        public void Auto()
        {
           
        }
        private void frmEmployeeAttendanceRecords_Load(object sender, EventArgs e)
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
        public void reset()
        {
            txtemployeeName.Text = "";
            dtpDateFrom.Text = System.DateTime.Now.ToString();
            dtpDateTo.Text = System.DateTime.Now.ToString();
           DataGridView1.Rows.Clear();
            Auto();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void txtemployeeName_TextChanged(object sender, EventArgs e)
        {

         }
    }
}
