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
            Wheels = getTruckWheels();
            // TODO
            FuelTank = new GasolineFuelTank();

        }

        private static LinkedList<Wheel> getTruckWheels()
        {
            const int k_TruckWheelCount = 12;
            const int k_TruckWheelMaximumAirPressure = 29;
            LinkedList<Wheel> truckWheels = new LinkedList<Wheel>(k_TruckWheelCount);

            for (int i = 0; i < k_TruckWheelCount; i++)
            {
                truckWheels.Add(new Wheel(k_TruckWheelMaximumAirPressure));
                
            }

            return truckWheels;
        }
    }
}