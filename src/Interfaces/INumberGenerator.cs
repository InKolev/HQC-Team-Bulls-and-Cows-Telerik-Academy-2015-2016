// <copyright  file="INumberGenerator.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    /// <summary>
    /// Interface for a number generator
    /// </summary>
    public interface INumberGenerator
    {
        /// <summary>
        /// Generates a number with a certain number of digits
        /// </summary>
        /// <param name="digits">Length of the number</param>
        /// <returns>String containing the generated number</returns>
        string GenerateNumber(int digits);

        /// <summary>
        /// Generates a number in a range
        /// </summary>
        /// <param name="minValue">Left border of the range</param>
        /// <param name="maxValue">Right border of the range</param>
        /// <returns>The generated number</returns>
        int Next(int minValue, int maxValue);
    }
}
