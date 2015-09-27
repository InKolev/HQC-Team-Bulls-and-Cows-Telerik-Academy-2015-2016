namespace BullsAndCows.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using BullsAndCows.Interfaces;
    using System.IO;

    internal class Serializer : ISerializer
    {
        private const string FilePath = @"../../scores.txt";

        public SortedList<int, string> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(SortedList<int, string> scores)
        {
            var writer = new StreamWriter(FilePath);

            using (writer)
            {

            }
        }
    }
}
