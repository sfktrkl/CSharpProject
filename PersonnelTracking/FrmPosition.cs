using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmPosition : Form
    {
        public bool isUpdate;
        public PositionDTO detail;

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

            if (isUpdate)
            {
                txtPosition.Text = detail.Name;
                cmbDepartment.SelectedValue = detail.DepartmentID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPosition.Text.Trim() == "")
                MessageBox.Show("Please fill the name field");
            else if (cmbDepartment.SelectedIndex == -1)
                MessageBox.Show("Please select the department");
            else
            {
                if (!isUpdate)
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
                else
                {
                    Position position = new Position
                    {
                        ID = detail.ID,
                        Name = txtPosition.Text,
                        DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue)
                    };
                    PositionBLL.UpdatePosition(position);
                    MessageBox.Show("Position was Updated");
                    this.Close();
                }
            }
        }
    }
}
