using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public enum ScoreType
    {
        GameFinished,
        Time,
        Health,
        Creeper,
        Slower,
        Explode,
        Ghast

    }

    static class Scoreboard
    {
        private static readonly Dictionary<ScoreType, int> score = new Dictionary<ScoreType, int>();
        static Scoreboard()
        {
            OlympusTheGame.OnNewPlayField += OlympusTheGame_OnNewPlayField;
        }

        static void OlympusTheGame_OnNewPlayField(PlayField obj)
        {
            ResetScore();
        }
        public static int Score
        {
            get
            {
                int totalScore = 0;
                foreach (int i in score.Values)
                {
                    totalScore += i;
                }
                return Math.Max(0, totalScore);
            }
            private set
            {

            }
        }

        public static void AddScore(ScoreType type, int i)
        {
            if (!score.ContainsKey(type))
                score[type] = 0;
            score[type] += i;
        }

        public static int GetScore(ScoreType type)
        {
            return score.ContainsKey(type) ? score[type] : 0;
        }

        public static void AddScore(ScoreType type)
        {
            switch (type)
            {
                case ScoreType.GameFinished:
                    AddScore(type, 10000);
                    break;
                case ScoreType.Time:
                    AddScore(type, -10);
                    break;
                case ScoreType.Health:
                    AddScore(type, 200);
                    break;
                case ScoreType.Creeper:
                    AddScore(type, 50);
                    break;
                case ScoreType.Slower:
                    AddScore(type, 50);
                    break;
                case ScoreType.Explode:
                    AddScore(type, 10);
                    break;
                case ScoreType.Ghast:
                    AddScore(type, 150);
                    break;
            }
        }

        public static void ResetScore()
        {
            score.Clear();
        }
    }
}
