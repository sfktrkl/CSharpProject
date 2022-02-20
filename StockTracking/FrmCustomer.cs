using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using System;

namespace StockTracking
{
    public partial class FrmCustomer : Form
    {
        private readonly bool isUpdate;
        private readonly CustomerDetailDTO detail;
        private readonly CustomerBLL bll = new CustomerBLL();

        public FrmCustomer()
        {
            InitializeComponent();
        }

        public FrmCustomer(CustomerDetailDTO detail)
        {
            InitializeComponent();
            this.isUpdate = true;
            this.detail = detail;
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtCustomerName.Text = detail.CustomerName;
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
                if (!isUpdate)
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
                else
                {
                    if (detail.CustomerName == txtCustomerName.Text)
                        MessageBox.Show("There is no chnage");
                    else
                    {
                        detail.CustomerName = txtCustomerName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Customer was Updated");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
