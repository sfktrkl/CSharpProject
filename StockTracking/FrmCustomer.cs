using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using System;

namespace StockTracking
{
    public partial class FrmCustomer : Form
    {
        private readonly CustomerBLL bll = new CustomerBLL();

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.Text.Trim() == "")
                MessageBox.Show("Customer Name is empty");
            else
            {
                CustomerDetailDTO customer = new CustomerDetailDTO
                {
                    CustomerName = txtCustomerName.Text
                };
                if (bll.Insert(customer))
                {
                    MessageBox.Show("Customer was added");
                    txtCustomerName.Clear();
                }
            }
        }
    }
}
