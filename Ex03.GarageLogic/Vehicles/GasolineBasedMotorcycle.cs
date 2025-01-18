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
            throw new System.NotImplementedException();
        }

        public override void SetDefiningProperties(Dictionary<string, string> i_DefiningPropertiesValuesToParse)
        {
            throw new System.NotImplementedException();
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