using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utilities;

namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineBasedCar : Car
    {
        public GasolineFuelTank FuelTank { get; set; }

        public GasolineBasedCar()
        {
            FuelTank = getInitialCarFuelTank();
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

        private static GasolineFuelTank getInitialCarFuelTank()
        {
            const float k_CarMaximumFuelAmountInLiters = 52;
            const eFuelType k_CarFuelType = eFuelType.Octan95;

            return new GasolineFuelTank(k_CarFuelType, k_CarMaximumFuelAmountInLiters);
        }
    }
}