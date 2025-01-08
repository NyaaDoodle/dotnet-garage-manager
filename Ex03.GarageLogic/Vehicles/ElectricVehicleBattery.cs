namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricVehicleBattery
    {
        public float ChargeTimeLeft { get; set; } = k_ChargeTimeLeftDefaultValue;
        public float MaximumChargeTime { get; set; } = k_MaximumChargeTimeDefaultValue;
        private const float k_ChargeTimeLeftDefaultValue = 0;
        private const float k_MaximumChargeTimeDefaultValue = 0;

        public void Charge(int i_ChargeTimeToAdd)
        {

        }
    }
}