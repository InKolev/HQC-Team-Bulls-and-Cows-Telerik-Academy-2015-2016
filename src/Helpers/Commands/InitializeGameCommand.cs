// <copyright  file="InitializeGameCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using System;
    using Interfaces;

    internal class InitializeGameCommand : ICommand
    {
        private const string NotifierIntroCallMessage = "IntroductionCall";
        private const string NotifierCommandsCallMessage = "CommandsCall";
        private const string NotifierNewGameStartedMessage = "New game started. Wish you luck.";
        private const string CheatHelperInitialValue = "XXXX";

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
            this.Notifier.Notify(NotifierIntroCallMessage);
            this.Notifier.Notify(NotifierCommandsCallMessage);
            this.Notifier.Notify(NotifierNewGameStartedMessage);

            this.Data.GuessAttemptsMaxValue = 25;
            this.Data.NumberToGuess = this.NumberGenerator.GenerateNumber(4);
            this.Data.GuessAttempts = 1;

            this.Data.CheatHelper = CheatHelperInitialValue;
            this.Data.HasCheated = false;

            return true;
        }
    }
}
