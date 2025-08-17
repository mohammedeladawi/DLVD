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
    public partial class ctrFindPersonInfo : UserControl
    {
        private clsPerson _person;
        
        public clsPerson person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
            }
        }
        
        public ctrFindPersonInfo()
        {
            InitializeComponent();
        }

        private void FindPerson()
        {
            // Find Person
            string searchTxt = txtSearch.Text;
            if (cmbFilter.SelectedItem == "NationalNo")
            {
                _person = clsPerson.FindByNationalNo(searchTxt);
            }
            else if (cmbFilter.SelectedItem == "PersonID" && int.TryParse(searchTxt, out int personID))
            {   
                _person = clsPerson.Find(personID);
            }   
        }
        
        private void LoadPersonIntoUIFileds()
        {
            if (_person == null)
                return;
            
            cmbFilter.SelectedItem = "PersonID";
            txtSearch.Text = _person.PersonID.ToString();
            ctrPersonInformation1.LoadPersonInfo(_person.PersonID);

        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {

            FindPerson();
            
            // Show Found Person
            if (_person != null)
            {
                ctrPersonInformation1.LoadPersonInfo(_person.PersonID);
                DisableGbFindPerson();
            }
            else
                MessageBox.Show("Person is not exist");
        }

        private void ctrFindShowPerson_Load(object sender, EventArgs e)
        {
            // Reset
            cmbFilter.SelectedItem = "PersonID";
            txtSearch.Clear();
            ctrPersonInformation1.ResetPersonInfoUI();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddEditPerson = new frmAddEditPerson();
            frmAddEditPerson.DataBack += FrmAddEditPerson_DataBack;
            frmAddEditPerson.ShowDialog();
        }

        private void FrmAddEditPerson_DataBack(object sender, int personID)
        {
            _person = clsPerson.Find(personID);
            LoadPersonIntoUIFileds();
            DisableGbFindPerson();
        }

        public void DisableGbFindPerson()
        {
            gbFindPerson.Enabled = false;
        }
    
        public void LoadPerson(int personID)
        {
            _person = clsPerson.Find(personID);
            
            // Update User
            LoadPersonIntoUIFileds();
            DisableGbFindPerson();
        }
    }
}
