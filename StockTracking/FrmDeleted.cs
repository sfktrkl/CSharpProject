﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockTracking
{
    public partial class FrmDeleted : Form
    {
        public FrmDeleted()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDeleted_Load(object sender, EventArgs e)
        {
            cmbDeleted.Items.Add("Category");
            cmbDeleted.Items.Add("Product");
            cmbDeleted.Items.Add("Customer");
            cmbDeleted.Items.Add("Sales");
        }
    }
}
