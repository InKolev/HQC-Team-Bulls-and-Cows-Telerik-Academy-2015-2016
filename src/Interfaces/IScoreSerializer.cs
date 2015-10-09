namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;

    using Helpers;

    public interface IScoreSerializer
    {
        IList<Score> Load();

        void Save(IList<Score> data);
    }
}
