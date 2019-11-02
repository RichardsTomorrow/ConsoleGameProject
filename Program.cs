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
            drill.Gameplay();
            //ColoringAndText.Traveling(drill);

            //ColoringAndText.Surface();
            //Console.WriteLine("Testing this to see how it looks!!!___=+++=22");
            //Console.ReadKey();

            //ColoringAndText.Soil();
            //Console.WriteLine("Testing this to see how it looks!!!___=+++=22");
            //Console.ReadKey();

            //ColoringAndText.Crust();
            //Console.WriteLine("Testing this to see how it looks!!!___=+++=22");
            //Console.ReadKey();

            //ColoringAndText.UpperMantle();
            //Console.WriteLine("Testing this to see how it looks!!!___=+++=22");
            //Console.ReadKey();

            //ColoringAndText.LowerMantle();
            //Console.WriteLine("Testing this to see how it looks!!!___=+++=22");
            //Console.ReadKey();

            //ColoringAndText.OuterCore();
            //Console.WriteLine("Testing this to see how it looks!!!___=+++=22");
            //Console.ReadKey();

            //ColoringAndText.InnerCore();
            //Console.WriteLine("Testing this to see how it looks!!!___=+++=22");
            //Console.ReadKey();

            Console.WriteLine("\nend of test");
            Console.ReadKey();

        }
    }
}
