using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Vehicle
    {
        public string ModelName { get; set; }
        public string RegistrationPlateId { get; set; }
        public float? EnergyRemainingPercentage { get; set; }
        public List<Wheel> Wheels { get; set; }
    }
}