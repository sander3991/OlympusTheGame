﻿using System;
using Olympus_the_Game.View.Editor;

namespace Olympus_the_Game.Model.Entities
{
    public class EntityPlayer : Entity
    {
        /// <summary>
        ///     De maximum health van een speler
        /// </summary>
        public const int Maxhealth = 5;
        // We houden de BaseDX in BaseDY voor de speler apart bij. Dit doen we omdat we anders de speed modifier elke keer als DX/DY wordt aangevraagd moeten casten naar een int. 
        // Ook al is dit geen zwaar proces, het is naar mijn inziens een betere oplossing om twee extra ints op te slaan in het geheugen. Helemaal omdat er toch maar 1 speler is.
        private int _baseDx;    //De basis DX snelheid zonder modifier.
        private int _baseDy;    //De basis DY snelheid zonder modifier.
        private int _dx;        //De DX snelheid inclusief modifier
        private int _dy;        //De DY snelheid inclusief modifier
        private int _frameCount = 1;
        private int _health;
        private float _propFrame;
        private double _speedModifier = 1;

        /// <summary>
        ///     Initialiseert een spelerobject, een speler begint standaard met <paramref name="=MAXHEALTH" /> health.
        /// </summary>
        /// <param name="width">De breedte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="height">De hoogte van het object, mag niet lager dan 0 zijn</param>
        /// <param name="x">De X positie van het object, mag niet lager dan 0 zijn</param>
        /// <param name="y">De Y positie van het object, mag niet lager dan 0 zijn</param>
        public EntityPlayer(int width, int height, int x, int y)
            : base(width, height, x, y, 0, 0)
        {
            _health = Maxhealth;
            Type = ObjectType.Player;
        }

        [ExcludeFromEditor]
        public override float Frame
        {
            get
            {
                //return 0.5f;
                if (_propFrame == 0.5f)
                {
                    _frameCount++;
                    if (_frameCount%20 == 0)
                        _propFrame = 0f;
                    return 0.5f;
                }
                return _propFrame;
            }
            protected set
            {
                _propFrame = Math.Min(value, 1f);
                _propFrame = Math.Max(value, 0f);
            }
        }

        /// <summary>
        ///     In hoeverre wordt de snelheid van de speler aangepast. Zodra deze wordt aangepast wordt de DX en DY van de speler
        ///     direct aangepast.
        /// </summary>
        public double SpeedModifier
        {
            get { return _speedModifier; }
            set
            {
                double prevSpeed = _speedModifier;
                _speedModifier = value;
                DX = _baseDx; //We stellen opnieuw DX in. De setter van DX (en DY) vermenigvuldigen met de nieuwe speedmodifier.
                DY = _baseDy; //Idem als DX.
            }
        }

        /// <summary>
        ///     Custom DX omdat wij bij de EntityPlayer de speedmodifier ook mee moeten nemen in de snelheid.
        /// </summary>
        public override int DX
        {
            get { return _dx; }
            set { _dx = Convert.ToInt32(value * _speedModifier); _baseDx = value; }
        }

        /// <summary>
        ///     Custom DY omdat wij bij de EntityPlayer de speedmodifier ook mee moeten nemen in de snelheid.
        /// </summary>
        public override int DY
        {
            get { return _dy; }
            set { _dy = Convert.ToInt32(value * _speedModifier); _baseDy = value; }
        }

        /// <summary>
        ///     De Health van de speler
        /// </summary>
        public int Health
        {
            get { return _health; }
            set
            {
                int prevHealth = _health;
                _health = Math.Max(0, value);
                _health = Math.Min(Maxhealth, value);
                if (prevHealth != _health)
                {
                    OlympusTheGame.GameController.PlayerHealthChanged(this, Health, prevHealth);
                    Frame = 0.5f;
                }
            }
        }

        /// <summary>
        ///     Geef de entity een beschrijving
        /// </summary>
        /// <returns>Beschrijving van de entity</returns>
        public override string GetDescription()
        {
            return "De speler";
        }
    }
}