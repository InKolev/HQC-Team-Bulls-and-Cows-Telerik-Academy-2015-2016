High-Quality Programming Code – Team Project
============================================

Sample Refactoring Documentation for Project “Bulls and Cows 5”                                                                                                                          
---------------------------------------------------------------

1.  Redesigned the project structure:
	-   Renamed the project to `BullsAndCows`.
	-   Renamed the main class `Program` to `BullsAndCowsGame`.
	
2.  Reformatted the source code:
	-   Removed all unneeded empty lines, e.g. in the method `ReadAction()`.
	-   Inserted empty lines between the methods, e.g. before the method `Cheat()`
	-   Split the lines containing several statements into several simple lines, e.g.:
	
	Before:
	
		while (ReadAction()) ;
		
	After:

		while (true)
            {
                ReadAction();
            }
			

	-   Formatted the curly braces **{** and **}** according to the best practices for the C\# language, e.g.:
	
	Before:
	
		static void ProcessWin() {
		...
		}
		
	After:
	
		static void ProcessWin() 
        {
		...
		}
	
	-   Put **{** and **}** after all conditionals and loops (when missing), e.g.:
	
	Before:
	
		for (int d = 0; d < 10; d++) digs[d] = 0;
		
	After:

		for (int d = 0; d < 10; d++)
            {
                digs[d] = 0;              
            }
	
	-   Simplified complex expressions, e.g.: 
	
	Before:
	
		for (int i = 0; i < 4; i++)
                 {
                     if (isBull[i] = snum[i] == sguess[i])
					 {
                         bulls++;
                     }
				 }
				 
	After:

		for (int i = 0; i < 4; i++)
                 {
                     if (snum[i] == sguess[i])
                     {
                         isBull[i] = true;
                         bulls++;
                     }
                 }       
		
	-   Character casing: variables and fields made **camelCase**; types and methods made **PascalCase**, e.g. "tryAddToScoreboard()" method renamed to "AddToScoreboard()"
	-   Removed unnecessary comments, e.g. "//tova mie purvata Csharp programa v jivota".
	-   Formatted all other elements of the source code according to the best practices introduced in the course “[High-Quality Programming Code](http://telerikacademy.com/Courses/Courses/Details/244)”.

3.  Renamed variables and methods:
	-   In the initial class `BullsAndCowsGame.cs`: `klasirane` to `scoreboard`;
	-	"rr" to "random";
	-	"patt" to "pattern";
	-	"notCheated" to "cheated" (with all corresponding logic);
	-	"number" to "numberToGuess";
	-	"attempts" to "guessAttempts";
	-	"name" to "topScorerName";
	-	"DisplayTop()" to "DisplayTopScores()";
	-	"ch" to "cheatHelper";
	-	"cha" to "cheatHelperChars";
	-	"digs" to "digits";
	-	"t" to "score".

4.  Introduced constants:
	-   `NUMBER_SIZE = 4`
	-   `IncorrectInputMessage = "Incorrect number. The guess cannot contain repeatable digits."`
	-   `PlayAgainMessage = "Would you like to play again? \"y\" or \"n\" "`
	-   `EnterCommandMessage = "Enter your Guess/Command: "`
	-   `NotifierIntroCallMessage = "IntroductionCall"`
	-   `NotifierCommandsCallMessage = "CommandsCall"`
	-   `NotifierNewGameStartedMessage = "New game started. Wish you luck."`
	-   `CheatHelperInitialValue = "XXXX"`
	-   `GameFinishedMessage = "Game finished."`
	-   `ExitGameMessage = "Exitting game..."`
	-   `FourDigitsPatternForRegex = "[0-9][0-9][0-9][0-9]"`
	-   `InputWarningMessage = "Please enter a 4-digit number or one of the commands: "`
	-   `MaxGuessesLimitMessage = "You have reached the maximum guess limit. You can't even finish a Bulls And Cows game. You are as dumb as you look..."`
	-   `EnterPlayerNameMessage = "Please enter your name for the scoreboard: "`
	-   `EmptyScoreboardMessage = "The scoreboard is empty."`

5.  Extracted all methods from the method in Program - Main() and introduced new interfaces, classes and methods.
6.  Newly created classes and design patterns implementations:
	Introduced class **ActionsController** and moved the Run and ReadUseInput functionalities in it.
	Introduced class **Data** which holds the core data which is required to process  user guesses and commands, and moved the corresponding functionalities in it.
	Introduced class **Engine** which is responsible for initializing all the Objects required for other classes to be constructed and used properly. The class also has a Run() method which starts the ActionsController after all of its properties have been initialized.
	Introduced **Program** class which is the Main entry point for the application.
	Introduced **Command** Pattern and the concrete classes and interfaces which follows his implementation requirements: **ICommand, CheatCommand, DisplayMessageCommand, DisplayScoreboardCommand, EmptyCommand, ExitGameCommand, GuessComand, InitializeGameCommand, QuitGameCommand and WinGameCommand**.
	Introduced **Factory** Pattern and the concrete classes and interfaces which follows his implementation requirements: **ICommandsFactory, CommandsFactory**.
	Introduced a class **RandomNumberGenerator** for generating the actual number that needs to be guessed. 
	Introduced a **Bridge** Pattern and the concrete classes and interfaces which follows his implementation requirements: INotifier, IReader, IValidator, IScoreboard, ConsoleNotifier, ConsoleReader, Scoreboard, NameValidator, etc.
	Introduced a **Flyweight** Pattern for the CommandsFactory class.
	Introduced a **Facade* Pattern for the Engine class. Hides the whole objects  Initialization logic inside the Initialize() Method.
	Introduced a **Strategy** Pattern for the Commands creation inside the CommandsFactory class.
	Introduced **LazyInitialization** Pattern for each command inside the CommandsFactory
	Introduced **Singleton** Pattern for the ScoreSerializer class.
	Introduced **Memento** Pattern for the Scoreboard class.
7.  Added unit tests to examinate the code's basic functionalities, corner cases and exceptions handling for most of the classes and interfaces. **Used MOQ framework** for testing cases where a User Input is required for the application to continue execution.