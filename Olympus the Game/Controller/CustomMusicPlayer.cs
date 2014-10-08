using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Olympus_the_Game
{
    public static class CustomMusicPlayer
    {
        public static bool IsPlaying { get; private set; }

        public static int MasterVolume
        {
            get
            {
                return 0; 
            }
            set
            {
                mciSendString(string.Concat("setaudio MediaFile volume to ", value), null, 0, 0);
            }
        }

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
            if (Mp3Player.IsPlaying)
                Mp3Player.StopPlaying();
        }
        public static void Pause()
        {
            string command = "pause MyMp3";
            mciSendString(command, null, 0, 0);
            IsPlaying = false;
        }

        public static void Stop()
        {
            string command = "close MyMp3";
            mciSendString(command, null, 0, 0);
            command = "stop MyMp3";
            mciSendString(command, null, 0, 0);
            IsPlaying = false;
        }

        
    }
}
