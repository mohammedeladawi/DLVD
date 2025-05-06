using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _LoadPeopleData()
        {
            DataTable dt = clsPerson.GetAllPersonsInfo();
            ctrManageData1.loadData(dt);
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {

            string mainLogoUrl = @"C:\Users\mazik\Desktop\19. Full Real Project\03. DVLD Project\DVLD\assets\images\team-management.png";
            ctrManageData1.loadLogoImgAndTitle(mainLogoUrl, "Manage People");

            _LoadPeopleData();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            Form frmAddPerson = new frmAddEditPerson();
            frmAddPerson.FormClosed += frmAddPerson_Closed;
            frmAddPerson.ShowDialog();
        }

        private void frmAddPerson_Closed(object sender, FormClosedEventArgs e)
        {
            _LoadPeopleData();
        }
    }
}
