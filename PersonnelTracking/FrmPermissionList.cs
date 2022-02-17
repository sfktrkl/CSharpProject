using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmPermissionList : Form
    {
        private PermissionDTO dto = new PermissionDTO();
        private PermissionDetailDTO detail = new PermissionDetailDTO();

        public FrmPermissionList()
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

        private void txtDayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Helper.IsNumber(e);
        }

        private void UpdatePermissions()
        {
            dto = PermissionBLL.GetAll();
            dataGridView.DataSource = dto.Permissions;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
            cmbState.DataSource = dto.States;
        }

        private void CleanFilter()
        {
            txtUserNo.Clear();
            txtName.Clear();
            txtSurname.Clear();
            txtDayAmount.Clear();

            dataGridView.DataSource = dto.Permissions;
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
            cmbState.DataSource = dto.States;

            cmbDepartment.SelectedIndex = -1;
            cmbState.SelectedIndex = -1;
            cmbPosition.SelectedIndex = -1;
            rbFinishDate.Checked = false;
            rbStartDate.Checked = false;
        }

        private void FrmPermissionList_Load(object sender, EventArgs e)
        {
            UpdatePermissions();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "UserNo";
            dataGridView.Columns[2].HeaderText = "Name";
            dataGridView.Columns[3].HeaderText = "Surname";
            dataGridView.Columns[4].Visible = false;
            dataGridView.Columns[5].Visible = false;
            dataGridView.Columns[6].Visible = false;
            dataGridView.Columns[7].Visible = false;
            dataGridView.Columns[8].HeaderText = "Start Date";
            dataGridView.Columns[9].HeaderText = "End Date";
            dataGridView.Columns[10].HeaderText = "Day Amount";
            dataGridView.Columns[12].Visible = false;
            dataGridView.Columns[11].HeaderText = "State";
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
            Helper.ShowForm(this, new FrmPermission());
            UpdatePermissions();
            CleanFilter();
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
            cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == departmentID).ToList();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<PermissionDetailDTO> list = dto.Permissions;
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
                list = list.Where(x => x.StartDate < Convert.ToDateTime(dtbFinishDate.Value) &&
                  x.StartDate > Convert.ToDateTime(dtbStartDate.Value)).ToList();
            else if (rbFinishDate.Checked)
                list = list.Where(x => x.EndDate < Convert.ToDateTime(dtbFinishDate.Value) &&
                  x.EndDate > Convert.ToDateTime(dtbStartDate.Value)).ToList();
            if (cmbState.SelectedIndex != -1)
                list = list.Where(x => x.State == Convert.ToInt32(cmbState.SelectedValue)).ToList();
            if (txtDayAmount.Text.Trim() != "")
                list = list.Where(x => x.PermissionDayAmount == Convert.ToInt32(txtDayAmount.Text)).ToList();
            dataGridView.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilter();
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.UserNo = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            detail.PermissionID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[14].Value);
            detail.StartDate = Convert.ToDateTime(dataGridView.Rows[e.RowIndex].Cells[8].Value);
            detail.EndDate = Convert.ToDateTime(dataGridView.Rows[e.RowIndex].Cells[9].Value);
            detail.PermissionDayAmount = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[10].Value);
            detail.State = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[12].Value);
            detail.Explanation = dataGridView.Rows[e.RowIndex].Cells[13].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.PermissionID == 0)
                MessageBox.Show("please select a permission from table");
            else
            {
                FrmPermission frm = new FrmPermission
                {
                    isUpdate = true,
                    detail = detail
                };
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                UpdatePermissions();
                CleanFilter();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            PermissionBLL.UpdatePermission(detail.PermissionID, PermissionStates.Approved);
            UpdatePermissions();
            CleanFilter();
        }

        private void btnDisapprove_Click(object sender, EventArgs e)
        {
            PermissionBLL.UpdatePermission(detail.PermissionID, PermissionStates.Disapproved);
            UpdatePermissions();
            CleanFilter();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this permission", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (detail.State == PermissionStates.Approved || detail.State == PermissionStates.Disapproved)
                    MessageBox.Show("You cannot delete approved or disapproved permissions");
                else
                {
                    PermissionBLL.DeletePermission(detail.PermissionID);
                    MessageBox.Show("Permission was deleted");
                    UpdatePermissions();
                    CleanFilter();
                }
            }
        }
    }
}
