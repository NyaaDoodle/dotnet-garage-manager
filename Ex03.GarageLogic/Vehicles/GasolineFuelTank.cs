using System;
using System.Collections.Generic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Garage;

namespace Ex03.GarageLogic.Vehicles
{
    internal class GasolineFuelTank
    {
        private float m_CurrentFuelAmountInLiters;
        private const float k_MinimumFuelAmountInLiters = 0;

        public eFuelType FuelTypeInTank { get; }

        public float MaximumFuelAmountInLiters { get; }

        public float CurrentFuelAmountInLiters
        {
            get
            {
                return m_CurrentFuelAmountInLiters;
            }
            set
            {
                if (value >= k_MinimumFuelAmountInLiters && value <= MaximumFuelAmountInLiters)
                {
                    m_CurrentFuelAmountInLiters = value;
                }
                else
                {
                    throwExceptionForFuelAmountOutOfRange();
                }
            }
        }

        public GasolineFuelTank(eFuelType i_FuelTypeInTank, float i_MaximumFuelAmountInLiters)
        { 
            const float k_DefaultCurrentFuelAmount = k_MinimumFuelAmountInLiters;

            FuelTypeInTank = i_FuelTypeInTank;
            MaximumFuelAmountInLiters = i_MaximumFuelAmountInLiters;
            CurrentFuelAmountInLiters = k_DefaultCurrentFuelAmount;
        }

        public void FuelUp(float i_FuelAmountToAddInLiters, eFuelType i_FuelType)
        {
            bool isFuelAmountBelowMinimum = i_FuelAmountToAddInLiters < k_MinimumFuelAmountInLiters;
            float newFuelAmountInLiters = CurrentFuelAmountInLiters + i_FuelAmountToAddInLiters;
            bool isCorrectFuelType = FuelTypeInTank == i_FuelType;
            bool isNewFuelAmountAboveMaximum = newFuelAmountInLiters > MaximumFuelAmountInLiters;

            if (isCorrectFuelType)
            {
                if (!isFuelAmountBelowMinimum && !isNewFuelAmountAboveMaximum)
                {
                    CurrentFuelAmountInLiters = newFuelAmountInLiters;
                }
                else
                {
                    throwExceptionForFuelAmountOutOfRange();
                }
            }
            else
            {
                throwExceptionForIncorrectFuelType(i_FuelType);
            }
        }

        public static ICollection<string> GetDefiningPropertiesNames()
        {
            LinkedList<string> definingPropertiesNames = new LinkedList<string>();

            definingPropertiesNames.AddLast(nameof(CurrentFuelAmountInLiters));

            return definingPropertiesNames;
        }

        public void SetDefiningProperties(DefiningPropertiesDictionary i_DefiningPropertiesDictionary)
        {
            float currentFuelAmountValue =
                i_DefiningPropertiesDictionary.GetParsedValueForDefiningProperty<float>(
                    nameof(CurrentFuelAmountInLiters));

            CurrentFuelAmountInLiters = currentFuelAmountValue;
        }

        private void throwExceptionForFuelAmountOutOfRange()
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