// <copyright  file="IController.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

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
