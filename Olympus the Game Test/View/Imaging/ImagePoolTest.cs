using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;
using Olympus_the_Game.Model;
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
                DataPool.ClearImagePool();
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
                Assert.AreNotEqual(null, DataPool.GetPicture(ot, new Size(100, 100)));
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
                Sprite sprite = DataPool.GetPicture(ot, s);

                // Assert
                Assert.AreEqual(s, sprite.Frames == -1 ? sprite[-1.0f].Size : sprite[0.0f].Size);
            }
        }

        [TestMethod]
        public void Test_Get_PreBuffered_Image()
        {
            // Arrange
            Size s = new Size(10, 10);
            Sprite expected = DataPool.GetPicture(ObjectType.CREEPER, s);

            // Act
            Sprite actual = DataPool.GetPicture(ObjectType.CREEPER, s);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
