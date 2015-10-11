// <copyright  file="Program.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Program
    {
        public static void Main()
        {
            var engine = new Engine();
            engine.Initialize();
            engine.Run();
        }
    }
}
