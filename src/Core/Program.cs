using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Core
{
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
