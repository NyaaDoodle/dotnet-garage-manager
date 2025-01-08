using System;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Wheel
    {
        public string ManufacturerName { get; set; }

        public float? CurrentAirPressureLevel { get; private set; } = 0;
        public float? MaximumAllowedAirPressureLevel { get; set; }

        public void Inflate(float i_AirPressureToAdd)
        {
            try
            {
                float currentAirPressureLevel = CurrentAirPressureLevel.Value;
                float maximumAllowedAirPressureLevel = MaximumAllowedAirPressureLevel.Value;
                float newAirPressureLevel = currentAirPressureLevel + i_AirPressureToAdd;
                if (newAirPressureLevel <= MaximumAllowedAirPressureLevel)
                {
                    CurrentAirPressureLevel = newAirPressureLevel;
                }
                else
                {
                    
                }
            }
        }
    }
}