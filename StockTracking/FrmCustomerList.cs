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
        private readonly CustomerDetailDTO detail = new CustomerDetailDTO();

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

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
            detail.CustomerName = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a customer from table");
            else
            {
                Helper.ShowForm(this, new FrmCustomer(detail));
                UpdateCategories();
            }
        }
    }
}
