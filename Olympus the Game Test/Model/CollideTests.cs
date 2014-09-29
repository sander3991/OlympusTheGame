using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;

namespace Olympus_the_Game_Test
{
    [TestClass]
    public class UnitTest1
    {
        EntityPlayer ep = new EntityPlayer(10, 10, 0, 0);
        EntityExplode ee = new EntityExplode(10, 10, 0, 0, 10);

        [TestMethod]
        public void Collides()
        {
            Assert.IsTrue(ee.CollidesWithObject(ep));
        }

        [TestMethod]
        public void LowerHealth() 
        {
            ee.OnCollide(ep);
            Assert.IsTrue(ep.Health == 4);
        }

        [TestMethod]
        public void RespawnPlayer() 
        {
            Assert.IsTrue(ep.X == 0 && ep.Y == 0);
        }

        [TestMethod]
        public void KillPlayer() 
        {
            for(int i = 0; i < 5; i++) {
                ep.X = 10;
                ep.Y = 10;
                ee.OnCollide(ep);
            }

            Assert.IsTrue(ep.Health == 0);
        }
    }
}
