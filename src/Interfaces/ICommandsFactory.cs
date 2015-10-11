// <copyright  file="ICommandsFactory.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface for the commands factory
    /// </summary>
    public interface ICommandsFactory
    {
        /// <summary>
        /// Creates a command
        /// </summary>
        /// <param name="command"></param>
        /// <returns>The created command</returns>
        ICommand GetCommand(string command);
    }
}
