using System;

namespace Ex03.GarageLogic.Vehicles
{
    internal class VehicleMaker
    {
        private static readonly Type[] sr_AllowedVehicleTypes =
            {
                typeof(ElectricCar),
                typeof(ElectricMotorcycle),
                typeof(GasolineBasedCar),
                typeof(GasolineBasedMotorcycle),
                typeof(Truck)
            };
        public static Vehicle MakeVehicle(string i_VehicleTypeString)
        {
            Type vehicleType = parseVehicleTypeString(i_VehicleTypeString);
            return Activator.CreateInstance(vehicleType) as Vehicle;
        }

        private static Type parseVehicleTypeString(string i_VehicleTypeString)
        {
            const string k_WhitespaceString = " ";
            Type inputType = null;
            bool isInputStringNotNull = i_VehicleTypeString != null;
            if (isInputStringNotNull)
            {
                string lowercaseInputString = i_VehicleTypeString.ToLower();
                string whitespaceRemovedInputString = lowercaseInputString.Replace(k_WhitespaceString, String.Empty);

                foreach (var type in sr_AllowedVehicleTypes)
                {
                    string typeString = type.Name.ToLower();
                    if (whitespaceRemovedInputString == typeString)
                    {
                        inputType = type;
                    }
                }
            }

            if (inputType == null)
            {
                throw new ArgumentException("This vehicle type cannot be created");
            }

            return inputType;
        }
    }
}