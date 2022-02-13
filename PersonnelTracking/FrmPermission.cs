using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmPermission : Form
    {
        public bool isUpdate;
        public PermissionDetailDTO detail;

        private TimeSpan permissionDay;

        public FrmPermission()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateDayAmount()
        {
            permissionDay = dtbFinishDate.Value.Date - dtbStartDate.Value.Date;
            txtDayAmount.Text = permissionDay.TotalDays.ToString();
        }

        private void FrmPermission_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                dtbStartDate.Value = detail.StartDate;
                dtbFinishDate.Value = detail.EndDate;
                txtExplanation.Text = detail.Explanation;
                txtUserNo.Text = detail.UserNo.ToString();
            }
            else
                txtUserNo.Text = User.UserNo.ToString();
            UpdateDayAmount();
        }

        private void dtbStartDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateDayAmount();
        }

        private void dtbFinishDate_ValueChanged(object sender, EventArgs e)
        {
            UpdateDayAmount();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDayAmount.Text.Trim() == "")
                MessageBox.Show("please change end or start date");
            else if (Convert.ToInt32(txtDayAmount.Text) <= 0)
                MessageBox.Show("Permission day must be bigger than 0");
            else if (txtExplanation.Text.Trim() == "")
                MessageBox.Show("Explanation is empty");
            else
            {
                if (!isUpdate)
                {
                    PermissionBLL.AddPermission(new Permission
                    {
                        EmployeeID = User.EmployeeID,
                        State = 1,
                        StartDate = dtbStartDate.Value.Date,
                        EndDate = dtbFinishDate.Value.Date,
                        Day = Convert.ToInt32(txtDayAmount.Text),
                        Explanation = txtExplanation.Text
                    });
                    MessageBox.Show("Permission was Added");
                    dtbStartDate.Value = DateTime.Today;
                    dtbFinishDate.Value = DateTime.Today;
                    txtDayAmount.Clear();
                    txtExplanation.Clear();
                }
                else
                {
                    DialogResult result = MessageBox.Show("Are you sure", "Warning", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        PermissionBLL.UpdatePermission(new Permission
                        {
                            ID = detail.PermissionID,
                            Explanation = txtExplanation.Text,
                            StartDate = dtbStartDate.Value,
                            EndDate = dtbFinishDate.Value,
                            Day = Convert.ToInt32(txtDayAmount.Text)
                        });
                        MessageBox.Show("Permission was Updated");
                        this.Close();
                    }
                }
            }
        }
    }
}
