// <copyright  file="Engine.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Core
{
    using System;
    using BullsAndCows.Helpers.Readers;
    using Helpers;
    using Helpers.Misc;
    using Interfaces;

    /// <summary>
    /// Application Engine
    /// </summary>
    internal class Engine : IEngine, IRunnable
    {
        public bool ReadyToRun { get; set; }

        public IDataState Data { get; set; }

        public IActionsReader ActionsReader { get; set; }

        public IController Controller { get; set; }

        public IScoreboard Scoreboard { get; set; }

        public IScoreNotifier Notifier { get; set; }

        public INumberGenerator NumberGenerator { get; set; }

        public ICommandsFactory CommandsFactory { get; set; }

        /// <summary>
        /// Initializes the application
        /// </summary>
        public void Initialize()
        {
            this.Data = new Data();
            this.ActionsReader = new ConsoleReader();
            this.Notifier = new ConsoleNotifier();
            this.NumberGenerator = new RandomNumberGenerator();
            this.Scoreboard = new Scoreboard(this.Notifier, ScoreSerializer.GetSerializer(), new PlayerNameReader());
            this.CommandsFactory = new CommandsFactory(this.Data, this.Notifier, this.NumberGenerator, this.Scoreboard);
            this.Controller = new ActionsController(this.Data, this.Notifier, this.NumberGenerator, this.Scoreboard, this.CommandsFactory, this.ActionsReader);
            this.ReadyToRun = true;
        }

        /// <summary>
        /// Runs the actions controller
        /// </summary>
        public void Run()
        {
            if (this.ReadyToRun)
            {
                this.Controller.Run();
            }
            else
            {
                throw new ArgumentException("Initialize() method was not called. In order to run the engine - you must first initialize all of its properties.");
            }
        }
    }
}
