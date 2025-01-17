using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    internal class VehicleInGarageInfo
    {
        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public eRepairState RepairState { get; set; }
        public Vehicle Vehicle { get; set; }

        public VehicleInGarageInfo()
        {
            const string k_DefaultOwnerName = null;
            const string k_DefaultOwnerPhoneNumber = null;
            const eRepairState k_DefaultRepairState = eRepairState.InRepairs;
            const Vehicle k_DefaultVehicleValue = null;

            OwnerName = k_DefaultOwnerName;
            OwnerPhoneNumber = k_DefaultOwnerPhoneNumber;
            RepairState = k_DefaultRepairState;
            Vehicle = k_DefaultVehicleValue;
        }
    }
}