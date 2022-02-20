using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System.Windows.Forms;
using StockTracking.BLL;
using System.Linq;
using System;

namespace StockTracking
{
    public partial class FrmAddStock : Form
    {
        private readonly ProductDetailDTO detail = new ProductDetailDTO();
        private readonly ProductBLL bll = new ProductBLL();
        private ProductDTO dto = new ProductDTO();

        public FrmAddStock()
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

        private void FrmAddStock_Load(object sender, EventArgs e)
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

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<ProductDetailDTO> list = dto.Products;
            list = list.Where(x => x.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            dataGridView.DataSource = list;
            if (list.Count == 0)
            {
                txtPrice.Clear();
                txtProductName.Clear();
                txtStock.Clear();
            }
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ProductName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtProductName.Text = detail.ProductName;
            detail.Price = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[3].Value);
            txtPrice.Text = detail.Price.ToString();
            detail.StockAmount = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[2].Value);
            detail.ProductID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[4].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Please select a product from table");
            else if (txtStock.Text.Trim() == "")
                MessageBox.Show("Please give a stock amount");
            else
            {
                detail.StockAmount = Convert.ToInt32(txtStock.Text) + detail.StockAmount;
                if (bll.Update(detail))
                {
                    MessageBox.Show("Stock was added");
                    txtStock.Clear();
                    UpdateProducts();
                }
            }
        }
    }
}
