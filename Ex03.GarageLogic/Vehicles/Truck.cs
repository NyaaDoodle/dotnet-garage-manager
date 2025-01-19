using Ex03.GarageLogic.Exceptions;
using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utilities;

namespace Ex03.GarageLogic.Vehicles
{
    internal class Truck : Vehicle
    {
        private float m_TruckloadVolume;
        private const float k_MinimumTruckloadVolume = 0;

        public bool IsDeliveringWithRefrigeration { get; set; }
        public GasolineFuelTank FuelTank { get; set; }

        public eFuelType FuelTypeInTank
        {
            get
            {
                return FuelTank.FuelTypeInTank;
            }
        }

        public float TruckloadVolume
        {
            get
            {
                return m_TruckloadVolume;
            }
            set
            {
                if (value >= k_MinimumTruckloadVolume)
                {
                    m_TruckloadVolume = value;
                }
                else
                {
                    throwExceptionForTruckloadVolumeOutOfRange();
                }
            }
        }

        public float CurrentFuelAmountInLiters
        {
            get
            {
                return FuelTank.CurrentFuelAmountInLiters;
            }
            set
            {
                FuelTank.CurrentFuelAmountInLiters = value;
            }
        }

        public float MaximumFuelAmountInLiters
        {
            get
            {
                return FuelTank.MaximumFuelAmountInLiters;
            }
        }

        public Truck()
        {
            const bool k_IsDeliveringWithRefrigerationDefaultValue = false;
            const float k_DefaultTruckloadVolume = k_MinimumTruckloadVolume;

            IsDeliveringWithRefrigeration = k_IsDeliveringWithRefrigerationDefaultValue;
            TruckloadVolume = k_DefaultTruckloadVolume;
            Wheels = getInitialTruckWheels();
            FuelTank = getInitialTruckFuelTank();
        }

        public void FuelUp(float i_FuelAmountToAddInLiters, eFuelType i_FuelType)
        {
            FuelTank.FuelUp(i_FuelAmountToAddInLiters, i_FuelType);
        }

        public override ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            LinkedListUtilities.AppendToLinkedList(base.GetDefiningPropertiesNames(), definingPropertiesNames);
            definingPropertiesNames.AddLast(nameof(IsDeliveringWithRefrigeration));
            definingPropertiesNames.AddLast(nameof(TruckloadVolume));

            return definingPropertiesNames;
        }

        public override void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            base.SetDefiningProperties(i_DefiningPropertiesDictionary);

            bool isDeliveringWithRefrigerationValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<bool>(
                    nameof(IsDeliveringWithRefrigeration));
            float truckLoadVolumeValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<float>(nameof(TruckloadVolume));

            IsDeliveringWithRefrigeration = isDeliveringWithRefrigerationValue;
            TruckloadVolume = truckLoadVolumeValue;
        }

        public override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> detailsDictionary = new Dictionary<string, string>();

            DictionaryUtilities.AppendToDictionary(base.GetDetails(), detailsDictionary);
            detailsDictionary.Add(nameof(IsDeliveringWithRefrigeration), IsDeliveringWithRefrigeration.ToString());
            detailsDictionary.Add(nameof(TruckloadVolume), TruckloadVolume.ToString());
            detailsDictionary.Add(nameof(FuelTypeInTank), FuelTypeInTank.ToString());
            detailsDictionary.Add(nameof(CurrentFuelAmountInLiters), CurrentFuelAmountInLiters.ToString());
            detailsDictionary.Add(nameof(MaximumFuelAmountInLiters), MaximumFuelAmountInLiters.ToString());

            return detailsDictionary;
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

            return new Wheel(k_TruckWheelMaximumAirPressureLevel);
        }

        private static GasolineFuelTank getInitialTruckFuelTank()
        {
            const eFuelType k_TruckFuelType = eFuelType.Soler;
            const float k_TruckMaximumFuelAmountInLiters = 125;

            return new GasolineFuelTank(k_TruckFuelType, k_TruckMaximumFuelAmountInLiters);
        }

        private static void throwExceptionForTruckloadVolumeOutOfRange()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumTruckloadVolume;
            throw valueOutOfRangeException;
        }
    }
}