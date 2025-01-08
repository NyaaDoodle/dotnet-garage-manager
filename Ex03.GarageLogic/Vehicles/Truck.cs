namespace Ex03.GarageLogic.Vehicles
{
    public class Truck
    {
        public bool IsDeliveringWithRefrigeration { get; set; } = k_IsDeliveringWithRefrigerationDefaultValue;
        public int TruckloadVolume { get; set; } = k_TruckloadVolumeDefaultValue;
        public GasolineFuelTank FuelTank { get; set; } = new GasolineFuelTank();
        private const bool k_IsDeliveringWithRefrigerationDefaultValue = false;
        private const int k_TruckloadVolumeDefaultValue = 0;
    }
}