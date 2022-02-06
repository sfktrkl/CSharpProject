using System.Windows.Forms;
using System;

namespace PersonnelTracking
{
    class Helper
    {
        public static bool IsNumber(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                return true;
            return false;
        }

        public static void ShowForm(Form parent, Form form)
        {
            parent.Hide();
            form.ShowDialog();
            parent.Visible = true;
        }
    }
}
