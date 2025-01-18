using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utilities;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricCar : Car
    {
        public ElectricVehicleBattery Battery { get; set; }

        public ElectricCar()
        {
            Battery = getInitialCarBattery();
        }

        public override ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            LinkedListUtilities.AppendToLinkedList(base.GetDefiningPropertiesNames(), definingPropertiesNames);
            LinkedListUtilities.AppendToLinkedList(
                ElectricVehicleBattery.GetDefiningPropertiesNames(),
                definingPropertiesNames);

            return definingPropertiesNames;
        }

        public override void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            base.SetDefiningProperties(i_DefiningPropertiesDictionary);
            Battery.SetDefiningProperties(i_DefiningPropertiesDictionary);
        }

        private static ElectricVehicleBattery getInitialCarBattery()
        {
            const float k_CarMaximumChargeTimeInHours = 5.4f;

            return new ElectricVehicleBattery(k_CarMaximumChargeTimeInHours);
        }
    }
}