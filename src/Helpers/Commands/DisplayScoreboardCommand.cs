using System;
using BullsAndCows.Interfaces;

namespace BullsAndCows.Helpers
{
    internal class DisplayScoreboardCommand : ICommand
    {
        public DisplayScoreboardCommand(IScoreboard scoreboard)
        {
            this.Scoreboard = scoreboard;
        }

        public IScoreboard Scoreboard { get; private set; }

        public bool Execute()
        {
            this.Scoreboard.DisplayTopScores();

            return true;
        }
    }
}