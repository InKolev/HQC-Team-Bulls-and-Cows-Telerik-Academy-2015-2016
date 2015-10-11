// <copyright  file="ScoreSerializer.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers
{
    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.IO;
    using Interfaces;

    internal class ScoreSerializer : IScoreSerializer
    {
        private const string FilePath = @"../../scores.txt";
        private static ScoreSerializer instance;
        private static object syncLock = new object();

        protected ScoreSerializer()
        {
        }

        public static ScoreSerializer GetSerializer()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new ScoreSerializer();
                    }
                }
            }

            return instance;
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
                    int firstSeparator = currentLine.IndexOf(':');
                    int secondSeparator = currentLine.LastIndexOf(':');
                    string playerName = currentLine.Substring(0, firstSeparator - 1);
                    string playerGuesses = currentLine.Substring(firstSeparator + 2, secondSeparator - firstSeparator - 3);
                    int guesses = int.Parse(playerGuesses);
                    double time = double.Parse(currentLine.Substring(secondSeparator + 2, currentLine.Length - secondSeparator - 2), CultureInfo.InvariantCulture);

                    scores.Add(new Score(guesses, playerName, time));
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
                    writer.WriteLine(score.PlayerName + " : " + score.NumberOfGuesses + " : " + score.Time);
                }
            }
        }
    }
}
