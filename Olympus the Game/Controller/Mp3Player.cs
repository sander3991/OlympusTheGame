using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using WMPLib;
using System.Windows.Forms;

namespace Olympus_the_Game
{
    public static class Mp3Player
    {
        private static WindowsMediaPlayer player = new WindowsMediaPlayer();
        private static int fadeInCounter;
        private static bool stopFading = false;
        public static bool IsPlaying { get; private set; }
        private static bool prop_enabled = true;
        public static bool Enabled { 
            get{
                return prop_enabled;
            }
            set{
                if (value)
                    player.settings.volume = 100;
                else
                    player.settings.volume = 0;
                prop_enabled = value;
                    
            }
        }
        /// <summary>
        /// Het volume van de MediaPlayer
        /// </summary>
        public static int Volume
        {
            get
            {
                return player.settings.volume;
            }
            set
            {
                if (Enabled)
                {
                player.settings.volume = Math.Min(100, value);
                player.settings.volume = Math.Max(0, value);

                }
            }
        }


        /// <summary>
        /// Speelt een resource file af.
        /// </summary>
        /// <param name="resource">De resource gespeeld dient te worden</param>
        public static void SetResource(byte[] resource)
        {
            Loop(false);
            player.URL = PrepareResource(resource);
        }

        /// <summary>
        /// Speelt een resource file af.
        /// </summary>
        /// <param name="resource">De resource gespeeld dient te worden</param>
        public static void SetResource(string resource)
        {
            Loop(false);
            player.URL = resource;
        }

        public static string PrepareResource(byte[] resource)
        {
            string tfl;
            tfl = String.Format("{0}{1}{2}", System.IO.Path.GetTempPath(), Guid.NewGuid().ToString("N"), ".mp3");
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
            player.settings.setMode("loop", loop);
        }
        /// <summary>
        /// Zet de positie van het nummer op het meegegeven punt
        /// </summary>
        /// <param name="pos">De positie in aantal seconden</param>
        public static void SetPosition(double pos)
        {
            player.controls.currentPosition = pos;
        }

        /// <summary>
        /// Starts playing the resource
        /// </summary>
        public static void PlaySelected()
        {
            player.controls.play();
            IsPlaying = true;
            if (CustomMusicPlayer.IsPlaying)
                CustomMusicPlayer.Stop();
            stopFading = true;
        }
        /// <summary>
        /// Do a fade in 
        /// </summary>
        /// <param name="time">De tijd in milliseconde, het minimum is 100</param>
        public static void FadeIn(int time)
        {
            fadeInCounter = 0;
            Volume = fadeInCounter;
            Timer timer = new Timer();
            timer.Interval = time / 100;
            timer.Tick += timer_Tick;
            timer.Start();
            player.controls.pause();
        }

        public static void FadeOut(int time)
        {
            fadeInCounter = 100;
            Volume = fadeInCounter;
            Timer timer = new Timer();
            timer.Interval = time / 100;
            timer.Tick += timer_tick_fadeout;
            timer.Start();
            stopFading = false;
        }

        /// <summary>
        /// Timer method die gebruikt wordt in de FadeIn()
        /// </summary>
        /// <param name="sender">De timer</param>
        /// <param name="e"></param>
        private static void timer_Tick(object sender, EventArgs e)
        {
            Volume = ++fadeInCounter;
            if (Volume == 1)
                player.controls.play();
            if (player.settings.volume == 100 || !IsPlaying)
            {
                Timer timer = sender as Timer;
                timer.Stop();
            }
        }

        private static void timer_tick_fadeout(object sender, EventArgs e)
        {
            Volume = --fadeInCounter;
            if (Volume == 0 || stopFading)
            {
                Timer timer = sender as Timer;
                timer.Stop();
                if(!stopFading)
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
            player.controls.stop();
        }

        /// <summary>
        /// Pauzeer de media speler
        /// </summary>
        internal static void Pause()
        {
            IsPlaying = false;
            player.controls.pause();

        }
        /// <summary>
        /// Gaat verder met afspelen
        /// </summary>
        internal static void Play()
        {
            IsPlaying = true;
            player.controls.play();
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
