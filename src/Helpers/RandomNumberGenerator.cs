namespace BullsAndCows.Helpers
{
    using Interfaces;
    using System;
    using System.Text;

    class RandomNumberGenerator : INumberGenerator
    {
        private Random RandomGenerator { get; set; }

        public RandomNumberGenerator()
        {
            this.RandomGenerator = new Random();
        }

        public string GenerateNumber(int digits)
        {
            var generatedNumber = new StringBuilder();
            
            while (generatedNumber.Length < digits)
            {
                var digit = this.RandomGenerator.Next(0, 10).ToString();

                if (!(generatedNumber.ToString().Contains(digit)))
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
