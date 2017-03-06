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
    public partial class frmStudentDiscount : Form
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
        public frmStudentDiscount()
        {
            InitializeComponent();
        }
        public void Sessions()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct RTRIM(Sessions.Session) FROM Student,Sessions where Sessions.SessionID=Student.Session_ID";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSession.Items.Add(rdr[0]);
                }
                con.Close();
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
                btnUpdate_record.Enabled = true;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.AdmissionNo),Rtrim(Student.StudentName),Rtrim(Student.Category),Rtrim(StudentDiscount.Discount) FROM Student INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN Student ON student.admissionno=studentdiscount.admission_no and SectionName=@d1 and ClassName=@d2 and Session=@d3 and Status='Active' and Feetype ='"+ txtFeeType.Text + "'  order by StudentName", con);
                cmd.Parameters.AddWithValue("@d1", txtSection.Text);
                cmd.Parameters.AddWithValue("@d2", txtClass.Text);
                cmd.Parameters.AddWithValue("@d3", txtSession.Text);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while (rdr.Read() == true)
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillClass()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct (Class.ClassName) FROM  Student INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN  Class ON ClassSection.Class_ID = Class.ClassID";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(StudentDiscount.Admission_No),Rtrim(Student.StudentName),Rtrim(Student.Category),Rtrim(StudentDiscount.Discount) FROM Student INNER JOIN StudentDiscount ON Student.AdmissionNo = StudentDiscount.Admission_No INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID and SectionName=@d1 and ClassName=@d2 and Session=@d3 and FeeType='" + txtFeeType.Text + "' and Status='Active' order by StudentName", con);
                cmd.Parameters.AddWithValue("@d1", txtSection.Text);
                cmd.Parameters.AddWithValue("@d2", txtClass.Text);
                cmd.Parameters.AddWithValue("@d3", txtSession.Text);
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dataGridView1.Rows.Clear();
                while ((rdr.Read() == true))
                {
                    dataGridView1.Rows.Add(rdr[0], rdr[1], rdr[2], rdr[3]);
                }
                con.Close();
                btnUpdate_record.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmStudentDiscount_Load(object sender, EventArgs e)
        {
            Sessions();
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSection.Items.Clear();
            txtSection.Text = "";
            txtSection.Enabled = true;
            txtSection.Focus();
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT distinct Rtrim(Section.SectionName) FROM Student INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID INNER JOIN Class ON Class.ClassID = ClassSection.Class_ID and Class.className = '" + txtClass.Text + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtSection.Items.Add(rdr[0]);
                }
                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtClass.Items.Clear();
                txtClass.Text = "";
                txtClass.Enabled = true;
                txtClass.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(Class.ClassName) FROM Student INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID where Sessions.session='"+txtSession.Text+"'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    txtClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData();
            btnUpdate_record.Enabled = true;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            {
                string strRowNumber = (e.RowIndex + 1).ToString();
                SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);
                if (dataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)))
                {
                    dataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20));
                }
                Brush b = SystemBrushes.ButtonHighlight;
                e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
            }
        }

        private void btnUpdate_record_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFeeType.Text == "")
                {
                    MessageBox.Show("Please enter Fees Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFeeType.Focus();
                    return;
                }
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Sorry nothing to update.Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb = "delete from Studentdiscount where admission_No=@d1 and FeeType=@d2";
                cmd = new SqlCommand(cb);
                cmd.Connection = con;
                cmd.Prepare();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                  if (!row.IsNewRow)
                    {
                        cmd.Parameters.AddWithValue("@d1", row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@d2", txtFeeType.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                con.Close();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string cb1 = "insert into StudentDiscount(Admission_No,FeeType,Discount) VALUES (@d3,@d4,@d5)";
                cmd = new SqlCommand(cb1);
                cmd.Connection = con;
                cmd.Prepare();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                  if (!row.IsNewRow)
                    {
                        cmd.Parameters.AddWithValue("@d3", row.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@d4",txtFeeType.Text);
                        cmd.Parameters.AddWithValue("@d5", Convert.ToDecimal(row.Cells[3].Value));
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
                st1 = lblUser.Text;
                st2 = "StudentDiscount is Updated Successfully";
                cf.LogFunc(st1, System.DateTime.Now, st2);
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate_record.Enabled = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void DataGridView1_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
        {

            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
                ((TextBox)e.Control).KeyPress += TextBox_keyPress;


            }
            //else if (dataGridView1.CurrentCell.ColumnIndex == 1)
            //{
            //    ((TextBox)e.Control).KeyPress += TextBox_keyPress1;


            //}

        }


        private void TextBox_keyPress(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(Convert.ToChar(Convert.ToString(e.KeyChar))) == false)
            //    e.Handled = true;
           

        }


        //private void TextBox_keyPress1(object sender, KeyPressEventArgs e)
        //{
        //    if (!(char.IsDigit(Convert.ToChar(Convert.ToString(e.KeyChar))) || e.KeyChar == "."))
        //        e.Handled = true;

        //}


        private void Column4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
       public void Reset()
       {
        txtClass.SelectedIndex = -1;
        txtSection.SelectedIndex = -1;
        txtSession.SelectedIndex = -1;
        txtFeeType.SelectedIndex = -1;
        dataGridView1.Rows.Clear();
        txtClass.Enabled = false;
        txtSection.Enabled = false;
        btnUpdate_record.Enabled = false;
         }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dataGridView1_EditingControlShowing_1(object sender, DataGridViewEditingControlShowingEventArgs e)
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
    }
}
