using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;


namespace Olympus_the_Game
{
    public class EntitySlower : Entity
    {
        static EntitySlower()
        {
            RegisterWithEditor(ObjectType.SLOWER, () => { return new EntityCreeper(50, 50, 0, 0, 0.0f); }); // TODO Maak waarden standaard
        }

        private Stopwatch stopwatch = Stopwatch.StartNew();
        private double prop_effectrange = 200;
        private int prop_firespeed = 2000;
        /// <summary>
        /// Afstand waarin de spin spinnenwebben afschiet. MIN = 50, DEFAULT = 100
        /// </summary>
        public double EffectRange
        {
            get { return prop_effectrange; }
            set
            {
                prop_effectrange = Math.Max(50, value);
            }
        }
        /// <summary>
        /// Snelheid van het schieten van een nieuw spinnenweb. MIN = 1, DEFAULT = 200
        /// </summary>
        public int FireSpeed
        {
            get { return prop_firespeed; }
            set
            {
                prop_firespeed = Math.Max(1, value);
            }
        }

        /// <summary>
        /// Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string getDescription()
        {
            return "Spider maakt je langzaam";
        }


        /// <summary>
        /// Een EntitySlower object die spelers langzamer laten lopen, loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        public EntitySlower(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.SLOWER;
        }
        /// <summary>
        /// Een EntitySlower object die spelers langzamer laten lopen, staat vanaf het begin stil
        /// </summary>
        public EntitySlower(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                if (DistanceToObject(Playfield.Player) <= EffectRange)
                {
                    // Maak een entity cobweb aan wanneer er x seconden voorbij zijn gegaan nadat de speler in de buurt van de spider komt
                    if (stopwatch.ElapsedMilliseconds >= FireSpeed)
                    {
                        if (!PreventDoubleWeb(Playfield.Player.X + 25, Playfield.Player.Y + 25))
                        {
                            EntityWebMissile web = new EntityWebMissile(this, Playfield.Player);
                            this.Playfield.AddObject(web);
                        }
                        stopwatch.Restart();
                    }
                }
            }
        }

        //TODO ELMAR: comment
        public bool PreventDoubleWeb(int x, int y)
        {
            List<GameObject> webOnXY = Playfield.GetObjectsAtLocation(x, y);

            bool value = false;
            if (webOnXY != null)
            {
                for (int i = 0; i < webOnXY.Count; i++) //loopt door alle objects
                {
                    GameObject o = webOnXY[i];
                    if (o.Type == ObjectType.WEB || o.Type == ObjectType.FINISH || o.Type == ObjectType.START)
                    {
                        value = true;
                    }
                }
            }
            return value;
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            // Verwijder dit object uit de gameloop
            OlympusTheGame.Controller.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "Spider";
        }


    }
}

