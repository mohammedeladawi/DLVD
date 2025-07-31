using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal static class clsErrProviderUtilities
    {
        private static ErrorProvider _errProvider = new ErrorProvider();

        public static void RunEventAndHideErr(TextBox txtBox, CancelEventArgs e)
        {
            e.Cancel = false;
            _errProvider.SetError(txtBox, string.Empty);
        }

        public static void CancelEventAndShowErr(TextBox txtBox, CancelEventArgs e, string message)
        {
            e.Cancel = true;
            txtBox.Focus();
            _errProvider.SetError(txtBox, message);
        }

    }
}
