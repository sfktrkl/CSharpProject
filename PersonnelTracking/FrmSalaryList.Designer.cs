
namespace PersonnelTracking
{
    partial class FrmSalaryList
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
            this.rbLess = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.rbEquals = new System.Windows.Forms.RadioButton();
            this.rbMore = new System.Windows.Forms.RadioButton();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblSurname = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblUserNo = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbLess
            // 
            this.rbLess.AutoSize = true;
            this.rbLess.Location = new System.Drawing.Point(61, 19);
            this.rbLess.Name = "rbLess";
            this.rbLess.Size = new System.Drawing.Size(47, 17);
            this.rbLess.TabIndex = 1;
            this.rbLess.TabStop = true;
            this.rbLess.Text = "Less";
            this.rbLess.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.rbEquals);
            this.groupBox.Controls.Add(this.rbLess);
            this.groupBox.Controls.Add(this.rbMore);
            this.groupBox.Location = new System.Drawing.Point(12, 88);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(184, 41);
            this.groupBox.TabIndex = 23;
            this.groupBox.TabStop = false;
            // 
            // rbEquals
            // 
            this.rbEquals.AutoSize = true;
            this.rbEquals.Location = new System.Drawing.Point(114, 18);
            this.rbEquals.Name = "rbEquals";
            this.rbEquals.Size = new System.Drawing.Size(57, 17);
            this.rbEquals.TabIndex = 2;
            this.rbEquals.TabStop = true;
            this.rbEquals.Text = "Equals";
            this.rbEquals.UseVisualStyleBackColor = true;
            // 
            // rbMore
            // 
            this.rbMore.AutoSize = true;
            this.rbMore.Location = new System.Drawing.Point(6, 19);
            this.rbMore.Name = "rbMore";
            this.rbMore.Size = new System.Drawing.Size(49, 17);
            this.rbMore.TabIndex = 0;
            this.rbMore.TabStop = true;
            this.rbMore.Text = "More";
            this.rbMore.UseVisualStyleBackColor = true;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(273, 39);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(121, 21);
            this.cmbPosition.TabIndex = 17;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(313, 47);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(205, 42);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(44, 13);
            this.lblPosition.TabIndex = 19;
            this.lblPosition.Text = "Position";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(273, 14);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(121, 21);
            this.cmbDepartment.TabIndex = 16;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(205, 17);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(62, 13);
            this.lblDepartment.TabIndex = 18;
            this.lblDepartment.Text = "Department";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(93, 66);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(100, 20);
            this.txtSurname.TabIndex = 14;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(93, 40);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 12;
            // 
            // txtUserNo
            // 
            this.txtUserNo.Location = new System.Drawing.Point(93, 14);
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Size = new System.Drawing.Size(100, 20);
            this.txtUserNo.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(313, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 17;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(18, 72);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(49, 13);
            this.lblSurname.TabIndex = 15;
            this.lblSurname.Text = "Surname";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Name";
            // 
            // lblUserNo
            // 
            this.lblUserNo.AutoSize = true;
            this.lblUserNo.Location = new System.Drawing.Point(18, 17);
            this.lblUserNo.Name = "lblUserNo";
            this.lblUserNo.Size = new System.Drawing.Size(69, 13);
            this.lblUserNo.TabIndex = 11;
            this.lblUserNo.Text = "User Number";
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.cmbPosition);
            this.panelLeft.Controls.Add(this.lblPosition);
            this.panelLeft.Controls.Add(this.cmbDepartment);
            this.panelLeft.Controls.Add(this.lblDepartment);
            this.panelLeft.Controls.Add(this.txtSurname);
            this.panelLeft.Controls.Add(this.txtName);
            this.panelLeft.Controls.Add(this.txtUserNo);
            this.panelLeft.Controls.Add(this.lblSurname);
            this.panelLeft.Controls.Add(this.lblName);
            this.panelLeft.Controls.Add(this.lblUserNo);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(403, 144);
            this.panelLeft.TabIndex = 17;
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(0, 144);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(800, 257);
            this.dataGridView.TabIndex = 7;
            this.dataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_RowEnter);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.panelRight);
            this.panelTop.Controls.Add(this.panelLeft);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(800, 144);
            this.panelTop.TabIndex = 6;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnExport);
            this.panelRight.Controls.Add(this.cmbMonth);
            this.panelRight.Controls.Add(this.txtSalary);
            this.panelRight.Controls.Add(this.txtYear);
            this.panelRight.Controls.Add(this.lblMonth);
            this.panelRight.Controls.Add(this.lblYear);
            this.panelRight.Controls.Add(this.lblSalary);
            this.panelRight.Controls.Add(this.groupBox);
            this.panelRight.Controls.Add(this.btnClear);
            this.panelRight.Controls.Add(this.btnSearch);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(403, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(397, 144);
            this.panelRight.TabIndex = 18;
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(96, 62);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(121, 21);
            this.cmbMonth.TabIndex = 56;
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(96, 10);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(100, 20);
            this.txtSalary.TabIndex = 55;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(96, 36);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 52;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(21, 68);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(37, 13);
            this.lblMonth.TabIndex = 54;
            this.lblMonth.Text = "Month";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(21, 38);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 53;
            this.lblYear.Text = "Year";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Location = new System.Drawing.Point(21, 12);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(36, 13);
            this.lblSalary.TabIndex = 51;
            this.lblSalary.Text = "Salary";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(93, 14);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnClose);
            this.panelBottom.Controls.Add(this.btnDelete);
            this.panelBottom.Controls.Add(this.btnUpdate);
            this.panelBottom.Controls.Add(this.btnAdd);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 401);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(800, 49);
            this.panelBottom.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(713, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(313, 76);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 57;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FrmSalaryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalaryList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary List";
            this.Load += new System.EventHandler(this.FrmSalaryList_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbLess;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.RadioButton rbEquals;
        private System.Windows.Forms.RadioButton rbMore;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblUserNo;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Button btnExport;
    }
}