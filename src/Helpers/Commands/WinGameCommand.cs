using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers
{
    internal class WinGameCommand : ICommand
    {
        public WinGameCommand(INotifier notifier, IScoreboard scoreboard, IDataState data)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
        }

        public bool Execute()
        {
            this.Notifier.Notify("Congratulations! You have guessed the secret number.");

            if (!this.Data.HasCheated)
            {
                this.Scoreboard.AddToScoreboard(this.Data.GuessAttempts);
            }

            return false;
        }

        private IScoreboard Scoreboard { get; set; }

        private INotifier Notifier { get; set; }

        private IDataState Data { get; set; }
    }
}
