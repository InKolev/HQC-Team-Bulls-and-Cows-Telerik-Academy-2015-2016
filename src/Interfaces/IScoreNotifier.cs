namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;
    using Helpers;

    public interface IScoreNotifier : INotifier
    {
        void DisplayScores(IList<Score> scores);
    }
}
