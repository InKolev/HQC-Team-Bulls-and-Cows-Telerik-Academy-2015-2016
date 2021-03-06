﻿// <copyright  file="CommandsFactory.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System;
    using Commands;
    using Interfaces;

    /// <summary>
    /// Commands Factory Class
    /// </summary>
    internal class CommandsFactory : ICommandsFactory
    {
        private const string FourDigitsPatternForRegex = "[0-9][0-9][0-9][0-9]";
        private const string MaxGuessesLimitMessage = "You have reached the maximum guess limit. You can't even finish a Bulls And Cows game. You are as dumb as you look...";
        private const string InputWarningMessage = "Please enter a 4-digit number or one of the commands: ";
       
        public CommandsFactory(IDataState data, INotifier notifier, INumberGenerator numberGenerator, IScoreboard scoreboard)
        {
            this.Data = data;
            this.Notifier = notifier;
            this.Scoreboard = scoreboard;
            this.NumberGenerator = numberGenerator;
            this.CommandsList = new Dictionary<string, ICommand>();
            this.FourDigitNumberPattern = new Regex(FourDigitsPatternForRegex);
        }

        public Dictionary<string, ICommand> CommandsList { get; private set; }

        public Regex FourDigitNumberPattern { get; private set; }

        public IDataState Data { get; private set; }

        public INotifier Notifier { get; private set; }

        public INumberGenerator NumberGenerator { get; private set; }

        public IScoreboard Scoreboard { get; private set; }

        /// <summary>
        /// Creates a command according to the user input
        /// </summary>
        /// <param name="command">Command to be created</param>
        /// <returns>The created command</returns>
        public ICommand GetCommand(string command)
        {
            if (!this.CommandsList.ContainsKey(command))
            {
                ICommand commandExecutor = null;

                switch (command)
                {
                    case "help":
                        {
                            commandExecutor = new CheatCommand(this.Data, this.Notifier, this.NumberGenerator);
                            break;
                        }

                    case "start":
                        {
                            commandExecutor = new InitializeGameCommand(this.Data, this.Notifier, this.NumberGenerator);
                            break;
                        }

                    case "commands":
                        {
                            commandExecutor = new DisplayCommandsListCommand(this.Notifier);
                            break;
                        }

                    case "top":
                        {
                            commandExecutor = new DisplayScoreboardCommand(this.Scoreboard);
                            break;
                        }

                    case "quit":
                        {
                            commandExecutor = new QuitGameCommand(this.Notifier);
                            break;
                        }

                    case "exit":
                        {
                            commandExecutor = new ExitGameCommand(this.Notifier);
                            break;
                        }

                    case "empty":
                        {
                            commandExecutor = new EmptyCommand();
                            break;
                        }

                    default:
                        {
                            commandExecutor = this.ProcessGuessAndReturnAppropriateCommand(command);
                            break;
                        }
                }

                this.CommandsList.Add(command, commandExecutor);

                return commandExecutor;
            }
            else
            {
                return this.CommandsList[command];
            }
        }

        /// <summary>
        /// Checks if the user input is correct and creates corresponding command
        /// </summary>
        /// <param name="command">User input command</param>
        /// <returns>The created command</returns>
        private ICommand ProcessGuessAndReturnAppropriateCommand(string command)
        {
            ICommand commandExecutor = null;

            if (this.FourDigitNumberPattern.IsMatch(command) && (command.Length == 4))
            {
                if (this.Data.GuessAttempts <= this.Data.GuessAttemptsMaxValue)
                {
                    if (command.Equals(this.Data.NumberToGuess))
                    {
                        commandExecutor = new WinGameCommand(this.Notifier, this.Scoreboard, this.Data);
                    }
                    else
                    {
                        commandExecutor = new GuessCommand(this.Data, this.Notifier, command);
                    }
                }
                else
                {
                    commandExecutor = new DisplayMessageCommand(this.Notifier, false, MaxGuessesLimitMessage);
                }
            }
            else
            {
                commandExecutor = new DisplayMessageCommand(this.Notifier, true, InputWarningMessage);
            }

            return commandExecutor;
        }
    }
}
