// <copyright  file="DisplayScoreboardCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using BullsAndCows.Interfaces;

    /// <summary>
    /// The concrete implementation of display scoreboard command for ICommand interface.
    /// </summary>
    internal class DisplayScoreboardCommand : ICommand
    {
        public DisplayScoreboardCommand(IScoreboard scoreboard)
        {
            this.Scoreboard = scoreboard;
        }

        /// <summary>
        /// Gets the scoreboard object which holds the score data.
        /// </summary>
        public IScoreboard Scoreboard { get; private set; }

        /// <summary>
        /// The core logic for executing a DisplayScoreboard command.
        /// </summary>
        /// <returns>Returns a boolean value - true</returns>
        public bool Execute()
        {
            this.Scoreboard.DisplayTopScores();

            return true;
        }
    }
}