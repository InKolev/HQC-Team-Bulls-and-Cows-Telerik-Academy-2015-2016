// <copyright  file="RandomNumberGenerator.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Misc
{
    using System;
    using System.Text;
    using Interfaces;

    /// <summary>
    /// Class for creating random numbers
    /// </summary>
    internal class RandomNumberGenerator : INumberGenerator
    {
        public RandomNumberGenerator()
        {
            this.RandomGenerator = new Random();
        }

        private Random RandomGenerator { get; set; }

        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <param name="digits">The needed number of digits</param>
        /// <returns>String with the generated random number</returns>
        public string GenerateNumber(int digits)
        {
            var generatedNumber = new StringBuilder();

            while (generatedNumber.Length < digits)
            {
                var digit = this.RandomGenerator.Next(0, 10).ToString();

                if (!generatedNumber.ToString().Contains(digit))
                {
                    generatedNumber.Append(digit);
                }
            }

            return generatedNumber.ToString();
        }

        /// <summary>
        /// Generates a random number in a range
        /// </summary>
        /// <param name="minValue">Left border of the range</param>
        /// <param name="maxValue">Right border of the range</param>
        /// <returns>A random number</returns>
        public int Next(int minValue, int maxValue)
        {
            return this.RandomGenerator.Next(minValue, maxValue);
        }
    }
}
