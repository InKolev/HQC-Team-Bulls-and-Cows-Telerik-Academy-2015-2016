namespace BullsAndCows.Helpers.Commands
{
    using BullsAndCows.Interfaces;
    using System;

    internal class WinGameCommand : ICommand
    {
        public WinGameCommand(INotifier notifier, IScoreboard scoreboard, IDataState data)
        {
            this.Data = data;
            this.Data.PlayTime = (DateTime.Now - this.Data.StartTime).TotalMinutes;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
        }

        public bool Execute()
        {
            this.Notifier.Notify("Congratulations! You have guessed the secret number.");

            if (!this.Data.HasCheated)
            {
                this.Scoreboard.AddToScoreboard(this.Data.GuessAttempts, this.Data.PlayTime);
            }

            return false;
        }

        private IScoreboard Scoreboard { get; set; }

        private INotifier Notifier { get; set; }

        private IDataState Data { get; set; }
    }
}
