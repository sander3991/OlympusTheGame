using System;
using System.Collections.Generic;
using System.Drawing;

namespace Olympus_the_Game.View.Imaging
{
    public class Sprite
    {
        /// <summary>
        /// Bitmap that will be returned when nothing logical can be returned.
        /// </summary>
        public static readonly Bitmap Empty = new Bitmap(1, 1);

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
            Image = bm;
            Cyclic = cyclic;

            // Check for moving image or static image
            if (countX > 0 && countY > 0 && countX*countY > 1)
            {
                Columns = countX;
                Rows = countY;
                Images = CutupImage(bm, Rows, Columns);
            }
            else
            {
                Columns = -1;
                Rows = 1;
            }
        }

        /// <summary>
        /// Create non-cyclic sprite, cut in pieces.
        /// </summary>
        /// <param name="bm"></param>
        /// <param name="countX"></param>
        /// <param name="countY"></param>
        public Sprite(Bitmap bm, int countX = -1, int countY = -1)
            : this(bm, countX, countY, false)
        {
        }

        /// <summary>
        /// Gets the amount of frames in this Sprite. -1 if this is a static image.
        /// </summary>
        public int Frames
        {
            get { return Columns*Rows; }
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
        /// Returns the given frame.
        /// </summary>
        /// <param name="index">-1.0f for static, between 0.0f (inclusive) and 1.0f (exclusive) (or higher if cyclic) for dynamic.</param>
        /// <returns></returns>
        public Bitmap this[float index]
        {
            get
            {
                // Als index lager is dan -1 => Ongeldig
                if (index < -1.0f)
                {
                    throw new ArgumentOutOfRangeException("Cannot get frame " + index);
                }
                if (Math.Abs(Frames - (-1.0f)) < 0.01f) // Index == -1, geef interne plaatje
                {
                    return Image;
                }
                if (!Cyclic)
                {
                    if (index >= 1.0f)
                        return Empty;
                    if (index < 0.0f) index = 0.0f;
                    return Images[(int) (index*Images.Count)];
                }
                if (!Cyclic) return Empty;
                index = index - (int) index;
                return Images[(int) (index*Images.Count)];
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

            if (Frames == -1)
            {
                return Cyclic == s.Cyclic && Image.Equals(s.Image);
            }
            return Cyclic == s.Cyclic &&
                   Image.Equals(s.Image) &&
                   Columns == s.Columns &&
                   Rows == s.Rows &&
                   Image.Equals(s.Image);
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
            result += Columns;

            result *= factor;
            result += Rows;

            result *= factor;
            result += Cyclic.GetHashCode();

            result *= factor;
            result += Image.GetHashCode();

            result *= factor;
            result += Images.GetHashCode();

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
        private static List<Bitmap> CutupImage(Image bitmap, int rows, int columns)
        {
            // Determine target
            Size s = new Size(bitmap.Width/columns, bitmap.Height/rows);
            Rectangle targetRectangle = new Rectangle(new Point(0, 0), s);

            // Create result
            List<Bitmap> result = new List<Bitmap>(s.Height*s.Width);

            // Cut up image
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Create new Bitmap
                    Bitmap subImage = new Bitmap(s.Width, s.Height);
                    // Draw scaled image
                    using (Graphics g = Graphics.FromImage(subImage))
                        g.DrawImage(bitmap, targetRectangle, new Rectangle(new Point(j*s.Width, i*s.Height), s),
                            GraphicsUnit.Pixel);
                    // Add to result
                    result.Add(subImage);
                }
            }
            return result;
        }
    }
}