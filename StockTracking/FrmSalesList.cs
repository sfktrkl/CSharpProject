using System.Collections.Generic;
using StockTracking.DAL.DTO;
using System.Windows.Forms;
using StockTracking.BLL;
using System.Linq;
using System;

namespace StockTracking
{
    public partial class FrmSalesList : Form
    {
        private SalesDTO dto = new SalesDTO();
        private readonly SalesBLL bll = new SalesBLL();
        private readonly SalesDetailDTO detail = new SalesDetailDTO();

        public FrmSalesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateSales()
        {
            dto = bll.Select();
            dataGridView.DataSource = dto.Sales;
            cmbCategory.DataSource = dto.Categories;
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtProductName.Clear();
            txtSales.Clear();
            rbPriceEquals.Checked = false;
            rbPriceLess.Checked = false;
            rbPriceMore.Checked = false;
            rbSalesEquals.Checked = false;
            rbSalesLess.Checked = false;
            rbSalesMore.Checked = false;
            dtbStart.Value = DateTime.Today;
            dtbEnd.Value = DateTime.Today;
            chkDate.Checked = false;
            cmbCategory.SelectedIndex = -1;
            dataGridView.DataSource = dto.Sales;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmSales(dto));
            UpdateSales();
            CleanFilters();
        }

        private void FrmSalesList_Load(object sender, EventArgs e)
        {
            UpdateSales();
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

            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.Sales;
            if (txtProductName.Text.Trim() != "")
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
            if (txtSales.Text.Trim() != "")
            {
                if (rbSalesEquals.Checked)
                    list = list.Where(x => x.SalesAmount == Convert.ToInt32(txtSales.Text)).ToList();
                else if (rbSalesMore.Checked)
                    list = list.Where(x => x.SalesAmount > Convert.ToInt32(txtSales.Text)).ToList();
                else if (rbSalesLess.Checked)
                    list = list.Where(x => x.SalesAmount < Convert.ToInt32(txtSales.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterion from Sale amount group");
            }
            if (chkDate.Checked)
                list = list.Where(x => x.SalesDate > dtbStart.Value && x.SalesDate < dtbEnd.Value).ToList();
            dataGridView.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.SalesID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[10].Value);
            detail.ProductID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[4].Value);
            detail.CustomerName = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            detail.ProductName = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            detail.Price = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[7].Value);
            detail.SalesAmount = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[6].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.SalesID == 0)
                MessageBox.Show("Please select asales from table");
            else
            {
                Helper.ShowForm(this, new FrmSales(dto, detail));
                UpdateSales();
                CleanFilters();
            }
        }
    }
}
