using DataAccessLayer.DataTransferObjects;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (!User.IsAdmin)
            {
                btnDepartment.Visible = false;
                btnPosition.Visible = false;
                btnPermission.Location = new System.Drawing.Point(93, 41);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (!User.IsAdmin)
            {
                EmployeeDTO dto = EmployeeBLL.GetAll();
                Helper.ShowForm(this, new FrmEmployee()
                { 
                    isUpdate = true,
                    detail = dto.Employees.First(x => x.EmployeeID == User.EmployeeID)
                });
            }
            else
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
