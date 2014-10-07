using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Olympus_the_Game
{
    public static class Mp3Player
    {
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

    }
}
