using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Olympus_the_Game.View.Imaging
{
    class Sprite
    {
        private static Bitmap EMPTY = new Bitmap(1, 1);

        public int Frames
        {
            get
            {
                return this.Columns * this.Rows;
            }
        }

        public int Columns { get; private set; }

        public int Rows { get; private set; }

        public bool Cyclic { get; private set; }

        public List<Bitmap> Images { get; private set; }

        public Bitmap Image { get; private set; }

        public Sprite(Bitmap bm, int countX, int countY, bool cyclic)
        {
            this.Image = ConvertBitmap(bm);

            this.Cyclic = cyclic;

            if (countX > 0 && countY > 0 && countX * countY > 1)
            {
                this.Columns = countX;
                this.Rows = countY;
                this.Images = CutupImage(bm, Rows, Columns);
            }
            else
            {
                Columns = -1;
                Rows = 1;
            }

        }

        public Bitmap this[float index]
        {
            get
            {
                if (index < -1.0f)
                {
                    throw new ArgumentOutOfRangeException("Cannot get frame " + index);
                }
                else if (index == -1.0f)
                {
                    return this.Image;
                }
                else if (this.Cyclic)
                {
                    int a = (int)(index * (float)Images.Count);
                    return Images[a% Images.Count];
                }
                else if (index < 1.0f)
                {
                    return Images[(int)(index * (float)(Images.Count-1))];
                }
                else
                {
                    return EMPTY;
                }
            }
        }

        public static implicit operator Sprite(Bitmap b)
        {
            return new Sprite(b, -1, -1, false);
        }

        private static List<Bitmap> CutupImage(Bitmap bitmap, int rows, int columns)
        {
            int width = bitmap.Width / columns;
            int height = bitmap.Height / rows;
            Rectangle targetRectangle = new Rectangle(0, 0, width, height);
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
            return result;
        }

        private static Bitmap ConvertBitmap(Bitmap b)
        {
            Bitmap result = new Bitmap(b.Width, b.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(b, 0, 0, b.Width, b.Height);
            return result;
        }
    }
}
