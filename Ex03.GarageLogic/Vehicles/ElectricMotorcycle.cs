using System.Collections.Generic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Utilities;

namespace Ex03.GarageLogic.Vehicles
{
    internal class ElectricMotorcycle : Motorcycle
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

        public ElectricMotorcycle()
        {
            Battery = getInitialMotorcycleBattery();
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

        private static ElectricVehicleBattery getInitialMotorcycleBattery()
        {
            const float k_MotorcycleMaximumChargeTimeInHours = 2.9f;

            return new ElectricVehicleBattery(k_MotorcycleMaximumChargeTimeInHours);
        }
    }
}