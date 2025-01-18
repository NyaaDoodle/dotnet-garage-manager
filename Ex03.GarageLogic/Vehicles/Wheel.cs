using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Wheel
    {
        private float m_CurrentAirPressureLevel;
        private const float k_MinimumAirPressureLevel = 0;

        public string ManufacturerName { get; set; }
        public float MaximumAirPressureLevel { get; }
        public float CurrentAirPressureLevel
        {
            get
            {
                return m_CurrentAirPressureLevel;
            }
            set
            {
                if (value >= k_MinimumAirPressureLevel && value <= MaximumAirPressureLevel)
                {
                    m_CurrentAirPressureLevel = value;
                }
                else
                {
                    throwExceptionForAirPressureOutOfRange();
                }
            }
        }


        public Wheel(float i_MaximumAirPressureLevel)
        {
            const string k_DefaultManufacturerName = null;
            const float k_DefaultCurrentAirPressureLevel = k_MinimumAirPressureLevel;

            ManufacturerName = k_DefaultManufacturerName;
            CurrentAirPressureLevel = k_DefaultCurrentAirPressureLevel;
            MaximumAirPressureLevel = i_MaximumAirPressureLevel;
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

        public static ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            definingPropertiesNames.AddLast(nameof(ManufacturerName));
            definingPropertiesNames.AddLast(nameof(CurrentAirPressureLevel));

            return definingPropertiesNames;
        }

        public void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            string manufacturerNameValue =
                i_DefiningPropertiesDictionary.GetValueStringForDefiningProperty(nameof(ManufacturerName));
            float currentAirPressureLevel =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<float>(
                    nameof(CurrentAirPressureLevel));

            ManufacturerName = manufacturerNameValue;
            CurrentAirPressureLevel = currentAirPressureLevel;
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