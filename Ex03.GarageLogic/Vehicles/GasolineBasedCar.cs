namespace Ex03.GarageLogic.Vehicles
{
    public class GasolineBasedCar : Car
    {
        public GasolineFuelTank FuelTank { get; set; } = new GasolineFuelTank();
    }
}