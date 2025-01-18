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
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            definingPropertiesNames.AddLast(nameof(IsDeliveringWithRefrigeration));
            definingPropertiesNames.AddLast(nameof(TruckloadVolume));

            return definingPropertiesNames;
        }

        public override void SetDefiningProperties(Dictionary<string, string> i_DefiningPropertiesValuesToParse)
        {
            bool isDeliveringWithRefrigerationValue = GetValueForDefiningProperty<bool>(
                nameof(IsDeliveringWithRefrigeration),
                i_DefiningPropertiesValuesToParse);
            float truckLoadVolumeValue = GetValueForDefiningProperty<float>(
                nameof(truckLoadVolumeValue),
                i_DefiningPropertiesValuesToParse);

            IsDeliveringWithRefrigeration = isDeliveringWithRefrigerationValue;
            TruckloadVolume = truckLoadVolumeValue;
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