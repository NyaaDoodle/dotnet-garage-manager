using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Vehicle
    {
        private float m_EnergyRemainingPercentage;
        private const float k_MinimumEnergyRemainingPercentage = 0;
        private const float k_MaximumEnergyRemainingPercentage = 100;

        public string ModelName { get; set; }
        public string RegistrationPlateId { get; set; }
        public ICollection<Wheel> Wheels { get; set; }
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

        public Vehicle()
        {
            const string k_DefaultModelName = null;
            const string k_DefaultRegistrationPlateId = null;

            const float k_DefaultEnergyRemainingPercentage = k_MinimumEnergyRemainingPercentage;

            ModelName = k_DefaultModelName;
            RegistrationPlateId = k_DefaultRegistrationPlateId;
            EnergyRemainingPercentage = k_DefaultEnergyRemainingPercentage;
            Wheels = new LinkedList<Wheel>();
        }

        protected virtual ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            definingPropertiesNames.AddLast(nameof(ModelName));
            definingPropertiesNames.AddLast(nameof(RegistrationPlateId));
            definingPropertiesNames.AddLast(nameof(EnergyRemainingPercentage));
            addWheelDefiningPropertiesNames(definingPropertiesNames);

            return definingPropertiesNames;
        }

        protected virtual void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            string modelNameValue = i_DefiningPropertiesDictionary.GetValueStringForDefiningProperty(nameof(ModelName));
            string registrationPlateIdValue =
                i_DefiningPropertiesDictionary.GetValueStringForDefiningProperty(nameof(RegistrationPlateId));
            float energyRemainingPercentageValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<float>(
                    nameof(EnergyRemainingPercentage));

            ModelName = modelNameValue;
            RegistrationPlateId = registrationPlateIdValue;
            EnergyRemainingPercentage = energyRemainingPercentageValue;
            foreach (Wheel wheel in Wheels)
            {
                wheel.SetDefiningProperties(i_DefiningPropertiesDictionary);
            }
        }

        protected static void AddMaximumAirPressureToDefiningPropertiesDictionary(float i_MaximumAirPressure, DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            i_DefiningPropertiesDictionary.AddValueStringForDefiningProperty(
                nameof(Wheel.MaximumAirPressureLevel),
                i_MaximumAirPressure.ToString());
        }

        protected void AddVehicleDefiningPropertiesNamesToList(LinkedList<string> i_ListToAddTo)
        {
            ICollection<string> propertiesNames = GetDefiningPropertiesNames();

            foreach (string propertyName in propertiesNames)
            {
                i_ListToAddTo.AddLast(propertyName);
            }
        }

        private static void addWheelDefiningPropertiesNames(LinkedList<string> i_ListToAddTo)
        {
            ICollection<string> wheelPropertiesNames = Wheel.GetDefiningPropertiesNames();

            foreach (string wheelPropertyName in wheelPropertiesNames)
            {
                i_ListToAddTo.AddLast(wheelPropertyName);
            }
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