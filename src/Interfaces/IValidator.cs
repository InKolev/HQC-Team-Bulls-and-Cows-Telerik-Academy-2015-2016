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
