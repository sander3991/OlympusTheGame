using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;

namespace Olympus_the_Game_Test.Model
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EntityPlayer ep = new EntityPlayer(10,10,0,0);
            EntityCreeper ec = new EntityCreeper(10, 10, 0, 0, 10);
            Assert.IsTrue(ep.CollidesWithObject(ec));
        }
    }
}
