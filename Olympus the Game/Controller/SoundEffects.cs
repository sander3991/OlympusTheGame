using System.IO;
using System.Media;

namespace Olympus_the_Game.Controller
{
    /// <summary>
    /// Class voor het afspelen van sound effects
    /// </summary>
    internal static class SoundEffects
    {

        private static readonly SoundPlayer Player = new SoundPlayer();

        /// <summary>
        /// Haal een soundplayer op van een resource.
        /// </summary>
        /// <param name="stream">Een UnmanagedMemoryStream object; Resources uit het geheugen zijn van dit objecttype.</param>
        /// <returns>Een SoundPlayer object met het in de parametere opgegeven stream ingeladen.</returns>
        private static SoundPlayer GetSoundPlayer(UnmanagedMemoryStream stream)
        {
            return new SoundPlayer(stream);
        }

        /// <summary>
        /// Speel een memorystream af.
        /// </summary>
        /// <param name="stream">Een UnmanagedMemoryStream object; Resources uit het geheugen zijn van dit objecttype.</param>
        public static void PlaySound(UnmanagedMemoryStream stream)
        {
            GetSoundPlayer(stream).Play();
        }
    }
}