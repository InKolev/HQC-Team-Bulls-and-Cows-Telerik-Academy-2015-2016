namespace BullsAndCows.Interfaces
{
    public interface IScoreboard
    {
        void DisplayTopScores();

        void AddToScoreboard(int guessAttempts, double playTime);
    }
}
