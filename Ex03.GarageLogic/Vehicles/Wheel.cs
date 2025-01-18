using System.Runtime.InteropServices.ComTypes;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Wheel
    {
        private float m_MaximumAirPressureLevel;
        private const float k_MinimumAirPressureLevel = 0;

        public string ManufacturerName { get; set; }
        public float CurrentAirPressureLevel { get; private set; }

        public float MaximumAirPressureLevel
        {
            get
            {
                return m_MaximumAirPressureLevel;
            }
            set
            {
                if (m_MaximumAirPressureLevel >= k_MinimumAirPressureLevel)
                {
                    m_MaximumAirPressureLevel = value;
                }
                else
                {
                    throwExceptionForAirPressureOutOfRange();
                }
            }
        }


        public Wheel()
        {
            const string k_DefaultManufacturerName = null;
            const float k_DefaultCurrentAirPressureLevel = k_MinimumAirPressureLevel;
            const float k_DefaultMaximumAirPressureLevel = k_MinimumAirPressureLevel;

            ManufacturerName = k_DefaultManufacturerName;
            CurrentAirPressureLevel = k_DefaultCurrentAirPressureLevel;
            MaximumAirPressureLevel = k_DefaultMaximumAirPressureLevel;
        }

        public void Inflate(float i_AirPressureToAdd)
        {
            bool isAirPressureToAddBelowMinimum = i_AirPressureToAdd < k_MinimumAirPressureLevel;
            float newAirPressureLevel = CurrentAirPressureLevel + i_AirPressureToAdd;
            bool isNewAirPressureAboveMaximum = newAirPressureLevel > MaximumAirPressureLevel;

            if (!isAirPressureToAddBelowMinimum && !isNewAirPressureAboveMaximum)
            {
                CurrentAirPressureLevel = newAirPressureLevel;
            }
            else
            {
                throwExceptionForAirPressureOutOfRange();
            }
        }

        private void throwExceptionForAirPressureOutOfRange()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumAirPressureLevel;
            valueOutOfRangeException.MaxValue = MaximumAirPressureLevel;
            throw valueOutOfRangeException;
        }
    }
}