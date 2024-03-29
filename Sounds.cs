﻿/// sounds curtesy of https://archive.org/details/WilhelmScreamSample, http://www.moviesoundclips.net/sound.php?id=85, http://soundbible.com/1357-Metal-Latch.html, 
/// http://soundbible.com/1165-Dinosaur-Roar.html, http://soundbible.com/1814-Scary.html, http://soundbible.com/1719-Godzilla.html,
/// http://soundbible.com/1317-Sci-Fi-Robot.html, http://soundbible.com/1981-Evil-Laugh-2.html, http://soundbible.com/497-Dot-Matrix-Printer.html,
/// http://soundbible.com/1970-Pen-Clicks.html, 

using System;
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
            string scream = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\WilhelmScream.wav";
            SoundPlayer(scream);
        }
        public static void TardisWoosh()
        {
            string woosh = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\tardis.wav";
            SoundPlayer(woosh);
        }
        public static void HatchOpen()
        {
            string hatch = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\MetalLatch-SoundBible.com-736691159.wav";
            SoundPlayer(hatch);
        }
        public static void DinoRoar()
        {
            string roar = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\DinosaurRoar-SoundBible.com-605392672.wav";
            SoundPlayer(roar);
        }
        public static void HellNoise()
        {
            string spooky = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\Scary-Titus_Calen-1449371204.wav";
            SoundPlayer(spooky);
        }
        public static void CthulhuRises()
        {
            string cry = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\Godzilla-Marc-785758480.wav";
            SoundPlayer(cry);
        }
        public static void ActuallyRobots()
        {
            string boop = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\SciFiRobot-SoundBible.com-481033379.wav";
            SoundPlayer(boop);
        }
        public static void SantaLaugh()
        {
            string laugh = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\Evil_Laugh_2-Sound_Explorer-1081271267.wav";
            SoundPlayer(laugh);
        }
        public static void Printer()
        {
            string print = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\DotMatrix Printer-SoundBible.com-790333844.wav";
            SoundPlayer(print);
        }
        public static void PenClick()
        {
            string click = @"C:\Users\richa\source\repos\ConsoleGameProject\soundFiles\Pen_Clicks-Simon_Craggs-514025171.wav";
            SoundPlayer(click);
        }
    }
}
