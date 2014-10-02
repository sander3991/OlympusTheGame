using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Olympus_the_Game.View
{
    class ImagePool
    {
        /// <summary>
        /// Source images
        /// </summary>
        private static Dictionary<ObjectType, Bitmap> source = new Dictionary<ObjectType, Bitmap>();

        /// <summary>
        /// Buffer of all images
        /// </summary>
        private static Dictionary<Tuple<ObjectType, Size>, Bitmap> images = new Dictionary<Tuple<ObjectType, Size>, Bitmap>();

        static ImagePool()
        {
            source.Add(ObjectType.CREEPER, ConvertBitmap(Properties.Resources.creeper));
            source.Add(ObjectType.EXPLODE, ConvertBitmap(Properties.Resources.tnt));
            source.Add(ObjectType.SLOWER, ConvertBitmap(Properties.Resources.spider));
            source.Add(ObjectType.PLAYER, ConvertBitmap(Properties.Resources.player));
            source.Add(ObjectType.TIMEBOMB, ConvertBitmap(Properties.Resources.timebomb));
            source.Add(ObjectType.HOME, ConvertBitmap(Properties.Resources.huis));
            source.Add(ObjectType.CAKE, ConvertBitmap(Properties.Resources.cake));
            source.Add(ObjectType.OBSTACLE, ConvertBitmap(Properties.Resources.cobble));
            source.Add(ObjectType.UNKNOWN, ConvertBitmap(Properties.Resources.missing));
        }

        private static Bitmap ConvertBitmap(Bitmap b)
        {
            Bitmap result = new Bitmap(b.Width, b.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(b, 0, 0, b.Width, b.Height);
            return result;
        }

        private static Bitmap CreateImage(ObjectType o, Size s)
        {
            // Create result
            Bitmap result = new Bitmap(s.Width, s.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Bitmap original = null;
            source.TryGetValue(o, out original);

            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(original, 0, 0, s.Width, s.Height);
            return result;
        }

        public static Bitmap GetPicture(ObjectType o, Size s)
        {
            // Define get result
            Bitmap bm = null;

            // Try to get
            images.TryGetValue(new Tuple<ObjectType, Size>(o, s), out bm);

            // Check if result
            if (bm != null)
                return bm;

            // No result, so create
            Bitmap newImage = CreateImage(o, s);
            images.Add(new Tuple<ObjectType, Size>(o, s), newImage);
            
            // Return new image
            return newImage;
        }

        public static void ClearPool()
        {
            images.Clear();
        }
    }
}
