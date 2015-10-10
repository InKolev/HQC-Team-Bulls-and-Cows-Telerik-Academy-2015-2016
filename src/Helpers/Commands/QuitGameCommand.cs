﻿
namespace BullsAndCows.Helpers.Commands
{
    using Interfaces;

    internal class QuitGameCommand : ICommand
    {
        public QuitGameCommand(INotifier notifier)
        {
            this.Notifier = notifier;
        }

        public INotifier Notifier { get; private set; }

        public bool Execute()
        {
            this.Notifier.Notify("Game finished.");
            return false;
        }
    }
}