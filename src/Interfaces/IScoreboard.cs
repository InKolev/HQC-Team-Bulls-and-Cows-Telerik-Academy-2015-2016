// <copyright  file="IScoreboard.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    public interface IScoreboard
    {
        void DisplayTopScores();

        void AddToScoreboard(int guessAttempts, double playTime);
    }
}
