namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineFuelTank
    {
        internal enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public eFuelType FuelType { get; set; }
        public float CurrentFuelAmountInLiters { get; set; } = k_CurrentFuelAmountDefaultValue;
        public float MaximumAllowedFuelAmountInLiters { get; set; } = k_MaximumAllowedFuelAmountDefaultValue;
        private const float k_CurrentFuelAmountDefaultValue = 0;
        private const float k_MaximumAllowedFuelAmountDefaultValue = 0;

        public GasolineFuelTank(eFuelType i_FuelType, float 

        public void FuelUp(int i_FuelAmountToAdd, GasolineFuelTank.eFuelType i_FuelTypeToAdd)
        {

        }
    }
}