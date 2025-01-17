using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.GarageLogic.Garage
{
    public class GarageManagementLogic
    {
        private readonly Dictionary<string, VehicleInGarageInfo> r_VehiclesInGarageByRegistrationPlateId;

        public GarageManagementLogic()
        {
            r_VehiclesInGarageByRegistrationPlateId = new Dictionary<string, VehicleInGarageInfo>();
        }

        public bool IsVehicleExistsInGarage(string i_RegistrationPlateId)
        {
            return r_VehiclesInGarageByRegistrationPlateId.ContainsKey(i_RegistrationPlateId);
        }

        public void ChangeRepairStateOfVehicleInGarage(string i_RegistrationPlateId, eRepairState i_NewRepairState)
        {
            VehicleInGarageInfo vehicleInGarageInfo = getVehicleInfo(i_RegistrationPlateId);

            vehicleInGarageInfo.RepairState = i_NewRepairState;
        }

        public void AddNewInitialVehicleToGarage(string i_VehicleType)
        {
            
        }

        public ICollection<string> GetAllRegistrationPlateIdsOfVehiclesInGarageList()
        {
            return r_VehiclesInGarageByRegistrationPlateId.Keys;
        }

        public ICollection<string> GetFilteredRegistrationPlateIdsOfVehiclesInGarage(eRepairState i_FilterRepairState)
        {
            LinkedList<string> filteredRegistrationPlateIdsOfVehiclesInGarage = new LinkedList<string>();

            foreach (KeyValuePair<string, VehicleInGarageInfo> pair in r_VehiclesInGarageByRegistrationPlateId)
            {
                if (pair.Value.RepairState == i_FilterRepairState)
                {
                    filteredRegistrationPlateIdsOfVehiclesInGarage.AddLast(pair.Key);
                }
            }

            return filteredRegistrationPlateIdsOfVehiclesInGarage;
        }

        public void InflateVehicleWheelsToMaximumAirPressureLevel(string i_RegistrationPlateId)
        {
            VehicleInGarageInfo vehicleInGarageInfo = getVehicleInfo(i_RegistrationPlateId);
            LinkedList<Wheel> vehicleWheels = vehicleInGarageInfo.Vehicle.Wheels;

            foreach (Wheel wheel in vehicleWheels)
            {
                if (wheel != null)
                {
                    float maximumAirPressureOfWheel = wheel.MaximumAirPressureLevel;

                    wheel.Inflate(maximumAirPressureOfWheel);
                }
            }
        }

        public void FuelUpGasolineBasedVehicleInGarage(
            string i_RegistrationPlateId,
            eFuelType i_FuelType,
            float i_FuelAmountToAdd)
        {
            VehicleInGarageInfo vehicleInGarageInfo = getVehicleInfo(i_RegistrationPlateId);
            bool isVehicleGasolineBased = vehicleInGarageInfo.Vehicle is GasolineBasedCar;
            if (isVehicleGasolineBased)
            {

            }
            else
            {
                // TODO turn to method
                throw new InvalidOperationException();
            }
        }

        public void ChargeElectricVehicleInGarage(string i_RegistrationPlateId, float i_ChargeTimeToAddInMinutes)
        {
            float chargeTimeToAddInHours = i_ChargeTimeToAddInMinutes / 60;

        }

        // TODO decide on return datatype
        public void getSpecificVehicleInGarageDetails(string i_RegistrationPlateId)
        {
            VehicleInGarageInfo vehicleInGarage = getVehicleInfo(i_RegistrationPlateId);

        }

        private VehicleInGarageInfo getVehicleInfo(string i_RegistrationPlateId)
        {
            bool successfulSearch = r_VehiclesInGarageByRegistrationPlateId.TryGetValue(
                i_RegistrationPlateId,
                out VehicleInGarageInfo vehicleInGarageInfo);

            if (!successfulSearch)
            {
                throwExceptionForVehicleNotExistingInGarage(i_RegistrationPlateId);
            }

            return vehicleInGarageInfo;
        }

        private static void throwExceptionForVehicleNotExistingInGarage(string i_RegistrationPlateId)
        {
            string vehicleNotInGarageMessage =
                $"Vehicle with registration plate ID: {i_RegistrationPlateId} does not exist in the garage.";
            throw new InvalidOperationException(vehicleNotInGarageMessage);
        }
    }
}