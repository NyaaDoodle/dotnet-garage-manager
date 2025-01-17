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
            const eFuelType k_CarFuelType = eFuelType.Octan95;
            GasolineFuelTank carFuelTank = new GasolineFuelTank(k_CarFuelType);

            carFuelTank.MaximumFuelAmountInLiters = k_CarMaximumFuelAmountInLiters;

            return carFuelTank;
        }
    }
}