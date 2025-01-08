namespace Ex03.GarageLogic.Vehicles
{
    public class Car
    {
        public enum eColor
        {
            Black,
            White,
            Grey,
            Blue
        }

        public eColor Color { get; set; } = k_ColorDefaultValue;
        public int DoorCount { get; set; } = k_DoorCountDefaultValue;
        private const eColor k_ColorDefaultValue = eColor.Black;
        private const int k_DoorCountDefaultValue = 0;
    }
}