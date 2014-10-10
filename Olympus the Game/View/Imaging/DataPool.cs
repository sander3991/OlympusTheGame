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
        private static readonly Dictionary<ObjectType, Sprite> Source = new Dictionary<ObjectType, Sprite>();

        /// <summary>
        /// Buffer of all images
        /// </summary>
        private static readonly Dictionary<Tuple<ObjectType, Size>, Sprite> Images =
            new Dictionary<Tuple<ObjectType, Size>, Sprite>();

        public static string GameSound { get; private set; }

        public static string IntroSound { get; private set; }

        /// <summary>
        /// Voegt alle plaatjes toe aan de bron-dictionary.
        /// </summary>
        public static void LoadDataPool()
        {
            Source.Add(ObjectType.CREEPER, Resources.creeper);
            Source.Add(ObjectType.EXPLODE, Resources.tnt);
            Source.Add(ObjectType.SLOWER, Resources.spider);
            Source.Add(ObjectType.WEB, Resources.cobweb);
            Source.Add(ObjectType.Player, new Sprite(Resources.player2, 2, 1, false));
            Source.Add(ObjectType.TIMEBOMB, new Sprite(Resources.timebomb, 2, 1, true));
            Source.Add(ObjectType.START, Resources.huis);
            Source.Add(ObjectType.FINISH, Resources.cake);
            Source.Add(ObjectType.OBSTACLE, Resources.cobble);
            Source.Add(ObjectType.UNKNOWN, Resources.missing);
            Source.Add(ObjectType.SILVERFISH, Resources.missing);
            Source.Add(ObjectType.GHAST, Resources.ghast);
            Source.Add(ObjectType.FIREBALL, Resources.fireball);
            Source.Add(ObjectType.SPRITEEXPLOSION, new Sprite(Resources.explosion, 5, 5, false));
            Source.Add(ObjectType.WEBMISSILE, Resources.cobweb);
            GameSound = Mp3Player.PrepareResource(Resources.HakunaMatata, "HakunaMatata");
            IntroSound = Mp3Player.PrepareResource(Resources.StarWars, "StarWars");
        }

        /// <summary>
        /// Maakt een gescalede image aan
        /// </summary>
        /// <param name="o">Het <code>ObjectType</code> van het plaatje</param>
        /// <param name="s">De grootte van het plaatje</param>
        /// <returns></returns>
        private static Sprite CreateImage(ObjectType o, Size s)
        {
            // Get source image
            Sprite result;
            Source.TryGetValue(o, out result);

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
            Images.TryGetValue(new Tuple<ObjectType, Size>(o, s), out result);

            // Check if result
            if (result != null)
                return result;

            // No result, so create
            result = CreateImage(o, s);
            Images.Add(new Tuple<ObjectType, Size>(o, s), result);

            // Return new image
            return result;
        }

        /// <summary>
        /// Leegt de cache van deze pool.
        /// </summary>
        public static void ClearImagePool()
        {
            Images.Clear();
        }

        public static void UnloadDataPool()
        {
            Mp3Player.UnloadResource(GameSound);
            Mp3Player.UnloadResource(IntroSound);
        }
    }
}