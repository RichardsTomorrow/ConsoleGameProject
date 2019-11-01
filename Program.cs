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
            //string[] test = new string[] { "hello", "darkness", "my old", "friend", "Here", "we meet", "again", "eight", "nine", "ten" };
            ColoringAndText.IntroScreen();
            ColoringAndText.PlayerSetup();

            //var tester = new List<string>();
            //for (int i = 0; i < 9; i++)
            //{
            //    var test = new CrewPerson();
            //    tester.Add(test.FirstName + " \"The "+ test.Trait + "\" "+ test.LastName);

            //}
            //foreach (string name in tester)
            //{
            //    Console.WriteLine(name);
            //}

        }
    }
}
