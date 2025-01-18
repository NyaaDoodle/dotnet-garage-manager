using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineBasedCar : Car
    {
        public GasolineFuelTank FuelTank { get; set; }

        public GasolineBasedCar()
        {
            FuelTank = getInitialCarFuelTank();
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

        private static GasolineFuelTank getInitialCarFuelTank()
        {
            const float k_CarMaximumFuelAmountInLiters = 52;
            const eFuelType k_CarFuelType = eFuelType.Octan95;
            GasolineFuelTank carFuelTank = new GasolineFuelTank(k_CarFuelType);

            carFuelTank.MaximumFuelAmountInLiters = k_CarMaximumFuelAmountInLiters;

            return carFuelTank;
        }
    }
}