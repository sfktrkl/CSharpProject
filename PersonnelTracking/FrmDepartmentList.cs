using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace PersonnelTracking
{
    public partial class FrmDepartmentList : Form
    {
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
    }
}
