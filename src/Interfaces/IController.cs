// <copyright  file="IController.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    /// <summary>
    /// Interface for the actions controller
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Notifier for the user
        /// </summary>
        INotifier Notifier { get; set; }

        /// <summary>
        /// Reader of the user's actions
        /// </summary>
        IActionsReader ActionsReader { get; set; }

        /// <summary>
        /// Reads user's next action
        /// </summary>
        void ReadAction();

        /// <summary>
        /// Runs the controller
        /// </summary>
        void Run();
    }
}
