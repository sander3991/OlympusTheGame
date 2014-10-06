﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olympus_the_Game;
using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntityTimeBomb : EntityExplode
    {
        /// <summary>
        /// De tijd hoe lang het duurt voordat deze entity explodeert
        /// </summary>
        public int EXPLODETIME = 3000; //Aanpasbaar in editor
        public bool touched;
        Stopwatch stopwatch = Stopwatch.StartNew();

        /// <summary>
        /// Een bom die na een bepaalde tijd explodeert. Loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        public EntityTimeBomb(int width, int height, int x, int y, int dx, int dy, double effectStrength)
            : base(width, height, x, y, dx, dy, effectStrength)
        {
            EntityControlledByAI = false;
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.TIMEBOMB;
        }
        /// <summary>
        /// Een bom die na een bepaalde tijd explodeert. Loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        public EntityTimeBomb(int width, int height, int x, int y, double effectStrength)
            : this(width, height, x, y, 0, 0, effectStrength)
        {
            
        }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            PlayField pf = OlympusTheGame.INSTANCE.Playfield;

            if (player != null)
            {
                stopwatch.Stop();
                if (DistanceToObject(player) < 100 && stopwatch.IsRunning == false)
                {
                    stopwatch.Start();
                }

                if (stopwatch.ElapsedMilliseconds >= EXPLODETIME && DistanceToObject(player) > 100)
                    pf.RemoveObject(this);
                else if (stopwatch.ElapsedMilliseconds >= EXPLODETIME && DistanceToObject(player) < 100)
                {
                    pf.Player.Health--;
                    pf.SetPlayerHome();
                    pf.RemoveObject(this);
                    stopwatch.Stop();
                }
 
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            Controller contr = OlympusTheGame.INSTANCE.Controller;
            PlayField pf = OlympusTheGame.INSTANCE.Playfield;
            contr.UpdateGameEvents -= OnUpdate;
            pf.AddObject(new SpriteExplosion(this));
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }

        public override void OnCollide(GameObject gameObject)
        {

        }

        public override string ToString()
        {
            return "TimeBomb";
        }
    }
}
