using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System.Windows.Forms;
using StockTracking.BLL;
using System.Linq;
using System;

namespace StockTracking
{
    public partial class FrmDeleted : Form
    {
        private SalesDTO dto = new SalesDTO();

        private readonly SalesBLL salesBLL = new SalesBLL();
        private readonly ProductBLL productBLL = new ProductBLL();
        private readonly CategoryBLL categoryBLL = new CategoryBLL();
        private readonly CustomerBLL customerBLL = new CustomerBLL();

        private readonly SalesDetailDTO salesdetail = new SalesDetailDTO();
        private readonly ProductDetailDTO productdetail = new ProductDetailDTO();
        private readonly CategoryDetailDTO categorydetail = new CategoryDetailDTO();
        private readonly CustomerDetailDTO customerdetail = new CustomerDetailDTO();

        public FrmDeleted()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateData()
        {
            dto = salesBLL.Select(true);
            dataGridView.DataSource = dto.Sales;

            if (cmbDeleted.SelectedIndex == -1)
                cmbDeleted.SelectedIndex = 0;

            if (cmbDeleted.SelectedIndex == 0)
            {
                dataGridView.DataSource = dto.Categories;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].HeaderText = "Category Name";
            }
            else if (cmbDeleted.SelectedIndex == 1)
            {
                dataGridView.DataSource = dto.Customers;
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].HeaderText = "Customer Name";
            }
            else if (cmbDeleted.SelectedIndex == 2)
            {
                dataGridView.DataSource = dto.Products;
                dataGridView.Columns[0].HeaderText = "Product Name";
                dataGridView.Columns[1].HeaderText = "Category Name";
                dataGridView.Columns[2].HeaderText = "Stock Amount";
                dataGridView.Columns[3].HeaderText = "Price";
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[6].Visible = false;
            }
            else if (cmbDeleted.SelectedIndex == 3)
            {
                dataGridView.DataSource = dto.Sales;
                dataGridView.Columns[0].HeaderText = "Customer Name";
                dataGridView.Columns[1].HeaderText = "Product Name";
                dataGridView.Columns[2].HeaderText = "Category Name";
                dataGridView.Columns[6].HeaderText = "Sales Amount";
                dataGridView.Columns[7].HeaderText = "Price";
                dataGridView.Columns[8].HeaderText = "Sales Date";
                dataGridView.Columns[3].Visible = false;
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[5].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].Visible = false;
                dataGridView.Columns[11].Visible = false;
                dataGridView.Columns[12].Visible = false;
                dataGridView.Columns[13].Visible = false;
            }
        }

        private void FrmDeleted_Load(object sender, EventArgs e)
        {
            cmbDeleted.Items.Add("Category");
            cmbDeleted.Items.Add("Customer");
            cmbDeleted.Items.Add("Product");
            cmbDeleted.Items.Add("Sales");
            UpdateData();
        }

        private void cmbDeleted_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbDeleted.SelectedIndex == 0)
            {
                categorydetail.ID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
                categorydetail.CategoryName = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeleted.SelectedIndex == 1)
            {
                customerdetail.ID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
                customerdetail.CustomerName = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            else if (cmbDeleted.SelectedIndex == 2)
            {
                productdetail.ProductID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[4].Value);
                productdetail.CategoryID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[5].Value);
                productdetail.ProductName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                productdetail.Price = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[3].Value);
                productdetail.isCategoryDeleted = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[6].Value);
            }
            else
            {
                salesdetail.SalesID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[10].Value);
                salesdetail.ProductID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[4].Value);
                salesdetail.CustomerName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                salesdetail.ProductName = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                salesdetail.Price = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[7].Value);
                salesdetail.SalesAmount = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[6].Value);
                salesdetail.StockAmount = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[9].Value);
                salesdetail.isCategoryDeleted = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[11].Value);
                salesdetail.isCustomerDeleted = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[12].Value);
                salesdetail.isProductDeleted = Convert.ToBoolean(dataGridView.Rows[e.RowIndex].Cells[13].Value);
            }
        }

        private void btnGetBack_Click(object sender, EventArgs e)
        {
            if (cmbDeleted.SelectedIndex == 0)
            {
                if (categoryBLL.GetBack(categorydetail))
                {
                    MessageBox.Show("Category was Get back");
                    UpdateData();
                }
            }
            else if (cmbDeleted.SelectedIndex == 1)
            {
                if (customerBLL.GetBack(customerdetail))
                {
                    MessageBox.Show("Customer was Get back");
                    UpdateData();
                }
            }
            else if (cmbDeleted.SelectedIndex == 2)
            {
                if (productdetail.isCategoryDeleted)
                    MessageBox.Show("Category was deleted first get back category");
                else if (productBLL.GetBack(productdetail))
                {
                    MessageBox.Show("Product was Get back");
                    UpdateData();
                }
            }
            else
            {
                if (salesdetail.isCategoryDeleted || salesdetail.isCustomerDeleted || salesdetail.isProductDeleted)
                {
                    if (salesdetail.isCategoryDeleted)
                        MessageBox.Show("Category was deleted first get back category");
                    else if (salesdetail.isCustomerDeleted)
                        MessageBox.Show("customer was deleted first get back category");
                    else if (salesdetail.isProductDeleted)
                        MessageBox.Show("Product was deleted first get back category");
                }
                else if (salesBLL.GetBack(salesdetail))
                {
                    MessageBox.Show("Sales was Get back");
                    UpdateData();
                }
            }
        }
    }
}
