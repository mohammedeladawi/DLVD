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
    public partial class frmUpdateTestType: Form
    {
        clsTestType _testType;
        public frmUpdateTestType(int testID)
        {
            InitializeComponent();
            _testType = clsTestType.Find(testID);
        }

        public void LoadTestTypeIntoUIFields()
        {
            lblTestID.Text = _testType.TestTypeID.ToString();
            txtTitle.Text = _testType.Title;
            txtDescription.Text = _testType.Description;
            txtFees.Text = _testType.Fees.ToString();
        }

        public void LoadUIFieldsIntoTestType()
        {
            _testType.Title = txtTitle.Text;
            _testType.Description = txtDescription.Text;
            _testType.Fees = Convert.ToDecimal(txtFees.Text);
        }
        
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            if (_testType == null)
            {
                MessageBox.Show("Test type is not exist",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            LoadTestTypeIntoUIFields();
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            LoadUIFieldsIntoTestType();
            if (_testType.Save())
            {
                MessageBox.Show("Test type has been updated successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
               MessageBox.Show("Couldn't update test type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
