using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OlympusTheGame;

namespace Olympus_the_Game_Test.Model
{
    [TestClass]
    public class PlayFieldTest
    {
        [TestMethod]
        public void TestAddGameObjects()
        {
            // Allocate
            PlayField pf = new PlayField();
            GameObject g1 = new ObjectFinish();
            GameObject g2 = new ObjectStart();

            // Act / Assert
            pf.AddObject(g1); // Add finish
            Assert.AreEqual(pf.GetObjects().Count, 1);
            Assert.AreEqual(pf.GetObjects()[0], g1);

            // Act / Assert
            pf.AddObject(g2); // Add start
            Assert.AreEqual(pf.GetObjects().Count, 2);
            Assert.IsTrue((pf.GetObjects()[0] == g1 && pf.GetObjects()[1] == g2) ^ (pf.GetObjects()[0] == g2 && pf.GetObjects()[1] == g1));

            // Act / Assert
            try
            {
                pf.AddObject(g1); // Add another finish, should throw error
                Assert.Fail("It is possible to add another finish");
            }
            catch (ArgumentException) { } // TODO Make exception more specific
        }
    }
}
