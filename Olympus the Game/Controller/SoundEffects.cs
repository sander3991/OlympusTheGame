using System.IO;
using System.Media;

namespace Olympus_the_Game.Controller
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
