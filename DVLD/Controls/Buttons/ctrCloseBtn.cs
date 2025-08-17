using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrCloseBtn : UserControl
    {
        public ctrCloseBtn()
        {
            InitializeComponent();
        }

        private void ctrCloseBtn_MouseClick(object sender, MouseEventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }
    }
}
