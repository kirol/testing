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
    public partial class frmStudentClassPromotion : Form
    {
        SqlDataReader rdr = null;
        DataTable dtable = new DataTable();
        SqlConnection con = null;
        SqlCommand cmd = null;
        DataTable dt = new DataTable();
        Connectionstring cs = new Connectionstring();
        public frmStudentClassPromotion()
        {
            InitializeComponent();
        }
       
        

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbClass.Items.Clear();
                cmbClass.Text = "";
                cmbClass.Enabled = true;
                cmbClass.Focus();
                con = new SqlConnection(cs.DBcon);
                con.Open();
                string ct = "SELECT distinct Rtrim(Class.ClassName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID where SchoolName=@d1 and Session=@d2";
                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@d1", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSession.Text);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbClass.Items.Add(rdr[0]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (cmbSchool.Text == "")
                {
                    MessageBox.Show("Please Select School of Student", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSchool .Focus();
                    return;
                }
                if (cmbSession.Text == "")
                {
                    MessageBox.Show("Please Select  current session", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSession.Focus();
                    return;
                }
                if (cmbClass.Text == "")
                {
                    MessageBox.Show("Please Select current class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbClass.Focus();
                    return;
                }
                if (cmbSection.Text == "")
                {
                    MessageBox.Show("Please Select current section", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbSection.Focus();
                    return;
                }
                btnUpdate.Enabled = true;

                con = new SqlConnection(cs.DBcon);
                con.Open();
                cmd = new SqlCommand("SELECT Rtrim(Student.AdmissionNo),Rtrim(Student.StudentName) FROM Student INNER JOIN School ON Student.School_ID = School.SchoolID INNER JOIN Sessions ON Student.Session_ID = Sessions.SessionID INNER JOIN ClassSection ON Student.ClassSection_ID = ClassSection.ClassSectionID INNER JOIN Class ON ClassSection.Class_ID = Class.ClassID INNER JOIN Section ON ClassSection.Section_ID = Section.SectionID where Schoolname=@d1 and Session=@d2 and Classname=@d3 and SectionName=@d4  order by StudentName", con);
                cmd.Parameters.AddWithValue("@d1", cmbSchool.Text);
                cmd.Parameters.AddWithValue("@d2", cmbSession.Text);
                cmd.Parameters.AddWithValue("@d3", cmbClass.Text);
                cmd.Parameters.AddWithValue("@d4", cmbSection.Text);
                rdr = cmd.ExecuteReader();
                listView1.Items.Clear();
                while (rdr.Read())
                {
                    dynamic item = new ListViewItem();
                    item.Text = rdr[0].ToString().Trim();
                    item.SubItems.Add(rdr[1].ToString().Trim());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnUpdate.Enabled = true;
            txtSession.Items.Clear();
            txtSession.Text = "";
            txtSession.Enabled = true;
            txtSession.Focus();
      
        }

        private void txtSession_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void txtClass_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSection_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public void Reset()
        {
            cmbSchool.SelectedIndex = -1;
            cmbClass.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.SelectedIndex = -1;
            txtSection.SelectedIndex = -1;
            txtClass.Text = "";
            txtSessionID.Text = "";
            txtSection.Text = "";
            txtClassSectionID.Text = "";
            cmbSection.SelectedIndex = -1;
            cmbSession.SelectedIndex = -1;
            listView1.Items.Clear();
            cmbSession.Enabled = false;
            cmbClass.Enabled = false;
            cmbSection.Enabled = false;
           
            txtSession.Enabled = false;
            txtClass.Enabled = false;
            txtSection.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("Sorry nothing to update..Please retrieve data in listview", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for (int i = listView1.Items.Count - 1; i >= 0; i += -1)
                {
                    if (listView1.Items[i].Checked == true)
                    {
                        con = new SqlConnection(cs.DBcon);
                        string cd = "update student set Session_ID=@d1,ClassSection_ID=@d2 where AdmissionNo=@d3";
                        cmd = new SqlCommand(cd);

                        cmd.Parameters.AddWithValue("@d1", txtSessionID.Text);
                        cmd.Parameters.AddWithValue("@d2", txtClassSectionID.Text);
                        cmd.Parameters.AddWithValue("@d3", listView1.Items[i].SubItems[0].Text);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnUpdate.Enabled = false;
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
    }
}
