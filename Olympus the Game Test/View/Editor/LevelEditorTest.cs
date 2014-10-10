using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game.Model;
using Olympus_the_Game.View;
using Olympus_the_Game;

namespace Olympus_the_Game_Test.View.Editor
{
    [TestClass]
    public class LevelEditorTest
    {
        [TestMethod]
        public void Test_Create_LevelEditor()
        {
            // Arrange
            

            // Act
            LevelEditor le = new LevelEditor();

            // Assert
            Assert.AreEqual(0, le.CurrentPlayField.GameObjects.Count);

            // Clean up
            le.Dispose();
        }

        [TestMethod]
        public void Test_Create_With_Given_Playfield()
        {
            // Arrange
            PlayField newPF = new PlayField(10000, 10000);

            // Act
            LevelEditor le = new LevelEditor(newPF);

            // Assert
            Assert.AreEqual(newPF, le.CurrentPlayField);

            // Clean up
            le.Dispose();
        }

        [TestMethod]
        public void Test_Dispose()
        {
            // Arrange
            LevelEditor le = new LevelEditor();

            // Act / assert
            try
            {
                le.Dispose();
            }
            catch (Exception)
            {
                Assert.Fail("Exception raised");
            }

            // Assert
            Assert.IsTrue(le.IsDisposed);
        }

        [TestMethod]
        public void Test_Add_GameObjects()
        {
            // Arrange
            PlayField newPF = new PlayField(10000, 10000);
            LevelEditor le = new LevelEditor(newPF);
            ObjectStart os = new ObjectStart(500, 500, 8000, 8000);

            // Act
            le.CurrentPlayField.AddObject(os);

            // Assert
            Assert.AreEqual(newPF, le.CurrentPlayField);
            Assert.AreNotEqual(null, le.CurrentPlayField.GameObjects);
            Assert.AreEqual(1, le.CurrentPlayField.GameObjects.Count);
            Assert.AreEqual(os, le.CurrentPlayField.GameObjects[0]);
            Assert.AreEqual(500, le.CurrentPlayField.GameObjects[0].Width);
            Assert.AreEqual(500, le.CurrentPlayField.GameObjects[0].Height);
            Assert.AreEqual(8000, le.CurrentPlayField.GameObjects[0].X);
            Assert.AreEqual(8000, le.CurrentPlayField.GameObjects[0].Y);

            // Clean up
            le.Dispose();
        }
    }
}
