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
        clsLDLApplication _ldlApplication;
        clsPerson _person;

        public frmAddEditLDLApplication()
        {
            Mode = enMode.AddNew;
            _ldlApplication = new clsLDLApplication();

            InitializeComponent();
        }
        public frmAddEditLDLApplication(int ldlApplicationID)
        {
            Mode = enMode.Update;
            _ldlApplication = clsLDLApplication.FindByID(ldlApplicationID);

            InitializeComponent();
        }
        private void HandleSelectTpApplicationInfo(TabControlCancelEventArgs e)
        {
            _person = ctrFindShowPerson1.person;

            if (_person == null)
            {
                e.Cancel = true;
                MessageBox.Show("Please add/find person first");
            }
            else
            {
                tcLDLApplication.SelectedTab = tpApplicationInfo;
                ctrNextBtn1.Visible = false;
                ctrSaveBtn1.Enabled = true;

            }
        }
        private void ctrNextBtn1_Click(object sender, EventArgs e)
        {
            tcLDLApplication.SelectedTab = tpApplicationInfo;
        }
        private void DefaultTapInitialization()
        {
            ctrNextBtn1.Visible = true;
            ctrSaveBtn1.Enabled = false;
        }
        private void tcLDLApplication_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tcLDLApplication.SelectedTab == tpApplicationInfo)
                HandleSelectTpApplicationInfo(e);
            else if (tcLDLApplication.SelectedTab == tpPersonInfo)
                DefaultTapInitialization();
        }

        private void SetFrmAddDataIntoUIFields()
        {
            DateTime applicationDate = _ldlApplication.Application.ApplicationDate;
            decimal applicationTypeFees = _ldlApplication.Application.ApplicationType.Fees;

            lblApplicationDate.Text = applicationDate.ToShortDateString();
            lblApplicationFees.Text = "$" + applicationTypeFees.ToString();
            lblCreatedBy.Text = clsGlobal.currentUser.UserName.ToString();
        }


        private void SetFrmUpdateDataIntoUIFields()
        {
            // disable addnew, find person buttons
            ctrFindShowPerson1.DisableGbFindPerson();


            ctrFindShowPerson1.person = _ldlApplication.Application.Person;
            SetFrmAddDataIntoUIFields();

            // Application Info Tap
            int createdByUserID = _ldlApplication.Application.CreatedByUserID;
            lblDLApplicationID.Text = _ldlApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _ldlApplication.Application.ApplicationDate.ToString();
            cbLicenseClasses.SelectedValue = _ldlApplication.LicenseClassID;
            lblApplicationFees.Text = _ldlApplication.Application.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindByID(createdByUserID).UserName;
        }
        private void SetFrmAddUpdateFields()
        {
            if (Mode == enMode.AddNew)
            {
                lblLDLApplicationTitle.Text = "New Local Driving License Application";
                SetFrmAddDataIntoUIFields();
            }
            else if (Mode == enMode.Update)
            {
                lblLDLApplicationTitle.Text = "Update Local Driving License Application";
                SetFrmUpdateDataIntoUIFields();
            }
        }

        private void cbLicenseClassesInitialization()
        {
            Dictionary<int, string> licenseClassesMap = clsLicenseClass.getClassesIDName();

            cbLicenseClasses.DataSource = new BindingSource(licenseClassesMap, null);
            cbLicenseClasses.DisplayMember = "Value";
            cbLicenseClasses.ValueMember = "Key";
        }
       
        private void frmAddEditLDLApplication_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
            cbLicenseClassesInitialization(); 
            SetFrmAddUpdateFields();
        }

        private void AddFieldsDataToLDLApplication()
        {
            int classID = ((KeyValuePair<int, string>)cbLicenseClasses.SelectedItem).Key;
            _ldlApplication.LicenseClassID = classID;
            _ldlApplication.Application.ApplicationPersonID = _person.PersonID;
            _ldlApplication.Application.ApplicationDate = DateTime.Now;
            _ldlApplication.Application.PaidFees = _ldlApplication.Application.ApplicationType.Fees;
            _ldlApplication.Application.CreatedByUserID = clsGlobal.currentUser.UserID;
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            AddFieldsDataToLDLApplication();

            if (_ldlApplication.Save())
            {
                Mode = enMode.Update;
                SetFrmAddUpdateFields();
                MessageBox.Show("Application Has Been Added/Updated Succesfully");
            }
            else
            {
                MessageBox.Show("Can't Add/Update Application");
            }

        }


    }
}
