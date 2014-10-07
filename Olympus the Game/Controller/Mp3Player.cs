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
        private static string tempFileLoc;
        private static int fadeInCounter;
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
                player.settings.volume = Math.Min(100, value);
                player.settings.volume = Math.Max(0, value);
            }
        }
        public static bool IsPlaying { get; private set; }
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        public static void Open(string file)
        {
            string command = "close MyMp3";
            mciSendString(command, null, 0, 0);
            command = "open \"" + file + "\" type MPEGVideo alias MyMp3";
            mciSendString(command, null, 0, 0);
        }
        public static void Play()
        {
            string command = "play MyMp3";
            mciSendString(command, null, 0, 0);
            IsPlaying = true;
        }
        public static void Pauze()
        {
            string command = "stop MyMp3";
            mciSendString(command, null, 0, 0);
            IsPlaying = false;

        }

        public static string Status()
        {
            int i = 128;
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(i);
            mciSendString("status MediaFile mode", stringBuilder, i, 0);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Speelt een resource file af.
        /// </summary>
        /// <param name="resource">De resource gespeeld dient te worden</param>
        public static void PlayResource(byte[] resource)
        {
            if(tempFileLoc != null) //Er wordt wat afgespeeld nu
                StopPlaying();
            Loop(false);
            tempFileLoc = String.Format("{0}{1}{2}", System.IO.Path.GetTempPath(), Guid.NewGuid().ToString("N"), ".mp3");
            using (var memoryStream = new MemoryStream(resource))
            using (var tempFileStream = new FileStream(tempFileLoc, FileMode.Create, FileAccess.Write))
            {
                memoryStream.Position = 0;
                memoryStream.WriteTo(tempFileStream);
            }
            player.URL = tempFileLoc;
            player.controls.play();
        }

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
            if (player.settings.volume == 100)
            {
                Timer timer = sender as Timer;
                timer.Stop();
            }
        }

        /// <summary>
        /// Stopt de media player
        /// </summary>
        internal static void StopPlaying()
        {
            player.controls.stop();
            if (File.Exists(tempFileLoc))
                File.Delete(tempFileLoc);
            tempFileLoc = null;
        }
    }
}
