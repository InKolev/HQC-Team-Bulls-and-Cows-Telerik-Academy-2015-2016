// <copyright  file="INumberGenerator.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    public interface INumberGenerator
    {
        string GenerateNumber(int digits);

        int Next(int minValue, int maxValue);
    }
}
