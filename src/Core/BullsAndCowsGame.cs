using BullsAndCows.Core;
using BullsAndCows.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    internal class BullsAndCowsGame
    {
        static void Main()
        {
            var commander = new ActionsController();

            commander.StartNewGame(new ConsoleNotifier());

            while(true)
            {
                commander.ReadAction(new Scoreboard(), new ConsoleNotifier());
            }
        }
    }
}
