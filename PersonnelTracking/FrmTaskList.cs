using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmTaskList : Form
    {
        private TaskDTO dto = new TaskDTO();
        private TaskDetailDTO detail = new TaskDetailDTO();

        public FrmTaskList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Helper.IsNumber(e);
        }

        private void UpdateTasks()
        {
            dto = TaskBLL.GetAll();
            dataGridView.DataSource = dto.Tasks;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
            cmbState.DataSource = dto.TaskStates;
        }

        private void CleanFilter()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();

            dataGridView.DataSource = dto.Tasks;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
            cmbState.DataSource = dto.TaskStates;

            cmbDepartment.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            cmbState.SelectedIndex = -1;
            dtbStartDate.Value = DateTime.Today;
            dtbFinishDate.Value = DateTime.Today;
            rbStartDate.Checked = false;
            rbFinishDate.Checked = false;
        }

        private void FrmTaskList_Load(object sender, EventArgs e)
        {
            UpdateTasks();
            dataGridView.Columns[0].HeaderText = "Task Title";
            dataGridView.Columns[1].HeaderText = "UserNo";
            dataGridView.Columns[2].HeaderText = "Name";
            dataGridView.Columns[3].HeaderText = "Surname";
            dataGridView.Columns[4].HeaderText = "Start Date";
            dataGridView.Columns[5].HeaderText = "Delivery Date";
            dataGridView.Columns[6].HeaderText = "Task State";
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].Visible = false;
            dataGridView.Columns[9].Visible = false;
            dataGridView.Columns[10].Visible = false;
            dataGridView.Columns[11].Visible = false;
            dataGridView.Columns[12].Visible = false;
            dataGridView.Columns[13].Visible = false;
            dataGridView.Columns[14].Visible = false;

            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;

            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedIndex = -1;

            cmbState.DisplayMember = "Name";
            cmbState.ValueMember = "ID";
            cmbState.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmTask());
            UpdateTasks();
            CleanFilter();
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
            cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == departmentID).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<TaskDetailDTO> list = dto.Tasks;
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
            if (rbStartDate.Checked)
                list = list.Where(x => x.StartDate > Convert.ToDateTime(dtbStartDate.Value) &&
                x.StartDate < Convert.ToDateTime(dtbFinishDate.Value)).ToList();
            if (rbFinishDate.Checked)
                list = list.Where(x => x.DeliveryDate > Convert.ToDateTime(dtbStartDate.Value) &&
                x.DeliveryDate < Convert.ToDateTime(dtbFinishDate.Value)).ToList();
            if (cmbState.SelectedIndex != -1)
                list = list.Where(x => x.StateID == Convert.ToInt32(cmbState.SelectedValue)).ToList();
            dataGridView.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilter();
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.Title = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.UserNo = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.Surname = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            detail.StartDate = Convert.ToDateTime(dataGridView.Rows[e.RowIndex].Cells[4].Value);
            detail.DeliveryDate = Convert.ToDateTime(dataGridView.Rows[e.RowIndex].Cells[5].Value);
            detail.StateID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[11].Value);
            detail.TaskID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[12].Value);
            detail.EmployeeID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[13].Value);
            detail.Explanation = dataGridView.Rows[e.RowIndex].Cells[14].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.TaskID == 0)
                MessageBox.Show("Please select a task on table");
            else
            {
                FrmTask frm = new FrmTask
                {
                    isUpdate = true,
                    detail = detail
                };
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                UpdateTasks();
                CleanFilter();
            }
        }
    }
}
