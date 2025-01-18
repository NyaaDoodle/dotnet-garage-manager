using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;
using System.Collections.Generic;
using Ex03.GarageLogic.Utilities;

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

        public override ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            LinkedListUtilities.AppendToLinkedList(base.GetDefiningPropertiesNames(), definingPropertiesNames);
            definingPropertiesNames.AddLast(nameof(Color));
            definingPropertiesNames.AddLast(nameof(DoorCount));

            return definingPropertiesNames;
        }

        public override void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            base.SetDefiningProperties(i_DefiningPropertiesDictionary);

            eColor colorValue = i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<eColor>(nameof(Color));
            int doorCountValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<int>(nameof(DoorCount));

            Color = colorValue;
            DoorCount = doorCountValue;
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

            return new Wheel(k_CarWheelMaximumAirPressureLevel);
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