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
            _testType = clsTestType.Find(testID);
            InitializeComponent();
        }

        public void AddTestTypeDataToFields()
        {
            if (_testType == null)
                return;

            lblTestID.Text = _testType.TestTypeID.ToString();
            txtTitle.Text = _testType.Title;
            txtDescription.Text = _testType.Description;
            txtFees.Text = _testType.Fees.ToString();
        }

        public void AddFieldsDataToTestType()
        {
            if (_testType == null)
                return;

            _testType.Title = txtTitle.Text;
            _testType.Description = txtDescription.Text;
            _testType.Fees = Convert.ToDecimal(txtFees.Text);
        }
        
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            AddTestTypeDataToFields();
        }

        private void ctrSaveBtn1_Click(object sender, EventArgs e)
        {
            AddFieldsDataToTestType();
            if (_testType.Save())
            {
                MessageBox.Show("Test Type Has Been Updated Successfully");
            }
            else
            {
               MessageBox.Show("Failed To Update Test Type");
            }
        }
    }
}
