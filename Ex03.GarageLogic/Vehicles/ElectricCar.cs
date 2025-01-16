namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricCar : Car
    {
        public ElectricVehicleBattery Battery { get; set; }

        public ElectricCar()
        {
            Battery = getInitialCarBattery();
        }

        private static ElectricVehicleBattery getInitialCarBattery()
        {
            const float k_CarMaximumChargeTimeInHours = 5.4f;
            ElectricVehicleBattery carBattery = new ElectricVehicleBattery();

            carBattery.MaximumChargeTimeInHours = k_CarMaximumChargeTimeInHours;

            return carBattery;
        }
    }
}