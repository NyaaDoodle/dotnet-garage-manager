using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricVehicleBattery
    {
        private float m_ChargeTimeLeftInHours;
        private const float k_MinimumChargeTimeInHours = 0;

        public float MaximumChargeTimeInHours { get; }

        public float ChargeTimeLeftInHours
        {
            get
            {
                return m_ChargeTimeLeftInHours;
            }
            set
            {
                if (value >= k_MinimumChargeTimeInHours && value <= MaximumChargeTimeInHours)
                {
                    m_ChargeTimeLeftInHours = value;
                }
                else
                {
                    throwExceptionForChargeTimeOutOfRange();
                }
            }
        }

        public ElectricVehicleBattery(float i_MaximumChargeTimeInHours)
        {
            const float k_DefaultChargeTimeLeftInHours = k_MinimumChargeTimeInHours;

            ChargeTimeLeftInHours = k_DefaultChargeTimeLeftInHours;
            MaximumChargeTimeInHours = i_MaximumChargeTimeInHours;
        }

        public void Charge(float i_ChargeTimeToAddInHours)
        {
            bool isChargeTimeBelowMinimum = i_ChargeTimeToAddInHours < k_MinimumChargeTimeInHours;
            float newChargeTimeLeftInHours = ChargeTimeLeftInHours + i_ChargeTimeToAddInHours;
            bool isNewChargeTimeAboveMaximum = newChargeTimeLeftInHours > MaximumChargeTimeInHours;

            if (!isChargeTimeBelowMinimum && !isNewChargeTimeAboveMaximum)
            {
                ChargeTimeLeftInHours = newChargeTimeLeftInHours;
            }
            else
            {
                throwExceptionForChargeTimeOutOfRange();
            }
        }

        public static ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            definingPropertiesNames.AddLast(nameof(ChargeTimeLeftInHours));

            return definingPropertiesNames;
        }

        public void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            float chargeTimeValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<float>(nameof(ChargeTimeLeftInHours));

            ChargeTimeLeftInHours = chargeTimeValue;
        }

        private void throwExceptionForChargeTimeOutOfRange()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();
            
            valueOutOfRangeException.MinValue = k_MinimumChargeTimeInHours;
            valueOutOfRangeException.MaxValue = MaximumChargeTimeInHours;
            throw valueOutOfRangeException;
        }
    }
}