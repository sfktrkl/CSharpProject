using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace PersonnelTracking
{
    public partial class FrmDepartmentList : Form
    {
        private Department detail = new Department();

        private List<Department> departments = new List<Department>();

        public FrmDepartmentList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDepartments()
        {
            departments = DepartmentBLL.GetDepartments();
            dataGridView.DataSource = departments;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmDepartment());
            UpdateDepartments();
        }

        private void FrmDepartmentList_Load(object sender, EventArgs e)
        {
            UpdateDepartments();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Department Name";
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            detail.Name = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a department from table");
            else
            {
                FrmDepartment frm = new FrmDepartment();
                frm.isUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                UpdateDepartments();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to delete this Department", "Warning!!", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == result)
            {
                DepartmentBLL.DeleteDepartment(detail.ID);
                MessageBox.Show("Department was Deleted");
                UpdateDepartments();
            }
        }
    }
}
