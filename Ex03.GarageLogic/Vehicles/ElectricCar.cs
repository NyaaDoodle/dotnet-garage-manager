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

        private static ElectricVehicleBattery getInitialCarBattery()
        {
            const float k_CarMaximumChargeTimeInHours = 5.4f;
            ElectricVehicleBattery carBattery = new ElectricVehicleBattery();

            carBattery.MaximumChargeTimeInHours = k_CarMaximumChargeTimeInHours;

            return carBattery;
        }
    }
}