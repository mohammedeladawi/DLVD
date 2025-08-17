using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class ctrFindDLicenseInfo: UserControl
    {
        public GroupBox gbFilterLicense 
        { 
            get { return gbFilter; } 
            set { gbFilter = value; } 
        }

        public string txtSearchText
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }

        public Button btnFindLicense
        {
            get { return btnFind; }
        }
        // Define a custom event handler delegate with parameters (Event Decleration)
        public event Action<int> onLocalLicenseInfoLoaded;

        // Create a protected method to raise the event with a parameter (Fire Decleration)
        protected virtual void LocalLicenseInfoLoaded(int licenseID)
        {
            Action<int> handler = onLocalLicenseInfoLoaded;

            if (handler != null)
            {
                handler(licenseID); // Raise the event with a parameter
            }
        }
        
        public ctrFindDLicenseInfo()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearch.Text, out int licenseID))
            {
                ctrDriverLicenseInfo1.LoadInfo(licenseID);

                if (ctrDriverLicenseInfo1.HasLicenseFound && onLocalLicenseInfoLoaded != null) 
                    LocalLicenseInfoLoaded(licenseID);
                
            }
            
        }
    
        public void DisableFilter()
        {
            gbFilter.Enabled = false;
        }
        
        public void ResetForm()
        {
            ctrDriverLicenseInfo1.ResetForm();
        }
    }
}
