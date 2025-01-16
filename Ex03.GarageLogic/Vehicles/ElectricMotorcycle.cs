namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricMotorcycle : Motorcycle
    {
        public ElectricVehicleBattery Battery { get; set; }

        public ElectricMotorcycle()
        {
            Battery = getInitialMotorcycleBattery();
        }

        private static ElectricVehicleBattery getInitialMotorcycleBattery()
        {
            const float k_MotorcycleMaximumChargeTimeInHours = 2.9f;
            ElectricVehicleBattery motorcycleBattery = new ElectricVehicleBattery();

            motorcycleBattery.MaximumChargeTimeInHours = k_MotorcycleMaximumChargeTimeInHours;

            return motorcycleBattery;
        }
    }
}