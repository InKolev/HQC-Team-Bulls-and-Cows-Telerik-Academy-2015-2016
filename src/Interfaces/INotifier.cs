// <copyright  file="INotifier.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    /// <summary>
    /// Interface for a notifier
    /// </summary>
    public interface INotifier
    {
        /// <summary>
        /// Notifies the user
        /// </summary>
        /// <param name="message">Message to be send to the user</param>
        void Notify(string message);
    }
}
