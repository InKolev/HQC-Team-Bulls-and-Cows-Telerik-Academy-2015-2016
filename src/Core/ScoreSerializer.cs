namespace BullsAndCows.Core
{
    using System.Collections.Generic;
    using System.IO;

    using Interfaces;
    using Helpers;

    //maybe make it singleton?
    internal class ScoreSerializer : IScoreSerializer
    {
        private const string FilePath = @"../../scores.txt";

        public ScoreSerializer()
        {
        }

        public List<Score> Load()
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

        public void Save(List<Score> scores)
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
