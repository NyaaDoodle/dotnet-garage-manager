using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Wheel
    {
        public string ManufacturerName { get; set; } = "";

        public float CurrentAirPressureLevel { get; private set; } = k_MinimumAirPressureLevel;

        public float MaximumAllowedAirPressureLevel { get; set; } = k_MinimumAirPressureLevel;

        private const int k_MinimumAirPressureLevel = 0;

        public void Inflate(float i_AirPressureToAdd)
        {
            float newAirPressureLevel = CurrentAirPressureLevel + i_AirPressureToAdd;
            if (newAirPressureLevel <= MaximumAllowedAirPressureLevel)
            { 
                CurrentAirPressureLevel = newAirPressureLevel;
            }
            else
            { 
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();
                valueOutOfRangeException.MinValue = k_MinimumAirPressureLevel;
                valueOutOfRangeException.MaxValue = MaximumAllowedAirPressureLevel;
                
                throw valueOutOfRangeException;
            }
        }
    }
}