﻿using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game.Model;
using Olympus_the_Game.View.Imaging;

namespace Olympus_the_Game_Test.View.Imaging
{
    [TestClass]
    public class DataPoolTest
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
            DataPool.LoadDataPool();

            foreach (ObjectType ot in Enum.GetValues(typeof (ObjectType)))
            {
                Sprite s = DataPool.GetPicture(ot, new Size(100, 100));
                if(s == null)
                    s = DataPool.GetPicture(ot, new Size(100, 100));
                Assert.IsNotNull(s);
                Assert.AreNotEqual(s, Sprite.Empty);
            }

            DataPool.UnloadDataPool();
        }

        [TestMethod]
        public void Test_Picture_Sizing_For_All_ObjectTypes()
        {
            DataPool.LoadDataPool();

            // Arrange
            var r = new Random();

            foreach (ObjectType ot in Enum.GetValues(typeof (ObjectType)))
            {
                // Act
                var s = new Size(r.Next(100) + 10, r.Next(100) + 10);
                Sprite sprite = DataPool.GetPicture(ot, s);

                // Assert
                Assert.AreEqual(s, sprite.Frames == -1 ? sprite[-1.0f].Size : sprite[0.0f].Size);
            }

            DataPool.UnloadDataPool();
        }

        [TestMethod]
        public void Test_Get_PreBuffered_Image()
        {
            DataPool.LoadDataPool();

            // Arrange
            var s = new Size(10, 10);
            Sprite expected = DataPool.GetPicture(ObjectType.Creeper, s);

            // Act
            Sprite actual = DataPool.GetPicture(ObjectType.Creeper, s);

            // Assert
            Assert.AreEqual(expected, actual);

            DataPool.UnloadDataPool();
        }
    }
}