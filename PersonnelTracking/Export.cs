using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System;

namespace PersonnelTracking
{
    public class Export
    {
        internal static void ToExcel(DataGridView dataGridView)
        {
            _Application app = new Microsoft.Office.Interop.Excel.Application();
            _Workbook workbook = app.Workbooks.Add(Type.Missing);
            _Worksheet worksheet = workbook.ActiveSheet;

            app.Visible = true;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
                worksheet.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;

            for (int i = 0; i < dataGridView.Rows.Count; i++)
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                    worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
        }
    }
}
