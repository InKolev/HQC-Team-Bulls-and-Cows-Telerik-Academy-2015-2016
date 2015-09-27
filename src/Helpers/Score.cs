namespace BullsAndCows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Score: IComparable<Score>
    {
        public int NumberOfGuesses { get; set; }

        public string PlayerName { get; set; }

        public int CompareTo(Score otherScore)
        {
            return this.NumberOfGuesses.CompareTo(otherScore.NumberOfGuesses);
        }

        public override string ToString()
        {
            return this.PlayerName + " : " + this.NumberOfGuesses;
        }
    }
}
