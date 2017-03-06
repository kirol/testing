namespace School_Software
{
    partial class frmSchoolFeesEntry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSchoolFeesEntry));
            this.Label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtClassID = new System.Windows.Forms.TextBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblsaves = new System.Windows.Forms.Label();
            this.txtSchooFeesID = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbFeeName = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.txtFeeID = new System.Windows.Forms.TextBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtClassQ = new System.Windows.Forms.TextBox();
            this.txtFeeIDQ = new System.Windows.Forms.TextBox();
            this.txtSchoolName = new System.Windows.Forms.ComboBox();
            this.txtMonthQ = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSchoolQ = new System.Windows.Forms.TextBox();
            this.txtSchoolID = new System.Windows.Forms.TextBox();
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(7, 164);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(30, 18);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Fee";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Indigo;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(-2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(555, 37);
            this.label5.TabIndex = 101;
            this.label5.Text = "School Fees Entry";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMonth
            // 
            this.cmbMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMonth.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(104, 130);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(147, 26);
            this.cmbMonth.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(7, 62);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 18);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Class";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(7, 130);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(49, 18);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Month";
            // 
            // txtClassID
            // 
            this.txtClassID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClassID.Location = new System.Drawing.Point(299, 62);
            this.txtClassID.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.Size = new System.Drawing.Size(104, 17);
            this.txtClassID.TabIndex = 96;
            this.txtClassID.Visible = false;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.BackColor = System.Drawing.Color.Transparent;
            this.lblUserType.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUserType.Location = new System.Drawing.Point(86, 22);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(53, 13);
            this.lblUserType.TabIndex = 98;
            this.lblUserType.Text = "UserType";
            this.lblUserType.Visible = false;
            // 
            // txtFee
            // 
            this.txtFee.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFee.Location = new System.Drawing.Point(104, 164);
            this.txtFee.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(104, 25);
            this.txtFee.TabIndex = 4;
            this.txtFee.Text = "0.00";
            this.txtFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblUser.Location = new System.Drawing.Point(64, 11);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 99;
            this.lblUser.Text = "User";
            this.lblUser.Visible = false;
            // 
            // lblsaves
            // 
            this.lblsaves.AutoSize = true;
            this.lblsaves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblsaves.Location = new System.Drawing.Point(378, 18);
            this.lblsaves.Name = "lblsaves";
            this.lblsaves.Size = new System.Drawing.Size(40, 13);
            this.lblsaves.TabIndex = 100;
            this.lblsaves.Text = "lblsave";
            this.lblsaves.Visible = false;
            // 
            // txtSchooFeesID
            // 
            this.txtSchooFeesID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSchooFeesID.Location = new System.Drawing.Point(298, 62);
            this.txtSchooFeesID.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtSchooFeesID.Name = "txtSchooFeesID";
            this.txtSchooFeesID.Size = new System.Drawing.Size(104, 17);
            this.txtSchooFeesID.TabIndex = 95;
            this.txtSchooFeesID.Visible = false;
            // 
            // btnGetData
            // 
            this.btnGetData.BackColor = System.Drawing.Color.Crimson;
            this.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetData.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnGetData.Location = new System.Drawing.Point(397, 21);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(92, 32);
            this.btnGetData.TabIndex = 4;
            this.btnGetData.Text = "&Get Data";
            this.btnGetData.UseVisualStyleBackColor = false;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(7, 96);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(70, 18);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Fee Name";
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.btnGetData);
            this.Panel1.Controls.Add(this.btnNew);
            this.Panel1.Controls.Add(this.btnDelete);
            this.Panel1.Controls.Add(this.btnSave);
            this.Panel1.Controls.Add(this.btnUpdate);
            this.Panel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(3, 248);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(499, 74);
            this.Panel1.TabIndex = 94;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Indigo;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNew.Location = new System.Drawing.Point(3, 21);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(92, 32);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Indigo;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDelete.Location = new System.Drawing.Point(199, 21);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 32);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.OrangeRed;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSave.Location = new System.Drawing.Point(101, 21);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Maroon;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(299, 21);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 32);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbFeeName
            // 
            this.cmbFeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbFeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeeName.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFeeName.FormattingEnabled = true;
            this.cmbFeeName.Location = new System.Drawing.Point(104, 96);
            this.cmbFeeName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbFeeName.Name = "cmbFeeName";
            this.cmbFeeName.Size = new System.Drawing.Size(298, 25);
            this.cmbFeeName.TabIndex = 1;
            this.cmbFeeName.SelectedIndexChanged += new System.EventHandler(this.cmbFeeName_SelectedIndexChanged);
            // 
            // cmbClass
            // 
            this.cmbClass.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbClass.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(104, 62);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(147, 25);
            this.cmbClass.TabIndex = 2;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // txtFeeID
            // 
            this.txtFeeID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFeeID.Location = new System.Drawing.Point(298, 62);
            this.txtFeeID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFeeID.Name = "txtFeeID";
            this.txtFeeID.Size = new System.Drawing.Size(105, 17);
            this.txtFeeID.TabIndex = 97;
            this.txtFeeID.Visible = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.txtClassQ);
            this.GroupBox1.Controls.Add(this.txtFeeIDQ);
            this.GroupBox1.Controls.Add(this.txtSchoolName);
            this.GroupBox1.Controls.Add(this.txtMonthQ);
            this.GroupBox1.Controls.Add(this.label6);
            this.GroupBox1.Controls.Add(this.txtSchoolQ);
            this.GroupBox1.Controls.Add(this.cmbMonth);
            this.GroupBox1.Controls.Add(this.txtSchoolID);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.cmbFeeName);
            this.GroupBox1.Controls.Add(this.txtClassID);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.cmbClass);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtSchooFeesID);
            this.GroupBox1.Controls.Add(this.txtFee);
            this.GroupBox1.Controls.Add(this.txtFeeID);
            this.GroupBox1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(5, 40);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.GroupBox1.Size = new System.Drawing.Size(500, 204);
            this.GroupBox1.TabIndex = 93;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "School Fee Info";
            // 
            // txtClassQ
            // 
            this.txtClassQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClassQ.Location = new System.Drawing.Point(256, 170);
            this.txtClassQ.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtClassQ.Name = "txtClassQ";
            this.txtClassQ.Size = new System.Drawing.Size(104, 17);
            this.txtClassQ.TabIndex = 106;
            this.txtClassQ.Visible = false;
            // 
            // txtFeeIDQ
            // 
            this.txtFeeIDQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFeeIDQ.Location = new System.Drawing.Point(299, 62);
            this.txtFeeIDQ.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtFeeIDQ.Name = "txtFeeIDQ";
            this.txtFeeIDQ.Size = new System.Drawing.Size(104, 17);
            this.txtFeeIDQ.TabIndex = 104;
            this.txtFeeIDQ.Visible = false;
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSchoolName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSchoolName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSchoolName.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchoolName.FormattingEnabled = true;
            this.txtSchoolName.Location = new System.Drawing.Point(104, 29);
            this.txtSchoolName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(298, 25);
            this.txtSchoolName.TabIndex = 0;
            this.txtSchoolName.SelectedIndexChanged += new System.EventHandler(this.txtSchoolName_SelectedIndexChanged);
            // 
            // txtMonthQ
            // 
            this.txtMonthQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonthQ.Location = new System.Drawing.Point(299, 62);
            this.txtMonthQ.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtMonthQ.Name = "txtMonthQ";
            this.txtMonthQ.Size = new System.Drawing.Size(104, 17);
            this.txtMonthQ.TabIndex = 103;
            this.txtMonthQ.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "School";
            // 
            // txtSchoolQ
            // 
            this.txtSchoolQ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSchoolQ.Location = new System.Drawing.Point(298, 62);
            this.txtSchoolQ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSchoolQ.Name = "txtSchoolQ";
            this.txtSchoolQ.Size = new System.Drawing.Size(105, 17);
            this.txtSchoolQ.TabIndex = 105;
            this.txtSchoolQ.Visible = false;
            // 
            // txtSchoolID
            // 
            this.txtSchoolID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSchoolID.Location = new System.Drawing.Point(298, 64);
            this.txtSchoolID.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtSchoolID.Name = "txtSchoolID";
            this.txtSchoolID.Size = new System.Drawing.Size(104, 17);
            this.txtSchoolID.TabIndex = 102;
            this.txtSchoolID.Visible = false;
            // 
            // frmSchoolFeesEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(552, 328);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblsaves);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSchoolFeesEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School Fees Entry";
            this.Load += new System.EventHandler(this.frmSchoolFeesEntry_Load);
            this.Panel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cmbMonth;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtClassID;
        public System.Windows.Forms.Label lblUserType;
        internal System.Windows.Forms.TextBox txtFee;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblsaves;
        internal System.Windows.Forms.TextBox txtSchooFeesID;
        public System.Windows.Forms.Button btnGetData;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.ComboBox cmbFeeName;
        internal System.Windows.Forms.ComboBox cmbClass;
        internal System.Windows.Forms.TextBox txtFeeID;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox txtSchoolName;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtSchoolID;
        internal System.Windows.Forms.TextBox txtClassQ;
        internal System.Windows.Forms.TextBox txtFeeIDQ;
        internal System.Windows.Forms.TextBox txtMonthQ;
        internal System.Windows.Forms.TextBox txtSchoolQ;
    }
}