using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using System;

namespace StockTracking
{
    public partial class FrmProduct : Form
    {
        private readonly bool isUpdate;
        private readonly ProductDetailDTO detail;
        private readonly ProductBLL bll = new ProductBLL();
        private ProductDTO dto = new ProductDTO();

        public FrmProduct(ProductDTO dto)
        {
            InitializeComponent();
            this.dto = dto;
        }

        public FrmProduct(ProductDTO dto, ProductDetailDTO detail)
        {
            InitializeComponent();
            this.isUpdate = true;
            this.detail = detail;
            this.dto = dto;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateCategories()
        {
            dto = bll.Select();
            cmbCategory.DataSource = dto.Categories;
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            UpdateCategories();
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
            if (isUpdate)
            {
                txtProductName.Text = detail.ProductName;
                txtPrice.Text = detail.Price.ToString();
                cmbCategory.SelectedValue = detail.CategoryID;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProductName.Text.Trim() == "")
                MessageBox.Show("Product Name is Empty");
            else if (cmbCategory.SelectedIndex == -1)
                MessageBox.Show("Please select a category");
            else if (txtPrice.Text.Trim() == "")
                MessageBox.Show("Price is empty");
            else
            {
                if (!isUpdate)
                {
                    ProductDetailDTO product = new ProductDetailDTO
                    {
                        ProductName = txtProductName.Text,
                        CategoryID = Convert.ToInt32(cmbCategory.SelectedValue),
                        Price = Convert.ToInt32(txtPrice.Text)
                    };
                    if (bll.Insert(product))
                    {
                        MessageBox.Show("Product was added");
                        txtPrice.Clear();
                        txtProductName.Clear();
                        cmbCategory.SelectedIndex = -1;
                    }
                }
                else
                {
                    if (detail.ProductName == txtProductName.Text &&
                        detail.CategoryID == Convert.ToInt32(cmbCategory.SelectedValue) &&
                        detail.Price == Convert.ToInt32(txtPrice.Text))
                        MessageBox.Show("There is no change");
                    else
                    {
                        detail.ProductName = txtProductName.Text;
                        detail.CategoryID = Convert.ToInt32(cmbCategory.SelectedValue);
                        detail.Price = Convert.ToInt32(txtPrice.Text);
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Product wa Updated");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
