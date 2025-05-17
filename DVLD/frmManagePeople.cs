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

            ctrManageData1.LoadTitle("Manage People");
            ctrManageData1.SetContextMenuStrip(cmsPeople);

            _LoadPeopleData();
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

        private void _DeletePersonDialog(int PersonID)
        {
            if (MessageBox.Show("Are you sure you want to delete this person?",
                "Delete a Person", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                == DialogResult.OK)
            {
                if (clsPerson.DeleteByID(PersonID))
                {
                    MessageBox.Show("Person has been deleted Succesfully.");
                    _LoadPeopleData();
                }
                else
                {
                    MessageBox.Show("Could't deleted this Person.");
                }
            }
        }

        private void _ShowPersonDetailsDialog(int PersonID)
        {
            Form frmPersonInfo = new frmPersonDetails(PersonID);
            frmPersonInfo.FormClosed += frmPersonDetails_Closed;
            frmPersonInfo.ShowDialog();
        }
            
        private void _LoadPeopleData()
        {
            DataTable dt = clsPerson.GetAllPersonsInfo();
            ctrManageData1.LoadData(dt);
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

        private void tsmiEditPersonInfo_Click(object sender, EventArgs e)
        {
            int PersonID = GetSelectedPersonID();
            
            if (PersonID != -1)
            {
                _UpdatePersonDialog(PersonID);
            }
            else
            {
                MessageBox.Show("There are no selected rows");
            }
        }

        private void tsmiDeletePerson_Click(object sender, EventArgs e)
        {
            int PersonID = GetSelectedPersonID();

            if (PersonID != -1)
            {
                _DeletePersonDialog(PersonID);
            }
            else
            {
                MessageBox.Show("There are no selected rows");
            }
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            int PersonID = GetSelectedPersonID();

            if (PersonID != -1)
            {
                _ShowPersonDetailsDialog(PersonID);
            }
            else
            {
                MessageBox.Show("There are no selected rows");
            }
        }

        private void frmPersonDetails_Closed(object sender, FormClosedEventArgs e)
        {
            _LoadPeopleData();
        }

    }
}
