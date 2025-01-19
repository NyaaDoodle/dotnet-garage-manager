using System;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Vehicles;

namespace Ex03.ConsoleUI
{
    public class ConsoleInputTools
    {
        private const string k_InvalidInputMessage = "Invalid input, please try again.";
        public static int GetUserInputInRange(int i_LowerBound, int i_UpperBound)
        {
            int inputNumber = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                string inputString = Console.ReadLine();
                bool isSuccessfulParse = int.TryParse(inputString, out inputNumber);
                if (isSuccessfulParse)
                {
                    if (inputNumber >= i_LowerBound && inputNumber <= i_UpperBound)
                    {
                        isValidInput = true;
                    }
                }

                if (!isValidInput)
                {
                    Console.WriteLine(k_InvalidInputMessage);
                }
            }

            return inputNumber;
        }

        public static eRepairState? GetUserInputRepairStateWithEmpty()
        {
            eRepairState? inputRepairState = null;
            bool isValidInput = false;

            while (!isValidInput)
            {
                string inputString = Console.ReadLine();
                if (inputString == String.Empty)
                {
                    isValidInput = true;
                }
                else
                {
                    bool isSuccessfulParse = tryParseRepairState(inputString, out eRepairState parsedRepairState);
                    if (isSuccessfulParse)
                    {
                        inputRepairState = parsedRepairState;
                        isValidInput = true;
                    }

                    if (!isValidInput)
                    {
                        Console.WriteLine(k_InvalidInputMessage);
                    }
                }
            }

            return inputRepairState;
        }

        public static eRepairState GetUserInputRepairState()
        {
            eRepairState inputRepairState = default;
            bool isValidInput = false;

            while (!isValidInput)
            {
                string inputString = Console.ReadLine();
                bool isSuccessfulParse = tryParseRepairState(inputString, out inputRepairState);
                if (isSuccessfulParse)
                {
                    isValidInput = true;
                }

                if (!isValidInput)
                {
                    Console.WriteLine(k_InvalidInputMessage);
                }
            }

            return inputRepairState;
        }

        public static string GetUserInputRegistrationPlateId()
        {
            Console.WriteLine("Enter registration plate ID:");

            return Console.ReadLine();
        }

        public static eFuelType GetUserInputFuelType()
        {
            eFuelType inputFuelType = default;
            bool isValidInput = false;

            while (!isValidInput)
            {
                string inputString = Console.ReadLine();
                bool isSuccessfulParse = tryParseFuelType(inputString, out inputFuelType);
                if (isSuccessfulParse)
                {
                    isValidInput = true;
                }

                if (!isValidInput)
                {
                    Console.WriteLine(k_InvalidInputMessage);
                }
            }

            return inputFuelType;
        }

        public static float GetUserInputFloatWithMinimum(float i_LowerBound)
        {
            float inputFloat = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                string inputString = Console.ReadLine();
                bool isSuccessfulParse = float.TryParse(inputString, out inputFloat);
                if (isSuccessfulParse)
                {
                    if (inputFloat >= i_LowerBound)
                    {
                        isValidInput = true;
                    }
                }

                if (!isValidInput)
                {
                    Console.WriteLine(k_InvalidInputMessage);
                }
            }

            return inputFloat;
        }

        private static bool tryParseRepairState(string i_InputString, out eRepairState o_RepairState)
        {
            const string k_InRepairsString = "in repairs";
            const string k_RepairedString = "repaired";
            const string k_PaidString = "paid";
            bool isSuccessfulParse = false;
            string lowercaseAndTrimmedInputString = i_InputString.Trim().ToLower();

            switch (lowercaseAndTrimmedInputString)
            {
                case k_InRepairsString:
                    o_RepairState = eRepairState.InRepairs;
                    isSuccessfulParse = true;
                    break;
                case k_RepairedString:
                    o_RepairState = eRepairState.Repaired;
                    isSuccessfulParse = true;
                    break;
                case k_PaidString:
                    o_RepairState = eRepairState.Paid;
                    isSuccessfulParse = true;
                    break;
                default:
                    o_RepairState = default;
                    isSuccessfulParse = false;
                    break;
            }

            return isSuccessfulParse;
        }

        private static bool tryParseFuelType(string i_InputString, out eFuelType o_FuelType)
        {
            const string k_Octan95String = "octan 95";
            const string k_Octan96String = "octan 96";
            const string k_Octan98String = "octan 98";
            const string k_SolerString = "soler";
            bool isSuccessfulParse = false;
            string lowercaseAndTrimmedInputString = i_InputString.Trim().ToLower();

            switch (lowercaseAndTrimmedInputString)
            {
                case k_Octan95String:
                    o_FuelType = eFuelType.Octan95;
                    isSuccessfulParse = true;
                    break;
                case k_Octan96String:
                    o_FuelType = eFuelType.Octan96;
                    isSuccessfulParse = true;
                    break;
                case k_Octan98String:
                    o_FuelType = eFuelType.Octan98;
                    isSuccessfulParse = true;
                    break;
                case k_SolerString:
                    o_FuelType = eFuelType.Soler;
                    isSuccessfulParse = true;
                    break;
                default:
                    o_FuelType = default;
                    isSuccessfulParse = false;
                    break;
            }

            return isSuccessfulParse;
        }
    }
}