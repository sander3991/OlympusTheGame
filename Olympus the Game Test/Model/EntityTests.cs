using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;
using Olympus_the_Game.Model;
using Olympus_the_Game.Model.Entities;

namespace Olympus_the_Game_Test.Model.Entities
{
    [TestClass]
    public class EntityTests
    {
        static EntityTests() //Alle entities gebruiken de Controller, daarom stellen we de controller in als deze class aangeroepen wordt zodat hij er altijd is.
        {
            OlympusTheGame.SetController();
        }
        [TestMethod]
        public void Test_GameObjectsAndEntities()
        {
            List<GameObject> gameObjects = new List<GameObject>
            {
                new ObjectStart(10,10,0,0),
                new ObjectFinish(10,10,0,0),
                new ObjectObstacle(10,10,0,0),
                new EntityCreeper(10,10,0,0,1),
                new EntityExplode(10,10,0,0,1),
                new EntityGhast(10,10,0,0),
                new EntityPlayer(10,10,0,0),
                new EntitySilverfish(10,10,0,0),
                new EntitySlower(10,10,0,0),
                new EntityTimeBomb(10,10,0,0, 1),
                new EntityWeb(10,10,0,0),
            };
            CheckUniqueID(gameObjects);
            foreach(GameObject go in gameObjects)
            {
                TestGameObject(go);

                Entity e = go as Entity;
                if (e != null)
                    TestEntity(e);
            }
        }

        /// <summary>
        /// Controleert in een lijst of ze allemaal een uniek ID hebben
        /// </summary>
        /// <param name="gameObjects">Een lijst met GameObject objecten</param>
        private void CheckUniqueID(List<GameObject> gameObjects)
        {
            List<int> uniqueIDs = new List<int>();
            foreach(GameObject go in gameObjects)
            {
                Assert.IsFalse(uniqueIDs.Contains(go.UniqueID));
                uniqueIDs.Add(go.UniqueID);
            }
        }
        /// <summary>
        /// Kunnen we de visibility aanpassen
        /// </summary>
        /// <param name="go">GameOject dat getest moet worden</param>
        /// <returns>true als de test goed gegaan is</returns>
        private void TestGameObject(GameObject go)
        {
            bool visibilityEventParam = go.Visible;
            go.OnVisibilityChanged += delegate(GameObject goEvent, bool visibility) { visibilityEventParam = visibility; };
            // Check of we de visibility property aan kunnen passen
            go.Visible = false;
            Assert.IsFalse(go.Visible);
            Assert.IsTrue(go.Visible == visibilityEventParam); //Is het event afgevuurd, en de goede waarde meegegeven
            go.Visible = true;
            Assert.IsTrue(go.Visible);
            Assert.IsTrue(go.Visible == visibilityEventParam); //Is het event afgevuurd en de goede waarde meegegeven

            //check of er een ObjectType is gekoppeld aan de entity.
            Assert.IsTrue(go.Type != ObjectType.Unknown);

            //Controleer of er maar 1 speelveld aan een entity gekoppeld kan worden
            PlayField pf = new PlayField();
            pf.Width = int.MaxValue; //Groottes zijn zo groot gemaakt dat entities vrijwel overal kunnen staan voor test purposes
            pf.Height = int.MaxValue;
            PlayField pf2 = new PlayField();
            go.Playfield = pf;
            go.Playfield = pf2;
            Assert.IsTrue(go.Playfield == pf);

            //Check of we de hoogte/breedte aan kunnen passen
            go.Height = 999;
            Assert.IsTrue(go.Height == 999);

            go.Width = 999;
            Assert.IsTrue(go.Width == 999);

            //Check of ze niet negatief kunnen, en naar de default van 10 gaan
            go.Height = -200;
            go.Width = -200;
            Assert.IsTrue(go.Height == 10);
            Assert.IsTrue(go.Width == 10);
            
            //Kunnen we de X waardes aanpassen
            go.X = 300;
            go.Y = 300;
            Assert.IsTrue(go.X == 300);
            Assert.IsTrue(go.Y == 300);

            //Kan de X / Y niet negatief worden
            go.X = -100;
            go.Y = -100;
            Assert.IsTrue(go.X == 0);
            Assert.IsTrue(go.Y == 0);

            //X waardes gecombineerd met PlayField testen
            pf.Width = 100;
            pf.Height = 100;
            go.Width = 50;
            go.Height = 50;
            go.X = 75;
            go.Y = 75;
            Assert.IsTrue(go.X == 50);
            Assert.IsTrue(go.Y == 50);


            // Hebben de gameobjects een description
            Assert.IsFalse(string.IsNullOrEmpty(go.GetDescription()));
            //Is de ToString niet null of leeg
            Assert.IsFalse(string.IsNullOrEmpty(go.ToString()));

            go.X = 0; //Reset het gameobject naar default waardes voor distance tests
            go.Y = 0;
            go.Height = 10;
            go.Width = 10;

            EntityPlayer testObject = new EntityPlayer(10, 10, 0, 0);
            //Distance to object test
            Assert.IsTrue(go.DistanceToObject(testObject) == 0);
            testObject.X = 5;
            Assert.IsTrue(go.DistanceToObject(testObject) == 5); //X afstand
            testObject.Y = 4;
            testObject.X = 0;
            Assert.IsTrue(go.DistanceToObject(testObject) == 4); //Y Afstand
            testObject.X = 3;
            Assert.IsTrue(go.DistanceToObject(testObject) == 5); // X en Y afstand

            testObject.X = 0;
            testObject.Y = 0;

            Assert.IsTrue(go.CollidesWithObject(testObject) != CollisionType.None);

            testObject.X = 100;
            testObject.Y = 100;
            Assert.IsTrue(go.CollidesWithObject(testObject) == CollisionType.None);
         }

        public void TestEntity(Entity e)
        {
            //Dit zou moeten kunnen wat hieronder gebeurt, is in GameObjectTest getest
            e.X = 0;
            e.Y = 0;
            e.Width = 10;
            e.Height = 10;
            //Kunnen we DX en DY zetten
            e.DX = 1;
            e.DY = 1;
            Assert.IsTrue(e.DX == 1);
            Assert.IsTrue(e.DY == 1);

            Entity entityEvent = null;
            e.OnMoved += delegate(Entity e2) { entityEvent = e2; };

            //Kijk of we kunnen bewegen
            e.Move();
            Assert.IsTrue(e.X == 1);
            Assert.IsTrue(e.Y == 1);
            //Hebben we een event gekregen met de entity?
            Assert.IsTrue(e == entityEvent);

            //Hebben ze netjes de previousX en previousY erin gezet
            Assert.IsTrue(e.PreviousX == 0);
            Assert.IsTrue(e.PreviousY == 0);
        }

        [TestMethod]
        public void Test_ObjectFinish()
        {
            //Test of we kunnen colliden met de finish
            EntityPlayer player = new EntityPlayer(10, 10, 0, 0);
            ObjectFinish finish = new ObjectFinish(10, 10, 0, 0);
            Olympus_the_Game.Controller.FinishType eventType = Olympus_the_Game.Controller.FinishType.Dead;
            OlympusTheGame.GameController.OnPlayerFinished += delegate(Olympus_the_Game.Controller.FinishType type) { eventType = type; };
            finish.OnCollide(player);
            Assert.IsTrue(eventType == Olympus_the_Game.Controller.FinishType.Cake);
        }

        [TestMethod]
        public void Test_EntityExplode()
        {
            PlayField pf = new PlayField();
            EntityExplode TNT = new EntityExplode(10, 10, 0, 0, 1);
            EntityPlayer player = new EntityPlayer(10, 10, 0, 0);
            pf.AddObject(TNT);
            pf.AddObject(player);
            int playerHealth = player.Health;
            TNT.OnCollide(player);
            Assert.IsTrue(player.Health == (playerHealth - 1)); //Controleer of hij inderdaad ge-explodeerd is zodra hij met de player collide.
            Assert.IsFalse(pf.GameObjects.Contains(TNT)); //Controleer of hij uit het speelveld is verwijderd
            Assert.IsTrue(pf.GameObjects.Count > 0 && pf.GameObjects[0].Type == ObjectType.Spriteexplosion); //Controleer of de sprite is aangemaakt
        }

        [TestMethod]
        public void Test_EntityCreeper()
        {
            
            EntityCreeper creeper = new EntityCreeper(10,10,200,200, 1);
            creeper.CreeperRange = 100;
            PlayField pf = new PlayField();
            OlympusTheGame.Playfield = pf;
            EntityPlayer player = pf.Player;
            //Zorg dat we zeker weten dat onze player de goede parameters heeft
            player.X = 0;
            player.Y = 0;
            player.Width = 10;
            player.Height = 10;
            pf.AddObject(creeper);
            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null,null);
            Assert.IsTrue(creeper.EntityControlledByAi); //Op dit moment zou de creeper bestuurd moeten worden door de AI omdat hij niet in range is
            //Zet de creeperrange hoog genoeg om de speler te volgen
            creeper.CreeperRange = 5000;
            double distanceBeforeUpdate = creeper.DistanceToObject(player);
            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            Assert.IsFalse(creeper.EntityControlledByAi); //Wordt hij nu door de Creeper AI bestuurd
            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            Assert.IsTrue(creeper.DistanceToObject(player) < distanceBeforeUpdate); //Controleer of hij inderdaad naar de speler loopt
            player.X = 300; //Zet de speler ergens anders neer, kijken of hij dan ook de speler kan vinden
            player.Y = 300;
            distanceBeforeUpdate = creeper.DistanceToObject(player);
            for (int i = 0; i < 3; i++ ) //we updaten 3 keer de creeper, de eerste keer loopt hij nog naar de verkeerde positie van de speler, de tweede keer reset hij die van de eerste keer, en de derde keer moet hij dichter naar de player gaan
                OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            Assert.IsTrue(creeper.DistanceToObject(player) < distanceBeforeUpdate);

            player.X = creeper.X; //zet de speler op dezelfde X as, controleer of hij de DX dan nog veranderd
            creeper.DX = 0; //We forceren hem hier op 0 zodat hij bij de volgende update niet de X verplaatst.
            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            Assert.IsTrue(creeper.DX == 0); //Heeft de OnUpdate van Creeper hem op 0 laten staan?

            player.Y = creeper.Y; //idem dito voor de Y as
            player.X = 100;
            creeper.X = 300;
            creeper.DY = 0;
            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            Assert.IsTrue(creeper.DY == 0);

            creeper.X = 200;
            creeper.Y = 200;
            player.X = 0;
            player.Y = 0;
            int prevHealth = player.Health;
            for (int i = 0; i <= 1000; i++) //We geven hem 1000 game ticks op te proberen bij de speler te komen
            {
                OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
                if (!pf.GameObjects.Contains(creeper))
                    break;
                Assert.IsFalse(i == 1000); //Als hij meer dan 100 keer heeft geupdate is hij niet bij de speler gekomen
            }
            //We hebben in de loop gecontroleerd of hij verwijderd is, oftewel gecollide is met de player.
            //Nu gaan we kijken of de SpriteExplosion is aangemaakt
            Assert.IsTrue(player.Health < prevHealth); //Kijk of hij inderdaad de speler gehit heeft
            Assert.IsTrue(pf.GameObjects.Count > 0 && pf.GameObjects[0].Type == ObjectType.Spriteexplosion); //Wordt er een sprite explosion aangemaakt op de plek van ontploffing
        }

        /// <summary>
        /// Helper method om alle fireballs en sprite explosions weg te halen uit een speelveld
        /// </summary>
        /// <param name="pf">Het speelveld waaruit het verwijderd moet worden</param>
        private void ClearPlayfieldFromFireballs(PlayField pf)
        {
            for (int i = pf.GameObjects.Count - 1; i >= 0; i--)
            {
                if (pf.GameObjects[i].Type == ObjectType.Fireball || pf.GameObjects[i].Type == ObjectType.Spriteexplosion)
                    pf.RemoveObject(pf.GameObjects[i]);
            }
        }

        [TestMethod]
        public void Test_EntityGhast()
        {
            EntityGhast ghast = new EntityGhast(10, 10, 200, 200);
            EntityPlayer player;
            PlayField playfield = new PlayField();
            ghast.DetectRange = 1;
            Assert.IsTrue(ghast.DetectRange == 50); //Word hij op de minimale waarde gezet als we hem op 1 proberen te zetten

            ghast.FireSpeed = -10;
            Assert.IsTrue(ghast.FireSpeed == 0); // Word hij op 0 gezet als er een negatief getal wordt ingegeven
            OlympusTheGame.Playfield = playfield;
            player = playfield.Player;
            player.X = 0;
            player.Y = 0;
            player.Height = 10;
            player.Width = 10;
            playfield.AddObject(ghast);

            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            Assert.IsTrue(playfield.GameObjects.Count == 1); //Controleerd of er geen Fireball is afgeschoten

            ghast.DetectRange = 1000;
            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            Assert.IsTrue(playfield.GameObjects.Count == 2 && playfield.GameObjects[1].Type == ObjectType.Fireball); //Controleerd of er een fireball is afgeschoten
            EntityFireBall fireball = playfield.GameObjects[1] as EntityFireBall;
            ghast.FireSpeed = int.MaxValue; //We zetten de firespeed op de maxValue zodat hij niet nog een keer schiet
            int prevHealth = player.Health;
            for (int i = 0; i <= 1000; i++)
            {
                OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
                if (prevHealth > player.Health) //De speler is gehit
                {
                    Assert.IsFalse(playfield.GameObjects.Contains(fireball)); //De fireball is verwijderd
                    prevHealth = player.Health; //update voor volgende test
                    break;
                }
                Assert.IsFalse(i == 1000); //Controleerd of we het binnen de loop voltooien
            }
            ClearPlayfieldFromFireballs(playfield);
            ghast.FireSpeed = 0; //0 schiet hij elke game event
            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            ghast.FireSpeed = int.MaxValue; //En weer op maxValue zodat hij niet nog een keer schiet
            Assert.IsTrue(playfield.GameObjects.Count == 2); //controleer of er wederom een fireball gemaakt is
            fireball = playfield.GameObjects[0] as EntityFireBall;
            player.X = 300; //We verplaatsen de speler nu naar een plek waar de fireball niet langs komt.
            player.Y = 300; //Dit doen we om te testen of hij ook tegen een muur explodeert
            for (int i = 0; i <= 1000; i++)
            {
                OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
                if (!playfield.GameObjects.Contains(fireball) && player.Health == prevHealth) //Hij heeft zichzelf verwijderd van het speelveld, en niet de speler geraakt
                    break;
                Assert.IsFalse(i == 1000); //Controleerd of we het binnen de loop voltooien
            }
            ClearPlayfieldFromFireballs(playfield);
            player.X = 0; //De ghast staat nu op 0,0. De player staat op 0,300. We gaan hiertussen een Entity zetten, die moet dood gaan door de fireball van de ghast
            ghast.X = 0;
            ghast.Y = 0;
            EntityExplode TNT = new EntityExplode(10, 10, 0, 150, 1); //Deze moet dood gaan door de fireball
            playfield.AddObject(TNT);
            ghast.FireSpeed = 0;
            fireball = null;
            foreach (GameObject go in playfield.GameObjects)
                Assert.IsFalse(go.Type == ObjectType.Fireball); //Hebben we geen fireballs in de GameObjects
            OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
            fireball = playfield.GameObjects[playfield.GameObjects.Count - 1] as EntityFireBall;
            Assert.IsTrue(fireball != null); //Hebben we een fireball geschoten
            ghast.FireSpeed = int.MaxValue; //zorg ervoor dat de ghast niet weer schiet (schiet zijn eigen fireball kaput)
            for (int i = 0; i <= 1000; i++)
            {
                OlympusTheGame.GameController.ExecuteUpdateGameEvent(null, null);
                if (!playfield.GameObjects.Contains(TNT)) //Is er TNT ontploft
                    break;
                Assert.IsFalse(i == 1000);
            }
            Assert.IsTrue(player.Health == prevHealth); // Is de speler wederom niet geraakt
            playfield.RemoveObject(ghast);
        }
    }
}