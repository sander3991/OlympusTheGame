using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Olympus_the_Game.View.Imaging
{
    public class Sprite
    {
        /// <summary>
        /// Bitmap that will be returned when nothing logical can be returned.
        /// </summary>
        public static readonly Bitmap EMPTY = new Bitmap(1, 1);

        /// <summary>
        /// Gets the amount of frames in this Sprite. -1 if this is a static image.
        /// </summary>
        public int Frames
        {
            get
            {
                return this.Columns * this.Rows;
            }
        }

        /// <summary>
        /// Gets the amount of columns in this sprite.
        /// </summary>
        public int Columns { get; private set; }

        /// <summary>
        /// Gets the amount of rows in this sprite.
        /// </summary>
        public int Rows { get; private set; }

        /// <summary>
        /// Gets whether this sprite is cyclic.
        /// </summary>
        public bool Cyclic { get; private set; }

        /// <summary>
        /// Gets the images of this sprite, please use sprite[index] instead of this list.
        /// </summary>
        public List<Bitmap> Images { get; private set; }

        /// <summary>
        /// Gets the internal image of this sprite
        /// </summary>
        public Bitmap Image { get; private set; }

        /// <summary>
        /// Create a new Sprite.
        /// </summary>
        /// <param name="bm">The bitmap</param>
        /// <param name="countX">Amount of pieces to divide x-axis to.</param>
        /// <param name="countY">Amount of pieces to divide y-axis to.</param>
        /// <param name="cyclic">Whether to create a cyclic sprite.</param>
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

        /// <summary>
        /// Create Sprite from single bitmap.
        /// </summary>
        /// <param name="bm"></param>
        public Sprite(Bitmap bm)
            : this(bm, -1, -1)
        { }

        /// <summary>
        /// Create non-cyclic sprite, cut in pieces.
        /// </summary>
        /// <param name="bm"></param>
        /// <param name="countX"></param>
        /// <param name="countY"></param>
        public Sprite(Bitmap bm, int countX, int countY)
            : this(bm, countX, countY, false)
        { }

        /// <summary>
        /// Returns the given frame.
        /// </summary>
        /// <param name="index">-1.0f for static, between 0.0f (inclusive) and 1.0f (exclusive) (or higher if cyclic) for dynamic.</param>
        /// <returns></returns>
        public Bitmap this[float index]
        { //TODO Ruben: Incode commentaar
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

        /// <summary>
        /// Returns whether this Sprite is equal to another object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

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
                    this.Rows == s.Rows && 
                    this.Image.Equals(s.Image);
            }
        }

        /// <summary>
        /// Geeft de hashcode van deze Sprite.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int result = 41;
            int factor = 37;

            result *= factor;
            result += this.Columns;

            result *= factor;
            result += this.Rows;

            result *= factor;
            result += this.Cyclic.GetHashCode();

            result *= factor;
            result += this.Image.GetHashCode();

            result *= factor;
            result += this.Images.GetHashCode();

            return result;
        }

        /// <summary>
        /// Cast operator from Bitmap.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static implicit operator Sprite(Bitmap b)
        {
            return new Sprite(b);
        }

        /// <summary>
        /// Helper method to cut up images.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        private static List<Bitmap> CutupImage(Bitmap bitmap, int rows, int columns)
        {
            // Determine target
            Size s = new Size(bitmap.Width / columns, bitmap.Height / rows);
            Rectangle targetRectangle = new Rectangle(new Point(0, 0), s);

            // Create result
            List<Bitmap> result = new List<Bitmap>(s.Height * s.Width);

            // Cut up image
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Create new Bitmap
                    Bitmap subImage = new Bitmap(s.Width, s.Height);
                    // Draw scaled image
                    using (Graphics g = Graphics.FromImage(subImage))
                        g.DrawImage(bitmap, targetRectangle, new Rectangle(new Point(j * s.Width, i * s.Height), s), GraphicsUnit.Pixel);
                    // Add to result
                    result.Add(subImage);
                }
            }
            return result;
        }
    }
}
