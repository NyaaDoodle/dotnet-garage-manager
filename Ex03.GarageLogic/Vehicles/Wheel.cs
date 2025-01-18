using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Wheel
    {
        private float m_CurrentAirPressureLevel;
        private float m_MaximumAirPressureLevel;
        private const float k_MinimumAirPressureLevel = 0;

        public string ManufacturerName { get; set; }
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

        public float MaximumAirPressureLevel
        {
            get
            {
                return m_MaximumAirPressureLevel;
            }
            set
            {
                if (value >= k_MinimumAirPressureLevel)
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
            float maximumAirPressureLevelValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<float>(
                    nameof(MaximumAirPressureLevel));
            float currentAirPressureLevel =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<float>(
                    nameof(CurrentAirPressureLevel));

            ManufacturerName = manufacturerNameValue;
            MaximumAirPressureLevel = maximumAirPressureLevelValue;
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