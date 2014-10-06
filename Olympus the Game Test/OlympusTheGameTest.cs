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
            // Arrange
            OlympusTheGame otg = new OlympusTheGame();
            PlayField expected = new PlayField();

            // Act
            otg.SetNewPlayfield(expected);

            // Assert
            Assert.AreEqual(expected, otg.Playfield);
        }

        [TestMethod]
        public void Test_Set_New_Playfield_Event_Fired()
        {
            // Arrange
            OlympusTheGame otg = new OlympusTheGame();
            PlayField pf = new PlayField();
            bool actual = false;
            bool expected = true;

            otg.OnNewPlayField += delegate(PlayField p) { actual = true; };

            // Act
            otg.SetNewPlayfield(pf);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Pause_Resume_Exception()
        {
            // Arrange
            OlympusTheGame otg = new OlympusTheGame();
            PlayField pf = new PlayField();
            otg.SetNewPlayfield(pf);

            // Act / Assert
            try
            {
                otg.Pause();
                otg.Resume();
                otg.Pause();
                otg.Resume();
            }
            catch (Exception e)
            {
                Assert.Fail("Error thrown: {0}", e.GetType());
            }
        }
    }
}
