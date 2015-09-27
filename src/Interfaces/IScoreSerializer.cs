namespace BullsAndCows.Interfaces
{
    using System.Collections.Generic;

    using Helpers;

    public interface IScoreSerializer
    {
        ICollection<Score> Load();

        void Save(ICollection<Score> data);
    }
}
