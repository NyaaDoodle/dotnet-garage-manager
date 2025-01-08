using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; set; } = k_MinValueDefaultValue;
        public float MaxValue { get; set; } = k_MaxValueDefaultValue;
        private const float k_MinValueDefaultValue = 0;
        private const float k_MaxValueDefaultValue = 0;

        public ValueOutOfRangeException() {}

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}