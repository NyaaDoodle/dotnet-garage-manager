using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineBasedMotorcycle : Motorcycle
    {
        public GasolineFuelTank FuelTank { get; set; }

        public GasolineBasedMotorcycle()
        {
            FuelTank = getInitialMotorcycleFuelTank();
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

        private static GasolineFuelTank getInitialMotorcycleFuelTank()
        {
            const float k_MotorcycleMaximumFuelAmountInLiters = 6.2f;
            const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;
            GasolineFuelTank motorcycleFuelTank = new GasolineFuelTank(k_MotorcycleFuelType);

            motorcycleFuelTank.MaximumFuelAmountInLiters = k_MotorcycleMaximumFuelAmountInLiters;

            return motorcycleFuelTank;
        }
    }
}