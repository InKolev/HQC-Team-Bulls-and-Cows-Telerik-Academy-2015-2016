﻿using BullsAndCows.Helpers;
using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Core
{
    internal class Engine
    {
        public static void Main()
        {
            INotifier notifier = new ConsoleNotifier();
            IScoreboard scoreboard = new Scoreboard(notifier);
            IController actionsController = new ActionsController(notifier, scoreboard);

            var bullsAndCows = new Game(actionsController);
            bullsAndCows.Start();
        }
    }
}
