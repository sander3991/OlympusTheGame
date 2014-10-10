using System;
using System.Collections.Generic;
using System.Drawing;
using Olympus_the_Game.Controller;
using Olympus_the_Game.Model;
using Olympus_the_Game.Properties;

namespace Olympus_the_Game.View.Imaging
{
    public class DataPool
    {
        /// <summary>
        /// Source images
        /// </summary>
        private static readonly Dictionary<ObjectType, Sprite> source = new Dictionary<ObjectType, Sprite>();

        /// <summary>
        /// Buffer of all images
        /// </summary>
        private static readonly Dictionary<Tuple<ObjectType, Size>, Sprite> images =
            new Dictionary<Tuple<ObjectType, Size>, Sprite>();

        public static string gameSound { get; private set; }

        public static string IntroSound { get; private set; }

        /// <summary>
        /// Voegt alle plaatjes toe aan de bron-dictionary.
        /// </summary>
        public static void LoadDataPool()
        {
            source.Add(ObjectType.CREEPER, Resources.creeper);
            source.Add(ObjectType.EXPLODE, Resources.tnt);
            source.Add(ObjectType.SLOWER, Resources.spider);
            source.Add(ObjectType.WEB, Resources.cobweb);
            source.Add(ObjectType.Player, new Sprite(Resources.player2, 2, 1, false));
            source.Add(ObjectType.TIMEBOMB, new Sprite(Resources.timebomb, 2, 1, true));
            source.Add(ObjectType.START, Resources.huis);
            source.Add(ObjectType.FINISH, Resources.cake);
            source.Add(ObjectType.OBSTACLE, Resources.cobble);
            source.Add(ObjectType.UNKNOWN, Resources.missing);
            source.Add(ObjectType.SILVERFISH, Resources.missing);
            source.Add(ObjectType.GHAST, Resources.ghast);
            source.Add(ObjectType.FIREBALL, Resources.fireball);
            source.Add(ObjectType.SPRITEEXPLOSION, new Sprite(Resources.explosion, 5, 5, false));
            source.Add(ObjectType.WEBMISSILE, Resources.cobweb);
            gameSound = Mp3Player.PrepareResource(Resources.HakunaMatata, "HakunaMatata");
            IntroSound = Mp3Player.PrepareResource(Resources.StarWars, "StarWars");
        }

        /// <summary>
        /// Maakt een gescalede image aan
        /// </summary>
        /// <param name="o">Het <code>ObjectType</code> van het plaatje</param>
        /// <param name="s">De grootte van het plaatje</param>
        /// <param name="index">De index van het plaatje, -1 is een static plaatje</param>
        /// <returns></returns>
        private static Sprite CreateImage(ObjectType o, Size s)
        {
            // Get source image
            Sprite result;
            source.TryGetValue(o, out result);

            // Check for null
            if (result == null)
                return null;

            // Check type
            if (result.Frames == -1) // 1 image
            {
                return new Bitmap(result.Image, s);
            }
            return new Sprite(
                new Bitmap(result.Image,
                    new Size(s.Width*result.Columns, s.Height*result.Rows)
                    ),
                result.Columns, result.Rows, result.Cyclic);
        }

        /// <summary>
        /// Geeft de Sprite terug voor het gegeven ObjectType.
        /// </summary>
        /// <param name="o"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Sprite GetPicture(ObjectType o, Size s)
        {
            // Define get result
            Sprite result;

            // Try to get
            images.TryGetValue(new Tuple<ObjectType, Size>(o, s), out result);

            // Check if result
            if (result != null)
                return result;

            // No result, so create
            result = CreateImage(o, s);
            images.Add(new Tuple<ObjectType, Size>(o, s), result);

            // Return new image
            return result;
        }

        /// <summary>
        /// Leegt de cache van deze pool.
        /// </summary>
        public static void ClearImagePool()
        {
            images.Clear();
        }

        public static void UnloadDataPool()
        {
            Mp3Player.UnloadResource(gameSound);
            Mp3Player.UnloadResource(IntroSound);
        }
    }
}