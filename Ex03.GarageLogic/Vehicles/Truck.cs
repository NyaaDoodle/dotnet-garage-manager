using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Truck : Vehicle
    {
        public bool IsDeliveringWithRefrigeration { get; set; }
        public float TruckloadVolume { get; set; }
        public GasolineFuelTank FuelTank { get; set; }
        
        
        public Truck()
        {
            const bool k_IsDeliveringWithRefrigerationDefaultValue = false;
            const float k_DefaultTruckloadVolume = 0;

            IsDeliveringWithRefrigeration = k_IsDeliveringWithRefrigerationDefaultValue;
            TruckloadVolume = k_DefaultTruckloadVolume;
            Wheels = getTruckWheelsList();
            // TODO
            FuelTank = new GasolineFuelTank();

        }

        private static List<Wheel> getTruckWheelsList()
        {
            const int k_TruckWheelCount = 12;
            const int k_TruckWheelMaximumAirPressure = 29;
            List<Wheel> truckWheels = new List<Wheel>(k_TruckWheelCount);

            for (int i = 0; i < k_TruckWheelCount; i++)
            {
                truckWheels.Add(new Wheel(k_TruckWheelMaximumAirPressure));
            }

            return truckWheels;
        }
    }
}