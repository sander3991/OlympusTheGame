using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.IO;

namespace Olympus_the_Game
{
    static class SoundEffects
    {
        private static readonly SoundPlayer player = new SoundPlayer();

        private static SoundPlayer GetSoundPlayer(UnmanagedMemoryStream stream)
        {
            return new SoundPlayer(stream);
        }

        public static void PlaySound(UnmanagedMemoryStream stream)
        {
            GetSoundPlayer(stream).Play();
        }

        public static void MuteSound()
        {
            player.Dispose();
        }
    }
}
