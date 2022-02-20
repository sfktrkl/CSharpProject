using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using System;

namespace StockTracking
{
    public partial class FrmCategory : Form
    {
        private readonly CategoryBLL bll = new CategoryBLL();

        public FrmCategory()
        {
            InitializeComponent();
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
        }
    }
}
