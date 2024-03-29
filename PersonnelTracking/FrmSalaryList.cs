﻿using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmSalaryList : Form
    {
        private SalaryDTO dto = new SalaryDTO();
        private SalaryDetailDTO detail = new SalaryDetailDTO();

        public FrmSalaryList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateSalaries()
        {
            dto = SalaryBLL.GetAll();
            if (!User.IsAdmin)
                dto.Salaries = dto.Salaries.Where(x => x.EmployeeID == User.EmployeeID).ToList();
            dataGridView.DataSource = dto.Salaries;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
            cmbMonth.DataSource = dto.Months;
        }

        private void CleanFilter()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtYear.Clear();
            txtSalary.Clear();

            dataGridView.DataSource = dto.Salaries;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;

            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            rbMore.Checked = false;
            rbLess.Checked = false;
            rbEquals.Checked = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmSalary());
            UpdateSalaries();
            CleanFilter();
        }

        private void FrmSalaryList_Load(object sender, EventArgs e)
        {
            UpdateSalaries();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "UserNo";
            dataGridView.Columns[2].HeaderText = "Name";
            dataGridView.Columns[3].HeaderText = "Surname";
            dataGridView.Columns[4].Visible = false;
            dataGridView.Columns[5].Visible = false;
            dataGridView.Columns[6].Visible = false;
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].HeaderText = "Month";
            dataGridView.Columns[9].HeaderText = "Year";
            dataGridView.Columns[11].HeaderText = "Salary";
            dataGridView.Columns[10].Visible = false;
            dataGridView.Columns[12].Visible = false;

            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;

            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedIndex = -1;

            cmbMonth.DisplayMember = "Name";
            cmbMonth.ValueMember = "ID";
            cmbMonth.SelectedIndex = -1;

            if (!User.IsAdmin)
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
                panelLeft.Hide();
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
            cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == departmentID).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalaryDetailDTO> list = dto.Salaries;
            if (txtUserNo.Text.Trim() != "")
                list = list.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            if (txtName.Text.Trim() != "")
                list = list.Where(x => x.Name.Contains(txtName.Text)).ToList();
            if (txtSurname.Text.Trim() != "")
                list = list.Where(x => x.Surname.Contains(txtSurname.Text)).ToList();
            if (cmbDepartment.SelectedIndex != -1)
                list = list.Where(x => x.DepartmentID == Convert.ToInt32(cmbDepartment.SelectedValue)).ToList();
            if (cmbPosition.SelectedIndex != -1)
                list = list.Where(x => x.PositionID == Convert.ToInt32(cmbPosition.SelectedValue)).ToList();
            if (txtYear.Text.Trim() != "")
                list = list.Where(x => x.SalaryYear == Convert.ToInt32(txtSalary.Text)).ToList();
            if (cmbMonth.SelectedIndex != -1)
                list = list.Where(x => x.MonthID == Convert.ToInt32(cmbMonth.SelectedValue)).ToList();
            if (txtSalary.Text.Trim() != "")
            {
                if (rbMore.Checked)
                    list = list.Where(x => x.SalaryAmount > Convert.ToInt32(txtSalary.Text)).ToList();
                else if (rbLess.Checked)
                    list = list.Where(x => x.SalaryAmount < Convert.ToInt32(txtSalary.Text)).ToList();
                else
                    list = list.Where(x => x.SalaryAmount == Convert.ToInt32(txtSalary.Text)).ToList();
            }
            dataGridView.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilter();
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.EmployeeID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            detail.UserNo = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Surname = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.SalaryYear = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[9].Value);
            detail.MonthID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[10].Value);
            detail.SalaryAmount = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[11].Value);
            detail.SalaryID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[12].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.SalaryID == 0)
                MessageBox.Show("Please select a salary from table");
            else
            {
                FrmSalary frm = new FrmSalary();
                frm.isUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                UpdateSalaries();
                CleanFilter();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this Salary", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SalaryBLL.DeleteSalary(detail.SalaryID);
                MessageBox.Show("Salary was Deleted");
                UpdateSalaries();
                CleanFilter();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export.ToExcel(dataGridView);
        }
    }
}
