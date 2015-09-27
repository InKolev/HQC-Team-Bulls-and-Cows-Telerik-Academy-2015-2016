using BullsAndCows.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BullsAndCows.Helpers
{
    internal class ConsoleNotifier : INotifier
    {
        private int WindowWidth { get; set; } = Console.WindowWidth;

        private void DisplayStartMessage()
        {
            Console.WriteLine("A new game have started. Wish you luck.");
        }

        private void DisplayExitMessage()
        {
            Console.WriteLine("Exiting game...");
        }

        private void DisplayWinMessage()
        {
            Console.WriteLine("Congratulations! You have guessed the secret number.");
        }

        private void DisplayLoseMessage()
        {
            Console.WriteLine("You have reached the maximum guess limit. You can't even finish a Bulls And Cows game. You are as dumb as you look...");
        }

        private void DisplayEnterGuessOrCommandMessage()
        {
            Console.WriteLine("Enter your GUESS or a COMMAND to be executed: ");
        }

        private void DisplayScoreboardMessage()
        {
            Console.WriteLine("Scoreboard: ");
        }

        private void DisplayIntroductionMessage()
        {
            string welcomeMessage = "Welcome to “Bulls and Cows” game. Try to guess my secret 4-digit number. The digits inside the secret number cannot be repeated. Have fun!";

            Console.WriteLine(new String('*', this.WindowWidth - 1));
            Console.WriteLine(String.Format("{0} {1} {0}", new String('*', this.WindowWidth / 2 - welcomeMessage.Length / 2 - 2), welcomeMessage));
            Console.WriteLine(new String('*', this.WindowWidth - 1));
        }

        private void DisplayCommandsList()
        {
            Console.WriteLine("\"COMMANDS\" - to display the commands list.");
            Console.WriteLine("\"START\"    - to start a new game.");
            Console.WriteLine("\"EXIT\"     - to quit the game and close the application.");
            Console.WriteLine("\"HELP\"     - to unveil a random secret digit (if you want to be a cheater).");
            Console.WriteLine("\"TOP\"      - to view the top scoreboard.");
        }

        public void Notify(string messageType)
        {
            switch(messageType)
            {
                case "Guess":
                    {
                        DisplayEnterGuessOrCommandMessage();
                        break;
                    }
                case "Introduction":
                    {
                        DisplayIntroductionMessage();
                        break;
                    }
                case "Commands":
                    {
                        DisplayCommandsList();
                        break;
                    }
                case "Win":
                    {
                        DisplayWinMessage();
                        break;
                    }
                case "Lose":
                    {
                        DisplayLoseMessage();
                        break;
                    }
                case "Start":
                    {
                        DisplayStartMessage();
                        break;
                    }
                case "Exit":
                    {
                        DisplayExitMessage();
                        break;
                    }
                case "Scoreboard":
                    {
                        DisplayScoreboardMessage();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Nothing to notify.");
                        break;
                    }
            }
        }
    }
}
