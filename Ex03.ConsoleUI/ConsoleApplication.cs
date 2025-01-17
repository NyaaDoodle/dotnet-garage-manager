using System;

namespace Ex03.ConsoleUI
{
    public class ConsoleApplication
    {
        public static void StartApplication()
        {
            showTitle();
            while (true)
            {
                showMainMenu();
            }
        }

        private static void showTitle()
        {
            Console.WriteLine("Welcome to the Garage!");
            Console.WriteLine();
        }

        private static void showMainMenu()
        {
            string[] menuOptionsStrings =
                {
                    "Add a new vehicle to the garage",
                    "Show all vehicles in the garage",
                    "Change state of vehicle in the garage",
                    "Inflate a vehicle's wheels to maximum air pressure in the garage",
                    "Fuel up a gasoline based vehicle in the garage",
                    "Charge up an electric vehicle in the garage",
                    "Show details of a vehicle in the garage"
                };
            int currentOptionNumber = 1;

            foreach (string optionString in menuOptionsStrings)
            {
                Console.WriteLine($"({currentOptionNumber}) {optionString}");
                currentOptionNumber++;
            }
        }

        private static void addNewVehicleToGarage()
        {

        }

        private static void showRegistrationPlateIdsOfVehiclesInGarageList()
        {

        }

        private static void changeRepairStateOfVehicleInGarage()
        {

        }

        private static void inflateVehicleWheelsToMaximumAirPressureLevel()
        {

        }

        private static void fuelUpGasolineBasedVehicleInGarage()
        {

        }

        private static void chargeElectricVehicleInGarage()
        {

        }

        private static void showSpecificVehicleInGarageDetails()
        {

        }
    }
}