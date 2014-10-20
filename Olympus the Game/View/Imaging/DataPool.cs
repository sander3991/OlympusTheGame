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
            Source.Add(ObjectType.Creeper, Resources.creeper);
            Source.Add(ObjectType.Explode, Resources.tnt);
            Source.Add(ObjectType.Slower, Resources.spider);
            Source.Add(ObjectType.Web, Resources.cobweb);
            Source.Add(ObjectType.Player, new Sprite(Resources.player2, 2, 1, false));
            Source.Add(ObjectType.Timebomb, new Sprite(Resources.timebomb, 2, 1, true));
            Source.Add(ObjectType.Start, Resources.huis);
            Source.Add(ObjectType.Finish, Resources.cake);
            Source.Add(ObjectType.Obstacle, Resources.cobble);
            Source.Add(ObjectType.Unknown, Resources.missing);
            Source.Add(ObjectType.Silverfish, Resources.silverfish);
            Source.Add(ObjectType.Ghast, Resources.ghast);
            Source.Add(ObjectType.Fireball, Resources.fireball);
            Source.Add(ObjectType.Spriteexplosion, new Sprite(Resources.explosion, 5, 5, false));
            Source.Add(ObjectType.Webmissile, Resources.cobweb);
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
                    new Size(s.Width * result.Columns, s.Height * result.Rows)
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