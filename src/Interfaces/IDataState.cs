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
        /// Gets or sets the cheat helper state
        /// </summary>
        string CheatHelper { get; set; }

        /// <summary>
        /// Gets or sets the number to guess
        /// </summary>
        string NumberToGuess { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user has cheated
        /// </summary>
        bool HasCheated { get; set; }

        /// <summary>
        /// Gets or sets the start time of the game
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the play time
        /// </summary>
        double PlayTime { get; set; }

        /// <summary>
        /// Gets or sets the number of guess attempts
        /// </summary>
        int GuessAttempts { get; set; }

        /// <summary>
        /// Gets or sets the maximal number of permitted guess attempts
        /// </summary>
        int GuessAttemptsMaxValue { get; set; }

        /// <summary>
        /// Gets or sets the number of bulls 
        /// </summary>
        int Bulls { get; set; }

        /// <summary>
        /// Gets or sets the number of cows
        /// </summary>
        int Cows { get; set; }
    }
}
