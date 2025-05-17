using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrDataView: UserControl
    {
        public DataGridView dgvManageDate1
        {
            get { return dgvManageData; }
            
        }
        public ctrDataView()
        {
            InitializeComponent();
        }

        public void SetContextMenuStrip(ContextMenuStrip cms)
        {
            dgvManageData.ContextMenuStrip = cms;
        }
        public void LoadDataInDgvManageData(DataTable dt)
        {
            dgvManageData.DataSource = dt;
            lblNumOfRecords.Text = dt.Rows.Count.ToString();
        }

    }
}
