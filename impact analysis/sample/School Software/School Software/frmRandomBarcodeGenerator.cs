using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Security.Cryptography;

namespace School_Software
{
    public partial class frmRandomBarcodeGenerator : Form
    {
        DataTable dt;
        Connectionstring cs = new Connectionstring();
        ReportDocument cry = new ReportDocument();
        public frmRandomBarcodeGenerator()
        {
            InitializeComponent();
        }
        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            timer1.Enabled = false;
        }

        private void frmRandomBarcodeGenrator_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.TableName = "Book";
            dt.Columns.Add("AccessionNo", typeof(String));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtNoPrint.Text = "1";
            crystalReportViewer1.ReportSource = null;
        }
    }
}
