using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Helper.IsNumber(e);
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnter_Click(object sender, System.EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                MessageBox.Show("Please fill the information");
            else
            {
                List<EmployeeDetailDTO> employees = EmployeeBLL.GetEmployees(Convert.ToInt32(txtUserNo.Text), txtPassword.Text);
                if (employees.Count == 0)
                    MessageBox.Show("Check your credentials");
                else
                {
                    EmployeeDetailDTO employee = employees.First();
                    User.EmployeeID = employee.EmployeeID;
                    User.UserNo = employee.UserNo;
                    User.IsAdmin = Convert.ToBoolean(employee.IsAdmin);
                    FrmMain frm = new FrmMain();
                    this.Hide();
                    frm.ShowDialog();
                }
            }
        }
    }
}
