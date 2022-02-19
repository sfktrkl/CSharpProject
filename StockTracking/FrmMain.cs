using System.Windows.Forms;
using StockTracking;
using System.Linq;
using System;

namespace StockTracking
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmCustomerList());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmProductList());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmSalesList());
        }

        private void btnAddStock_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmAddStock());
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmCategoryList());
        }

        private void btnDeleted_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmDeleted());
        }
    }
}
