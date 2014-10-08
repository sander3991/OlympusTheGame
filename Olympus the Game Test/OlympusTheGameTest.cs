using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;

namespace Olympus_the_Game_Test
{
    [TestClass]
    public class OlympusTheGameTest
    {
        [TestMethod]
        public void Test_Set_New_Playfield()
        {
            PlayField expected = new PlayField();

            // Act
            OlympusTheGame.Playfield = expected;

            // Assert
            Assert.AreEqual(expected, OlympusTheGame.Playfield);
        }

        [TestMethod]
        public void Test_Set_New_Playfield_Event_Fired()
        {
            // Arrange
            PlayField pf = new PlayField();
            bool actual = false;
            bool expected = true;

            OlympusTheGame.OnNewPlayField += delegate(PlayField p) { actual = true; };

            // Act
            OlympusTheGame.Playfield = pf;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Pause_Resume_Exception()
        {
            // Arrange
            PlayField pf = new PlayField();
            OlympusTheGame.Playfield = pf;

            // Act / Assert
            try
            {
                OlympusTheGame.Pause();
                OlympusTheGame.Resume();
                OlympusTheGame.Pause();
                OlympusTheGame.Resume();
            }
            catch (Exception e)
            {
                Assert.Fail("Error thrown: {0}", e.GetType());
            }
        }
    }
}
