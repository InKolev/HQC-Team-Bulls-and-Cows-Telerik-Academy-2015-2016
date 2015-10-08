
namespace BullsAndCows.Helpers.Commands
{
    using BullsAndCows.Interfaces;

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