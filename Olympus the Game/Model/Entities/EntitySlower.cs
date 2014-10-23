using System;
using System.Collections.Generic;
using System.Diagnostics;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model.Entities
{
    public class EntitySlower : Entity
    {
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();
        private double prop_effectrange = 200;
        private int prop_firespeed = 2000;

        static EntitySlower()
        {
            RegisterWithEditor(ObjectType.Slower, () => new EntitySlower(50, 50, 0, 0));
            // TODO Maak waarden standaard
        }

        /// <summary>
        ///     Een EntitySlower object die spelers langzamer laten lopen, loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        public EntitySlower(int width, int height, int x, int y, int dx = 0, int dy = 0)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            Type = ObjectType.Slower;
        }

        /// <summary>
        ///     Afstand waarin de spin spinnenwebben afschiet. MIN = 50, DEFAULT = 200
        /// </summary>
        [EditorTooltip("Effect afstand", "Afstand waarin de Spider spinnenwebben schiet.")]
        public double EffectRange
        {
            get { return prop_effectrange; }
            set { prop_effectrange = Math.Max(50, value); }
        }

        /// <summary>
        ///     Snelheid van het schieten van een nieuw spinnenweb. MIN = 1, DEFAULT = 2000
        /// </summary>
        [EditorTooltip("Vuursnelheid", "De snelheid waarmee de Spider spinnenwebben schiet")]
        public int FireSpeed
        {
            get { return prop_firespeed; }
            set { prop_firespeed = Math.Max(1, value); }
        }

        /// <summary>
        ///     Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "Spider maakt je langzaam";
        }


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
                            var web = new EntityWebMissile(this, Playfield.Player);
                            Playfield.AddObject(web);
                        }
                        stopwatch.Restart();
                    }
                }
            }
        }

        /// <summary>
        /// Voorkomt dubbele webs op de start, finish, of op een web
        /// </summary>
        /// <param name="x">De x locatie die gecontroleerd moet worden</param>
        /// <param name="y">De y locatie die gecontroleerd moet worden</param>
        /// <returns>True als er al geen web geschoten mag worden, false als er wel een web geschoten mag worden</returns>
        public bool PreventDoubleWeb(int x, int y)
        {
            List<GameObject> webOnXY = Playfield.GetObjectsAtLocation(x, y);
            if (webOnXY != null)
                foreach (GameObject o in webOnXY)
                    if (o.Type == ObjectType.Web || o.Type == ObjectType.Finish || o.Type == ObjectType.Start)
                        return true;
            return false;
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            // Verwijder dit object uit de gameloop
            OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "Spider";
        }
    }
}