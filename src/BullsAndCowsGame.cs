using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BullsAndCows
{
    class BullsAndCowsGame
    {
        static int numberToGuess, guessAttempts;
        static bool cheated;
        static SortedList<int, string> scoreboard = new SortedList<int, string>();
        static Random random = new Random();
        static string cheatHelper;

        static void WriteAbout()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.");
        }

        private static void AddToScoreboard()
        {
            if (scoreboard.Count < 5 || scoreboard.ElementAt(4).Key > guessAttempts) 
            {
                Console.WriteLine("Please enter your name for the top scoreboard: ");
                string topScorerName = Console.ReadLine().Trim();
                scoreboard.Add(guessAttempts, topScorerName);

                if (scoreboard.Count == 6)
                {
                    scoreboard.RemoveAt(5);
                }                    

                DisplayTopScores();
            }
        }

        static void ProcessWin() 
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", guessAttempts);
            
            if (!cheated) 
            {
                AddToScoreboard();
            }

            StartNewGame();
        }

        static void ProcessGuess(int guess)
        {
            if (guess == numberToGuess)
            {
                ProcessWin();
            }
            else
            {
                string snum = numberToGuess.ToString(), sguess = guess.ToString();
                bool[] isBull = new bool[4];
                int bulls = 0, cows = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (snum[i] == sguess[i])
                    {
                        isBull[i] = true;
                        bulls++;
                    }
                }                  
                
                int[] digs = new int[10];

                for (int d = 0; d < 10; d++)
                {
                    digs[d] = 0;
                }
                                    
                for (int i = 0; i < 4; i++)
                {
                    if (!isBull[i])
                    {
                        digs[snum[i] - '0']++;
                    }                       
                }
                    
                for (int i = 0; i < 4; i++)
                {
                    if (!isBull[i])
                    {
                        if (digs[sguess[i] - '0'] > 0)
                        {
                            cows++;
                            digs[sguess[i] - '0']--;
                        }
                    }                    
                }

                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
                guessAttempts++;
            }
        }

        static void DisplayTopScores()
        {
            if (scoreboard.Count() > 0)
            {
                Console.WriteLine("Scoreboard:");
                int i = 1;
                
                foreach (var t in scoreboard)
                {
                    Console.WriteLine("{0}. {1} --> {2} guesses", i, t.Value, t.Key);
                }
            }
            else
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
        }
   
        static void StartNewGame() 
        {
            WriteAbout();
            numberToGuess = random.Next(1000, 10000);
            guessAttempts = 1;
            cheated = false;
            cheatHelper = "XXXX";
        }
     
        static void Cheat() 
        {
            cheated = true;

            if (cheatHelper.Contains('X')) 
            {
                int i;

                do 
                {
                    i = random.Next(0, 4);
                }                
                while (cheatHelper[i] != 'X');

                char[] cha = cheatHelper.ToCharArray();
                cha[i] = numberToGuess.ToString()[i];
                cheatHelper = new string(cha);
            }

            Console.WriteLine("The number looks like {0}.", cheatHelper);
        }

        static bool ReadAction()
        {
            Console.WriteLine("Enter your guess or command: ");
            string line = Console.ReadLine().Trim();
            Regex pattern = new Regex("[1-9][0-9][0-9][0-9]");
                    
            switch (line)
            {
                case "top":
                    DisplayTopScores();    
                    break;
                
                case "restart":
                    StartNewGame();
                    break;
                
                case "help":
                    Cheat();
                    break;
                
                case "exit":
                    return false;

                default:
                    if (pattern.IsMatch(line))
                    {
                        int guess = int.Parse(line);
                        ProcessGuess(guess);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a 4-digit number or");
                        Console.WriteLine("one of the commands: 'top', 'restart', 'help' or 'exit'.");
                    }

                    break;
            }

            return true;
        }

        static void Main()
        {
            StartNewGame();

            while (true)
            {
                ReadAction();
            }
        }
    }
}
