using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;

namespace Olympus_the_Game_Test.Model
{
    [TestClass]
    public class PlayFieldTest
    {
        /*[TestMethod]
        public void TestAddGameObjects()
        {
            // Allocate
            PlayField pf = new PlayField();
            PlayField pfWithStart = new PlayField();
            PlayField pfWithFinish = new PlayField();
            PlayField pfWithStartAndFinish = new PlayField();
            PlayField pfWith2StartAnd1Finish = new PlayField();
            PlayField pfWith1StartAnd2Finish = new PlayField();

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
                Assert.AreEqual(2, pfWith1StartAnd2Finish.GetObjects().Count);
                Assert.IsFalse(pfWith1StartAnd2Finish.GetObjects().Contains(gF2));
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
                Assert.AreEqual(2, pfWith2StartAnd1Finish.GetObjects().Count);
                Assert.IsFalse(pfWith2StartAnd1Finish.GetObjects().Contains(gS2));
            }

            // Assert
            pfWithStart.AddObject(gS); // Add start
            Assert.AreEqual(pfWithStart.GetObjects().Count, 1);
            Assert.AreEqual(pfWithStart.GetObjects()[0], gS);

            // Assert
            pfWithFinish.AddObject(gS); // Add finish
            Assert.AreEqual(1, pfWithFinish.GetObjects().Count);
            Assert.AreEqual(gS, pfWithFinish.GetObjects()[0]);

            // Assert
            Assert.AreEqual(0, pf.GetObjects().Count);

            // Act / Assert
            Assert.AreEqual(2, pfWithStartAndFinish.GetObjects().Count);
            Assert.IsTrue(pfWithStartAndFinish.GetObjects().Contains(gS) && pfWithStartAndFinish.GetObjects().Contains(gF));
        }*/
    }
}
