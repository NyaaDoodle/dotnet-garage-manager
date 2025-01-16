using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Car : Vehicle
    {
        internal enum eColor : byte
        {
            Black,
            White,
            Grey,
            Blue
        }

        public eColor? Color { get; set; }
        public int DoorCount { get; set; }
        private const int k_MinimumDoorCount = 0;
        
        public Car()
        {
            const int k_DefaultDoorCount = k_MinimumDoorCount;

            Color = null;
            DoorCount = k_DefaultDoorCount;
            Wheels = getInitialCarWheels();
        }

        private static LinkedList<Wheel> getInitialCarWheels()
        {
            const int k_CarWheelCount = 5;
            LinkedList<Wheel> carWheels = new LinkedList<Wheel>();

            for (int i = 0; i < k_CarWheelCount; i++)
            {
                carWheels.AddLast(getNewCarWheel());
            }

            return carWheels;
        }

        private static Wheel getNewCarWheel()
        {
            const float k_CarWheelMaximumAirPressureLevel = 34;
            Wheel carWheel = new Wheel();

            carWheel.MaximumAirPressureLevel = k_CarWheelMaximumAirPressureLevel;

            return carWheel;
        }
    }
}