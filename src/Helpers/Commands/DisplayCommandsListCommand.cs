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

        /// <summary>
        /// The constructor which accepts a notifier to display the commands list.
        /// </summary>
        /// <param name="notifier">The notifier object.</param>
        public DisplayCommandsListCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        /// <summary>
        /// The object that is used for notification the user for the current changes.
        /// </summary>
        public INotifier Notifier { get; private set; }

        /// <summary>
        /// The core logic for executing the display commands list command.
        /// </summary>
        /// <returns></returns>
        public bool Execute()
        {
            this.Notifier.Notify(NotifierCallMessage);

            return true;
        }
    }
}
