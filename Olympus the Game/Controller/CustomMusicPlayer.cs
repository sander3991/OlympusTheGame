using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Olympus_the_Game
{
    public static class CustomMusicPlayer
    {
        /// <summary>
        /// Geef feedback over de player of hij aan het afspelen is
        /// </summary>
        public static bool IsPlaying { get; private set; }
        /// <summary>
        /// Regel het volume
        /// </summary>
        public static int MasterVolume
        {
            get
            {
                return 0;
            }
            private set
            {
                mciSendString(string.Concat("setaudio MediaFile volume to ", value), null, 0, 0);
            }
        }

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);
        /// <summary>
        /// Open een mp3 file
        /// </summary>
        /// <param name="file"></param>
        public static void Open(string file)
        {
            string command = "close MyMp3";
            mciSendString(command, null, 0, 0);
            command = "open \"" + file + "\" type MPEGVideo alias MyMp3";
            mciSendString(command, null, 0, 0);
        }
        /// <summary>
        /// Speel de file af
        /// </summary>
        /// <param name="repeat">Speel af met of zonder repeat</param>
        public static void Play(bool repeat)
        {
            string command = "play MyMp3";
            if (repeat)
                command += " REPEAT";
            mciSendString(command, null, 0, 0);
            IsPlaying = true;
            if (Mp3Player.IsPlaying)
                Mp3Player.StopPlaying();
        }
        /// <summary>
        /// Pauzeer de speler.
        /// </summary>
        public static void Pause()
        {
            const string command = "pause MyMp3";
            mciSendString(command, null, 0, 0);
            IsPlaying = false;
        }
        /// <summary>
        /// Stop en gooi de mp3 weg
        /// </summary>
        public static void Stop()
        {
            string command = "close MyMp3";
            mciSendString(command, null, 0, 0);
            command = "stop MyMp3";
            mciSendString(command, null, 0, 0);
            IsPlaying = false;
        }
        /// <summary>
        /// Verander het volume
        /// </summary>
        /// <param name="volume"> 1 - 100 hoe hard het volume moet</param>
        public static void ChangeVolume(int volume)
        {

            mciSendString(string.Concat("setaudio MediaFile volume to ", volume), null, 0, 0);
        }


    }
}
