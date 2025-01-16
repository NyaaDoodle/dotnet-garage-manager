using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricVehicleBattery
    {
        public float ChargeTimeLeftInHours { get; private set; }
        public float MaximumChargeTimeInHours { get; set; }
        private const float k_MinimumChargeTimeInHours = 0;

        public ElectricVehicleBattery()
        {
            const float k_DefaultChargeTimeLeftInHours = k_MinimumChargeTimeInHours;
            const float k_DefaultMaximumChargeTimeInHours = k_MinimumChargeTimeInHours;

            ChargeTimeLeftInHours = k_DefaultChargeTimeLeftInHours;
            MaximumChargeTimeInHours = k_DefaultMaximumChargeTimeInHours;
        }

        public void Charge(float i_ChargeTimeToAddInHours)
        {
            float newChargeTimeLeftInHours = ChargeTimeLeftInHours + i_ChargeTimeToAddInHours;

            if (newChargeTimeLeftInHours <= MaximumChargeTimeInHours)
            {
                ChargeTimeLeftInHours = newChargeTimeLeftInHours;
            }
            else
            {
                throwExceptionForExceedingMaximumChargeTime();
            }
        }

        private void throwExceptionForExceedingMaximumChargeTime()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();
            
            valueOutOfRangeException.MinValue = k_MinimumChargeTimeInHours;
            valueOutOfRangeException.MaxValue = MaximumChargeTimeInHours;
            throw valueOutOfRangeException;
        }
    }
}