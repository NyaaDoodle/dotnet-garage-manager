using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utilities;

namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineBasedMotorcycle : Motorcycle
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

        public GasolineBasedMotorcycle()
        {
            FuelTank = getInitialMotorcycleFuelTank();
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

        private static GasolineFuelTank getInitialMotorcycleFuelTank()
        {
            const float k_MotorcycleMaximumFuelAmountInLiters = 6.2f;
            const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;

            return new GasolineFuelTank(k_MotorcycleFuelType, k_MotorcycleMaximumFuelAmountInLiters);
        }
    }
}