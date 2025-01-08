namespace Ex03.GarageLogic.Vehicles
{
    public class ElectricCar : Car
    {
        public ElectricVehicleBattery Battery { get; set; } = new ElectricVehicleBattery();
    }
}