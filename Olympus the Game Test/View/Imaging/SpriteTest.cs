using System;
using System.Drawing;
using Olympus_the_Game.View.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Olympus_the_Game_Test.View.Imaging
{
    [TestClass]
    public class SpriteTest
    {
        [TestMethod]
        public void Sprite_Cast_From_Bitmap()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 100);
            Sprite expected = new Sprite(bm);

            // Act
            Sprite actual = bm;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sprite_Creation_Static()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);

            // Act
            Sprite actual = new Sprite(bm);

            // Assert
            Assert.AreEqual(bm, actual.Image);
            Assert.AreEqual(-1, actual.Frames);
            Assert.AreEqual(bm, actual[-1]);
        }

        [TestMethod]
        public void Sprite_Creation_Dynamic()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            int col = 10;
            int row = 20;

            // Act
            Sprite actual = new Sprite(bm, col, row);

            // Assert
            Assert.AreEqual(bm, actual.Image);
            Assert.AreEqual(col, actual.Columns);
            Assert.AreEqual(row, actual.Rows);
            Assert.AreEqual(false, actual.Cyclic);
            Assert.AreEqual(col * row, actual.Images.Count);
            Assert.AreEqual(col * row, actual.Frames);
        }

        [TestMethod]
        public void Sprite_Get_Out_Of_Range_Frame()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            int col = 10;
            int row = 20;

            // Act
            Sprite actual = new Sprite(bm, col, row);

            // Assert
            try
            {
                Bitmap b = actual[-2.0f];
                Assert.Fail("No error thrown");
            }
            catch (ArgumentOutOfRangeException) {
                // This should happen
            }
            catch (AssertFailedException e)
            {
                // Let assert failed exception bubble up
                throw e;
            }
            catch (Exception e)
            {
                // Unexpected exception thrown
                Assert.Fail("Another exception has been thrown: {0}", e.GetType());
            }
        }

        [TestMethod]
        public void Sprite_Get_Minus_One_Frame()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            int col = 10;
            int row = 20;

            // Act
            Sprite actual = new Sprite(bm, col, row);

            // Assert
            Assert.AreEqual(actual[-1.0f], bm);
        }

        [TestMethod]
        public void Sprite_Get_Larger_Frame()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            int col = 10;
            int row = 20;
            bool cyclic = true;

            // Act
            Sprite s = new Sprite(bm, col, row, cyclic);
            Bitmap expected = s[0.7f];
            Bitmap actual = s[5.7f];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sprite_Get_Correct_Frame()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            int col = 10;
            int row = 20;
            bool cyclic = false;

            // Act
            Bitmap actual = new Sprite(bm, col, row, cyclic)[0.5f];

            // Assert
            Assert.AreEqual(bm.Width / col, actual.Width);
            Assert.AreEqual(bm.Height / row, actual.Height);
        }

        [TestMethod]
        public void Sprite_Get_Too_Large_Frame()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            Bitmap expected = Sprite.EMPTY;
            int col = 10;
            int row = 20;
            bool cyclic = false;

            // Act
            Bitmap actual = new Sprite(bm, col, row, cyclic)[1.5f];

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sprite_Equals_Null()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            Sprite s = bm;
            bool expected = false;

            // Act
            bool actual = s.Equals(null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sprite_Equals_Other_Class()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            Sprite s = bm;
            bool expected = false;

            // Act
            bool actual = s.Equals(Point.Empty);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sprite_Equals_Other_Sprite()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            Sprite s = bm;
            bool expected = false;

            // Act
            bool actual = s.Equals(new Sprite(bm, -1, -1, true));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sprite_Equals_Same_Sprite()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            Sprite s = bm;
            bool expected = true;

            // Act
            bool actual = s.Equals(new Sprite(bm));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sprite_Equals_Same_Cyclic_Sprite()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            Sprite s = new Sprite(bm, 10, 5, true);
            bool expected = true;

            // Act
            bool actual = s.Equals(new Sprite(bm, 10, 5, true));

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sprite_Equals_Different_Cyclic_Sprite()
        {
            // Arrange
            Bitmap bm = new Bitmap(100, 200);
            Sprite s = new Sprite(bm, 10, 5, true);
            bool expected = false;

            // Act
            bool actual = s.Equals(new Sprite(bm, 5, 5, true));

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
