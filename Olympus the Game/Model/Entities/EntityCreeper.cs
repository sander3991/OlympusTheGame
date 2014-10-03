using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus_the_Game;

namespace Olympus_the_Game
{
    public class EntityCreeper : EntityExplode
    {
        public int creeperRange = 150; // Aanpasbaar in editor
        /// <summary>
        /// Een Creeper object met een beginsnelheid
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="dx">De standaard verandering in de X</param>
        /// <param name="dy">De standaard verandering in de Y</param>
        /// <param name="effectStrength">De sterkte van het exploderende object</param>
        public EntityCreeper(int width, int height, int x, int y, int dx, int dy, double explodeStrength) : base(width, height, x, y, dx, dy, explodeStrength)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            EntityControlledByAI = true;
            Type = ObjectType.CREEPER;
        }

        /// <summary>
        /// Een creeper object die stil staat op het begin
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="effectStrength">De sterkte van het exploderende object</param>
        public EntityCreeper(int width, int height, int x, int y, double explodeStrength) : this(width, height, x, y, 0, 0, explodeStrength) { }

        public void OnUpdate() {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            if(player != null){
                if(DistanceToObject(player) < creeperRange){
                    this.EntityControlledByAI = false;

                    if(this.X - player.X > 0){
                        this.DX = -1;
                    } else {
                        this.DX = 1;
                    }

                    if(this.Y - player.Y > 0){
                        this.DY = -1;
                    } else {
                        this.DY = 1;
                    }

                    if(this.X == player.X) {
                        this.DX = 0;
                    }

                    if(this.Y == player.Y){
                        this.DY = 0;
                    }

                } else {
                    this.EntityControlledByAI = true;
                }
            }   
        }

        public override void OnCollide(GameObject gameObject) {
            EntityPlayer player = gameObject as EntityPlayer;
            if(player != null) {
                player.Health -= Convert.ToInt32(EffectStrength);
                OlympusTheGame.INSTANCE.Playfield.SetPlayerHome();
                OlympusTheGame.INSTANCE.Playfield.RemoveObject(this);
            }
        }

        public override string ToString()
        {
            return "Creeper";
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            Controller contr = OlympusTheGame.INSTANCE.Controller;
            PlayField pf = OlympusTheGame.INSTANCE.Playfield;
            contr.UpdateGameEvents -= OnUpdate;
            if(!fieldRemoved)
                pf.AddObject(new SpriteExplosion(this));
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }
    }
}
