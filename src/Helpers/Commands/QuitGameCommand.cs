// <copyright  file="QuitGameCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using Interfaces;

    /// <summary>
    /// The concrete implementation of ICommand for QuitGame command.
    /// </summary>
    internal class QuitGameCommand : ICommand
    {
        private const string GameFinishedMessage = "Game finished.";

        public QuitGameCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        public INotifier Notifier { get; private set; }

        /// <summary>
        /// The core logic for executing a Quit Game Command.
        /// </summary>
        /// <returns>Returns a boolean value - false</returns>
        public bool Execute()
        {
            this.Notifier.Notify(GameFinishedMessage);
            return false;
        }
    }
}
