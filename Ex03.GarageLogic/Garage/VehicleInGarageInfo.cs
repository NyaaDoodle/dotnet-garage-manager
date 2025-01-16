namespace Ex03.GarageLogic.Garage
{
    public class VehicleInGarageInfo
    {
        public enum eRepairState : byte
        {
            InRepairs,
            Repaired,
            Paid
        }

        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public eRepairState RepairState { get; set; }

        public VehicleInGarageInfo()
        {
            const string k_DefaultOwnerName = null;
            const string k_DefaultOwnerPhoneNumber = null;
            const eRepairState k_DefaultRepairState = eRepairState.InRepairs;

            OwnerName = k_DefaultOwnerName;
            OwnerPhoneNumber = k_DefaultOwnerPhoneNumber;
            RepairState = k_DefaultRepairState;
        }
    }
}