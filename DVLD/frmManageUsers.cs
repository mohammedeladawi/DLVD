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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void ShowUserDetailsDialog(int userID)
        {
            frmUserDetails userDialog = new frmUserDetails(userID);
            userDialog.ShowDialog();
        }

        private int GetSelectedUserID()
        {
            DataGridView dgvUsers = ctrManageData1.dgvManageDate1;
            int UserID = -1;

            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsers.SelectedRows[0];
                UserID = Convert.ToInt32(row.Cells["UserID"].Value);
            }

            return UserID;
        }
       
        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            ctrManageData1.LoadLogoImgAndTitle("", "Manage Users");
            ctrManageData1.LoadData(clsUser.GetAllUsersData());
            ctrManageData1.SetContextMenuStrip(cmsUsers);
        }

        private void tsmiShowUserDetails_Click(object sender, EventArgs e)
        {
            int userID = GetSelectedUserID();

            if (userID != -1)
            {
                ShowUserDetailsDialog(userID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }    

        }
    }
}
