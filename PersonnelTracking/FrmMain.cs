using System.Windows.Forms;
using System;

namespace PersonnelTracking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmEmployeeList());
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmTaskList());
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmSalaryList());
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmPermissionList());
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmDepartmentList());
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmPositionList());
        }
    }
}
