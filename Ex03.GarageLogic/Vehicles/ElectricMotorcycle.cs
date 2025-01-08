namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricMotorcycle : Motorcycle
    {
        public ElectricVehicleBattery Battery { get; set; } = new ElectricVehicleBattery();
    }
}