
namespace BullsAndCows.Helpers.Commands
{
    using BullsAndCows.Interfaces;

    internal class DisplayCommandsListCommand : ICommand
    {
        public INotifier Notifier { get; private set; }

        public DisplayCommandsListCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        public bool Execute()
        {
            this.Notifier.Notify("CommandsCall");

            return true;
        }
    }
}
