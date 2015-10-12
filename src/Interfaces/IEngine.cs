// <copyright  file="IEngine.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    /// <summary>
    /// Interface for the game engine
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Gets or sets the data state
        /// </summary>
        IDataState Data { get; set; }

        /// <summary>
        /// Gets or sets the game controller
        /// </summary>
        IController Controller { get; set; }

        /// <summary>
        /// Gets or sets the Scoreboard
        /// </summary>
        IScoreboard Scoreboard { get; set; }

        /// <summary>
        /// Gets or sets the notifier used
        /// </summary>
        IScoreNotifier Notifier { get; set; }

        /// <summary>
        /// Gets or sets the number generator 
        /// </summary>
        INumberGenerator NumberGenerator { get; set; }

        /// <summary>
        /// Gets or sets the commands factory
        /// </summary>
        ICommandsFactory CommandsFactory { get; set; }
    }
}
