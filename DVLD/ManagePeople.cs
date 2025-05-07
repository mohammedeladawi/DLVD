using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _AddNewPersonDialog()
        {
            Form frmAddPerson = new frmAddEditPerson();
            frmAddPerson.FormClosed += frmAddEditPerson_Closed;
            frmAddPerson.ShowDialog();
        }

        private void _UpdatePersonDialog(int PersonID)
        {
            Form frmAddPerson = new frmAddEditPerson(PersonID);
            frmAddPerson.FormClosed += frmAddEditPerson_Closed;
            frmAddPerson.ShowDialog();
        }

        private void _LoadPeopleData()
        {
            DataTable dt = clsPerson.GetAllPersonsInfo();
            ctrManageData1.LoadData(dt);
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {

            string mainLogoUrl = @"C:\Users\mazik\Desktop\19. Full Real Project\03. DVLD Project\DVLD\assets\images\team-management.png";
            ctrManageData1.LoadLogoImgAndTitle(mainLogoUrl, "Manage People");
            ctrManageData1.SetContextMenuStrip(cmsPeople);

            _LoadPeopleData();
            
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewPersonDialog();
        }

        private void frmAddEditPerson_Closed(object sender, FormClosedEventArgs e)
        {
            _LoadPeopleData();
        }

        private void tsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewPersonDialog();
        }

        private void tsmiEditPersonInfo_Click(object sender, EventArgs e)
        {
            DataGridView dgvPeople = ctrManageData1.dgvManageDate1;
            if (dgvPeople.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPeople.SelectedRows[0];
                int PersonID = Convert.ToInt32(row.Cells["PersonID"].Value);
                _UpdatePersonDialog(PersonID);                
            }
            else
            {
                MessageBox.Show("There are no selected rows");
            }
        }
    }
}
