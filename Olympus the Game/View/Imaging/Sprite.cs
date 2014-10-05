using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Olympus_the_Game.View.Imaging
{
    public class Sprite
    {
        public static readonly Bitmap EMPTY = new Bitmap(1, 1);

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
            // Save variables
            this.Image = bm;
            this.Cyclic = cyclic;

            // Check for moving image or static image
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

        public Sprite(Bitmap bm)
            : this(bm, -1, -1)
        { }

        public Sprite(Bitmap bm, int countX, int countY)
            : this(bm, countX, countY, false)
        { }

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
                    float f = index - (float)((int)index);
                    int a = (int)(f * (float)Images.Count);
                    return Images[a];
                }
                else if (index < 1.0f)
                {
                    return Images[(int)(index * (float)Images.Count)];
                }
                else
                {
                    return EMPTY;
                }
            }
        }

        public override bool Equals(object obj)
        {
            Sprite s = obj as Sprite;

            if (s == null)
                return false;

            if (this.Frames == -1)
            {
                return this.Cyclic == s.Cyclic && this.Image.Equals(s.Image);
            }
            else
            {
                return this.Cyclic == s.Cyclic &&
                    this.Image.Equals(s.Image) &&
                    this.Columns == s.Columns &&
                    this.Rows == s.Rows;
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
    }
}
