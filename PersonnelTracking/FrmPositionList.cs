using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using System;

namespace PersonnelTracking
{
    public partial class FrmPositionList : Form
    {
        private List<PositionDTO> positions = new List<PositionDTO>();

        public FrmPositionList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdatePositions()
        {
            positions = PositionBLL.GetPositions();
            dataGridView.DataSource = positions;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Helper.ShowForm(this, new FrmPosition());
            UpdatePositions();
        }

        private void FrmPositionList_Load(object sender, EventArgs e)
        {
            UpdatePositions();
            dataGridView.Columns[1].Visible = false;
            dataGridView.Columns[3].Visible = false;
            dataGridView.Columns[0].HeaderText = "Department Name";
            dataGridView.Columns[2].HeaderText = "Position Name";
        }
    }
}
