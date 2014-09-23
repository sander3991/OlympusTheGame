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
                    if (i != j)
                        Assert.IsTrue(objects[i].CollidesWithObject(objects[j])); //ze zijn even groot op dezelfde locatie, dit is dus een collide in alle gevallen!
                }
            }
            for (int i = 0; i < objects.Count; i++)
                objects[i].X = i * 10; //Stelt alle X waardes 10 van elkaar af zodat ze naast elkaar staan.

            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j < objects.Count; j++)
                {
                    if (i != j)
                        Assert.IsFalse(objects[i].CollidesWithObject(objects[j])); //ze zijn uit elkaar gezet, dus nu moet hij niet meer colliden
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
                    if (i != j)
                        Assert.IsFalse(objects[i].CollidesWithObject(objects[j])); //ze zijn uit elkaar gezet, dus nu moet hij niet meer colliden
                }
            }

            GameObject go1, go2;
            go1 = new ObjectStart(10, 10, 0, 0);
            go2 = new ObjectFinish(10, 10, 5, 5);

            Assert.IsTrue(go1.CollidesWithObject(go2));
            Assert.IsTrue(go2.CollidesWithObject(go1));
        }

        [TestMethod]
        public void EntityOutOfBoundsTest()
        {
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
        public void EntityMoveTest()
        {
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
