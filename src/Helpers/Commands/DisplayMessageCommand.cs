// <copyright  file="DisplayMessageCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using BullsAndCows.Interfaces;

    /// <summary>
    /// The concrete implementation for display message command.
    /// </summary>
    internal class DisplayMessageCommand : ICommand
    {
        /// <summary>
        /// The constructor for display message command which accepts a notifier, a boolean value to be returned from the Execute method, and a message.
        /// </summary>
        /// <param name="notifier"></param>
        /// <param name="returnValue"></param>
        /// <param name="message"></param>
        public DisplayMessageCommand(INotifier notifier, bool returnValue, string message)
        {
            this.Notifier = notifier;
            this.Message = message;
            this.ReturnValue = returnValue;
        }

        public bool ReturnValue { get; private set; }

        public string Message { get; private set; }

        public INotifier Notifier { get; private set; }

        public bool Execute()
        {
            this.Notifier.Notify(this.Message);
            return this.ReturnValue;
        }
    }
}
