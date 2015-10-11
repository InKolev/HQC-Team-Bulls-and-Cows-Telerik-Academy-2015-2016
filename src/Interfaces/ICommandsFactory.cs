// <copyright  file="ICommandsFactory.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    /// <summary>
    /// Interface for the commands factory
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Creates a command based on a command string
        /// </summary>
        /// <param name="command">String containing the command</param>
        /// <returns>The created command</returns>
        ICommand GetCommand(string command);
    }
}
