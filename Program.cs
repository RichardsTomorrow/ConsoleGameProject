using System;
using NAudio.Wave;
using System.Drawing;
using Console = Colorful.Console;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ColoringAndText.IntroScreen();
            Drill drill = ColoringAndText.PlayerSetup();
            ColoringAndText.Roster(drill);

            Console.WriteLine("\nend of test");
            Console.ReadKey();

        }
    }
}
