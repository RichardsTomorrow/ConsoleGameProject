using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Console = Colorful.Console;
using System.Threading;

namespace ConsoleGameProject
{
    public static class ColoringAndText
    {
         static void IntroGradient(string[] strings)
        {
            int r = 50; int g = 255; int b = 50;
            for (int i = 0; i < strings.Length; i += 2)
            {
                Console.WriteLine(strings[i], Color.FromArgb(Math.Clamp(r, 0, 255), Math.Clamp(g, 0, 255), Math.Clamp(b, 0, 255)));
                if (i + 1 < strings.Length)
                {
                    Console.WriteLine(strings[i + 1], Color.FromArgb(Math.Clamp(r, 0, 255), Math.Clamp(g, 0, 255), Math.Clamp(b, 0, 255)));
                }
                if (i <= 10) { r += 30; b -= 15; } // transition of green to yellow
                else if (i > 10) { g -= 30; } // transition of yellow to orange
            }
            Debug.Write($"The string length is{strings.Length}");

            //for (int j = 0; j <strings.Length; j++) //this was here until I figure out a way around the console's 16 color limit.
            //{
            //    if (j < 10) { Console.WriteLine(strings[j], Color.Green); }
            //    else if (j < 20) { Console.WriteLine(strings[j], Color.Yellow); }
            //    else { Console.WriteLine(strings[j], Color.Orange); }
            //}
        }

        public static void IntroScreen()
        {
            string[] introbox = new string[]
            {
                @"[]+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%[]",
                @"+|             _____                                                                        __                        |+",
                @"%|            |     \                                                                      |  \                       |%",
                @"+|             \$$$$$  ______   __    __   ______   _______    ______   __    __          _| $$_     ______           |+",
                @"%|               | $$ /      \ |  \  |  \ /      \ |       \  /      \ |  \  |  \        |   $$ \   /      \          |%",
                @"+|          __   | $$|  $$$$$$\| $$  | $$|  $$$$$$\| $$$$$$$\|  $$$$$$\| $$  | $$         \$$$$$$  |  $$$$$$\         |+",
                @"%|         |  \  | $$| $$  | $$| $$  | $$| $$   \$$| $$  | $$| $$    $$| $$  | $$          | $$ __ | $$  | $$         |%",
                @"+|         | $$__| $$| $$__/ $$| $$__/ $$| $$      | $$  | $$| $$$$$$$$| $$__/ $$          | $$|  \| $$__/ $$         |+",
                @"%|          \$$    $$ \$$    $$ \$$    $$| $$      | $$  | $$ \$$     \ \$$    $$           \$$  $$ \$$    $$         |%",
                @"+|           \$$$$$$   \$$$$$$   \$$$$$$  \$$       \$$   \$$  \$$$$$$$ _\$$$$$$$            \$$$$   \$$$$$$          |+",
                @"%|                                                                     |  \__| $$                                     |%",
                @"+|                                                                      \$$    $$                                     |+",
                @"%|                                                                       \$$$$$$                                      |%",
                @"%|                                 _______             __                          __                                 |%",
                @"+|                                |       \           |  \                        |  \                                |+",
                @"%|                                | $$$$$$$\  ______  | $$  ______   __   __   __ | $$                                |%",
                @"+|                                | $$__/ $$ /      \ | $$ /      \ |  \ |  \ |  \| $$                                |+",
                @"%|                                | $$    $$|  $$$$$$\| $$|  $$$$$$\| $$ | $$ | $$| $$                                |%",
                @"+|                                | $$$$$$$\| $$    $$| $$| $$  | $$| $$ | $$ | $$ \$$                                |+",
                @"%|                                | $$$$$$$\| $$    $$| $$| $$  | $$| $$ | $$ | $$ \$$                                |%",
                @"+|                                | $$__/ $$| $$$$$$$$| $$| $$__/ $$| $$_/ $$_/ $$ __                                 |+",
                @"%|                                | $$    $$ \$$     \| $$ \$$    $$ \$$   $$   $$|  \                                |%",
                @"+|                                 \$$$$$$$   \$$$$$$$ \$$  \$$$$$$   \$$$$$\$$$$  \$$                                |+",
                @"%|                                                                                                                    |%",
                @"+|Good morning Captain! You have been selected to lead an expedition to the center of the earth                       |+",
                @"%|text describing the game goes here at some point                                                                    |%",
                @"+|text describing the game goes here at some point                                                                    |+",
                @"%| text describing the game goes here at some point                                                                   |%",
                @"[]+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%[]"
            };
            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            Debug.WriteLine($"Intro screen width:{Console.WindowWidth}");
            Debug.WriteLine($"Intro screen height:{Console.WindowHeight}");

            IntroGradient(introbox);
            Thread.Sleep(5_000); //5 seconds

            Debug.WriteLine($"text color before reset:{Console.ForegroundColor}");

            Console.ReplaceAllColorsWithDefaults();
            System.Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Debug.WriteLine($"text color after reset:{Console.ForegroundColor}");
        }
    }
}
