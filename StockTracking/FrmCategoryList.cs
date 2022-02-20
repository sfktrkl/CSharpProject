using System.Windows.Forms;
using StockTracking.DAL.DTO;
using StockTracking.BLL;
using System.Linq;
using System;

namespace StockTracking
{
    public partial class FrmCategoryList : Form
    {
        private CategoryDTO dto = new CategoryDTO();
        private readonly CategoryBLL bll = new CategoryBLL();

        public FrmCategoryList()
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
            dataGridView.DataSource = dto.Categories;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmCategory());
            UpdateCategories();
        }

        private void FrmCategoryList_Load(object sender, EventArgs e)
        {
            UpdateCategories();
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].HeaderText = "Category Name";
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            var list = dto.Categories;
            list = list.Where(x => x.CategoryName.Contains(txtCategoryName.Text)).ToList();
            dataGridView.DataSource = list;
        }
    }
}
