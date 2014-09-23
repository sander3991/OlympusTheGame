using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    public class ObjectFinish : GameObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public ObjectFinish(int width, int height, int x, int y) : base(width, height, x , y)
        {

        }
        public override void PaintObject()
        {
            throw new NotImplementedException();
        }
    }
}
