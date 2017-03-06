namespace School_Software
{
    partial class frmHostelInstallment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHostelInstallment));
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.ComboBox();
            this.txtSchoolName = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtHostel = new System.Windows.Forms.ComboBox();
            this.txtInstallment = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtCharges = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel5 = new System.Windows.Forms.Panel();
            this.txtSearchByClass = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtSchoolID = new System.Windows.Forms.TextBox();
            this.txtClassID = new System.Windows.Forms.TextBox();
            this.txthostelID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtsearchBySchool = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIHID = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserType = new System.Windows.Forms.Label();
            this.txtInstallment1 = new System.Windows.Forms.TextBox();
            this.txtHostel1 = new System.Windows.Forms.TextBox();
            this.txtclass1 = new System.Windows.Forms.TextBox();
            this.txtSchool1 = new System.Windows.Forms.TextBox();
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.Panel5.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel4
            // 
            this.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel4.Controls.Add(this.Label5);
            this.Panel4.Controls.Add(this.Label4);
            this.Panel4.Controls.Add(this.txtClass);
            this.Panel4.Controls.Add(this.txtSchoolName);
            this.Panel4.Controls.Add(this.Label2);
            this.Panel4.Controls.Add(this.txtHostel);
            this.Panel4.Controls.Add(this.txtInstallment);
            this.Panel4.Controls.Add(this.Label6);
            this.Panel4.Controls.Add(this.txtCharges);
            this.Panel4.Controls.Add(this.Label3);
            this.Panel4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel4.Location = new System.Drawing.Point(4, 42);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(343, 158);
            this.Panel4.TabIndex = 4;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(5, 94);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(42, 17);
            this.Label5.TabIndex = 15;
            this.Label5.Text = "Class :";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(7, 64);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(86, 17);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "School Name :";
            // 
            // txtClass
            // 
            this.txtClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtClass.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClass.FormattingEnabled = true;
            this.txtClass.Location = new System.Drawing.Point(122, 94);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(96, 24);
            this.txtClass.TabIndex = 3;
            this.txtClass.SelectedIndexChanged += new System.EventHandler(this.txtClass_SelectedIndexChanged);
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSchoolName.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchoolName.FormattingEnabled = true;
            this.txtSchoolName.Location = new System.Drawing.Point(122, 64);
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(190, 24);
            this.txtSchoolName.TabIndex = 2;
            this.txtSchoolName.SelectedIndexChanged += new System.EventHandler(this.txtSchoolName_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(7, 34);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(49, 17);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Hostel :";
            // 
            // txtHostel
            // 
            this.txtHostel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtHostel.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHostel.FormattingEnabled = true;
            this.txtHostel.Location = new System.Drawing.Point(122, 34);
            this.txtHostel.Name = "txtHostel";
            this.txtHostel.Size = new System.Drawing.Size(190, 24);
            this.txtHostel.TabIndex = 1;
            this.txtHostel.SelectedIndexChanged += new System.EventHandler(this.txtHostel_SelectedIndexChanged);
            // 
            // txtInstallment
            // 
            this.txtInstallment.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallment.Location = new System.Drawing.Point(122, 5);
            this.txtInstallment.Name = "txtInstallment";
            this.txtInstallment.Size = new System.Drawing.Size(96, 22);
            this.txtInstallment.TabIndex = 0;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(5, 124);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(59, 17);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "Charges :";
            // 
            // txtCharges
            // 
            this.txtCharges.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharges.Location = new System.Drawing.Point(122, 124);
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.Size = new System.Drawing.Size(96, 22);
            this.txtCharges.TabIndex = 4;
            this.txtCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(7, 5);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(75, 17);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Installment :";
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LavenderBlush;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView1.ColumnHeadersHeight = 24;
            this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column9,
            this.Column8,
            this.Column4});
            this.DataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.DataGridView1.EnableHeadersVisualStyles = false;
            this.DataGridView1.GridColor = System.Drawing.Color.White;
            this.DataGridView1.Location = new System.Drawing.Point(6, 291);
            this.DataGridView1.MultiSelect = false;
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView1.RowHeadersWidth = 25;
            this.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(678, 218);
            this.DataGridView1.TabIndex = 5;
            this.DataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridView1_RowHeaderMouseClick);
            this.DataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.DataGridView1_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Installment";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Hostel ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Hostel Name";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "School ID";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "School Name";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 260;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Class ID";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Class";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Charges";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Panel5
            // 
            this.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel5.Controls.Add(this.txtSearchByClass);
            this.Panel5.Controls.Add(this.Label7);
            this.Panel5.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel5.Location = new System.Drawing.Point(232, 211);
            this.Panel5.Name = "Panel5";
            this.Panel5.Size = new System.Drawing.Size(221, 75);
            this.Panel5.TabIndex = 6;
            // 
            // txtSearchByClass
            // 
            this.txtSearchByClass.BackColor = System.Drawing.Color.White;
            this.txtSearchByClass.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchByClass.Location = new System.Drawing.Point(7, 33);
            this.txtSearchByClass.Name = "txtSearchByClass";
            this.txtSearchByClass.Size = new System.Drawing.Size(188, 25);
            this.txtSearchByClass.TabIndex = 0;
            this.txtSearchByClass.TextChanged += new System.EventHandler(this.txtSearchByClass_TextChanged);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(4, 4);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(110, 18);
            this.Label7.TabIndex = 12;
            this.Label7.Text = "Search By Class :";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Indigo;
            this.label10.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(-1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(683, 36);
            this.label10.TabIndex = 159;
            this.label10.Text = "Hostel Installments";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel1.Controls.Add(this.btnNew);
            this.Panel1.Controls.Add(this.btnDelete);
            this.Panel1.Controls.Add(this.btnSave);
            this.Panel1.Controls.Add(this.btnUpdate);
            this.Panel1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Panel1.Location = new System.Drawing.Point(548, 41);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(116, 169);
            this.Panel1.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Indigo;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNew.Location = new System.Drawing.Point(10, 5);
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
            this.btnDelete.Location = new System.Drawing.Point(10, 83);
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
            this.btnSave.Location = new System.Drawing.Point(10, 43);
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
            this.btnUpdate.Location = new System.Drawing.Point(10, 124);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 32);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtSchoolID
            // 
            this.txtSchoolID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSchoolID.Location = new System.Drawing.Point(381, 135);
            this.txtSchoolID.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtSchoolID.Name = "txtSchoolID";
            this.txtSchoolID.Size = new System.Drawing.Size(104, 13);
            this.txtSchoolID.TabIndex = 162;
            this.txtSchoolID.Visible = false;
            // 
            // txtClassID
            // 
            this.txtClassID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClassID.Location = new System.Drawing.Point(353, 135);
            this.txtClassID.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.Size = new System.Drawing.Size(104, 13);
            this.txtClassID.TabIndex = 161;
            this.txtClassID.Visible = false;
            // 
            // txthostelID
            // 
            this.txthostelID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txthostelID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txthostelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthostelID.Location = new System.Drawing.Point(379, 113);
            this.txthostelID.Name = "txthostelID";
            this.txthostelID.Size = new System.Drawing.Size(106, 15);
            this.txthostelID.TabIndex = 163;
            this.txthostelID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtsearchBySchool);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(7, 211);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 75);
            this.panel2.TabIndex = 13;
            // 
            // txtsearchBySchool
            // 
            this.txtsearchBySchool.BackColor = System.Drawing.Color.White;
            this.txtsearchBySchool.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchBySchool.Location = new System.Drawing.Point(7, 33);
            this.txtsearchBySchool.Name = "txtsearchBySchool";
            this.txtsearchBySchool.Size = new System.Drawing.Size(188, 25);
            this.txtsearchBySchool.TabIndex = 0;
            this.txtsearchBySchool.TextChanged += new System.EventHandler(this.txtsearchBySchool_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Search By School:";
            // 
            // txtIHID
            // 
            this.txtIHID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIHID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIHID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIHID.Location = new System.Drawing.Point(393, 116);
            this.txtIHID.Name = "txtIHID";
            this.txtIHID.Size = new System.Drawing.Size(106, 15);
            this.txtIHID.TabIndex = 164;
            this.txtIHID.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(389, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(106, 15);
            this.textBox1.TabIndex = 165;
            this.textBox1.Visible = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUser.Location = new System.Drawing.Point(333, 383);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 353;
            this.lblUser.Text = "User";
            this.lblUser.Visible = false;
            // 
            // lblUserType
            // 
            this.lblUserType.AutoSize = true;
            this.lblUserType.BackColor = System.Drawing.Color.Transparent;
            this.lblUserType.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblUserType.Location = new System.Drawing.Point(366, 373);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(53, 13);
            this.lblUserType.TabIndex = 352;
            this.lblUserType.Text = "UserType";
            this.lblUserType.Visible = false;
            // 
            // txtInstallment1
            // 
            this.txtInstallment1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInstallment1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInstallment1.Location = new System.Drawing.Point(389, 125);
            this.txtInstallment1.Name = "txtInstallment1";
            this.txtInstallment1.Size = new System.Drawing.Size(96, 15);
            this.txtInstallment1.TabIndex = 16;
            this.txtInstallment1.Visible = false;
            // 
            // txtHostel1
            // 
            this.txtHostel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHostel1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHostel1.Location = new System.Drawing.Point(389, 125);
            this.txtHostel1.Name = "txtHostel1";
            this.txtHostel1.Size = new System.Drawing.Size(96, 15);
            this.txtHostel1.TabIndex = 354;
            this.txtHostel1.Visible = false;
            // 
            // txtclass1
            // 
            this.txtclass1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtclass1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclass1.Location = new System.Drawing.Point(369, 133);
            this.txtclass1.Name = "txtclass1";
            this.txtclass1.Size = new System.Drawing.Size(96, 15);
            this.txtclass1.TabIndex = 355;
            this.txtclass1.Visible = false;
            // 
            // txtSchool1
            // 
            this.txtSchool1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSchool1.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchool1.Location = new System.Drawing.Point(357, 175);
            this.txtSchool1.Name = "txtSchool1";
            this.txtSchool1.Size = new System.Drawing.Size(96, 15);
            this.txtSchool1.TabIndex = 356;
            this.txtSchool1.Visible = false;
            // 
            // frmHostelInstallment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(682, 512);
            this.Controls.Add(this.txtSchool1);
            this.Controls.Add(this.txtclass1);
            this.Controls.Add(this.txtHostel1);
            this.Controls.Add(this.txtInstallment1);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblUserType);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtIHID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txthostelID);
            this.Controls.Add(this.txtSchoolID);
            this.Controls.Add(this.txtClassID);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Panel5);
            this.Controls.Add(this.Panel4);
            this.Controls.Add(this.DataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHostelInstallment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hostel Installment";
            this.Load += new System.EventHandler(this.frmHostelInstallment_Load);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.Panel5.ResumeLayout(false);
            this.Panel5.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.ComboBox txtClass;
        internal System.Windows.Forms.ComboBox txtSchoolName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ComboBox txtHostel;
        internal System.Windows.Forms.TextBox txtInstallment;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox txtCharges;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DataGridView DataGridView1;
        internal System.Windows.Forms.Panel Panel5;
        internal System.Windows.Forms.TextBox txtSearchByClass;
        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.TextBox txtSchoolID;
        internal System.Windows.Forms.TextBox txtClassID;
        public System.Windows.Forms.TextBox txthostelID;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.TextBox txtsearchBySchool;
        internal System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtIHID;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label lblUser;
        public System.Windows.Forms.Label lblUserType;
        internal System.Windows.Forms.TextBox txtInstallment1;
        internal System.Windows.Forms.TextBox txtHostel1;
        internal System.Windows.Forms.TextBox txtclass1;
        internal System.Windows.Forms.TextBox txtSchool1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}