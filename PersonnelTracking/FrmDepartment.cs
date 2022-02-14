using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace PersonnelTracking
{
    public partial class FrmDepartment : Form
    {
        public bool isUpdate;
        public Department detail;

        public FrmDepartment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtDepartment.Text = detail.Name;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartment.Text.Trim() == "")
                MessageBox.Show("Please fill the name field");
            else
            {
                if (!isUpdate)
                {
                    DepartmentBLL.AddDepartment(new Department
                    {
                        Name = txtDepartment.Text
                    });
                    MessageBox.Show("Department has been added successfully.");
                    txtDepartment.Text = "";
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure?", "Warning!!", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == result)
                    {
                        Department department = new Department
                        {
                            ID = detail.ID,
                            Name = txtDepartment.Text
                        };
                        DepartmentBLL.UpdateDepartment(department);
                        MessageBox.Show("Department was updated");
                        this.Close();
                    }
                }
            }
        }
    }
}
