namespace BullsAndCows.Helpers.Commands
{
    using System;
    using Interfaces;

    internal class InitializeGameCommand : ICommand
    {
        public InitializeGameCommand(IDataState data, INotifier notifier, INumberGenerator numberGenerator)
        {
            this.Data = data;
            this.Data.StartTime = DateTime.Now;
            this.Notifier = notifier;
            this.NumberGenerator = numberGenerator;
        }

        public IDataState Data { get; private set; }

        public INotifier Notifier { get; private set; }

        public INumberGenerator NumberGenerator { get; private set; }

        public bool Execute()
        {
            this.Notifier.Notify("IntroductionCall");
            this.Notifier.Notify("CommandsCall");
            this.Notifier.Notify("New game started. Wish you luck.");

            this.Data.GuessAttemptsMaxValue = 25;
            this.Data.NumberToGuess = this.NumberGenerator.GenerateNumber(4);
            this.Data.GuessAttempts = 1;

            this.Data.CheatHelper = "XXXX";
            this.Data.HasCheated = false;

            return true;
        }
    }
}
