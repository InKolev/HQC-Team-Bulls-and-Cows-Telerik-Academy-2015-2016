using BullsAndCows.Core;
using BullsAndCows.Helpers;
using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows.Core
{
    internal class Game
    {
        public Game(IController controller)
        {
            this.Controller = controller;
        }

        private IController Controller { get; set; }

        public void Start()
        {
            this.Controller.Initialize();
            this.Controller.Run();
        }
    }
}
