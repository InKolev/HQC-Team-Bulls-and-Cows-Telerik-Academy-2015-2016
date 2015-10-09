
namespace BullsAndCows.Core
{
    using System;
    using Interfaces;
    using BullsAndCows.Helpers.Commands;

    internal class ActionsController : IController
    {
        public ActionsController(IDataState data, INotifier notifier, IScoreboard scoreboard, INumberGenerator numberGenerator, ICommandsFactory commandsFactory)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
            this.CommandsFactory = commandsFactory;
            this.NumberGenerator = numberGenerator;
        }

        public INotifier Notifier { get; set; }

        public IScoreboard Scoreboard { get; set; }

        public ICommandsFactory CommandsFactory { get; set; }

        public INumberGenerator NumberGenerator { get; set; }

        public IDataState Data { get; set; }

        private bool ReadAction()
        {
            this.Notifier.Notify("Enter your Guess/Command: ");

            string input = Console.ReadLine().Trim();
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

                var answer = Console.ReadLine();

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
