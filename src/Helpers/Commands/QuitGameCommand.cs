// <copyright  file="QuitGameCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using Interfaces;

    internal class QuitGameCommand : ICommand
    {
        private const string GameFinishedMessage = "Game finished.";

        public QuitGameCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        public INotifier Notifier { get; private set; }

        public bool Execute()
        {
            this.Notifier.Notify(GameFinishedMessage);
            return false;
        }
    }
}
