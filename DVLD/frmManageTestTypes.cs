﻿using System;
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
    public partial class frmManageTestTypes: Form
    {
        private int GetSelectedTestTypetID()
        {
            DataGridView dgvTestType = ctrDataView1.dgvManageDate1;
            int TestTypeID = -1;

            if (dgvTestType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvTestType.SelectedRows[0];
                TestTypeID = Convert.ToInt32(row.Cells["TestTypeID"].Value);
            }

            return TestTypeID;
        }

        private void UpdateTestTypeDialog(int testTypeID)
        {
            Form updateTestType = new frmUpdateTestType(testTypeID);
            updateTestType.FormClosed += frmUpdateTestType_Closed;
            updateTestType.ShowDialog();
        }
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void ReloadTestTypesData()
        {
            ctrDataView1.LoadDataInDgvManageData(clsTestType.GetAllTypes());
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            ctrDataView1.LoadDataInDgvManageData(clsTestType.GetAllTypes());
            ctrDataView1.SetContextMenuStrip(cmsManageTestTypes);
        }

        private void tsmiEditTestType_Click(object sender, EventArgs e)
        {
            int testTypeID = GetSelectedTestTypetID();

            if (testTypeID != -1)
            {
                UpdateTestTypeDialog(testTypeID);
            }
            else
            {
                MessageBox.Show("There is no selected row");
            }

        }

        private void frmUpdateTestType_Closed(object sender, EventArgs e)
        {
            ReloadTestTypesData();
        }
    }
}
