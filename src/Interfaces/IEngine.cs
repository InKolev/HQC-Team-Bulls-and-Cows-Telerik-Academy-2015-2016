// <copyright  file="IEngine.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface for the game engine
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Holds the data state
        /// </summary>
        IDataState Data { get; set; }

        /// <summary>
        /// Holds the game controller
        /// </summary>
        IController Controller { get; set; }

        /// <summary>
        /// Holds the Scoreboard
        /// </summary>
        IScoreboard Scoreboard { get; set; }

        /// <summary>
        /// Holds the notifier used
        /// </summary>
        IScoreNotifier Notifier { get; set; }

        /// <summary>
        /// Holds the number generator 
        /// </summary>
        INumberGenerator NumberGenerator { get; set; }

        /// <summary>
        /// Holds the commands factory
        /// </summary>
        ICommandsFactory CommandsFactory { get; set; }
    }
}
