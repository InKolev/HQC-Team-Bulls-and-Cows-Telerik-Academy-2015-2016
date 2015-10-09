namespace BullsAndCows.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using Interfaces;

    //maybe make it singleton?
    internal class ScoreSerializer : IScoreSerializer
    {
        private const string FilePath = @"../../scores.txt";

        public ScoreSerializer()
        {
        }

        public IList<Score> Load()
        {
            List<Score> scores = new List<Score>();
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

                    scores.Add(new Score(guesses, playerName));
                    currentLine = reader.ReadLine();
                }
            }

            return scores;
        }

        public void Save(IList<Score> scores)
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
