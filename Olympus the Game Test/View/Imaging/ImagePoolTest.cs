using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;
using Olympus_the_Game.View;
using System.Drawing;
using Olympus_the_Game.View.Imaging;

namespace Olympus_the_Game_Test.View.Imaging
{
    [TestClass]
    public class ImagePoolTest
    {
        [TestMethod]
        public void Test_Clear_Pool()
        {
            try
            {
                ImagePool.ClearPool();
            }
            catch (Exception)
            {
                Assert.Fail("Exception was thrown");
            }
        }

        [TestMethod]
        public void Test_Picture_Availability_For_All_ObjectTypes()
        {
            foreach (ObjectType ot in Enum.GetValues(typeof(ObjectType)))
            {
                Assert.AreNotEqual(null, ImagePool.GetPicture(ot, new Size(100, 100)));
            }
        }

        [TestMethod]
        public void Test_Picture_Sizing_For_All_ObjectTypes()
        {
            // Arrange
            Random r = new Random();

            foreach (ObjectType ot in Enum.GetValues(typeof(ObjectType)))
            {
                // Act
                Size s = new Size(r.Next(100) + 10, r.Next(100) + 10);
                Sprite sprite = ImagePool.GetPicture(ot, s);

                // Assert
                Assert.AreEqual(s, sprite.Frames == -1 ? sprite[-1.0f].Size : sprite[0.0f].Size);
            }
        }
    }
}
