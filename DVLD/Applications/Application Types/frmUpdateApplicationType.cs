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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class frmUpdateApplicationType : Form
    {
        private clsApplicationType _applicationType;
        public frmUpdateApplicationType(int applicationTypeID)
        {
            InitializeComponent();
            _applicationType = clsApplicationType.Find(applicationTypeID);
        }

        
        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            if (_applicationType == null)
            {
                MessageBox.Show("Application type is not exist", 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadApplicationTypeIntoUIFields();
        }

        private void LoadApplicationTypeIntoUIFields()
        {
            lblApplicationTypeID.Text = _applicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _applicationType.Title;
            txtFees.Text = _applicationType.Fees.ToString();
        }

        private void LoadUIFieldsIntoApplicationType()
        {
            _applicationType.Title = txtTitle.Text;
            _applicationType.Fees = Convert.ToDecimal(txtFees.Text);
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            LoadUIFieldsIntoApplicationType();
            
            if (_applicationType.Save())
                MessageBox.Show("Application type has been updated successfully");
            else
                MessageBox.Show("Couldn't update application type");
        }
    }
}
