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
    public partial class frmSchoolFeesList : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        frmSchoolFeesEntry frm1 = null;
        public frmSchoolFeesList(frmSchoolFeesEntry par)
        {
             frm1 = par; 
             InitializeComponent();
        }
        public frmSchoolFeesList()
        {
           InitializeComponent();
        }
       
        private void frmSchoolFeesList_Load(object sender, EventArgs e)
        {
            Auto();
      }
        public void Auto()
        {
          
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
          
        }

        private void txtclass_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
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
             if(lblSET.Text == "R1") 
            {

                DataGridViewRow dr = DataGridView1.SelectedRows[0];
                this.Hide();
                frm1.Activate();
                frm1.BringToFront();
                frm1.txtSchooFeesID.Text = dr.Cells[0].Value.ToString();
               frm1.txtFeeIDQ.Text = dr.Cells[5].Value.ToString();
                frm1.cmbFeeName .Text = dr.Cells[6].Value.ToString();
                frm1.txtFee.Text = dr.Cells[7].Value.ToString();
                frm1.cmbMonth.Text = dr.Cells[8].Value.ToString();
                frm1.txtMonthQ.Text = dr.Cells[8].Value.ToString();
                 frm1.btnSave.Enabled = false;
                frm1.btnUpdate.Enabled = true;
                frm1.btnDelete.Enabled = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

           
        }
    }
}
