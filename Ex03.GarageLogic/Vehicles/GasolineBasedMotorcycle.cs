namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineBasedMotorcycle : Motorcycle
    {
        public GasolineFuelTank FuelTank { get; set; }

        public GasolineBasedMotorcycle()
        {
            FuelTank = getInitialMotorcycleFuelTank();
        }

        private static GasolineFuelTank getInitialMotorcycleFuelTank()
        {
            const float k_MotorcycleMaximumFuelAmountInLiters = 6.2f;
            const GasolineFuelTank.eFuelType k_MotorcycleFuelType = GasolineFuelTank.eFuelType.Octan98;
            GasolineFuelTank motorcycleFuelTank = new GasolineFuelTank();

            motorcycleFuelTank.MaximumFuelAmountInLiters = k_MotorcycleMaximumFuelAmountInLiters;
            motorcycleFuelTank.FuelTypeInTank = k_MotorcycleFuelType;

            return motorcycleFuelTank;
        }
    }
}