// <copyright  file="IValidator.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Interfaces
{
    /// <summary>
    /// Interface for validator
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Validates a name
        /// </summary>
        /// <param name="name">The name to be validated</param>
        /// <returns>If the name was validated</returns>
        bool ValidateName(string name);
    }
}
