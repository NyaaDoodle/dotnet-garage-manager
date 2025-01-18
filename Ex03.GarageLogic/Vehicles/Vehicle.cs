using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        private float m_EnergyRemainingPercentage;
        private const float k_MinimumEnergyRemainingPercentage = 0;
        private const float k_MaximumEnergyRemainingPercentage = 100;
        public string ModelName { get; set; }
        public string RegistrationPlateId { get; set; }
        public LinkedList<Wheel> Wheels { get; set; }
        public float EnergyRemainingPercentage {
            get
            {
                return m_EnergyRemainingPercentage;
            }
            set
            {
                if (value >= k_MinimumEnergyRemainingPercentage && value <= k_MaximumEnergyRemainingPercentage)
                {
                    m_EnergyRemainingPercentage = value;
                }
                else
                {
                    throwExceptionForEnergyPercentageOutOfRange();
                }
            }
        }

        public abstract ICollection<string> GetDefiningProperties();
        public abstract void SetDefiningProperties(Dictionary<string, string> i_DefiningPropertiesDictionary);

        protected Vehicle()
        {
            const string k_DefaultModelName = null;
            const string k_DefaultRegistrationPlateId = null;
            
            const float k_DefaultEnergyRemainingPercentage = k_MinimumEnergyRemainingPercentage;

            ModelName = k_DefaultModelName;
            RegistrationPlateId = k_DefaultRegistrationPlateId;
            EnergyRemainingPercentage = k_DefaultEnergyRemainingPercentage;
            Wheels = new LinkedList<Wheel>();
        }

        private static void throwExceptionForEnergyPercentageOutOfRange()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumEnergyRemainingPercentage;
            valueOutOfRangeException.MaxValue = k_MaximumEnergyRemainingPercentage;
            throw valueOutOfRangeException;
        }
    }
}