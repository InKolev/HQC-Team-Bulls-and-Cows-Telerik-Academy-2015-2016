namespace BullsAndCows.Helpers
{
    using System;

    public class Score : IComparable
    {
        public int NumberOfGuesses { get; set; }

        public string PlayerName { get; set; }

        public Score(int guesses, string name)
        {
            this.NumberOfGuesses = guesses;
            this.PlayerName = name;
        }

        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var otherScore = obj as Score;

            return this.NumberOfGuesses.CompareTo(otherScore.NumberOfGuesses);
        }

        public override string ToString()
        {
            return this.PlayerName + " : " + this.NumberOfGuesses;
        }
    }
}
