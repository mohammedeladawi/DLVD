using DVLD.Global_Classes;
using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace DVLD
{
    public partial class frmAddEditLDLApplication : Form
    {
        private enum enMode { AddNew, Update };
        private enMode Mode;

        clsApplicationType _applicationTypeInfo = clsApplicationType.Find(
                (int)clsApplicationType.enApplicationTypes.NewLocalDrivingLicenseService);
        clsLDLApplication _ldlApplication;
        clsPerson _person;

        public frmAddEditLDLApplication()
        {
            InitializeComponent();
            
            _ldlApplication = new clsLDLApplication();
            Mode = enMode.AddNew;
        }
       
        public frmAddEditLDLApplication(int ldlApplicationID)
        {
            InitializeComponent();

            _ldlApplication = clsLDLApplication.FindByLDLApplicationID(ldlApplicationID);
            Mode = enMode.Update;
        }
        
        private void HandleSelectTpApplicationInfo(TabControlCancelEventArgs e)
        {
            _person = ctrFindShowPerson1.person;

            if (_person == null)
            {
                e.Cancel = true;
                MessageBox.Show("Please add a person first");
            }
            else
            {
                //tcLDLApplication.SelectedTab = tpApplicationInfo;
                ctrNextBtn1.Visible = false;
                ctrSaveBtn1.Enabled = true;

            }
        }
        private void ctrNextBtn1_Click(object sender, EventArgs e)
        {
            tcLDLApplication.SelectedTab = tpApplicationInfo;
        }
        private void ResetButtons()
        {
            ctrNextBtn1.Visible = true;
            ctrSaveBtn1.Enabled = false;
        }
        private void tcLDLApplication_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tcLDLApplication.SelectedTab == tpApplicationInfo) // tap 2
                HandleSelectTpApplicationInfo(e);
            else if (tcLDLApplication.SelectedTab == tpPersonInfo) // tap 1
                ResetButtons();
        }
        
        private void ResetForm()
        {
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblApplicationFees.Text = "$" + _applicationTypeInfo.Fees.ToString();
            lblCreatedBy.Text = clsGlobal.currentUser.UserName.ToString();
            ResetButtons();
        }

        private void LoadApplicationIntoUIFields()
        {
            if (_ldlApplication != null)
            {
                ctrFindShowPerson1.LoadPerson(_ldlApplication.ApplicationPersonID);

                // Application Info Tap
                lblDLApplicationID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
                lblApplicationDate.Text = _ldlApplication.ApplicationDate.ToString();
                cbLicenseClasses.SelectedValue = _ldlApplication.LicenseClassID;
                lblApplicationFees.Text = _ldlApplication.PaidFees.ToString();
                lblCreatedBy.Text = _ldlApplication.CreatedByUserInfo.UserName.ToString();
            }
            else
            {
                MessageBox.Show("Couldn't load local driving license data");
            }
        }

        private void LoadAllLicenseClassesIntoComboBox()
        {
            Dictionary<int, string> licenseClassesMap = clsLicenseClass.GetClassesIDName();

            cbLicenseClasses.DataSource = new BindingSource(licenseClassesMap, null);
            cbLicenseClasses.DisplayMember = "Value";
            cbLicenseClasses.ValueMember = "Key";
        }
       
        private void frmAddEditLDLApplication_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            LoadAllLicenseClassesIntoComboBox();
           
            if (Mode == enMode.AddNew)
            {
                lblLDLApplicationTitle.Text = "New Local Driving License Application";
                ResetForm();
            }
            else if (Mode == enMode.Update)
            {
                lblLDLApplicationTitle.Text = "Update Local Driving License Application";
                LoadApplicationIntoUIFields();
            }
        }

        private void LoadUIFieldsIntoLDLApplication()
        {
            int classID = ((KeyValuePair<int, string>)cbLicenseClasses.SelectedItem).Key;
            _ldlApplication.LicenseClassID = classID;
            if (Mode == enMode.AddNew)
            {
                _ldlApplication.ApplicationTypeID = _applicationTypeInfo.ApplicationTypeID;
                _ldlApplication.ApplicationPersonID = _person.PersonID;
                _ldlApplication.ApplicationDate = DateTime.Now;
                _ldlApplication.PaidFees = _applicationTypeInfo.Fees;
                _ldlApplication.CreatedByUserID = clsGlobal.currentUser.UserID;
            }
        }

        private bool IsAllowedAge()
        {
            int selectedLicenseClassID = ((KeyValuePair<int, string>)cbLicenseClasses.SelectedItem).Key;
            int minAllowedAge = clsLicenseClass.Find(selectedLicenseClassID).MinmumAllowedAge;

            if (!clsUtil.IsAllowedAge(_person.DateOfBirth, minAllowedAge))
            {
                MessageBox.Show("Person age is not allowed for this license class");
                return false ;
            }

            return true;
        }

        private bool IsApplicationExist()
        {
            int selectedLicenseClassID = ((KeyValuePair<int, string>)cbLicenseClasses.SelectedItem).Key;
            if (clsLDLApplication.IsAlreadyExist(_person.PersonID, selectedLicenseClassID))
            {
                MessageBox.Show("This person already has an active or completed application for this license class");
                return true;
            }
            return false;
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            if (!IsAllowedAge() ||
                (Mode == enMode.AddNew && IsApplicationExist()))
                return;

            LoadUIFieldsIntoLDLApplication();
            if (_ldlApplication.Save())
            {
                MessageBox.Show($"Application has been {(Mode == enMode.AddNew ? "added" : "updated")} succesfully");
                this.Close();
            }
            else
            {
                MessageBox.Show($"Couldn't {(Mode == enMode.AddNew ? "add" : "update")} the application");
            }

        }


    }
}
