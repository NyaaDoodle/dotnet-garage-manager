using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricCar : Car
    {
        public ElectricVehicleBattery Battery { get; set; }

        public ElectricCar()
        {
            Battery = getInitialCarBattery();
        }

        public override ICollection<string> GetDefiningPropertiesNames()
        {
            throw new System.NotImplementedException();
        }

        public override void SetDefiningProperties(Dictionary<string, string> i_DefiningPropertiesValuesToParse)
        {
            throw new System.NotImplementedException();
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