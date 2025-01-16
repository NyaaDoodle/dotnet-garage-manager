using System.Collections.Generic;

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

        public eLicenseClass? LicenseClass { get; set; }
        public int EngineVolumeInCubicCentimeters { get; set; }
        private const int k_MinimumEngineVolumeInCubicCentimeters = 0;

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
            const float k_MotorcycleWheelMaximumAirPressureLevel = 32;
            Wheel motorcycleWheel = new Wheel();

            motorcycleWheel.MaximumAirPressureLevel = k_MotorcycleWheelMaximumAirPressureLevel;

            return motorcycleWheel;
        }
    }
}