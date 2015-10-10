namespace BullsAndCows.Interfaces
{
    public interface IController
    {
        INotifier Notifier { get; set; }

        IActionsReader ActionsReader { get; set; }

        void ReadAction();

        void Run();
    }
}
