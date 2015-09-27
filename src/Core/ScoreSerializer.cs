namespace BullsAndCows.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    using Interfaces;
    using Helpers;

    internal class ScoreSerializer : IScoreSerializer
    {
        private const string FilePath = @"../../scores.txt";

        public ICollection<Score> Load()
        {
            List<Score> result = new List<Score>();
            StreamReader reader = new StreamReader(FilePath);

            using (reader)
            {
                string currentLine = reader.ReadLine();

                while (currentLine != null)
                {
                    int separatorIndex = currentLine.IndexOf(':');
                    string playerName = currentLine.Substring(0, separatorIndex - 1);
                    string playerGuesses = currentLine.Substring(separatorIndex + 2, currentLine.Length - separatorIndex - 2);
                    int guesses = int.Parse(playerGuesses);

                    result.Add(new Score(guesses, playerName));
                    currentLine = reader.ReadLine();
                }
            }

            return result;
        }

        public void Save(ICollection<Score> scores)
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
