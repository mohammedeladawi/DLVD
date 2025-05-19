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

        private void frmUpdateApplicationTypes_Load(object sender, EventArgs e)
        {
            AddApplicationTypeDataToFields();
        }

        public frmUpdateApplicationType(int applicationTypeID)
        {
            _applicationType = clsApplicationType.Find(applicationTypeID);
            InitializeComponent();
        }

        public void AddApplicationTypeDataToFields()
        {
            if (_applicationType == null)
                return;

            lblApplicationTypeID.Text = _applicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _applicationType.Title;
            txtFees.Text = _applicationType.Fees.ToString();
        }

        public void AddFieldsDataToApplicationType()
        {
            if (_applicationType == null)
                return;

            _applicationType.Title = txtTitle.Text;
            _applicationType.Fees = Convert.ToDecimal(txtFees.Text);
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            AddFieldsDataToApplicationType();
            if (_applicationType.Save())
            {
                MessageBox.Show("Application Type Has Been Updated Successfully");
            }
            else
            {
                MessageBox.Show("Failed To Update Application Type");
            }
        }
    }
}
