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
        private static Dictionary<ObjectType, List<Bitmap>> dynamicSource = new Dictionary<ObjectType, List<Bitmap>>();

        /// <summary>
        /// Buffer of all images
        /// </summary>
        private static Dictionary<Tuple<ObjectType, Size>, Bitmap> images = new Dictionary<Tuple<ObjectType, Size>, Bitmap>();
        private static Dictionary<Tuple<ObjectType, Size>, List<Bitmap>> dynamicImages = new Dictionary<Tuple<ObjectType, Size>, List<Bitmap>>();

        static ImagePool()
        {
            AddStaticImage(ObjectType.CREEPER, Properties.Resources.creeper);
            AddStaticImage(ObjectType.EXPLODE, Properties.Resources.tnt);
            AddStaticImage(ObjectType.SLOWER, Properties.Resources.spider);
            AddStaticImage(ObjectType.PLAYER, Properties.Resources.player);
            AddStaticImage(ObjectType.TIMEBOMB, Properties.Resources.timebomb);
            AddStaticImage(ObjectType.HOME, Properties.Resources.huis);
            AddStaticImage(ObjectType.CAKE, Properties.Resources.cake);
            AddStaticImage(ObjectType.OBSTACLE, Properties.Resources.cobble);
            AddStaticImage(ObjectType.UNKNOWN, Properties.Resources.missing);

            AddDynamicImage(ObjectType.SPRITEEXPLOSION, CutupImage(Properties.Resources.explosion, 5, 5));
        }


        private static void AddStaticImage(ObjectType type, Bitmap bitmap)
        {
            source.Add(type, ConvertBitmap(bitmap));
        }

        private static void AddDynamicImage(ObjectType type, Bitmap bitmap)
        {
            List<Bitmap> bitmaps;
            if (dynamicSource.ContainsKey(type))
                bitmaps = dynamicSource[type];
            else
                bitmaps = new List<Bitmap>();
            bitmaps.Add(ConvertBitmap(bitmap));
            dynamicSource[type] = bitmaps;
        }

        private static void AddDynamicImage(ObjectType type, List<Bitmap> bitmaps)
        {
            for (int i = 0; i < bitmaps.Count; i++)
                AddDynamicImage(type, bitmaps[i]);
        }

        private static Bitmap ConvertBitmap(Bitmap b)
        {
            Bitmap result = new Bitmap(b.Width, b.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(b, 0, 0, b.Width, b.Height);
            return result;
        }

        /// <summary>
        /// Maakt een gescalede image aan
        /// </summary>
        /// <param name="o">Het <code>ObjectType</code> van het plaatje</param>
        /// <param name="s">De grootte van het plaatje</param>
        /// <param name="index">De index van het plaatje, -1 is een static plaatje</param>
        /// <returns></returns>
        private static Bitmap CreateImage(ObjectType o, Size s, int index)
        {
            // Create result
            Bitmap result = new Bitmap(s.Width, s.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Bitmap original = null;
            if (index == -1)
                original = source[o];
            else
                original = dynamicSource[o][index];
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(original, 0, 0, s.Width, s.Height);
            return result;
        }

        private static Bitmap CreateImage(ObjectType o, Size s)
        {
            return CreateImage(o, s, -1);
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

        public static Bitmap GetDynamicPicture(ObjectType o, Size s, int index)
        {
            // Define get result
            List<Bitmap> bm = null;

            // Try to get
            dynamicImages.TryGetValue(new Tuple<ObjectType, Size>(o, s), out bm);

            // Check if result
            if (bm != null)
                return bm[index % bm.Count];

            // No result, so create
            List<Bitmap> sprite = dynamicSource[o];
            List<Bitmap> newImages = new List<Bitmap>();
            for(int i = 0; i < sprite.Count; i++)
            {
                newImages.Add(CreateImage(o, s, i));
            }
            dynamicImages.Add(new Tuple<ObjectType, Size>(o, s), newImages);

            // Return new image
            return newImages[index % newImages.Count];
        }

        public static bool IsDynamic(ObjectType type)
        {
            return dynamicSource.ContainsKey(type);
        }

        public static void ClearPool()
        {
            images.Clear();
            dynamicImages.Clear();
        }

        private static List<Bitmap> CutupImage(Bitmap bitmap, int rows, int columns)
        {
            int width = bitmap.Width / columns;
            int height = bitmap.Height / rows;
            Rectangle targetRectangle = new Rectangle(0,0,width, height);
            List<Bitmap> result = new List<Bitmap>(height * width);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Bitmap subImage = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(subImage))
                        g.DrawImage(bitmap, targetRectangle, new Rectangle(j * width, i * height, width, height), GraphicsUnit.Pixel);
                    result.Add(subImage);
                }
            }
            for (int i = 0; i < result.Count; i++)
                result[i].Save("sprite_" + i + ".bmp");
            return result;
        }
    }
}
