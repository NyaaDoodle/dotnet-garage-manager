using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Vehicle
    {
        public string ModelName { get; set; } = null;
        public string RegistrationPlateId { get; set; } = null;
        public float EnergyRemainingPercentage { get; set; } = k_MinimumEnergyRemainingPercentage;
        public List<Wheel> Wheels { get; set; } = new List<Wheel>();
        private const float k_MinimumEnergyRemainingPercentage = 0;
    }
}