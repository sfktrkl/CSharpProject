using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmTask : Form
    {
        public bool isUpdate;
        public TaskDetailDTO detail;

        private TaskDTO dto = new TaskDTO();

        public FrmTask()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDTO()
        {
            dto = TaskBLL.GetAll();
            dataGridView.DataSource = dto.Employees;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
        }

        private void FrmTask_Load(object sender, EventArgs e)
        {
            lblState.Visible = false;
            cmbState.Visible = false;

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

            if (isUpdate)
            {
                panelRight.Hide();
                lblState.Visible = true;
                cmbState.Visible = true;

                txtName.Text = detail.Name;
                txtUserNo.Text = detail.UserNo.ToString();
                txtSurname.Text = detail.Surname;
                txtTitle.Text = detail.Title;
                txtExplanation.Text = detail.Explanation;

                cmbState.DataSource = dto.TaskStates;
                cmbState.DisplayMember = "Name";
                cmbState.ValueMember = "ID";
                cmbState.SelectedValue = detail.StateID;
            }
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
        }

        private void cmbPosition_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int positionID = Convert.ToInt32(cmbPosition.SelectedValue);
            dataGridView.DataSource = dto.Employees.Where(x => x.PositionID == positionID).ToList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isUpdate && dataGridView.SelectedRows.Count == 0)
                MessageBox.Show("Please select an employee on table");
            else if (txtTitle.Text.Trim() == "")
                MessageBox.Show("Task Title is empty");
            else if (txtExplanation.Text.Trim() == "")
            {
                MessageBox.Show("Content is empty");
            }
            else
            {
                if (!isUpdate)
                {
                    TaskBLL.AddTask(new Task
                    {
                        EmployeeID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value),
                        State = 1,
                        Title = txtTitle.Text,
                        StartDate = DateTime.Today,
                        Explanation = txtExplanation.Text,
                    });
                    MessageBox.Show("Task was added");
                    txtTitle.Clear();
                    txtExplanation.Clear();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TaskBLL.UpdateTask(new Task
                        {
                            ID = detail.TaskID,
                            EmployeeID = detail.EmployeeID,
                            Title = txtTitle.Text,
                            Explanation = txtExplanation.Text,
                            State = Convert.ToInt32(cmbState.SelectedValue)
                        });
                        MessageBox.Show("Task was updated");
                        this.Close();
                    }
                }
            }
        }
    }
}
