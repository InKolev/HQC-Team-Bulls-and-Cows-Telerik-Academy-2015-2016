// <copyright  file="DisplayCommandsListCommand.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers.Commands
{
    using BullsAndCows.Interfaces;

    internal class DisplayCommandsListCommand : ICommand
    {
        private const string NotifierCallMessage = "CommandsCall";

        public DisplayCommandsListCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        public INotifier Notifier { get; private set; }

        public bool Execute()
        {
            this.Notifier.Notify(NotifierCallMessage);

            return true;
        }
    }
}
