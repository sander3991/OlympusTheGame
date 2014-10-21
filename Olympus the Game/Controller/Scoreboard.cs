using System;
using System.Collections.Generic;
using Olympus_the_Game.Model;

namespace Olympus_the_Game.Controller
{
    public enum ScoreType
    {
        GameFinished,
        Time,
        Health,
        Creeper,
        Slower,
        Explode,
        Ghast,
        Silverfish
    }
    /// <summary>
    /// Deze class houd de score bij die in het spel behaald is.
    /// </summary>
    internal static class Scoreboard
    {
        private static readonly Dictionary<ScoreType, int> Scorelist = new Dictionary<ScoreType, int>(); //Een dictionary om de score in bij te houden per ScoreType.

        static Scoreboard()
        {
            OlympusTheGame.OnNewPlayField += OlympusTheGame_OnNewPlayField; // Subscribe op het OnNewPlayField event om de score te resetten als er een nieuw speelveld wordt aangemaakt.
        }

        /// <summary>
        /// De huidige score van alle elementen.
        /// </summary>
        public static int Score
        {
            get
            {
                int totalScore = 0;
                foreach (int i in Scorelist.Values)
                {
                    totalScore += i;
                }
                return Math.Max(0, totalScore);
            }
        }
        /// <summary>
        /// Reset de score bij het aanmaken van een nieuw speelveld.
        /// </summary>
        /// <param name="obj"></param>
        private static void OlympusTheGame_OnNewPlayField(PlayField obj)
        {
            ResetScore();
        }

        /// <summary>
        /// Voeg een score toe met een custom waarde.
        /// </summary>
        /// <param name="type">Welk type score moet worden toegevoegd</param>
        /// <param name="i">Wat is de waarde die toegevoegd moet worden</param>
        public static void AddScore(ScoreType type, int i)
        {
            if (!Scorelist.ContainsKey(type))
                Scorelist[type] = 0;
            Scorelist[type] += i;
        }

        /// <summary>
        /// Haalt een score op van een bepaalde type.
        /// </summary>
        /// <param name="type">De type waarvan de score opgehaald moet worden</param>
        /// <returns>De waarde van de score</returns>
        public static int GetScore(ScoreType type)
        {
            return Scorelist.ContainsKey(type) ? Scorelist[type] : 0;
        }

        /// <summary>
        /// Voeg de standaard waarde van een ScoreType toe
        /// </summary>
        /// <param name="type">ScoreType type wat er toegevoegd</param>
        public static void AddScore(ScoreType type)
        { //In deze method staan de standaard waarden voor de scoretypes. Dit kan als er tijd over is aangepast worden naar een oplossing die meer toegankelijk is.
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
                case ScoreType.Silverfish:
                    AddScore(type, 200);
                    break;
            }
        }
        /// <summary>
        /// Zet de score op 0.
        /// </summary>
        public static void ResetScore()
        {
            Scorelist.Clear();
        }
    }
}