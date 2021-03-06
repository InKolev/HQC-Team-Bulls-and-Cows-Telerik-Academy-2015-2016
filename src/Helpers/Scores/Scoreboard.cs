﻿// <copyright  file="Scoreboard.cs" company="TA-HQC-Team-Bulls-And-Cows">
// All rights reserved.
// </copyright>
// <authors>vot24100, InKolev, mdraganov</authors>

namespace BullsAndCows.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    internal class Scoreboard : IScoreboard
    {
        private const byte TopPlayersDisplayCount = 10;
        private const string EnterPlayerNameMessage = "Please enter your name for the scoreboard: ";
        private const string EmptyScoreboardMessage = "The scoreboard is empty.";

        public Scoreboard(IScoreNotifier notifier, IScoreSerializer serializer, IActionsReader actionsReader)
        {
            this.Notifier = notifier;
            this.Serializer = serializer;
            this.ActionsReader = actionsReader;
            this.Scores = this.Serializer.Load();
            this.Scores = this.SortScores();
        }

        private IList<Score> Scores { get; set; }

        private IActionsReader ActionsReader { get; set; }

        private IScoreNotifier Notifier { get; set; }

        private IScoreSerializer Serializer { get; set; }

        public void AddToScoreboard(int guessAttempts, double playTime)
        {
            if (this.Scores.Count < TopPlayersDisplayCount || this.Scores[TopPlayersDisplayCount - 1].NumberOfGuesses > guessAttempts)
            {
                this.Notifier.Notify(EnterPlayerNameMessage);

                var playerName = this.ActionsReader.Read();

                Score playerScore = new Score(guessAttempts, playerName, playTime);
                this.Scores.Add(playerScore);
                this.Scores = this.SortScores();
                
                if (this.Scores.Count > TopPlayersDisplayCount)
                {
                    this.Scores.RemoveAt(this.Scores.Count - 1);
                }

                this.Serializer.Save(this.Scores);
            }
        }
        
        public void DisplayTopScores()
        {
            if (this.Scores.Count > 0)
            {
                this.Notifier.DisplayScores(this.Scores);
            }
            else
            {
                this.Notifier.Notify(EmptyScoreboardMessage);
            }
        }

        private IList<Score> SortScores()
        {
            return this.Scores.OrderBy(x => x.NumberOfGuesses).ThenBy(x => x.Time).ToList();
        }
    }
}
