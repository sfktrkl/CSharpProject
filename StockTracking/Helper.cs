using System.Windows.Forms;
using System;

namespace StockTracking
{
    class Helper
    {
        public static void ShowForm(Form parent, Form form)
        {
            parent.Hide();
            form.ShowDialog();
            parent.Visible = true;
        }
    }
}
