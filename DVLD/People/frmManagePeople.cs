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

        private void AddNewPersonDialog()
        {
            Form frmAddPerson = new frmAddEditPerson();
            frmAddPerson.FormClosed += frmAddEditPerson_Closed;
            frmAddPerson.ShowDialog();
        }

        private void UpdatePersonDialog(int PersonID)
        {
            Form frmAddPerson = new frmAddEditPerson(PersonID);
            frmAddPerson.FormClosed += frmAddEditPerson_Closed;
            frmAddPerson.ShowDialog();
        }

        private void DeletePersonDialog(int PersonID)
        {
            if (MessageBox.Show("Are you sure you want to delete this person?",
                "Delete a Person", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                if (clsPerson.DeleteByID(PersonID))
                {
                    MessageBox.Show("Person has been deleted Succesfully.");
                    ReloadPeopleData();
                }
                else
                {
                    MessageBox.Show("Could't deleted this Person.");
                }
            }
        }

        private void PersonDetailsDialog(int PersonID)
        {
            Form frmPersonInfo = new frmPersonDetails(PersonID);
            frmPersonInfo.FormClosed += frmPersonDetails_Closed;
            frmPersonInfo.ShowDialog();
        }

        private void ReloadPeopleData()
        {
            DataTable dt = clsPerson.GetAllPersonsInfo();
            ctrManageData1.LoadData(dt);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            AddNewPersonDialog();
        }

        private void frmAddEditPerson_Closed(object sender, FormClosedEventArgs e)
        {
            ReloadPeopleData();
        }

        private void tsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            AddNewPersonDialog();
        }

        private int GetSelectedPersonID()
        {
            DataGridView dgvPeople = ctrManageData1.dgvManageDate1;
            int PersonID = -1;

            if (dgvPeople.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPeople.SelectedRows[0];
                PersonID = Convert.ToInt32(row.Cells["PersonID"].Value);
            }

            return PersonID;
        }

        private bool TryGetSelectedPersonID(out int personID)
        {
            personID = GetSelectedPersonID();
            if (personID == -1)
            {
                MessageBox.Show("There are no selected rows");
                return false;
            }
            return true;
        }

        private void tsmiEditPersonInfo_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedPersonID(out int personID))
                UpdatePersonDialog(personID);
        }

        private void tsmiDeletePerson_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedPersonID(out int personID))
                DeletePersonDialog(personID);
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            if (TryGetSelectedPersonID(out int personID))
                PersonDetailsDialog(personID);
        }

        private void frmPersonDetails_Closed(object sender, FormClosedEventArgs e)
        {
            ReloadPeopleData();
        }

        private void ctrManageData1_Load(object sender, EventArgs e)
        {

            ctrManageData1.LoadTitle("Manage People");
            ctrManageData1.LoadContextMenuStrip(cmsPeople);

            DataTable dt = clsPerson.GetAllPersonsInfo();
            ctrManageData1.LoadData(dt);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            AddNewPersonDialog();
        }
    }
}
