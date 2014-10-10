using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;
using Olympus_the_Game.Model;
using Olympus_the_Game.Model.Entities;

namespace Olympus_the_Game_Test.Model
{
    [TestClass]
    public class PlayFieldTest
    {
        [TestMethod]
        public void TestAddGameObjects()
        {
            // Allocate
            PlayField pf = new PlayField(100, 100);
            PlayField pfWithStart = new PlayField(100 ,100);
            PlayField pfWithFinish = new PlayField(100, 100);
            PlayField pfWithStartAndFinish = new PlayField(100, 100);
            PlayField pfWith2StartAnd1Finish = new PlayField(100, 100);
            PlayField pfWith1StartAnd2Finish = new PlayField(100, 100);

            GameObject gS = new ObjectFinish(400, 200, 100, 100);
            GameObject gF = new ObjectStart(0, 0, 100, 100);
            GameObject gS2 = new ObjectFinish(400, 200, 100, 100);
            GameObject gF2 = new ObjectStart(0, 0, 100, 100);

            // Act
            pfWithStart.AddObject(gS);

            pfWithFinish.AddObject(gF);

            pfWithStartAndFinish.AddObject(gS);
            pfWithStartAndFinish.AddObject(gF);

            pfWith1StartAnd2Finish.AddObject(gS);
            pfWith1StartAnd2Finish.AddObject(gF);

            pfWith2StartAnd1Finish.AddObject(gS);
            pfWith2StartAnd1Finish.AddObject(gF);

            // Act / Assert

            // Add double finish
            try
            {
                pfWith1StartAnd2Finish.AddObject(gF2); // should throw error
                Assert.Fail("It is possible to add another finish");
            }
            catch (ArgumentException) // TODO Make exception more specific
            {
                // Should not be added, and length should stay same
                Assert.AreEqual(2, pfWith1StartAnd2Finish.GameObjects.Count);
                Assert.IsFalse(pfWith1StartAnd2Finish.GameObjects.Contains(gF2));
            }

            // Add double start
            try
            {
                pfWith2StartAnd1Finish.AddObject(gS2); // should throw error
                Assert.Fail("It is possible to add another start");
            }
            catch (ArgumentException) // TODO Make exception more specific
            {
                // Should not be added, and length should stay same
                Assert.AreEqual(2, pfWith2StartAnd1Finish.GameObjects.Count);
                Assert.IsFalse(pfWith2StartAnd1Finish.GameObjects.Contains(gS2));
            }

            // Assert
            pfWithStart.AddObject(gS); // Add start
            Assert.AreEqual(pfWithStart.GameObjects.Count, 1);
            Assert.AreEqual(pfWithStart.GameObjects[0], gS);

            // Assert
            pfWithFinish.AddObject(gS); // Add finish
            Assert.AreEqual(1, pfWithFinish.GameObjects.Count);
            Assert.AreEqual(gS, pfWithFinish.GameObjects[0]);

            // Assert
            Assert.AreEqual(0, pf.GameObjects.Count);

            // Act / Assert
            Assert.AreEqual(2, pfWithStartAndFinish.GameObjects.Count);
            Assert.IsTrue(pfWithStartAndFinish.GameObjects.Contains(gS) && pfWithStartAndFinish.GameObjects.Contains(gF));
        }

        [TestMethod]
        public void TestGetGameObjects()
        {
            PlayField pf = new PlayField(100, 100);
            pf.AddObject(new EntityPlayer(10, 10, 0, 0));
            pf.AddObject(new EntityPlayer(10, 10, 0, 0));
            pf.AddObject(new EntityPlayer(10, 10, 10, 10));
            Assert.IsTrue(pf.GetObjectsAtLocation(5, 5).Count == 2);
        }
    }
}
