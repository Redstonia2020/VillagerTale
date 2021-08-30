using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace VillagerTale
{
    class Sound
    {
        public static string Directory = "sound/";

        public static void Play(string sound)
        {
            new SoundPlayer() { SoundLocation = $"{Directory}{sound}" }.Play();
        }
    }
}
