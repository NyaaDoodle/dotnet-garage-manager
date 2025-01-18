using Ex03.GarageLogic.Exceptions;
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

        private int m_DoorCount;
        private const int k_MinimumDoorCount = 2;
        private const int k_MaximumDoorCount = 5;

        public eColor? Color { get; set; }

        public int DoorCount
        {
            get
            {
                return m_DoorCount;
            }
            set
            {
                if (value >= k_MinimumDoorCount && value <= k_MaximumDoorCount)
                {
                    m_DoorCount = value;
                }
                else
                {
                    throwExceptionForDoorCountOutOfRange();
                }
            }
        }


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

        private static void throwExceptionForDoorCountOutOfRange()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumDoorCount;
            valueOutOfRangeException.MaxValue = k_MaximumDoorCount;
            throw valueOutOfRangeException;
        }
    }
}