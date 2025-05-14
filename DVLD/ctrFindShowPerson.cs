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
    public partial class ctrFindShowPerson : UserControl
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
                // Update User
                SetFindShowPersonFields();

            }
        }
        
        public ctrFindShowPerson()
        {
            InitializeComponent();
        }
        public ctrFindShowPerson(clsPerson person)
        {
            this.person = person;
            InitializeComponent();
        }

        private void FindPerson()
        {
            // Find Person
            string searchTxt = txtSearch.Text;
            if (cmbFilter.SelectedItem == "NationalNo")
            {
                person = clsPerson.FindByNationalNo(searchTxt);
            }
            else if (cmbFilter.SelectedItem == "PersonID" && int.TryParse(searchTxt, out int personId))
            {   
                person = clsPerson.FindByID(personId);
            }   
        }
        
        private void SetFindShowPersonFields()
        {
            if (person == null)
                return;
            
            cmbFilter.SelectedItem = "PersonID";
            txtSearch.Text = person.PersonId.ToString();
            ctrPersonInformation1.LoadPersonInfo(person);

        }
        
        private void btnFind_Click(object sender, EventArgs e)
        {

            FindPerson();
            
            // Show Found Person
            if (person != null)
                ctrPersonInformation1.LoadPersonInfo(person);
            else
                MessageBox.Show("Person is not exist");
        }

        private void ctrFindShowPerson_Load(object sender, EventArgs e)
        {
            // Initialize cmbFilter
            cmbFilter.SelectedItem = "PersonID";
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddEditPerson = new frmAddEditPerson();
            frmAddEditPerson.DataBack += FrmAddEditPerson_DataBack;
            frmAddEditPerson.ShowDialog();
        }

        private void FrmAddEditPerson_DataBack(object sender, clsPerson person)
        {
            this.person = person;
            SetFindShowPersonFields();
        }
    }
}
