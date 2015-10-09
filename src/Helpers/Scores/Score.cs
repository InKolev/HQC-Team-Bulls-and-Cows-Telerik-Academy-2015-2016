namespace BullsAndCows.Helpers
{
    using System;

    public class Score
    {
        public Score(int guesses, string name, double time)
        {
            this.NumberOfGuesses = guesses;
            this.PlayerName = name;
            this.Time = time;
        }
             
        public int NumberOfGuesses { get; set; }

        public string PlayerName { get; set; }

        public double Time { get; set; }
    }
}
