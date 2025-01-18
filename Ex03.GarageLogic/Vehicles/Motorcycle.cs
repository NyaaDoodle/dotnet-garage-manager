using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;
using static Ex03.GarageLogic.Vehicles.Car;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        internal enum eLicenseClass : byte
        {
            A1,
            A2,
            B1,
            B2
        }

        private int m_EngineVolumeInCubicCentimeters;
        private const int k_MinimumEngineVolumeInCubicCentimeters = 0;
        private const float k_MotorcycleWheelMaximumAirPressureLevel = 32;

        public eLicenseClass? LicenseClass { get; set; }

        public int EngineVolumeInCubicCentimeters
        {
            get
            {
                return m_EngineVolumeInCubicCentimeters;
            }
            set
            {
                if (value >= k_MinimumEngineVolumeInCubicCentimeters)
                {
                    m_EngineVolumeInCubicCentimeters = value;
                }
                else
                {
                    throwExceptionForEngineVolumeOutOfRange();
                }
            }
        }

        protected override ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            AddVehicleDefiningPropertiesNamesToList(definingPropertiesNames);
            definingPropertiesNames.AddLast(nameof(LicenseClass));
            definingPropertiesNames.AddLast(nameof(EngineVolumeInCubicCentimeters));

            return definingPropertiesNames;
        }

        protected override void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            AddMaximumAirPressureToDefiningPropertiesDictionary(k_MotorcycleWheelMaximumAirPressureLevel, i_DefiningPropertiesDictionary);
            base.SetDefiningProperties(i_DefiningPropertiesDictionary);

            eLicenseClass licenseClassValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<eLicenseClass>(nameof(LicenseClass));
            int engineVolumeInCubicCentimetersValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<int>(nameof(EngineVolumeInCubicCentimeters));

            LicenseClass = licenseClassValue;
            EngineVolumeInCubicCentimeters = engineVolumeInCubicCentimetersValue;
        }

        public Motorcycle()
        {
            const int k_DefaultEngineVolume = k_MinimumEngineVolumeInCubicCentimeters;

            LicenseClass = null;
            EngineVolumeInCubicCentimeters = k_DefaultEngineVolume;
            Wheels = getInitialMotorcycleWheels();
        }

        private static LinkedList<Wheel> getInitialMotorcycleWheels()
        {
            const int k_MotorcycleWheelCount = 2;
            LinkedList<Wheel> motorcycleWheels = new LinkedList<Wheel>();

            for (int i = 0; i < k_MotorcycleWheelCount; i++)
            {
                motorcycleWheels.AddLast(getNewMotorcycleWheel());
            }

            return motorcycleWheels;
        }

        private static Wheel getNewMotorcycleWheel()
        {
            Wheel motorcycleWheel = new Wheel();

            motorcycleWheel.MaximumAirPressureLevel = k_MotorcycleWheelMaximumAirPressureLevel;

            return motorcycleWheel;
        }

        private static void throwExceptionForEngineVolumeOutOfRange()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumEngineVolumeInCubicCentimeters;
            throw valueOutOfRangeException;
        }
    }
}