using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{ 
    public enum enApplicationTypes
    {
        NewLocalDrivingLicenseService = 1,
        RenewDrivingLicenseService = 2,
        ReplacementForLostDrivingLicense = 3,
        ReplacementForDamagedDrivingLicense = 4,
        ReleaseDetainedDrivingLicense = 5,
        NewInternationalLicense = 6,
        RetakeTest = 7
    }

    public enum enLicenseClasses
    {
        Class1_SmallMotorcycle = 1,
        Class2_HeavyMotorcycle = 2,
        Class3_OrdinaryDrivingLicense = 3,
        Class4_Commercial = 4,
        Class5_Agricultural = 5,
        Class6_SmallAndMediumBus = 6,
        Class7_TruckAndHeavyVehicle = 7
    }

    public enum enTestTypes
    {
        VisionTest = 1,
        WrittenTheoryTest = 2,
        PracticalStreetTest = 3
    }

    public enum enIssueReasons
    {
        FirstTime = 1,
        Renew = 2,
        ReplacementForDamaged = 3,
        ReplacementForLost = 4
    }

    public enum enApplicationStatus
    {
        New = 1,
        Cancelled = 2,
        Completed = 3
    }
}
