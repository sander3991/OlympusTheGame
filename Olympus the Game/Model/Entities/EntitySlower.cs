using System.Diagnostics;

namespace Olympus_the_Game
{
    public class EntitySlower : Entity
    {
        //TODO Elmar: Access modifiers
        Stopwatch stopwatch = Stopwatch.StartNew();
        EntityWeb web; //TODO Elmar: Is deze wel nodig hier?

        /// <summary>
        /// De afstand waarin deze entity zijn effect werkt
        /// </summary>
        public const int EFFECTRANGE = 10;
        /// <summary>
        /// De sterkte van het effect van deze entity
        /// </summary>
        public const double EFFECTSTRENGTH = 0.5;

        /// <summary>
        /// Een EntitySlower object die spelers langzamer laten lopen, loopt vanaf het begin de meegegeven snelheid
        /// </summary>
        public EntitySlower(int width, int height, int x, int y, int dx, int dy)
            : base(width, height, x, y, dx, dy)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents += OnUpdate;
            Type = ObjectType.SLOWER;
        }
        /// <summary>
        /// Een EntitySlower object die spelers langzamer laten lopen, staat vanaf het begin stil
        /// </summary>
        public EntitySlower(int width, int height, int x, int y) : this(width, height, x, y, 0, 0) { }

        public void OnUpdate()
        {
            EntityPlayer player = OlympusTheGame.INSTANCE.Playfield.Player;
            double distance = DistanceToObject(player);

            if (distance <= 100)
            {   
                // Maak een cobweb aan wanneer er 4 seconden voorbij zijn gegaan nadat de speler in de buurt van de spider komt
                if (stopwatch.ElapsedMilliseconds >= 4000)
                {
                    web = new EntityWeb(55, 55, player.X, player.Y, 0, 0);
                    this.Playfield.AddObject(web);
                    stopwatch.Restart();
                }
            }
        }

        public override void OnRemoved(bool fieldRemoved)
        {
            OlympusTheGame.INSTANCE.Controller.UpdateGameEvents -= OnUpdate;
        }

        public override string ToString()
        {
            return "Spider";
        }


    }
}

