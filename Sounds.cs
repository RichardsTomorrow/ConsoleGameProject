/// sounds curtesy of https://archive.org/details/WilhelmScreamSample, http://www.moviesoundclips.net/sound.php?id=85

using System;
using System.Collections.Generic;
using System.Text;
using NAudio.Wave;
using System.Threading;

namespace ConsoleGameProject
{
    static class Sounds
    {
        private static void SoundPlayer(string filepath)
        {
            using (var audioFile = new AudioFileReader(filepath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public static void DeathScream()
        {
            string Scream = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\WilhelmScream.wav";
            SoundPlayer(Scream);
        }
        public static void TardisWoosh()
        {
            string Woosh = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\tardis.wav";
            SoundPlayer(Woosh);
        }
    }
}
