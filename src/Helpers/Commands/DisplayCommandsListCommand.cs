// <copyright  file="DisplayCommandsListCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using BullsAndCows.Interfaces;

    /// <summary>
    /// The concrete implementation for Display Commands List command.
    /// </summary>
    internal class DisplayCommandsListCommand : ICommand
    {
        private const string NotifierCallMessage = "CommandsCall";

        public DisplayCommandsListCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        /// <summary>
        /// Gets the object that is used for notification the user for the current changes.
        /// </summary>
        public INotifier Notifier { get; private set; }

        /// <summary>
        /// The core logic for executing the display commands list command.
        /// </summary>
        /// <returns>Boolean value - true</returns>
        public bool Execute()
        {
            this.Notifier.Notify(NotifierCallMessage);

            return true;
        }
    }
}
