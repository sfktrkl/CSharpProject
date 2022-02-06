
namespace PersonnelTracking
{
    partial class FrmSalary
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUserNo = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 164);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 47;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(81, 111);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 43;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(6, 143);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 46;
            this.lblMonth.Text = "Month";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(6, 113);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 44;
            this.lblYear.Text = "Year";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(6, 87);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(36, 13);
            this.lblSalary.TabIndex = 42;
            this.lblSalary.Text = "Salary";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 77);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(211, 120);
            this.dataGridView.TabIndex = 1;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(82, 35);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(121, 21);
            this.cmbPosition.TabIndex = 23;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(14, 13);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 24;
            this.lblDepartment.Text = "Department";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(14, 38);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(44, 13);
            this.lblPosition.TabIndex = 25;
            this.lblPosition.Text = "Position";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(82, 10);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(121, 21);
            this.cmbDepartment.TabIndex = 22;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.cmbPosition);
            this.panelTop.Controls.Add(this.lblDepartment);
            this.panelTop.Controls.Add(this.lblPosition);
            this.panelTop.Controls.Add(this.cmbDepartment);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(211, 77);
            this.panelTop.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(127, 164);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(81, 58);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.ReadOnly = true;
            this.txtSurname.Size = new System.Drawing.Size(100, 20);
            this.txtSurname.TabIndex = 39;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(81, 32);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 37;
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(81, 6);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.ReadOnly = true;
            this.txtUserNo.Size = new System.Drawing.Size(100, 20);
            this.txtUserNo.TabIndex = 35;
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(6, 64);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(49, 13);
            this.lblSurname.TabIndex = 40;
            this.lblSurname.Text = "Surname";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 34);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 38;
            this.lblName.Text = "Name";
            // 
            // lblUserNo
            // 
            this.lblUserNo.AutoSize = true;
            this.lblUserNo.Location = new System.Drawing.Point(6, 9);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(69, 13);
            this.lblUserNo.TabIndex = 36;
            this.lblUserNo.Text = "User Number";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dataGridView);
            this.panelRight.Controls.Add(this.panelTop);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(233, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(211, 197);
            this.panelRight.TabIndex = 34;
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(81, 85);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(100, 20);
            this.txtSalary.TabIndex = 49;
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(81, 137);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 50;
            // 
            // FrmSalary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 197);
            this.ControlBox = false;
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtUserNo);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblUserNo);
            this.Controls.Add(this.panelRight);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalary";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserNo;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUserNo;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.ComboBox cmbMonth;
    }
}