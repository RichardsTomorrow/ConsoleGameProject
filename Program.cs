using System;
using NAudio.Wave;

namespace ConsoleGameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            string[] test = new string[] { "hello", "darkness", "my old", "friend", "Here", "we meet", "again", "eight", "nine", "ten" };

            ColoringAndText.IntroGradient(test);
            
        }
    }
}
