using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Wheel
    {
        public string ManufacturerName { get; set; }
        public float CurrentAirPressureLevel { get; private set; }
        public float MaximumAirPressureLevel { get; set; }
        private const int k_MinimumAirPressureLevel = 0;

        public Wheel()
        {
            const string k_DefaultManufacturerName = null;
            const float k_DefaultCurrentAirPressureLevel = k_MinimumAirPressureLevel;
            const float k_DefaultMaximumAirPressureLevel = k_MinimumAirPressureLevel;

            ManufacturerName = k_DefaultManufacturerName;
            CurrentAirPressureLevel = k_DefaultCurrentAirPressureLevel;
            MaximumAirPressureLevel = k_DefaultMaximumAirPressureLevel;
        }

        public Wheel(int i_MaximumAirPressureLevel)
            : this()
        {
            MaximumAirPressureLevel = i_MaximumAirPressureLevel;
        }

        public void Inflate(float i_AirPressureToAdd)
        {
            float newAirPressureLevel = CurrentAirPressureLevel + i_AirPressureToAdd;
            if (newAirPressureLevel <= MaximumAirPressureLevel)
            { 
                CurrentAirPressureLevel = newAirPressureLevel;
            }
            else
            { 
                ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();
                valueOutOfRangeException.MinValue = k_MinimumAirPressureLevel;
                valueOutOfRangeException.MaxValue = MaximumAirPressureLevel;
                
                throw valueOutOfRangeException;
            }
        }
    }
}