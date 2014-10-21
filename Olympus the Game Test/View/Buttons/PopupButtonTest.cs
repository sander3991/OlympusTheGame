using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game.View.Buttons;

namespace Olympus_the_Game_Test.View.Buttons
{
    [TestClass]
    public class PopupButtonTest
    {
        [TestMethod]
        public void Test_Popup_Working()
        {
            // Arrange
            Form f = new Form();
            UserControl uc = new UserControl();
            PopupButton pb = new PopupButton();
            f.Controls.Add(uc);
            uc.Controls.Add(pb);
            f.Show();
            Form expected = pb.FindForm();

            // Act
            pb.PerformClick();
            Form actual = pb.FindForm();

            // Assert
            Assert.AreNotSame(expected, actual);

            // Act
            actual.Close();
            Form actual2 = pb.FindForm();

            // Assert
            Assert.AreSame(expected, actual2);
        }
    }
}
