// <copyright  file="Score.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

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
