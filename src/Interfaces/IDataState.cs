// <copyright  file="IDataState.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    using System;

    /// <summary>
    /// Interface for the data state of the game
    /// </summary>
    public interface IDataState
    {
        /// <summary>
        /// Holds the cheat helper state
        /// </summary>
        string CheatHelper { get; set; }

        /// <summary>
        /// Holds the number to guess
        /// </summary>
        string NumberToGuess { get; set; }

        /// <summary>
        /// Holds info if the user has cheated
        /// </summary>
        bool HasCheated { get; set; }

        /// <summary>
        /// Holds the start time of the game
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Holds the play time
        /// </summary>
        double PlayTime { get; set; }

        /// <summary>
        /// Holds the number of guess attempts
        /// </summary>
        int GuessAttempts { get; set; }

        /// <summary>
        /// Holds the maximal number of permitted guess attempts
        /// </summary>
        int GuessAttemptsMaxValue { get; set; }

        /// <summary>
        /// Holds the number of bulls 
        /// </summary>
        int Bulls { get; set; }

        /// <summary>
        /// Holds the number of cows
        /// </summary>
        int Cows { get; set; }
    }
}
