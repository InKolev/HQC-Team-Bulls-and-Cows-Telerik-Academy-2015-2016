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
