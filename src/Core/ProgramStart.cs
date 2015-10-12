// <copyright  file="Program.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Core
{
    /// <summary>
    /// Main Entry Point for the Application
    /// </summary>
    internal class ProgramStart
    {
        /// <summary>
        /// The Main Entry Point for the Application
        /// </summary>
        public static void Main()
        {
            var engine = new Engine();
            engine.Initialize();
            engine.Run();
        }
    }
}
