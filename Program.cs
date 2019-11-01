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
            Console.WriteLine("hi!");

            var tester = new List<string>();
            for (int i = 0; i < 25; i++)
            {
                var test = new CrewPerson();
                tester.Add(test.FirstName + " " + test.LastName);

            }
            foreach (string name in tester)
            {
                Console.WriteLine(name);
            }

        }
    }
}
