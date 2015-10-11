// <copyright  file="RandomNumberGenerator.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Misc
{
    using System;
    using System.Text;
    using Interfaces;

    internal class RandomNumberGenerator : INumberGenerator
    {
        public RandomNumberGenerator()
        {
            this.RandomGenerator = new Random();
        }

        private Random RandomGenerator { get; set; }

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

        public int Next(int minValue, int maxValue)
        {
            return this.RandomGenerator.Next(minValue, maxValue);
        }
    }
}
