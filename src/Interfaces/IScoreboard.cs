// <copyright  file="IScoreboard.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    /// <summary>
    /// Interface for a scoreboard
    /// </summary>
    public interface IScoreboard
    {
        /// <summary>
        /// Displays the top results
        /// </summary>
        void DisplayTopScores();

        /// <summary>
        /// Adds a top result to the scoreboard 
        /// </summary>
        /// <param name="guessAttempts">Number of guess attempts</param>
        /// <param name="playTime">Played time</param>
        void AddToScoreboard(int guessAttempts, double playTime);
    }
}
