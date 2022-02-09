using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System;

namespace PersonnelTracking
{
    public partial class FrmPosition : Form
    {
        private List<Department> departments = new List<Department>();

        public FrmPosition()
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
            cmbDepartment.DataSource = departments;
        }

        private void FrmPosition_Load(object sender, EventArgs e)
        {
            UpdateDepartments();
            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text.Trim() == "")
                MessageBox.Show("Please fill the name field");
            else if (cmbDepartment.SelectedIndex == -1)
                MessageBox.Show("Please select the department");
            else
            {
                PositionBLL.AddPosition(new Position
                {
                    Name = txtPosition.Text,
                    DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                });
                MessageBox.Show("Position has been added successfully.");
                txtPosition.Text = "";
                cmbDepartment.SelectedIndex = -1;
            }
        }
    }
}
