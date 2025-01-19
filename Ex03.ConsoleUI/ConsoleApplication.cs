using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.ConsoleUI
{
    public class ConsoleApplication
    {
        private static readonly GarageManagementLogic sr_GarageManagementLogic = new GarageManagementLogic();
        private static readonly string[] sr_MenuOptionsStrings =
            {
                "Add a new vehicle to the garage",
                "Show all vehicles in the garage",
                "Change state of vehicle in the garage",
                "Inflate a vehicle's wheels to maximum air pressure in the garage",
                "Fuel up a gasoline based vehicle in the garage",
                "Charge up an electric vehicle in the garage",
                "Show details of a vehicle in the garage",
                "Exit"
            };
        private const int k_StartingSelectionNumber = 1;
        private static bool m_ExitSelected = false;
        public static void StartApplication()
        {
            showTitle();
            while (!m_ExitSelected)
            {
                showMainMenu();
                selectMainMenuOption();
            }
        }

        private static void showTitle()
        {
            Console.WriteLine("Welcome to the Garage!");
            Console.WriteLine();
        }

        private static void showMainMenu()
        {
            int currentOptionNumber = k_StartingSelectionNumber;

            foreach (string optionString in sr_MenuOptionsStrings)
            {
                Console.WriteLine($"({currentOptionNumber}) {optionString}");
                currentOptionNumber++;
            }
        }

        private static void selectMainMenuOption()
        {
            int inputSelection = ConsoleInputTools.GetUserInputInRange(
                k_StartingSelectionNumber,
                sr_MenuOptionsStrings.Length);

            switch (inputSelection)
            {
                case 1:
                    addNewVehicleToGarage();
                    break;
                case 2:
                    showRegistrationPlateIdsOfVehiclesInGarageList();
                    break;
                case 3:
                    changeRepairStateOfVehicleInGarage();
                    break;
                case 4:
                    inflateVehicleWheelsToMaximumAirPressureLevel();
                    break;
                case 5:
                    fuelUpGasolineBasedVehicleInGarage();
                    break;
                case 6:
                    chargeElectricVehicleInGarage();
                    break;
                case 7:
                    showSpecificVehicleInGarageDetails();
                    break;
                case 8:
                    m_ExitSelected = true;
                    break;
            }
        }

        private static void addNewVehicleToGarage()
        {
            string inputRegistrationPlateId = ConsoleInputTools.GetUserInputRegistrationPlateId();

            if (!sr_GarageManagementLogic.IsVehicleExistsInGarage(inputRegistrationPlateId))
            {
                Console.WriteLine("Enter vehicle type to add:");
                string inputVehicleType = Console.ReadLine();
                try
                {
                    sr_GarageManagementLogic.AddNewInitialVehicleToGarage(inputVehicleType, inputRegistrationPlateId);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    return;
                }

                ICollection<string> vehicleDefiningProperties =
                    sr_GarageManagementLogic.GetVehicleDefiningPropertiesNames(inputRegistrationPlateId);
                DefiningPropertiesDictionary definingPropertiesDictionary = new DefiningPropertiesDictionary();

                foreach (var definingPropertyName in vehicleDefiningProperties)
                {
                    Console.WriteLine($"{definingPropertyName}:");
                    string inputDefiningProperty = Console.ReadLine();
                    definingPropertiesDictionary.AddValueStringForDefiningProperty(definingPropertyName, inputDefiningProperty);
                }

                try
                {
                    sr_GarageManagementLogic.SetDefiningPropertiesOfVehicle(
                        inputRegistrationPlateId,
                        definingPropertiesDictionary);
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Input invalid, please try again");
                    sr_GarageManagementLogic.RemoveVehicleFromGarage(inputRegistrationPlateId);
                }
            }
            else
            {
                Console.WriteLine("Vehicle already exists in garage, changing to 'In Repairs' state");
                sr_GarageManagementLogic.ChangeRepairStateOfVehicleInGarage(inputRegistrationPlateId, eRepairState.InRepairs);
            }
        }

        private static void showRegistrationPlateIdsOfVehiclesInGarageList()
        {
            Console.WriteLine("Enter repair state to filter by state (In Repairs, Repaired or Paid):");
            Console.WriteLine("(Just press 'enter' to see all)");
            eRepairState? inputRepairState = ConsoleInputTools.GetUserInputRepairStateWithEmpty();
            ICollection<string> registrationPlatesIdsList = null;

            if (inputRepairState != null)
            {
                registrationPlatesIdsList =
                    sr_GarageManagementLogic.GetFilteredRegistrationPlateIdsOfVehiclesInGarage(inputRepairState.Value);
            }
            else
            {
                registrationPlatesIdsList = sr_GarageManagementLogic.GetAllRegistrationPlateIdsOfVehiclesInGarageList();
            }

            foreach (var registrationPlateId in registrationPlatesIdsList)
            {
                Console.WriteLine(registrationPlateId);
            }
        }

        private static void changeRepairStateOfVehicleInGarage()
        {
            string inputRegistrationPlateId = ConsoleInputTools.GetUserInputRegistrationPlateId();

            Console.WriteLine("Enter repair state to change to (In Repairs, Repaired or Paid):");
            eRepairState inputRepairState = ConsoleInputTools.GetUserInputRepairState();

            try
            {
                sr_GarageManagementLogic.ChangeRepairStateOfVehicleInGarage(inputRegistrationPlateId, inputRepairState);
                Console.WriteLine("Change successful!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void inflateVehicleWheelsToMaximumAirPressureLevel()
        {
            string inputRegistrationPlateId = ConsoleInputTools.GetUserInputRegistrationPlateId();

            try
            {
                sr_GarageManagementLogic.InflateVehicleWheelsToMaximumAirPressureLevel(inputRegistrationPlateId);
                Console.WriteLine("Inflation successful!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void fuelUpGasolineBasedVehicleInGarage()
        {
            const float k_MinimumFuelAmountInLiters = 0;
            string inputRegistrationPlateId = ConsoleInputTools.GetUserInputRegistrationPlateId();

            Console.WriteLine("Enter fuel type (Octan 95, Octan 96, Octan 98 or Soler):");
            eFuelType inputFuelType = ConsoleInputTools.GetUserInputFuelType();
            Console.WriteLine("Enter fuel amount in liters:");
            float inputFuelAmountInLiters = ConsoleInputTools.GetUserInputFloatWithMinimum(k_MinimumFuelAmountInLiters);

            try
            {
                sr_GarageManagementLogic.FuelUpGasolineBasedVehicleInGarage(
                    inputRegistrationPlateId,
                    inputFuelType,
                    inputFuelAmountInLiters);
                Console.WriteLine("Fueling successful!");
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine("Fuel amount to add exceeds the maximum fuel amount");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void chargeElectricVehicleInGarage()
        {
            const float k_MinimumChargeTimeInMinutes = 0;
            string inputRegistrationPlateId = ConsoleInputTools.GetUserInputRegistrationPlateId();

            Console.WriteLine("Enter charge time in minutes:");
            float inputChargeTimeInMinutes = ConsoleInputTools.GetUserInputFloatWithMinimum(k_MinimumChargeTimeInMinutes);

            try
            {
                sr_GarageManagementLogic.ChargeElectricVehicleInGarage(
                    inputRegistrationPlateId,
                    inputChargeTimeInMinutes);
                Console.WriteLine("Charging successful!");
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine("Charge time to add exceeds the maximum charge amount");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void showSpecificVehicleInGarageDetails()
        {
            string inputRegistrationPlateId = ConsoleInputTools.GetUserInputRegistrationPlateId();

            try
            {
                Dictionary<string, string> detailsDictionary =
                    sr_GarageManagementLogic.GetSpecificVehicleInGarageDetails(inputRegistrationPlateId);

                foreach (KeyValuePair<string, string> pair in detailsDictionary)
                {
                    Console.WriteLine($"{pair.Key}: {pair.Value}");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}