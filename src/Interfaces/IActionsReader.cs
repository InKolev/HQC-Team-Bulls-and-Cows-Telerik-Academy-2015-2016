// <copyright  file="IActionsReader.cs" company="TA-HQC-Team-Bulls-And-Cows">
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
    /// Interface for the reader of the user's actions
    /// </summary>
    public interface IActionsReader
    {
        /// <summary>
        /// Reads the user's action
        /// </summary>
        /// <returns>User's action</returns>
        string Read();
    }
}
