// <copyright  file="ActionsController.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Core
{
    using System;
    using Interfaces;
    using BullsAndCows.Helpers.Commands;

    /// <summary>
    /// Application Actions Controller 
    /// </summary>
    internal class ActionsController : IController, IRunnable
    {
        private const string EnterCommandMessage = "Enter your Guess/Command: ";
        private const string PlayAgainMessage = "Would you like to play again? \"y\" or \"n\" ";

        public ActionsController(IDataState data, INotifier notifier, INumberGenerator numberGenerator, IScoreboard scoreboard, ICommandsFactory commandsFactory, IActionsReader reader)
        {
            this.Data = data;
            this.ActionsReader = reader;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
            this.CommandsFactory = commandsFactory;
            this.NumberGenerator = numberGenerator;
        }

        public bool IsRunning { get; private set; }

        public IActionsReader ActionsReader { get; set; }

        public INotifier Notifier { get; set; }

        public IScoreboard Scoreboard { get; set; }

        public ICommandsFactory CommandsFactory { get; set; }

        public INumberGenerator NumberGenerator { get; set; }

        public IDataState Data { get; set; }

        /// <summary>
        /// Reads actions from user input
        /// </summary>
        public void ReadAction()
        {
            string input = string.Empty;

            this.Notifier.Notify(EnterCommandMessage);

            input = this.ActionsReader.Read();

            var command = this.CommandsFactory.GetCommand(input);

            this.IsRunning = command.Execute();
        }

        /// <summary>
        /// Runs the controller
        /// </summary>
        public void Run()
        {
            this.CommandsFactory
                .GetCommand("start")
                .Execute();

            this.IsRunning = true;

            while (true)
            {
                while (this.IsRunning)
                {
                    this.ReadAction();
                }

                this.Notifier.Notify(PlayAgainMessage);

                var answer = this.ActionsReader.Read();

                if (answer.Equals("y") || answer.Equals("Y"))
                {
                    this.Run();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
