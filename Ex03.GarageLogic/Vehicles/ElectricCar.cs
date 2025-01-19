using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utilities;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricCar : Car
    {
        public ElectricVehicleBattery Battery { get; set; }

        public float ChargeTimeLeftInHours
        {
            get
            {
                return Battery.ChargeTimeLeftInHours;
            }
            set
            {
                Battery.ChargeTimeLeftInHours = value;
            }
        }

        public float MaximumChargeTimeInHours
        {
            get
            {
                return Battery.MaximumChargeTimeInHours;
            }
        }

        public ElectricCar()
        {
            Battery = getInitialCarBattery();
        }

        public void Charge(float i_ChargeTimeToAddInHours)
        {
            Battery.Charge(i_ChargeTimeToAddInHours);
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

        public override Dictionary<string, string> GetDetails()
        {
            Dictionary<string, string> detailsDictionary = new Dictionary<string, string>();

            DictionaryUtilities.AppendToDictionary(base.GetDetails(), detailsDictionary);
            detailsDictionary.Add(nameof(ChargeTimeLeftInHours), ChargeTimeLeftInHours.ToString());
            detailsDictionary.Add(nameof(MaximumChargeTimeInHours), MaximumChargeTimeInHours.ToString());

            return detailsDictionary;
        }

        private static ElectricVehicleBattery getInitialCarBattery()
        {
            const float k_CarMaximumChargeTimeInHours = 5.4f;

            return new ElectricVehicleBattery(k_CarMaximumChargeTimeInHours);
        }
    }
}