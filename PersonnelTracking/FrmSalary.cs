using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmSalary : Form
    {
        private SalaryDTO dto = new SalaryDTO();

        public FrmSalary()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDTO()
        {
            dto = SalaryBLL.GetAll();
            dataGridView.DataSource = dto.Employees;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
            cmbMonth.DataSource = dto.Months;
        }

        private void FrmSalary_Load(object sender, EventArgs e)
        {
            UpdateDTO();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "UserNo";
            dataGridView.Columns[2].HeaderText = "Name";
            dataGridView.Columns[3].HeaderText = "Surname";
            dataGridView.Columns[4].Visible = false;
            dataGridView.Columns[5].Visible = false;
            dataGridView.Columns[6].Visible = false;
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].Visible = false;
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

            cmbMonth.DisplayMember = "Name";
            cmbMonth.ValueMember = "ID";
            cmbMonth.SelectedIndex = -1;
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
            cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == departmentID).ToList();
            dataGridView.DataSource = dto.Employees.Where(x => x.DepartmentID == departmentID).ToList();
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtUserNo.Text = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSurname.Text = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtYear.Text = DateTime.Today.Year.ToString();
            txtSalary.Text = dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void cmbPosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int positionID = Convert.ToInt32(cmbPosition.SelectedValue);
            dataGridView.DataSource = dto.Employees.Where(x => x.PositionID == positionID).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
                MessageBox.Show("Please select an employee on table");
            else if (txtYear.Text.Trim() == "")
                MessageBox.Show("year is empty");
            else if (txtSalary.Text.Trim() == "")
                MessageBox.Show("Salary is empty");
            else if (cmbMonth.SelectedIndex == -1)
                MessageBox.Show("Select a month");
            else
            {
                SalaryBLL.AddSalary(new Salary
                {
                    EmployeeID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value),
                    Year = Convert.ToInt32(txtYear.Text),
                    MonthID = Convert.ToInt32(cmbMonth.SelectedValue),
                    Amount = Convert.ToInt32(txtSalary.Text)
                });
                MessageBox.Show("Salary was added");
                cmbMonth.SelectedIndex = -1;
            }
        }
    }
}
