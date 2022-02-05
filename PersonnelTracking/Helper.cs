using System.Windows.Forms;

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
    }
}
