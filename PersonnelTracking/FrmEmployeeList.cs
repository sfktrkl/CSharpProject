using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmEmployeeList : Form
    {
        private EmployeeDTO dto = new EmployeeDTO();
        private EmployeeDetailDTO detail = new EmployeeDetailDTO();

        public FrmEmployeeList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateEmployees()
        {
            dto = EmployeeBLL.GetAll();
            dataGridView.DataSource = dto.Employees;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
        }

        private void CleanFilter()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();

            dataGridView.DataSource = dto.Employees;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;

            cmbPosition.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmEmployee());
            UpdateEmployees();
            CleanFilter();
        }

        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            UpdateEmployees();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "UserNo";
            dataGridView.Columns[2].HeaderText = "Name";
            dataGridView.Columns[3].HeaderText = "Surname";
            dataGridView.Columns[4].HeaderText = "Dapartment";
            dataGridView.Columns[5].HeaderText = "Position";
            dataGridView.Columns[6].Visible = false;
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].HeaderText = "Salary";
            dataGridView.Columns[9].Visible = false;
            dataGridView.Columns[10].Visible = false;
            dataGridView.Columns[11].Visible = false;
            dataGridView.Columns[12].Visible = false;
            dataGridView.Columns[13].Visible = false;

            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;

            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedIndex = -1;
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
            cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == departmentID).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<EmployeeDetailDTO> list = dto.Employees;
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
            detail.DepartmentID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[6].Value);
            detail.PositionID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[7].Value);
            detail.Salary = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[8].Value);
            detail.IsAdmin = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[9].Value);
            detail.Password = dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString();
            detail.ImagePath = dataGridView.Rows[e.RowIndex].Cells[11].Value.ToString();
            detail.Adress = dataGridView.Rows[e.RowIndex].Cells[12].Value.ToString();
            detail.Birthday = Convert.ToDateTime(dataGridView.Rows[e.RowIndex].Cells[13].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.EmployeeID == 0)
                MessageBox.Show("Please select an employee on table");
            else
            {
                FrmEmployee frm = new FrmEmployee();
                frm.isUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                UpdateEmployees();
                CleanFilter();
            }
        }
    }
}
