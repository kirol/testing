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
    public partial class frmMarksLedger : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        frmReport frm = new frmReport();
        SqlDataAdapter adp;
        DataSet ds;
        Connectionstring cs = new Connectionstring();
        public frmMarksLedger()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbSchoolSearch.Text == "")
                {
                    MessageBox.Show("Please select school", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSchoolSearch.Focus();
                    return;
                }
                if (cmbBatchSearch.Text == "")
                {
                    MessageBox.Show("Please Enter Batch", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBatchSearch.Focus();
                    return;
                }
                if (CmbClassSearch.Text == "")
                {
                    MessageBox.Show("Please Enter Class", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbClassSearch.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                Timer1.Enabled = true;
                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Student INNER JOIN MarksEntry ON Student.AdmissionNo = MarksEntry.AdmissionNo INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID INNER JOIN Subject ON MarksEntry_Join.Subject_ID = Subject.SubjectID Where StudentSchool=@d1 and MarksEntry.Session=@d2 and StudentClass=@d3", con);
                adp = new SqlDataAdapter(cmd);
                dtable = new DataTable();
                adp.Fill(dtable);
                ds = new DataSet();
                con.Close();
                ds.Tables.Add(dtable);
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillSchool()
        {
            try
            {
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT distinct Rtrim(MarksEntry.StudentSchool) FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                cmbSchoolSearch.Items.Clear();
                while (rdr.Read())
                {
                    cmbSchoolSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Timer1.Enabled = false;
        }
        public void reset()
        {
            CmbClassSearch.SelectedIndex = -1;
            cmbBatchSearch.SelectedIndex = -1;
            cmbSchoolSearch.SelectedIndex = -1;
            CmbClassSearch.Enabled = false;
            cmbBatchSearch.Enabled = false;
           FillSchool();
       }
        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void cmbSchoolSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBatchSearch.Items.Clear();
                cmbBatchSearch.Text = "";
                cmbBatchSearch.Enabled = true;
                cmbBatchSearch.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(MarksEntry.Session) FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID where MarksEntry.StudentSchool='" + cmbSchoolSearch.Text + "'";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbBatchSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbBatchSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CmbClassSearch.Items.Clear();
                CmbClassSearch.Text = "";
                CmbClassSearch.Enabled = true;
                CmbClassSearch.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct1 = "SELECT distinct Rtrim(MarksEntry.StudentClass) FROM MarksEntry INNER JOIN MarksEntry_Join ON MarksEntry.M_ID = MarksEntry_Join.MarksID where MarksEntry.StudentSchool=@d1 and MarksEntry.Session=@d2";
                cmd = new SqlCommand(ct1);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchoolSearch.Text);
                cmd.Parameters.AddWithValue("@d2", cmbBatchSearch.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CmbClassSearch.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMarksLedger_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
