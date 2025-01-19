using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utilities;

namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineBasedCar : Car
    {
        public GasolineFuelTank FuelTank { get; set; }

        public eFuelType FuelTypeInTank
        {
            get
            {
                return FuelTank.FuelTypeInTank;
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

        public GasolineBasedCar()
        {
            FuelTank = getInitialCarFuelTank();
        }

        public void FuelUp(float i_FuelAmountToAddInLiters, eFuelType i_FuelType)
        {
            FuelTank.FuelUp(i_FuelAmountToAddInLiters, i_FuelType);
        }

        public override ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            LinkedListUtilities.AppendToLinkedList(base.GetDefiningPropertiesNames(), definingPropertiesNames);
            LinkedListUtilities.AppendToLinkedList(
                GasolineFuelTank.GetDefiningPropertiesNames(),
                definingPropertiesNames);

            return definingPropertiesNames;
        }

        public override void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            base.SetDefiningProperties(i_DefiningPropertiesDictionary);
            FuelTank.SetDefiningProperties(i_DefiningPropertiesDictionary);
        }

        public override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> detailsDictionary = new Dictionary<string, string>();

            DictionaryUtilities.AppendToDictionary(base.GetDetails(), detailsDictionary);
            detailsDictionary.Add(nameof(FuelTypeInTank), FuelTypeInTank.ToString());
            detailsDictionary.Add(nameof(CurrentFuelAmountInLiters), CurrentFuelAmountInLiters.ToString());
            detailsDictionary.Add(nameof(MaximumFuelAmountInLiters), MaximumFuelAmountInLiters.ToString());

            return detailsDictionary;
        }

        private static GasolineFuelTank getInitialCarFuelTank()
        {
            const float k_CarMaximumFuelAmountInLiters = 52;
            const eFuelType k_CarFuelType = eFuelType.Octan95;

            return new GasolineFuelTank(k_CarFuelType, k_CarMaximumFuelAmountInLiters);
        }
    }
}