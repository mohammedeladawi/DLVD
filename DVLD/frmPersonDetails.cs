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
    public partial class frmPersonDetails : Form
    {
        clsPerson _person;
        public frmPersonDetails(int personID)
        {
            InitializeComponent();

            _person = clsPerson.FindByID(personID);
            ctrPersonInformation1.LoadPersonInfo(_person);
        }
    }
}
