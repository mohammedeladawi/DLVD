using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmManageLDLApplications : Form
    {
        public frmManageLDLApplications()
        {
            InitializeComponent();
        }

        private int GetSelectedLDLApplicationID()
        {
            DataGridView dgvLDLApplication = ctrManageData1.dgvManageDate1;
            int ldlApplicationID = -1;

            if (dgvLDLApplication.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvLDLApplication.SelectedRows[0];
                ldlApplicationID = Convert.ToInt32(row.Cells["L.D.L. AppID"].Value);
            }

            return ldlApplicationID;
        }

        private void frmManageLDLApplications_Load(object sender, EventArgs e)
        {
            ctrManageData1.LoadTitle("Local Driving License Applications");
            ctrManageData1.LoadData(clsLDLApplication.GetAllApplications());
            ctrManageData1.SetContextMenuStrip(cmsManageLDLApplications);
        }

        private void ReloadApplicationData()
        {
            ctrManageData1.LoadData(clsLDLApplication.GetAllApplications());
        }

        private void ShowDeleteApplicationDialog(int ldlApplicationID)
        {
            if (MessageBox.Show("Are you sure you want to cancel this application?",
                   "Cancel Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                   == DialogResult.OK)
            {
                if (clsLDLApplication.Cancel(ldlApplicationID))
                {
                    MessageBox.Show("Application has been canceled succesfully.");
                    ReloadApplicationData();
                }
                else
                {
                    MessageBox.Show("Could't cancel this application.");
                }
            }
        }
      
        private void tsmiCancelApplication_Click(object sender, EventArgs e)
        {
            int ldlApplicationID = GetSelectedLDLApplicationID();

            if (ldlApplicationID != -1)
            {
                ShowDeleteApplicationDialog(ldlApplicationID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }
        }

        private void tsmiAddNewLDLApplication_Click(object sender, EventArgs e)
        {
            Form addUpdateLDLApplication = new frmAddEditLDLApplication();
            addUpdateLDLApplication.FormClosed += frm_Closed;
            addUpdateLDLApplication.ShowDialog();
        }

        private void frm_Closed(object sender, FormClosedEventArgs e)
        {
            ReloadApplicationData();
        }
    }
}
