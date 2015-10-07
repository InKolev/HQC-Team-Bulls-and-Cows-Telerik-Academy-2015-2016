namespace BullsAndCows.Core
{
    using BullsAndCows.Interfaces;

    internal class Data : IDataState
    {
        public string CheatHelper { get; set; }

        public string NumberToGuess { get; set; }

        public bool HasCheated { get; set; }

        public int GuessAttempts { get; set; }

        public int GuessAttemptsMaxValue { get; set; }

        public int Bulls { get; set; }

        public int Cows { get; set; }
    }
}
