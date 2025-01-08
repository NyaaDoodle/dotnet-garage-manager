namespace Ex03.GarageLogic.Vehicles
{
    public class GasolineBasedMotorcycle : Motorcycle
    {
        public GasolineFuelTank FuelTank { get; set; } = new GasolineFuelTank();
    }
}