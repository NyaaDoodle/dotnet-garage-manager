using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Vehicle
    {
        public string ModelName { get; set; }
        public string RegistrationPlateId { get; set; }
        public float EnergyRemainingPercentage { get; set; }
        public ICollection<Wheel> Wheels { get; set; }

        public Vehicle()
        {
            const string k_DefaultModelName = null;
            const string k_DefaultRegistrationPlateId = null;
            const float k_DefaultEnergyRemainingPercentage = 0;
            const ICollection<Wheel> k_DefaultWheelsValue = null;

            ModelName = k_DefaultModelName;
            RegistrationPlateId = k_DefaultRegistrationPlateId;
            EnergyRemainingPercentage = k_DefaultEnergyRemainingPercentage;
            Wheels = k_DefaultWheelsValue;

        }
    }
}