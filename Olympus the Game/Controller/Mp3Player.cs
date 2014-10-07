using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Olympus_the_Game
{
    public class Mp3Player
    {
        public bool IsPlaying {get; private set;}
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);

        public void Open(string file)
        {
            string command = "close MyMp3";
            mciSendString(command, null, 0, 0);
            command = "open \"" + file + "\" type MPEGVideo alias MyMp3";
            mciSendString(command, null, 0, 0);
        }
        public void Play()
        {
            string command = "play MyMp3";
            mciSendString(command, null, 0, 0);
            IsPlaying = true;
        }
        public void Pauze()
        {
            string command = "stop MyMp3";
            mciSendString(command, null, 0, 0);
            IsPlaying = false;

            //command = "close MyMp3";
            //mciSendString(command, null, 0, 0);
        }

    }
}
