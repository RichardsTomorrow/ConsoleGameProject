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
        static void Main()
        {
            Texts.IntroScreenText();
            Drill drill = Texts.PlayerSetup();
            Texts.RosterText(drill);
            drill.DriveDrill();

            //Console.WriteLine("\nend of test");
            //Console.ReadKey();

        }
    }
}
