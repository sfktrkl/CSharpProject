using DataAccessLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataAccessLayer;
using System.Linq;
using System;

namespace PersonnelTracking
{
    public partial class FrmPositionList : Form
    {
        private PositionDTO detail = new PositionDTO();

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

        private void dataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detail.ID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[1].Value);
            detail.Name = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            detail.DepartmentID = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[3].Value);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (detail.ID == 0)
                MessageBox.Show("Please select a position from table");
            else
            {
                FrmPosition frm = new FrmPosition();
                frm.isUpdate = true;
                frm.detail = detail;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                UpdatePositions();
            }
        }
    }
}
