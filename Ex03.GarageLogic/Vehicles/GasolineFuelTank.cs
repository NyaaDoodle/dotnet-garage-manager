using System;
using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineFuelTank
    {
        internal enum eFuelType : byte
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public eFuelType? FuelTypeInTank { get; set; }
        public float CurrentFuelAmountInLiters { get; private set; }
        public float MaximumFuelAmountInLiters { get; set; }
        private const float k_MinimumFuelAmountInLiters = 0;

        public GasolineFuelTank()
        {
            const float k_DefaultCurrentFuelAmount = k_MinimumFuelAmountInLiters;
            const float k_DefaultMaximumFuelAmount = k_MinimumFuelAmountInLiters;

            FuelTypeInTank = null;
            CurrentFuelAmountInLiters = k_DefaultCurrentFuelAmount;
            MaximumFuelAmountInLiters = k_DefaultMaximumFuelAmount;
        }

        public void FuelUp(float i_FuelAmountToAdd, eFuelType i_FuelTypeToAdd)
        {
            float newFuelAmount = CurrentFuelAmountInLiters + i_FuelAmountToAdd;

            if (newFuelAmount <= MaximumFuelAmountInLiters)
            {
                CurrentFuelAmountInLiters = newFuelAmount;
                FuelTypeInTank = i_FuelTypeToAdd;
            }
            else
            {
                throwExceptionForExceedingMaximumFuelAmount();
            }
        }

        private void throwExceptionForExceedingMaximumFuelAmount()
        {
            ValueOutOfRangeException valueOutOfRangeException = new ValueOutOfRangeException();

            valueOutOfRangeException.MinValue = k_MinimumFuelAmountInLiters;
            valueOutOfRangeException.MaxValue = MaximumFuelAmountInLiters;
            throw valueOutOfRangeException;
        }
    }
}