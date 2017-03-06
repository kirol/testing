namespace School_Software
{
    partial class frmEmployeeReport
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeReport));
            this.txtSchool = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.ComboBox();
            this.txtDepartment = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.GroupBox4.SuspendLayout();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSchool
            // 
            this.txtSchool.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSchool.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtSchool.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSchool.FormattingEnabled = true;
            this.txtSchool.Location = new System.Drawing.Point(11, 42);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(193, 24);
            this.txtSchool.TabIndex = 44;
            this.txtSchool.SelectedIndexChanged += new System.EventHandler(this.txtSchool_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Crimson;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReset.Location = new System.Drawing.Point(8, 24);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(82, 30);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 17);
            this.label8.TabIndex = 43;
            this.label8.Text = "School :";
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.Color.OrangeRed;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Button1.Location = new System.Drawing.Point(461, 37);
            this.Button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(87, 30);
            this.Button1.TabIndex = 36;
            this.Button1.Text = "&Search";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.txtSchool);
            this.GroupBox4.Controls.Add(this.label8);
            this.GroupBox4.Controls.Add(this.Button1);
            this.GroupBox4.Controls.Add(this.Label2);
            this.GroupBox4.Controls.Add(this.label4);
            this.GroupBox4.Controls.Add(this.txtDesignation);
            this.GroupBox4.Controls.Add(this.txtDepartment);
            this.GroupBox4.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox4.Location = new System.Drawing.Point(7, 36);
            this.GroupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupBox4.Size = new System.Drawing.Size(561, 92);
            this.GroupBox4.TabIndex = 383;
            this.GroupBox4.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(349, 18);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(82, 17);
            this.Label2.TabIndex = 34;
            this.Label2.Text = "Designation  :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Department :";
            // 
            // txtDesignation
            // 
            this.txtDesignation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDesignation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDesignation.Enabled = false;
            this.txtDesignation.FormattingEnabled = true;
            this.txtDesignation.Location = new System.Drawing.Point(350, 41);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.Size = new System.Drawing.Size(95, 25);
            this.txtDesignation.TabIndex = 1;
            // 
            // txtDepartment
            // 
            this.txtDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDepartment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtDepartment.Enabled = false;
            this.txtDepartment.FormattingEnabled = true;
            this.txtDepartment.Location = new System.Drawing.Point(215, 43);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(124, 25);
            this.txtDepartment.TabIndex = 0;
            this.txtDepartment.SelectedIndexChanged += new System.EventHandler(this.txtDepartment_SelectedIndexChanged);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Indigo;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button10.Location = new System.Drawing.Point(103, 25);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(82, 30);
            this.button10.TabIndex = 1;
            this.button10.Text = "Close";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Indigo;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(-6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(582, 34);
            this.label3.TabIndex = 381;
            this.label3.Text = "Employee Report";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel15
            // 
            this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel15.Controls.Add(this.btnReset);
            this.panel15.Controls.Add(this.button10);
            this.panel15.Location = new System.Drawing.Point(6, 133);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(195, 73);
            this.panel15.TabIndex = 382;
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // frmEmployeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(574, 222);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel15);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmployeeReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Report";
            this.Load += new System.EventHandler(this.frmEmployeeReport_Load);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox txtSchool;
        private System.Windows.Forms.Button btnReset;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox txtDesignation;
        internal System.Windows.Forms.ComboBox txtDepartment;
        public System.Windows.Forms.Button button10;
        public System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Panel panel15;
        internal System.Windows.Forms.Timer Timer1;
    }
}