namespace BullsAndCows.Helpers
{
    using Interfaces;
    using System;
    using System.Text;

    class RandomNumberGenerator : INumberGenerator
    {
        private Random RandomGenerator { get; set; }

        public string GenerateNumber(int digits)
        {
            var generatedNumber = new StringBuilder();
            this.RandomGenerator = new Random();

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
    }
}
