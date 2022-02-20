using System.Collections.Generic;
using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using System.Linq;
using System;

namespace StockTracking
{
    public partial class FrmSales : Form
    {
        private readonly SalesDetailDTO detail = new SalesDetailDTO();
        private readonly SalesBLL bll = new SalesBLL();
        private SalesDTO dto = new SalesDTO();

        public FrmSales(SalesDTO dto)
        {
            InitializeComponent();
            this.dto = dto;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateSales()
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            dataGridViewProduct.DataSource = dto.Products;
            dataGridViewCustomer.DataSource = dto.Customers;
        }

        private void FrmSales_Load(object sender, EventArgs e)
        {
            UpdateSales();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;

            dataGridViewProduct.Columns[0].HeaderText = "Product Name";
            dataGridViewProduct.Columns[1].HeaderText = "Category Name";
            dataGridViewProduct.Columns[2].HeaderText = "Stock Amount";
            dataGridViewProduct.Columns[3].HeaderText = "Price";
            dataGridViewProduct.Columns[4].Visible = false;
            dataGridViewProduct.Columns[5].Visible = false;

            dataGridViewCustomer.Columns[0].Visible = false;
            dataGridViewCustomer.Columns[1].HeaderText = "Customer Name";
        }

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.Products;
            list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            dataGridViewProduct.DataSource = list;
            if (list.Count == 0)
            {
                txtPrice.Clear();
                txtProductName.Clear();
                txtStock.Clear();
            }
        }

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            var list = dto.Customers;
            list = list.Where(x => x.CustomerName.Contains(txtCustomer.Text)).ToList();
            dataGridViewCustomer.DataSource = list;
            if (list.Count == 0)
                txtCustomerName.Clear();
        }

        private void dataGridViewProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = dataGridViewProduct.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.StockAmount = Convert.ToInt32(dataGridViewProduct.Rows[e.RowIndex].Cells[2].Value);
            detail.Price = Convert.ToInt32(dataGridViewProduct.Rows[e.RowIndex].Cells[3].Value);
            detail.ProductID = Convert.ToInt32(dataGridViewProduct.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(dataGridViewProduct.Rows[e.RowIndex].Cells[5].Value);
            txtProductName.Text = detail.ProductName;
            txtPrice.Text = detail.Price.ToString();
            txtStock.Text = detail.StockAmount.ToString();
        }

        private void dataGridViewCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.CustomerID = Convert.ToInt32(dataGridViewCustomer.Rows[e.RowIndex].Cells[0].Value);
            detail.CustomerName = dataGridViewCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtCustomerName.Text = detail.CustomerName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Please select a product from product table");
            else if (detail.CustomerID == 0)
                MessageBox.Show("Please select a customer from customer table");
            else if (detail.StockAmount < Convert.ToInt32(txtSales.Text))
                MessageBox.Show("You have bot enough product for sale");
            else
            {
                detail.SalesAmount = Convert.ToInt32(txtSales.Text);
                detail.SalesDate = DateTime.Today;
                if (bll.Insert(detail))
                {
                    MessageBox.Show("Sales was added");
                    txtSales.Clear();
                    UpdateSales();
                }
            }
        }
    }
}
