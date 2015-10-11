// <copyright  file="WinGameCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using System;
    using BullsAndCows.Interfaces;

    internal class WinGameCommand : ICommand
    {
        private const string CongratsMessage = "Congratulations! You have guessed the secret number.";

        public WinGameCommand(INotifier notifier, IScoreboard scoreboard, IDataState data)
        {
            this.Data = data;
            this.Data.PlayTime = (DateTime.Now - this.Data.StartTime).TotalMinutes;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
        }

        private IScoreboard Scoreboard { get; set; }

        private INotifier Notifier { get; set; }

        private IDataState Data { get; set; }

        public bool Execute()
        {
            this.Notifier.Notify(CongratsMessage);

            if (!this.Data.HasCheated)
            {
                this.Scoreboard.AddToScoreboard(this.Data.GuessAttempts, this.Data.PlayTime);
            }

            return false;
        }
    }
}
