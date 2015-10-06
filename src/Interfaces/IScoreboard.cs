namespace BullsAndCows.Interfaces
{
    interface IScoreboard
    {
        void DisplayTopScores();

        void AddToScoreboard(int guessAttempts);
    }
}
