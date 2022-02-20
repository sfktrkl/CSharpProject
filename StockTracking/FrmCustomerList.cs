using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using System.Linq;
using System;

namespace StockTracking
{
    public partial class FrmCustomerList : Form
    {
        private CustomerDTO dto = new CustomerDTO();
        private readonly CustomerBLL bll = new CustomerBLL();

        public FrmCustomerList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateCategories()
        {
            dto = bll.Select();
            dataGridView.DataSource = dto.Customers;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmCustomer());
            UpdateCategories();
        }

        private void FrmCustomerList_Load(object sender, EventArgs e)
        {
            UpdateCategories();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Customer Name";
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            var list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
            dataGridView.DataSource = list;
        }
    }
}
