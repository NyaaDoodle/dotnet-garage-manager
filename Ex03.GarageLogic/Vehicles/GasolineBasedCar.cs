namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineBasedCar : Car
    {
        public GasolineFuelTank FuelTank { get; set; }

        public GasolineBasedCar()
        {
            FuelTank = getInitialCarFuelTank();
        }

        private static GasolineFuelTank getInitialCarFuelTank()
        {
            const float k_CarMaximumFuelAmountInLiters = 52;
            const GasolineFuelTank.eFuelType k_CarFuelType = GasolineFuelTank.eFuelType.Octan95;
            GasolineFuelTank carFuelTank = new GasolineFuelTank();

            carFuelTank.MaximumFuelAmountInLiters = k_CarMaximumFuelAmountInLiters;
            carFuelTank.FuelTypeInTank = k_CarFuelType;

            return carFuelTank;
        }
    }
}