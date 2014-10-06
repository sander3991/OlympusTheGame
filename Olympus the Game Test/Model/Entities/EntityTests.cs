using Microsoft.VisualStudio.TestTools.UnitTesting;
using Olympus_the_Game;
using System;
using System.Collections.Generic;

namespace Olympus_the_Game_Test.Model
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void CollisionTest()
        {
            OlympusTheGame.INSTANCE = new OlympusTheGame();
            List<GameObject> objects = new List<GameObject>();
            //alle objecten zijn in eerste instantie 10 breed en hoog, en staan op X en Y.
            objects.Add(new ObjectStart(10, 10, 0, 0));
            objects.Add(new ObjectFinish(10, 10, 0, 0));
            objects.Add(new ObjectObstacle(10, 10, 0, 0));
            objects.Add(new EntityCreeper(10, 10, 0, 0, 0));
            objects.Add(new EntityExplode(10, 10, 0, 0, 0));
            objects.Add(new EntityPlayer(10, 10, 0, 0));
            objects.Add(new EntitySlower(10, 10, 0, 0));
            objects.Add(new EntityTimeBomb(10, 10, 0, 0, 0));

            
            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j < objects.Count; j++)
                {
                    /*if (i != j)
                        Assert.IsTrue(objects[i].CollidesWithObject(objects[j]));*/ //ze zijn even groot op dezelfde locatie, dit is dus een collide in alle gevallen!
                }
            }
            for (int i = 0; i < objects.Count; i++)
                objects[i].X = i * 10; //Stelt alle X waardes 10 van elkaar af zodat ze naast elkaar staan.

            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j < objects.Count; j++)
                {
                    /*if (i != j)
                        Assert.IsFalse(objects[i].CollidesWithObject(objects[j]));*/ //ze zijn uit elkaar gezet, dus nu moet hij niet meer colliden
                }
            }
            for(int i = 0; i < objects.Count; i++)
            {
                objects[i].X = 0; //zet alle X waardes weer gelijk
                objects[i].Y = i * 10; //en zet alle Y waardes uit elkaar
            }
            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j < objects.Count; j++)
                {
                    /*if (i != j)
                        Assert.IsFalse(objects[i].CollidesWithObject(objects[j]));*/ //ze zijn uit elkaar gezet, dus nu moet hij niet meer colliden
                }
            }

            GameObject go1, go2, go3;
            go1 = new ObjectStart(10, 10, 0, 0);
            go2 = new ObjectFinish(10, 10, 5, 5);
            go3 = new ObjectFinish(5, 5, 3, 3);

            /*Assert.IsTrue(go1.CollidesWithObject(go2));
            Assert.IsTrue(go2.CollidesWithObject(go1));
            Assert.IsTrue(go3.CollidesWithObject(go1));
            Assert.IsTrue(go1.CollidesWithObject(go3));*/
        }

        [TestMethod]
        public void EntityOutOfBoundsTest()
        {
            OlympusTheGame.INSTANCE = new OlympusTheGame();
            List<Entity> entities = new List<Entity>();
            entities.Add(new EntityPlayer(-1, -1, -1, -1));
            entities.Add(new EntitySlower(-1, -1, -1, -1));
            entities.Add(new EntityCreeper(-1, -1, -1, -1, 0));
            entities.Add(new EntityExplode(-1, -1, -1, -1, 0));
            entities.Add(new EntityTimeBomb(-1, -1, -1, -1, 0));

            for (int i = 0; i < entities.Count; i++)
            {
                //Controleert of de properties naar 0 worden gezet in plaats van -1.
                Entity e = entities[i];
                Assert.IsTrue(e.X == 0);
                Assert.IsTrue(e.Y == 0);
                Assert.IsTrue(e.Width == 0);
                Assert.IsTrue(e.Height == 0);
            }
            //TODO: Voeg een test toe om te kijken of hij aan het onderkant van het veld out of bounds raakt

        }
        [TestMethod]
        public void EntityDistanceTest()
        {
            OlympusTheGame.INSTANCE = new OlympusTheGame();
            List<Entity> entities = new List<Entity>();
            Entity player = new EntityPlayer(0, 0, 0, 0);
            player.DX = 5;
            player.DY = 10;
            entities.Add(player);
            entities.Add(new EntitySlower(0, 0, 0, 0, 5, 10));
            entities.Add(new EntityCreeper(0, 0, 0, 0, 5, 10, 0));
            entities.Add(new EntityExplode(0, 0, 0, 0, 5, 10, 0));
            entities.Add(new EntityTimeBomb(0, 0, 0, 0, 5, 10, 0));
            for (int i = 0; i < entities.Count; i++)
            {
                Entity ent1 = entities[i];
                for(int j = 0; j < entities.Count; j++)
                {
                    Entity ent2 = entities[j];
                    if (ent1 != ent2)
                        Assert.IsTrue(ent1.DistanceToObject(ent2) == 0);
                }
            }

            Entity e1 = new EntityPlayer(10, 10, 0, 0);
            Entity e2 = new EntityPlayer(10, 10, 0, 5);
            Entity e3 = new EntityPlayer(6, 6, 0, 0);
            //Tests met gelijke groote van entities
            Assert.IsTrue(e1.DistanceToObject(e2) == 5.0); //verticale afstand
            e2.X = 5;
            e2.Y = 0;
            Assert.IsTrue(e1.DistanceToObject(e2) == 5); // horizontale afstand
            e2.X = 4;
            e2.Y = 3;
            Assert.IsTrue(e1.DistanceToObject(e2) == 5); //Verticale afstand, pyhtagors Wortel van (3^2 + 4^2) == 5

            //Tests met ongelijke grootte entities
            e3.X = 2; //hierdoor is het midden van beide objecten op hetzelfde punt
            e3.Y = 2;
            Assert.IsTrue(e1.DistanceToObject(e3) == 0); //afstand is bepaald vana het midden van het object

            e3.X = 10;
            e3.Y = 2;
            Assert.IsTrue(e1.DistanceToObject(e3) == 8); // Horizontale afstand
            e3.X = 2;
            e3.Y = 10;
            Assert.IsTrue(e1.DistanceToObject(e3) == 8); // Verticale afstand
            e3.X = 8;
            e3.Y = 10;
            Assert.IsTrue(e1.DistanceToObject(e3) == 10); //Schuine afstand
            
            
        }
        [TestMethod]
        public void EntityMoveTest()
        {
            OlympusTheGame.INSTANCE = new OlympusTheGame();
            List<Entity> entities = new List<Entity>();
            Entity player = new EntityPlayer(0, 0, 0, 0);
            player.DX = 5;
            player.DY = 10;
            entities.Add(player);
            entities.Add(new EntitySlower(0, 0, 0, 0, 5, 10));
            entities.Add(new EntityCreeper(0, 0, 0, 0, 5, 10, 0));
            entities.Add(new EntityExplode(0, 0, 0, 0, 5, 10, 0));
            entities.Add(new EntityTimeBomb(0, 0, 0, 0, 5, 10, 0));

            for (int i = 0; i < entities.Count; i++)
            {
                Entity e = entities[i];
                e.Move();
                Assert.IsTrue(e.X == 5);
                Assert.IsTrue(e.Y == 10);
                e.Move();
                Assert.IsTrue(e.X == 10);
                Assert.IsTrue(e.Y == 20);
                e.DX = -5;
                e.DY = -10;
                e.Move();
                Assert.IsTrue(e.X == 5);
                Assert.IsTrue(e.Y == 10);
                e.Move();
                Assert.IsTrue(e.X == 0);
                Assert.IsTrue(e.Y == 0);
                e.Move();
                Assert.IsTrue(e.X == 0);
                Assert.IsTrue(e.Y == 0);
            }
        }
    }
}
