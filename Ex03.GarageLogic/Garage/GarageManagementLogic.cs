using System;
using System.Collections.Generic;
using System.Reflection;
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

        public void AddNewInitialVehicleToGarage(string i_VehicleType, string i_RegistrationPlateId)
        {
            Vehicle newVehicle = VehicleMaker.MakeVehicle(i_VehicleType);
            if (newVehicle != null)
            {
                newVehicle.RegistrationPlateId = i_RegistrationPlateId;
                VehicleInGarageInfo newVehicleInGarageInfo = new VehicleInGarageInfo(newVehicle);
                newVehicleInGarageInfo.RepairState = eRepairState.InRepairs;
                r_VehiclesInGarageByRegistrationPlateId.Add(i_RegistrationPlateId, newVehicleInGarageInfo);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public ICollection<string> GetVehicleDefiningPropertiesNames(string i_RegistrationPlateId)
        {
            VehicleInGarageInfo vehicleInGarageInfo = getVehicleInfo(i_RegistrationPlateId);

            return vehicleInGarageInfo.GetDefiningPropertiesNames();
        }

        public void SetDefiningPropertiesOfVehicle(string i_RegistrationPlateId, DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            VehicleInGarageInfo vehicleInGarageInfo = getVehicleInfo(i_RegistrationPlateId);

            vehicleInGarageInfo.SetDefiningProperties(i_DefiningPropertiesDictionary);
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
            ICollection<Wheel> vehicleWheels = vehicleInGarageInfo.Vehicle.Wheels;

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
            const string k_FuelUpMethodName = "FuelUp";
            VehicleInGarageInfo vehicleInGarageInfo = getVehicleInfo(i_RegistrationPlateId);
            Vehicle vehicleInGarage = vehicleInGarageInfo.Vehicle;
            bool isGasolineBased = isVehicleGasolineBased(vehicleInGarage);
            if (isGasolineBased)
            {
                MethodInfo fuelUpMethod = vehicleInGarage.GetType().GetMethod(k_FuelUpMethodName);
                if (fuelUpMethod != null)
                {
                    object[] fuelUpParameters = { i_FuelAmountToAdd, i_FuelType };
                    fuelUpMethod.Invoke(vehicleInGarage, fuelUpParameters);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void ChargeElectricVehicleInGarage(string i_RegistrationPlateId, float i_ChargeTimeToAddInMinutes)
        {
            const string k_ChargeMethodName = "Charge";
            float chargeTimeToAddInHours = i_ChargeTimeToAddInMinutes / 60;
            VehicleInGarageInfo vehicleInGarageInfo = getVehicleInfo(i_RegistrationPlateId);
            Vehicle vehicleInGarage = vehicleInGarageInfo.Vehicle;
            bool isElectricBased = isVehicleElectricBased(vehicleInGarage);
            if (isElectricBased)
            {
                MethodInfo chargeMethod = vehicleInGarage.GetType().GetMethod(k_ChargeMethodName);
                if (chargeMethod != null)
                {
                    object[] chargeParameters = { i_ChargeTimeToAddInMinutes };
                    chargeMethod.Invoke(vehicleInGarage, chargeParameters);
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public Dictionary<string, string> GetSpecificVehicleInGarageDetails(string i_RegistrationPlateId)
        {
            VehicleInGarageInfo vehicleInGarageInfo = getVehicleInfo(i_RegistrationPlateId);

        }

        private static bool isVehicleGasolineBased(Vehicle i_Vehicle)
        {
            const string k_GasolineFuelTankName = nameof(GasolineFuelTank);

            return i_Vehicle.GetType().GetProperty(k_GasolineFuelTankName) != null;
        }

        private static bool isVehicleElectricBased(Vehicle i_Vehicle)
        {
            const string k_ElectricVehicleBatteryName = nameof(ElectricVehicleBattery);

            return i_Vehicle.GetType().GetProperty(k_ElectricVehicleBatteryName) != null;
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