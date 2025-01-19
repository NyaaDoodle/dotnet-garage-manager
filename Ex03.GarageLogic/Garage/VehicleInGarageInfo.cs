using Ex03.GarageLogic.Vehicles;
using System.Collections.Generic;
using Ex03.GarageLogic.Utilities;

namespace Ex03.GarageLogic.Garage
{
    internal class VehicleInGarageInfo
    {
        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public eRepairState RepairState { get; set; }
        public Vehicle Vehicle { get; }

        public VehicleInGarageInfo(Vehicle i_VehicleToAdd)
        {
            const string k_DefaultOwnerName = null;
            const string k_DefaultOwnerPhoneNumber = null;
            const eRepairState k_DefaultRepairState = eRepairState.InRepairs;

            OwnerName = k_DefaultOwnerName;
            OwnerPhoneNumber = k_DefaultOwnerPhoneNumber;
            RepairState = k_DefaultRepairState;
            Vehicle = i_VehicleToAdd;
        }

        public ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            definingPropertiesNames.AddLast(nameof(OwnerName));
            definingPropertiesNames.AddLast(nameof(OwnerPhoneNumber));
            LinkedListUtilities.AppendToLinkedList(Vehicle.GetDefiningPropertiesNames(), definingPropertiesNames);

            return definingPropertiesNames;

        }

        public void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            string ownerNameValue = i_DefiningPropertiesDictionary.GetValueStringForDefiningProperty(nameof(OwnerName));
            string ownerPhoneNumberValue =
                i_DefiningPropertiesDictionary.GetValueStringForDefiningProperty(nameof(OwnerPhoneNumber));

            OwnerName = ownerNameValue;
            OwnerPhoneNumber = ownerPhoneNumberValue;
            Vehicle.SetDefiningProperties(i_DefiningPropertiesDictionary);
        }

        public Dictionary<string, string> GetVehicleDetails()
        {
            Dictionary<string, string> detailsDictionary = new Dictionary<string, string>();

            detailsDictionary.Add(nameof(OwnerName), OwnerName);
            detailsDictionary.Add(nameof(OwnerPhoneNumber), OwnerPhoneNumber);
            detailsDictionary.Add(nameof(RepairState), RepairState.ToString());
            
            DictionaryUtilities.AppendToDictionary(Vehicle.GetDetails(), detailsDictionary);

            return detailsDictionary;
        }
    }
}