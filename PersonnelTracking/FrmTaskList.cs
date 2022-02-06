using System.Windows.Forms;
using System;

namespace PersonnelTracking
{
    public partial class FrmTaskList : Form
    {
        public FrmTaskList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Helper.IsNumber(e);
        }

        private void FrmTaskList_Load(object sender, EventArgs e)
        {
            panelLeft.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmTask());
        }
    }
}
