namespace Ex03.GarageLogic.Vehicles
{
    public class GasolineFuelTank
    {
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public float CurrentFuelAmountInLiters { get; set; } = k_CurrentFuelAmountDefaultValue;
        public float MaximumAllowedFuelAmountInLiters { get; set; } = k_MaximumAllowedFuelAmountDefaultValue;
        private const float k_CurrentFuelAmountDefaultValue = 0;
        private const float k_MaximumAllowedFuelAmountDefaultValue = 0;

        public void FuelUp(int i_FuelAmountToAdd, GasolineFuelTank.eFuelType i_FuelTypeToAdd)
        {

        }
    }
}