using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace PersonnelTracking
{
    public partial class FrmDepartment : Form
    {
        public FrmDepartment()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDepartment.Text.Trim() == "")
                MessageBox.Show("Please fill the name field");
            else
            {
                DepartmentBLL.AddDepartment(new Department
                {
                    Name = txtDepartment.Text
                });
                MessageBox.Show("Department has been added successfully.");
                txtDepartment.Text = "";
            }
        }
    }
}
