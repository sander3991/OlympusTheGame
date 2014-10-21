using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;
using Olympus_the_Game.Model;

namespace Olympus_the_Game_Test.View.Editor
{
    [TestClass]
    public class RegisterWithEditorTest
    {
        [TestMethod]
        public void Test_RegisterWithEditor()
        {
            OlympusTheGame.SetController();

            foreach (var entry in GameObject.ConstructorList)
            {
                // Extract ObjectType en Constructor
                ObjectType ot = entry.Key;
                Func<GameObject> f = entry.Value;

                // Act
                GameObject go = f();

                // Assert
                Assert.IsNotNull(go);
                Assert.AreEqual(ot, go.Type);
            }
        }
    }
}
