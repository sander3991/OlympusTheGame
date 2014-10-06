using Olympus_the_Game.View.Imaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Olympus_the_Game.View
{
    public class ImagePool
    {
        /// <summary>
        /// Source images
        /// </summary>
        private static Dictionary<ObjectType, Sprite> source = new Dictionary<ObjectType, Sprite>();

        /// <summary>
        /// Buffer of all images
        /// </summary>
        private static Dictionary<Tuple<ObjectType, Size>, Sprite> images = new Dictionary<Tuple<ObjectType, Size>, Sprite>();

        /// <summary>
        /// Voegt alle plaatjes toe aan de bron-dictionary.
        /// </summary>
        static ImagePool()
        {
            source.Add(ObjectType.CREEPER, Properties.Resources.creeper);
            source.Add(ObjectType.EXPLODE, Properties.Resources.tnt);
            source.Add(ObjectType.SLOWER, Properties.Resources.spider);
            source.Add(ObjectType.WEB, Properties.Resources.cobweb);
            source.Add(ObjectType.PLAYER, Properties.Resources.player);
            source.Add(ObjectType.TIMEBOMB, Properties.Resources.timebomb);
            source.Add(ObjectType.HOME, Properties.Resources.huis);
            source.Add(ObjectType.CAKE, Properties.Resources.cake);
            source.Add(ObjectType.OBSTACLE, Properties.Resources.cobble);
            source.Add(ObjectType.UNKNOWN, Properties.Resources.missing);
            source.Add(ObjectType.SILVERFISH, Properties.Resources.missing);
            source.Add(ObjectType.GHAST, Properties.Resources.ghast);
            source.Add(ObjectType.FIREBALL, Properties.Resources.fireball);
            source.Add(ObjectType.SPRITEEXPLOSION, new Sprite(Properties.Resources.explosion, 5, 5, false));
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
            Sprite result = null;
            source.TryGetValue(o, out result);

            // Check for null
            if (result == null)
                return result;

            // Check type
            if (result.Frames == -1) // 1 image
            {
                return new Bitmap(result.Image, s);
            }
            else // multiple images
            {
                return new Sprite(
                    new Bitmap(result.Image,
                        new Size(s.Width * result.Columns, s.Height * result.Rows)
                        ),
                        result.Columns, result.Rows, result.Cyclic);
            }

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
            Sprite result = null;

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
        public static void ClearPool()
        {
            images.Clear();
        }
    }
}
