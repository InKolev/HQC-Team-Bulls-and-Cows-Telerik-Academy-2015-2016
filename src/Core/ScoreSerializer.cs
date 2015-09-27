namespace BullsAndCows.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    using BullsAndCows.Interfaces;
    using Helpers;

    internal class ScoreSerializer : ISerializer
    {
        private const string FilePath = @"../../scores.txt";

        public IList<IComparable> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(IList<IComparable> scores)
        {
            var writer = new StreamWriter(FilePath);

            using (writer)
            {
                foreach (var score in scores)
                {
                    writer.WriteLine(score);
                }
            }
        }
    }
}
