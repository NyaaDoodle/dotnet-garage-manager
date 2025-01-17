using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineFuelTank
    {
        public eFuelType FuelTypeInTank { get; }
        public float CurrentFuelAmountInLiters { get; private set; }
        public float MaximumFuelAmountInLiters { get; set; }
        private const float k_MinimumFuelAmountInLiters = 0;

        public GasolineFuelTank(eFuelType i_FuelTankInTank)
        {
            const float k_DefaultCurrentFuelAmount = k_MinimumFuelAmountInLiters;
            const float k_DefaultMaximumFuelAmount = k_MinimumFuelAmountInLiters;

            FuelTypeInTank = i_FuelTankInTank;
            CurrentFuelAmountInLiters = k_DefaultCurrentFuelAmount;
            MaximumFuelAmountInLiters = k_DefaultMaximumFuelAmount;
        }

        public void FuelUp(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            float newFuelAmount = CurrentFuelAmountInLiters + i_FuelAmountToAdd;
            bool isCorrectFuelType = FuelTypeInTank == i_FuelType;
            bool isFuelAmountExceedsMaximumFuelAmount = newFuelAmount > MaximumFuelAmountInLiters;

            if (isCorrectFuelType)
            {
                if (!isFuelAmountExceedsMaximumFuelAmount)
                {
                    CurrentFuelAmountInLiters = newFuelAmount;
                }
                else
                {
                    throwExceptionForExceedingMaximumFuelAmount();
                }
            }
            else
            {
                throwExceptionForIncorrectFuelType(i_FuelType);
            }
        }

        private void throwExceptionForExceedingMaximumFuelAmount()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumFuelAmountInLiters;
            valueOutOfRangeException.MaxValue = MaximumFuelAmountInLiters;
            throw valueOutOfRangeException;
        }

        private void throwExceptionForIncorrectFuelType(eFuelType i_SuppliedFuelType)
        {
            string incorrectFuelTypeMessage =
                $"Fuel tank expects {FuelTypeInTank.ToString()}, received {i_SuppliedFuelType} instead.";
            throw new ArgumentException(incorrectFuelTypeMessage);
        }
    }
}