using System;
using System.IO;
using System.Windows.Forms;
using WMPLib;

namespace Olympus_the_Game.Controller
{
    public static class Mp3Player
    {
        private static readonly WindowsMediaPlayer Player = new WindowsMediaPlayer();
        private static int _fadeInCounter;
        private static bool _stopFading;
        public static bool IsPlaying { get; private set; }
        private static bool _propEnabled = true;
        public static bool Enabled { 
            get{
                return _propEnabled;
            }
            set{
                if (value)
                    Player.settings.volume = 100;
                else
                    Player.settings.volume = 0;
                _propEnabled = value;
                    
            }
        }
        /// <summary>
        /// Het volume van de MediaPlayer
        /// </summary>
        public static int Volume
        {
            get
            {
                return Player.settings.volume;
            }
            set
            {
                if (Enabled)
                {
                Player.settings.volume = Math.Min(100, value);
                Player.settings.volume = Math.Max(0, value);

                }
            }
        }
        /// <summary>
        /// Speelt een resource file af.
        /// </summary>
        /// <param name="resource">De resource gespeeld dient te worden</param>
        public static void SetResource(string resource)
        {
            Loop(false);
            Player.URL = resource;
        }

        public static string PrepareResource(byte[] resource, string name)
        {
            string tfl = String.Format("{0}{1}{2}{3}", System.IO.Path.GetTempPath(), "OlympusTheGame_",name, ".mp3");
            if (File.Exists(tfl))
                File.Delete(tfl);
            using (var memoryStream = new MemoryStream(resource))
            using (var tempFileStream = new FileStream(tfl, FileMode.Create, FileAccess.Write))
            {
                memoryStream.Position = 0;
                memoryStream.WriteTo(tempFileStream);
            }
            return tfl;
        }

        /// <summary>
        /// Zet het loopen aan of uit
        /// </summary>
        /// <param name="loop">True voor loop aan, false voor uit</param>
        public static void Loop(bool loop)
        {
            Player.settings.setMode("loop", loop);
        }
        /// <summary>
        /// Zet de positie van het nummer op het meegegeven punt
        /// </summary>
        /// <param name="pos">De positie in aantal seconden</param>
        public static void SetPosition(double pos)
        {
            Player.controls.currentPosition = pos;
        }

        /// <summary>
        /// Starts playing the resource
        /// </summary>
        public static void PlaySelected()
        {
            Player.controls.play();
            IsPlaying = true;
            if (CustomMusicPlayer.IsPlaying)
                CustomMusicPlayer.Stop();
            _stopFading = true;
        }
        /// <summary>
        /// Do a fade in 
        /// </summary>
        /// <param name="time">De tijd in milliseconde, het minimum is 100</param>
        public static void FadeIn(int time)
        {
            _fadeInCounter = 0;
            Volume = _fadeInCounter;
            Timer timer = new Timer();
            timer.Interval = time / 100;
            timer.Tick += timer_Tick;
            timer.Start();
            Player.controls.pause();
        }

        public static void FadeOut(int time)
        {
            _fadeInCounter = 100;
            Volume = _fadeInCounter;
            Timer timer = new Timer();
            timer.Interval = time / 100;
            timer.Tick += timer_tick_fadeout;
            timer.Start();
            _stopFading = false;
        }

        /// <summary>
        /// Timer method die gebruikt wordt in de FadeIn()
        /// </summary>
        /// <param name="sender">De timer</param>
        /// <param name="e"></param>
        private static void timer_Tick(object sender, EventArgs e)
        {
            Volume = ++_fadeInCounter;
            if (Volume == 1)
                Player.controls.play();
            if (Player.settings.volume == 100 || !IsPlaying)
            {
                Timer timer = sender as Timer;
                timer.Stop();
            }
        }

        private static void timer_tick_fadeout(object sender, EventArgs e)
        {
            Volume = --_fadeInCounter;
            if (Volume == 0 || _stopFading)
            {
                Timer timer = sender as Timer;
                timer.Stop();
                if(!_stopFading)
                   StopPlaying();
                Volume = 100;
            }
        }

        /// <summary>
        /// Stopt de media player
        /// </summary>
        internal static void StopPlaying()
        {
            IsPlaying = false;
            Player.controls.stop();
        }

        /// <summary>
        /// Pauzeer de media speler
        /// </summary>
        internal static void Pause()
        {
            IsPlaying = false;
            Player.controls.pause();

        }
        /// <summary>
        /// Gaat verder met afspelen
        /// </summary>
        internal static void Play()
        {
            IsPlaying = true;
            Player.controls.play();
        }

        /// <summary>
        /// Handelt het verwijderen van de temporary files af
        /// </summary>
        /// <param name="resourceLoc">De locatie van de resource</param>
        internal static void UnloadResource(string resourceLoc)
        {
            if (File.Exists(resourceLoc))
                File.Delete(resourceLoc);
        }
    }
}
