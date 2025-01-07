using System;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Wheel
    {
        public string ManufacturerName { get; set; }
        public float? CurrentAirPressureLevel { get; set; }
        public float? MaximumAllowedAirPressureLevel { get; set; }

        public void Inflate(float i_AirPressureToAdd)
        {
            
        }
    }
}