using DataAccessLayer.DataTransferObjects;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Linq;
using System;
using DataAccessLayer;
using System.IO;

namespace PersonnelTracking
{
    public partial class FrmEmployee : Form
    {
        public bool isUpdate;
        public EmployeeDetailDTO detail;

        private EmployeeDTO dto = new EmployeeDTO();
        private string filename = "";

        public FrmEmployee()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Helper.IsNumber(e);
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Helper.IsNumber(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDTO()
        {
            dto = EmployeeBLL.GetAll();
            cmbDepartment.DataSource = dto.Departments;
            cmbPosition.DataSource = dto.Positions;
        }

        private void FrmEmployee_Load(object sender, EventArgs e)
        {
            UpdateDTO();

            cmbDepartment.DisplayMember = "Name";
            cmbDepartment.ValueMember = "ID";
            cmbDepartment.SelectedIndex = -1;

            cmbPosition.DisplayMember = "Name";
            cmbPosition.ValueMember = "ID";
            cmbPosition.SelectedIndex = -1;

            if (isUpdate)
            {
                txtName.Text = detail.Name;
                txtSurname.Text = detail.Surname;
                txtUserNo.Text = detail.UserNo.ToString();
                txtPassword.Text = detail.Password;
                chkIsAdmin.Checked = Convert.ToBoolean(detail.IsAdmin);
                txtAddress.Text = detail.Adress;
                dateTimePicker.Value = Convert.ToDateTime(detail.Birthday);
                cmbDepartment.SelectedValue = detail.DepartmentID;
                cmbPosition.SelectedValue = detail.PositionID;
                txtSalary.Text = detail.Salary.ToString();
                filename = Application.StartupPath + "\\images\\" + detail.ImagePath;
                txtImagePath.Text = filename;
                pictureBox.ImageLocation = filename;
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int departmentID = Convert.ToInt32(cmbDepartment.SelectedValue);
            cmbPosition.DataSource = dto.Positions.Where(x => x.DepartmentID == departmentID).ToList();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Load(openFileDialog.FileName);
                txtImagePath.Text = openFileDialog.FileName;
                string unique = Guid.NewGuid().ToString();
                filename = unique + openFileDialog.SafeFileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("UserNo is Empty");
            else if (!isUpdate && !EmployeeBLL.isUnique(Convert.ToInt32(txtUserNo.Text)))
                MessageBox.Show("UserNo is already used");
            else if (txtPassword.Text.Trim() == "")
                MessageBox.Show("Password is Empty");
            else if (txtName.Text.Trim() == "")
                MessageBox.Show("Name is Empty");
            else if (txtSurname.Text.Trim() == "")
                MessageBox.Show("Surname is Empty");
            else if (txtSalary.Text.Trim() == "")
                MessageBox.Show("Salary is Empty");
            else if (cmbDepartment.SelectedIndex == -1)
                MessageBox.Show("Select a department");
            else if (cmbPosition.SelectedIndex == -1)
                MessageBox.Show("Select a position");
            else
            {
                if (!isUpdate)
                {
                    EmployeeBLL.AddEmployee(new Employee
                    {
                        UserNo = Convert.ToInt32(txtUserNo.Text),
                        Password = txtPassword.Text,
                        isAdmin = chkIsAdmin.Checked,
                        Name = txtName.Text,
                        Surname = txtSurname.Text,
                        Salary = Convert.ToInt32(txtSalary.Text),
                        DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue),
                        PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                        Adress = txtAddress.Text,
                        Birthday = dateTimePicker.Value,
                        ImagePath = filename
                    });
                    File.Copy(txtImagePath.Text, @"images\\" + filename);
                    MessageBox.Show("Employee was added");
                    txtUserNo.Clear();
                    txtPassword.Clear();
                    chkIsAdmin.Checked = false;
                    txtName.Clear();
                    txtSurname.Clear();
                    txtSalary.Clear();
                    txtAddress.Clear();
                    txtImagePath.Clear();
                    pictureBox.Image = null;
                    dateTimePicker.Value = DateTime.Today;

                    cmbDepartment.DataSource = dto.Departments;
                    cmbDepartment.SelectedIndex = -1;

                    cmbPosition.DataSource = dto.Positions;
                    cmbPosition.SelectedIndex = -1;
                }
                else
                {
                    DialogResult result = MessageBox.Show("are you sure?", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Employee employee = new Employee
                        {
                            ID = detail.EmployeeID,
                            UserNo = Convert.ToInt32(txtUserNo.Text),
                            Name = txtName.Text,
                            Surname = txtSurname.Text,
                            isAdmin = chkIsAdmin.Checked,
                            Password = txtPassword.Text,
                            Adress = txtAddress.Text,
                            Birthday = dateTimePicker.Value,
                            DepartmentID = Convert.ToInt32(cmbDepartment.SelectedValue),
                            PositionID = Convert.ToInt32(cmbPosition.SelectedValue),
                            Salary = Convert.ToInt32(txtSalary.Text),
                            ImagePath = detail.ImagePath
                        };
                        if (txtImagePath.Text != filename)
                        {
                            if (File.Exists(@"images\\" + detail.ImagePath))
                                File.Delete(@"images\\" + detail.ImagePath);
                            File.Copy(txtImagePath.Text, @"images\\" + filename);
                            employee.ImagePath = filename;
                        }
                        EmployeeBLL.UpdateEmployee(employee);
                        MessageBox.Show("Employee was updated");
                        this.Close();
                    }
                }
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "")
                MessageBox.Show("User no is Empty");
            else
            {
                if (!EmployeeBLL.isUnique(Convert.ToInt32(txtUserNo.Text)))
                    MessageBox.Show("UserNo is already used");
                else
                    MessageBox.Show("UserNo is okay");
            }
        }
    }
}
