using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        public float? MinValue { get; set; }
        public float? MaxValue { get; set; }

        public ValueOutOfRangeException()
        {
            MinValue = null;
            MaxValue = null;
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}