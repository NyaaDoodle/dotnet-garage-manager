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
            FuelTank = getTruckFuelTank();
        }

        private static LinkedList<Wheel> getTruckWheels()
        {
            const int k_TruckWheelCount = 12;
            const int k_TruckWheelMaximumAirPressure = 29;
            LinkedList<Wheel> truckWheels = new LinkedList<Wheel>();

            for (int i = 0; i < k_TruckWheelCount; i++)
            {
                truckWheels.AddLast(new Wheel(k_TruckWheelMaximumAirPressure));
                truckWheels.Last.Value.MaximumAirPressureLevel = k_TruckWheelMaximumAirPressure;

            }

            return truckWheels;
        }

        private static GasolineFuelTank getTruckFuelTank()
        {
            const GasolineFuelTank.eFuelType k_TruckFuelType = GasolineFuelTank.eFuelType.Soler;
            const float k_TruckMaximumFuelAmount = 125;
            GasolineFuelTank truckFuelTank = new GasolineFuelTank();

            truckFuelTank.FuelType = k_TruckFuelType;
            truckFuelTank.MaximumFuelAmountInLiters = k_TruckMaximumFuelAmount;

            return truckFuelTank;
        }
    }
}