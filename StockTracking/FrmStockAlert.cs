using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System.Windows.Forms;
using StockTracking.BLL;
using System.Linq;
using System;


namespace StockTracking
{
    public partial class FrmStockAlert : Form
    {
        private readonly ProductBLL bll = new ProductBLL();
        private ProductDTO dto = new ProductDTO();

        public FrmStockAlert()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FrmMain().ShowDialog();
        }

        private void UpdateProducts()
        {
            dto = bll.Select();
            dataGridView.DataSource = dto.Products.Where(x => x.StockAmount < 10).ToList();
        }

        private void FrmStockAlert_Load(object sender, EventArgs e)
        {
            UpdateProducts();
            dataGridView.Columns[0].HeaderText = "Product Name";
            dataGridView.Columns[1].HeaderText = "Category Name";
            dataGridView.Columns[2].HeaderText = "Stock Amount";
            dataGridView.Columns[3].HeaderText = "Price";
            dataGridView.Columns[4].Visible = false;
            dataGridView.Columns[5].Visible = false;
        }
    }
}
