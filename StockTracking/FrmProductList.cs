using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System.Windows.Forms;
using StockTracking.BLL;
using System.Linq;
using System;

namespace StockTracking
{
    public partial class FrmProductList : Form
    {
        private ProductDTO dto = new ProductDTO();
        private readonly ProductBLL bll = new ProductBLL();
        private readonly ProductDetailDTO detail = new ProductDetailDTO();

        public FrmProductList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateProducts()
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
            dataGridView.DataSource = dto.Products;
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            txtStock.Clear();
            cmbCategory.SelectedIndex = -1;
            rbPriceEquals.Checked = false;
            rbPriceLess.Checked = false;
            rbPriceMore.Checked = false;
            rbStockEquals.Checked = false;
            rbStockLess.Checked = false;
            rbStockMore.Checked = false;
            dataGridView.DataSource = dto.Products;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmProduct(dto));
            UpdateProducts();
            CleanFilters();
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            UpdateProducts();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;

            dataGridView.Columns[0].HeaderText = "Product Name";
            dataGridView.Columns[1].HeaderText = "Category Name";
            dataGridView.Columns[2].HeaderText = "Stock Amount";
            dataGridView.Columns[3].HeaderText = "Price";
            dataGridView.Columns[4].Visible = false;
            dataGridView.Columns[5].Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.Products;
            if (txtProductName.Text.Trim() != null)
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            if (cmbCategory.SelectedIndex != -1)
                list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            if (txtPrice.Text.Trim() != "")
            {
                if (rbPriceEquals.Checked)
                    list = list.Where(x => x.Price == Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbPriceMore.Checked)
                    list = list.Where(x => x.Price > Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbPriceLess.Checked)
                    list = list.Where(x => x.Price < Convert.ToInt32(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion from price group");
            }
            if (txtStock.Text.Trim() != "")
            {
                if (rbStockEquals.Checked)
                    list = list.Where(x => x.StockAmount == Convert.ToInt32(txtStock.Text)).ToList();
                else if (rbStockMore.Checked)
                    list = list.Where(x => x.StockAmount > Convert.ToInt32(txtStock.Text)).ToList();
                else if (rbStockLess.Checked)
                    list = list.Where(x => x.StockAmount < Convert.ToInt32(txtStock.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion from Stock group");
            }
            dataGridView.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[4].Value);
            detail.CategoryID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[5].Value);
            detail.ProductName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.Price = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[3].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Please select a product from table");
            else
            {
                Helper.ShowForm(this, new FrmProduct(dto, detail));
                UpdateProducts();
                CleanFilters();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (detail.ProductID == 0)
                MessageBox.Show("Please select a product from table");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Warning!!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (bll.Delete(detail))
                    {
                        MessageBox.Show("Product was Deleted");
                        UpdateProducts();
                        CleanFilters();
                    }
                }
            }
        }
    }
}
