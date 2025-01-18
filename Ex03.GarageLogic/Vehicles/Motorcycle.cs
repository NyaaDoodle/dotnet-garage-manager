using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utilities;

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

        public Motorcycle()
        {
            const int k_DefaultEngineVolume = k_MinimumEngineVolumeInCubicCentimeters;

            LicenseClass = null;
            EngineVolumeInCubicCentimeters = k_DefaultEngineVolume;
            Wheels = getInitialMotorcycleWheels();
        }

        public override ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            LinkedListUtilities.AppendToLinkedList(base.GetDefiningPropertiesNames(), definingPropertiesNames);
            definingPropertiesNames.AddLast(nameof(LicenseClass));
            definingPropertiesNames.AddLast(nameof(EngineVolumeInCubicCentimeters));

            return definingPropertiesNames;
        }

        public override void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            base.SetDefiningProperties(i_DefiningPropertiesDictionary);

            eLicenseClass licenseClassValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<eLicenseClass>(nameof(LicenseClass));
            int engineVolumeInCubicCentimetersValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<int>(nameof(EngineVolumeInCubicCentimeters));

            LicenseClass = licenseClassValue;
            EngineVolumeInCubicCentimeters = engineVolumeInCubicCentimetersValue;
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
            const float k_MotorcycleWheelMaximumAirPressureLevel = 32;

            return new Wheel(k_MotorcycleWheelMaximumAirPressureLevel);
        }

        private static void throwExceptionForEngineVolumeOutOfRange()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumEngineVolumeInCubicCentimeters;
            throw valueOutOfRangeException;
        }
    }
}