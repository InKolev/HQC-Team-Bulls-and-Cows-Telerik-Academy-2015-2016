
namespace BullsAndCows.Core
{
    using System;
    using Interfaces;
    using BullsAndCows.Helpers.Commands;

    internal class ActionsController : IController, IRunnable
    {
        public ActionsController(IDataState data, INotifier notifier, INumberGenerator numberGenerator, IScoreboard scoreboard, ICommandsFactory commandsFactory, IActionsReader reader)
        {
            this.Data = data;
            this.ActionsReader = reader;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
            this.CommandsFactory = commandsFactory;
            this.NumberGenerator = numberGenerator;
        }

        public IActionsReader ActionsReader { get; set; }

        public INotifier Notifier { get; set; }

        public IScoreboard Scoreboard { get; set; }

        public ICommandsFactory CommandsFactory { get; set; }

        public INumberGenerator NumberGenerator { get; set; }

        public IDataState Data { get; set; }

        private bool ReadAction()
        {
            string input = String.Empty;

            this.Notifier.Notify("Enter your Guess/Command: ");

            this.ActionsReader.Read(out input);

            var command = this.CommandsFactory.GetCommand(input);

            bool isRunning = command.Execute();

            return isRunning;
        }

        public void Run()
        {
            this.CommandsFactory
                .GetCommand("start")
                .Execute();

            bool isRunning = true;

            while (true)
            {
                while (isRunning)
                {
                    isRunning = ReadAction();
                }

                this.Notifier.Notify("Would you like to play again? \"y\" or \"n\" ");

                string answer = String.Empty;

                this.ActionsReader.Read(out answer);

                if (answer.Equals("y") || answer.Equals("Y"))
                {
                    Run();
                }
                else if (answer.Equals("n") || answer.Equals("N"))
                {
                    break;
                }
            }
        }
    }
}
