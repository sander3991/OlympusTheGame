using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game
{
    //TODO Elmar: Commentaar toevoegen aan public props en methods
    public class EntityFireBall : Entity
    {
        // TODO Elmar: Onderstaande 3 regels kunnen niet. Geen referenties naar externe statics als variabelen in de class. Playfield zit al intern in GameObject.cs
        Controller contr = OlympusTheGame.INSTANCE.Controller;
        EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
        PlayField pf = OlympusTheGame.INSTANCE.Playfield;

        public int fireballSpeed = 50; // Aanpasbaar in editor
        public int destinyX, destinyY, i, j; // TODO Elmar: Betere omschrijving van de variabelen, en Props van maken, of private als ze alleen lokaal gebruikt worden
        private bool targetFound = false;

        public EntityFireBall(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            EntityControlledByAI = false;
            Type = ObjectType.FIREBALL;
            IsSolid = false;
        }
        public EntityFireBall(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        //TODO Elmar: Graag overleggen met Sander
        public void OnUpdate()
        {
            if (player != null)
            {
                if (!targetFound)
                {
                    destinyX = player.X;
                    destinyY = player.Y;
                    //stapjes per verandering bepalen in de x- en y-as
                    i = -((this.X - destinyX) / fireballSpeed);
                    j = -((this.Y - destinyY) / fireballSpeed);
                    targetFound = true;
                }
                this.X += i;
                this.Y += j;
            }

            // Explodeer onder bepaalde voorwaarden
            if (this.CollidesWithObject(player) != CollisionType.NONE )
            {
                player.Health--;
                pf.RemoveObject(this);
            }
            else if(this.X == 0 || this.Y == 0 || this.X >= 966 || this.Y >= 469)
                pf.RemoveObject(this);
        }

        public override void OnCollide(GameObject gameObject) {
            EntityGhast eg = gameObject as EntityGhast;
            if(gameObject == null){
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            contr.UpdateGameEvents -= OnUpdate; // TODO Elmar: Je haalt hier 2 keer OnUpdate weg!
            pf.AddObject(new SpriteExplosion(this));
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "Fireball";
        }
    }
}
