using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using System;

namespace StockTracking
{
    public partial class FrmCategory : Form
    {
        private readonly bool isUpdate;
        private readonly CategoryDetailDTO detail;
        private readonly CategoryBLL bll = new CategoryBLL();

        public FrmCategory()
        {
            InitializeComponent();
        }

        public FrmCategory(CategoryDetailDTO detail)
        {
            InitializeComponent();
            this.isUpdate = true;
            this.detail = detail;
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtCategoryName.Text = detail.CategoryName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Trim() == "")
                MessageBox.Show("Empty");
            else
            {
                if (!isUpdate)
                {
                    CategoryDetailDTO category = new CategoryDetailDTO()
                    {
                        CategoryName = txtCategoryName.Text
                    };
                    if (bll.Insert(category))
                    {
                        MessageBox.Show("Added");
                        txtCategoryName.Clear();
                    }
                }
                else
                {
                    if (detail.CategoryName == txtCategoryName.Text.Trim())
                        MessageBox.Show("There is No change");
                    else
                    {
                        detail.CategoryName = txtCategoryName.Text;
                        if (bll.Update(detail))
                        {
                            MessageBox.Show("Category was Updated");
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
