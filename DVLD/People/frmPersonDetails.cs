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
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int personID)
        {
            InitializeComponent();

            ctrPersonInformation1.LoadPersonInfo(personID);
        }
    }
}
