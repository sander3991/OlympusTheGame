using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus_the_Game;

namespace Olympus_the_Game
{
    public class EntityCreeper : EntityExplode
    {
        // TODO Joel: Property van maken + denk aan limitaties van de property.
        public int CreeperRange = 150; // Aanpasbaar in editor

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Volgt je en explodeert bij aanraken";
        }

        /// <summary>
        /// Een Creeper object met een beginsnelheid
        /// </summary>
        public EntityCreeper(int width, int height, int x, int y, int dx, int dy, double explodeStrength)
            : base(width, height, x, y, dx, dy, explodeStrength)
        {
            OlympusTheGame.Controller.UpdateGameEvents += OnUpdate;
            EntityControlledByAI = true;
            Type = ObjectType.CREEPER;

        }

        /// <summary>
        /// Een creeper object die stil staat op het begin
        /// </summary>
        public EntityCreeper(int width, int height, int x, int y, double explodeStrength) : this(width, height, x, y, 0, 0, explodeStrength) { }

        /// <summary>
        /// Update het object.
        /// Wanneer dit object te dichtbij een speler is zal deze richting de speler lopen.
        /// </summary>
        public void OnUpdate()
        {
            EntityPlayer player = Playfield.Player;
            if (player != null)
            {
                if (DistanceToObject(player) < CreeperRange)
                {
                    this.EntityControlledByAI = false;

                    if (this.X - player.X > 0)
                    {
                        this.DX = -1;
                    }
                    else
                    {
                        this.DX = 1;
                    }

                    if (this.Y - player.Y > 0)
                    {
                        this.DY = -1;
                    }
                    else
                    {
                        this.DY = 1;
                    }


                    /**
                     *Als de X of Y waarde van de speler of het object gelijk is zal het object in een rechte lijn achter de speler aan lopen.
                    **/
                    if (this.X == player.X)
                    {
                        this.DX = 0;
                    }

                    if (this.Y == player.Y)
                    {
                        this.DY = 0;
                    }

                }
                else
                {
                    this.EntityControlledByAI = true;
                }
            }
        }

        public override string ToString()
        {
            return "Creeper";
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            Controller contr = OlympusTheGame.Controller;
            PlayField pf = Playfield;
            contr.UpdateGameEvents -= OnUpdate;
            if (!fieldRemoved)
            {
                pf.AddObject(new SpriteExplosion(this));
                SoundEffects.PlaySound(Properties.Resources.bomb);
            }
            OlympusTheGame.Controller.UpdateGameEvents -= OnUpdate;
        }
    }
}
