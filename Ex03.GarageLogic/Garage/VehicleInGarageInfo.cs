namespace Ex03.GarageLogic.Garage
{
    public class VehicleInGarageInfo
    {
        public enum eRepairState
        {
            InRepairs,
            Repaired,
            Paid
        }

        public string OwnerName { get; set; } = k_OwnerNameDefaultValue;
        public string OwnerPhoneNumber { get; set; } = k_OwnerPhoneNumberDefaultValue;
        public eRepairState RepairState { get; set; } = k_RepairStateDefaultState;
        private const string k_OwnerNameDefaultValue = "";
        private const string k_OwnerPhoneNumberDefaultValue = "";
        private const eRepairState k_RepairStateDefaultState = eRepairState.InRepairs;
    }
}