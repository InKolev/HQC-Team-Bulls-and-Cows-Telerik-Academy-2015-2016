// <copyright  file="IScoreSerializer.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;

    using Helpers;

    /// <summary>
    /// Interface for a score serializer
    /// </summary>
    public interface IScoreSerializer
    {
        /// <summary>
        /// Loads the score serializer
        /// </summary>
        /// <returns>List of scores</returns>
        IList<Score> Load();

        /// <summary>
        /// Saves the scores
        /// </summary>
        /// <param name="data">List of scores</param>
        void Save(IList<Score> data);
    }
}
