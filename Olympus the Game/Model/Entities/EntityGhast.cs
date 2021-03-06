﻿using System;
using System.Diagnostics;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityGhast : Entity
    {
        private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
        private int _propDetectrange = 150;
        private int _propFirespeed = 1050;

        static EntityGhast()
        {
            RegisterWithEditor(ObjectType.Ghast, () => new EntityGhast(50, 50, 0, 0));
            // TODO Maak waarden standaard
        }

        /// <summary>
        /// Een ghast die vuurballen schiet zodra de speler in een configureerbare radius loopt
        /// </summary>
        public EntityGhast(int width, int height, int x, int y, int dx = 0, int dy = 0)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.GameController.UpdateGameEvents += OnUpdate;
            Type = ObjectType.Ghast;
            EntityControlledByAi = true;
        }

        /// <summary>
        ///     Vuursnelheid van de ghast. MIN = 0, DEFAULT = 1000
        /// </summary>
        [EditorTooltip("Vuur snelheid", "De snelheid waarmee de Ghast vuurballen schiet in milliseconden.")]
        public int FireSpeed
        {
            get { return _propFirespeed; }
            set { _propFirespeed = Math.Max(0, value); }
        }

        /// <summary>
        ///     Afstand van wanneer de Ghast begint met aanvallen. MIN = 50, DEFAULT = 150
        /// </summary>
        [EditorTooltip("Detectie afstand", "De afstand van wanneer de Ghast begint met aanvallen.")]
        public int DetectRange
        {
            get { return _propDetectrange; }
            set { _propDetectrange = Math.Max(50, value); }
        }

        /// <summary>
        ///     Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "Ghast schiet vuurballen";
        }

        private void OnUpdate()
        {
            if (Playfield.Player != null)
            {
                // Wanneer de speler in de buurt van dit object komt:
                if (DistanceToObject(Playfield.Player) <= DetectRange)
                {
                    // Vuur dan een vuurbal af om de x aantal seconden
                    if (_stopwatch.ElapsedMilliseconds >= FireSpeed)
                    {
                        var fireball = new EntityFireBall(25, 25, X, Y, 0, 0, this, Playfield.Player);
                        Playfield.AddObject(fireball);
                        _stopwatch.Restart();
                    }
                }
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            // Verwijder dit object uit de gameloop
            OlympusTheGame.GameController.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "Ghast";
        }
    }
}