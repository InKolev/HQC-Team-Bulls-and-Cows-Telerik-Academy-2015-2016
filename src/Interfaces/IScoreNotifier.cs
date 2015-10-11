// <copyright  file="IScoreNotifier.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;
    using Helpers;

    /// <summary>
    /// Interface for a score notifier
    /// </summary>
    public interface IScoreNotifier : INotifier
    {
        /// <summary>
        /// Displays the scores
        /// </summary>
        /// <param name="scores">List with the scores</param>
        void DisplayScores(IList<Score> scores);
    }
}
