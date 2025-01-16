using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Truck : Vehicle
    {
        public bool IsDeliveringWithRefrigeration { get; set; }
        public float TruckloadVolume { get; set; }
        public GasolineFuelTank FuelTank { get; set; }
        private const float k_MinimumTruckloadVolume = 0;
        
        public Truck()
        {
            const bool k_IsDeliveringWithRefrigerationDefaultValue = false;
            const float k_DefaultTruckloadVolume = k_MinimumTruckloadVolume;

            IsDeliveringWithRefrigeration = k_IsDeliveringWithRefrigerationDefaultValue;
            TruckloadVolume = k_DefaultTruckloadVolume;
            Wheels = getInitialTruckWheels();
            FuelTank = getInitialTruckFuelTank();
        }

        private static LinkedList<Wheel> getInitialTruckWheels()
        {
            const int k_TruckWheelCount = 12;
            LinkedList<Wheel> truckWheels = new LinkedList<Wheel>();

            for (int i = 0; i < k_TruckWheelCount; i++)
            {
                truckWheels.AddLast(getNewTruckWheel());

            }

            return truckWheels;
        }

        private static Wheel getNewTruckWheel()
        {
            const float k_TruckWheelMaximumAirPressureLevel = 29;
            Wheel truckWheel = new Wheel();

            truckWheel.MaximumAirPressureLevel = k_TruckWheelMaximumAirPressureLevel;

            return truckWheel;
        }

        private static GasolineFuelTank getInitialTruckFuelTank()
        {
            const GasolineFuelTank.eFuelType k_TruckFuelType = GasolineFuelTank.eFuelType.Soler;
            const float k_TruckMaximumFuelAmountInLiters = 125;
            GasolineFuelTank truckFuelTank = new GasolineFuelTank();

            truckFuelTank.FuelTypeInTank = k_TruckFuelType;
            truckFuelTank.MaximumFuelAmountInLiters = k_TruckMaximumFuelAmountInLiters;

            return truckFuelTank;
        }
    }
}