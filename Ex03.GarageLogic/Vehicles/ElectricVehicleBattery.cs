using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;
using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricVehicleBattery
    {
        private float m_MaximumChargeTimeInHours;
        private const float k_MinimumChargeTimeInHours = 0;

        public float ChargeTimeLeftInHours { get; private set; }
        public float MaximumChargeTimeInHours
        {
            get
            {
                return m_MaximumChargeTimeInHours;
            }
            set
            {
                if (value >= k_MinimumChargeTimeInHours)
                {
                    m_MaximumChargeTimeInHours = value;
                }
                else
                {
                    throwExceptionForMaximumChargeTimeOutOfRange();
                }
            }
        }

        public ElectricVehicleBattery()
        {
            const float k_DefaultChargeTimeLeftInHours = k_MinimumChargeTimeInHours;
            const float k_DefaultMaximumChargeTimeInHours = k_MinimumChargeTimeInHours;

            ChargeTimeLeftInHours = k_DefaultChargeTimeLeftInHours;
            MaximumChargeTimeInHours = k_DefaultMaximumChargeTimeInHours;
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
            
        }

        private static void throwExceptionForMaximumChargeTimeOutOfRange()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumChargeTimeInHours;
            throw valueOutOfRangeException;
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