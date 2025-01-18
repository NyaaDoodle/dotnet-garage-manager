using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricMotorcycle : Motorcycle
    {
        public ElectricVehicleBattery Battery { get; set; }

        public ElectricMotorcycle()
        {
            Battery = getInitialMotorcycleBattery();
        }

        public override ICollection<string> GetDefiningPropertiesNames()
        {
            throw new System.NotImplementedException();
        }

        public override void SetDefiningProperties(Dictionary<string, string> i_DefiningPropertiesValuesToParse)
        {
            throw new System.NotImplementedException();
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