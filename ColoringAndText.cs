using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Console = Colorful.Console;
using System.Threading;
using System.Text.RegularExpressions;

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
            //Debug.Write($"The string length is {strings.Length}");

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
                @"[]+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+[]",
                @"+|             _____                                                                        __                       |+",
                @"%|            |     \                                                                      |  \                      |%",
                @"+|             \$$$$$  ______   __    __   ______   _______    ______   __    __          _| $$_     ______          |+",
                @"%|               | $$ /      \ |  \  |  \ /      \ |       \  /      \ |  \  |  \        |   $$ \   /      \         |%",
                @"+|          __   | $$|  $$$$$$\| $$  | $$|  $$$$$$\| $$$$$$$\|  $$$$$$\| $$  | $$         \$$$$$$  |  $$$$$$\        |+",
                @"%|         |  \  | $$| $$  | $$| $$  | $$| $$   \$$| $$  | $$| $$    $$| $$  | $$          | $$ __ | $$  | $$        |%",
                @"+|         | $$__| $$| $$__/ $$| $$__/ $$| $$      | $$  | $$| $$$$$$$$| $$__/ $$          | $$|  \| $$__/ $$        |+",
                @"%|          \$$    $$ \$$    $$ \$$    $$| $$      | $$  | $$ \$$     \ \$$    $$           \$$  $$ \$$    $$        |%",
                @"+|           \$$$$$$   \$$$$$$   \$$$$$$  \$$       \$$   \$$  \$$$$$$$ _\$$$$$$$            \$$$$   \$$$$$$         |+",
                @"%|                                                                     |  \__| $$                                    |%",
                @"+|                                                                      \$$    $$                                    |+",
                @"%|                                                                       \$$$$$$                                     |%",
                @"%|                                 _______             __                          __                                |%",
                @"+|                                |       \           |  \                        |  \                               |+",
                @"%|                                | $$$$$$$\  ______  | $$  ______   __   __   __ | $$                               |%",
                @"+|                                | $$__/ $$ /      \ | $$ /      \ |  \ |  \ |  \| $$                               |+",
                @"%|                                | $$    $$|  $$$$$$\| $$|  $$$$$$\| $$ | $$ | $$| $$                               |%",
                @"+|                                | $$$$$$$\| $$    $$| $$| $$  | $$| $$ | $$ | $$ \$$                               |+",
                @"%|                                | $$$$$$$\| $$    $$| $$| $$  | $$| $$ | $$ | $$ \$$                               |%",
                @"+|                                | $$__/ $$| $$$$$$$$| $$| $$__/ $$| $$_/ $$_/ $$ __                                |+",
                @"%|                                | $$    $$ \$$     \| $$ \$$    $$ \$$   $$   $$|  \                               |%",
                @"+|                                 \$$$$$$$   \$$$$$$$ \$$  \$$$$$$   \$$$$$\$$$$  \$$                               |+",
                @"%|                                                                                                                   |%",
                @"+|Good morning Captain! You have been selected to lead an expedition to the center of the earth                      |+",
                @"%|text describing the game goes here at some point                                                                   |%",
                @"+|text describing the game goes here at some point                                                                   |+",
                @"%| text describing the game goes here at some point                                                                  |%",
                @"[]+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+[]"
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
            Console.Clear();

            Debug.WriteLine($"text color after reset:{Console.ForegroundColor}");
        }

        static string NameValidation()
        {
            var name = Console.ReadLine();
            string noNumbers = @"[A-Z][^\d.&,]{2,12}$"; //beware messing with this dark magic
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Come on you can't have a blank name. Try again!");
                Debug.WriteLine($"1The name not being matched is : {name}");
                name = NameValidation();
            }
            else if (!Regex.Match(name, noNumbers).Success)
            {
                Console.WriteLine("Your name must begin with an uppercase later and only contain letters A-Z .");
                Debug.WriteLine($"2The name not being matched is : {name}");
                name = NameValidation();
            }
            else if (name.Length > 12)
            {
                Console.WriteLine("Sorry our computer system is ancient and can only handle a name 12 letters long. Do you have nickname?");
                Debug.WriteLine($"3The name not being matched is : {name}");
                name = NameValidation();
            }
            return name;
        }
        static int CrewSizeValidation()
        {
            Console.WriteLine($"One more question! Are you rated for a three-person, four-person, or five-person crew?\n");
            if (!Int32.TryParse(Console.ReadLine(), out int crewSize))
            {
                Console.WriteLine($"Sorry I must've misheard you, since that doesn't sound like a number. How many are in your crew?");
                crewSize = CrewSizeValidation();
            }
            else if (crewSize < 3 || crewSize > 5)
            {
                Console.WriteLine($"Wooah!, you must of misheard me. We only have drills that can hold 3-5 people. How many are on your crew?");
                crewSize = CrewSizeValidation();
            }
            return crewSize;
        }

        public static Drill PlayerSetup()
        {
            Console.BackgroundColor = Color.AntiqueWhite;
            Console.Clear();
            Console.ForegroundColor = Color.Black;
            Console.CursorVisible = true;
            var textColor = Color.Black;
            Console.WriteLine("Hello Captain! It seems we mis-placed the paperwork. What is your first name?\n");
            string firstName = NameValidation();
            Console.WriteLine($"Ok, so your first name is {firstName}! Sorry I am new here what was your last name again?\n");
            string lastName = NameValidation();
            Console.WriteLine($"OHHHH!! You are {firstName} {lastName}! It is a pleasure to meet you.\n");
            int crewSize = CrewSizeValidation();
            Console.WriteLine($"Ahh yes! Now I found you! Captain {firstName} {lastName}, total crew of {crewSize}.\n\nGive me a second and I will grab your crew roster.\n");
            CrewPerson player = new CrewPerson(firstName, lastName);
            Drill drill = new Drill(player, crewSize);
            Thread.Sleep(2_000); // 2 seconds
            return drill;
        }

        public static void Roster(Drill drill)
        {
            Console.BackgroundColor = Color.AntiqueWhite;
            Console.Clear();
            Console.ForegroundColor = Color.Black;
            Console.CursorVisible = false;
            Console.WriteLine($"Found it! It looks like the administration has already selected your crew of {drill.CrewSize}.\n\nThey are an outstanding group of people even if they have a few quirks.\n");
            for (int i = 0; i < drill.CrewSize - 1; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"Your first officer is {drill.CrewPeople[i].FirstName} \"The {drill.CrewPeople[i].Trait}\" {drill.CrewPeople[i].LastName}\n");
                }
                else if (i == drill.CrewSize - 2)
                {
                    Console.WriteLine($"Last but not least is {drill.CrewPeople[i].FirstName} \"The {drill.CrewPeople[i].Trait}\" {drill.CrewPeople[i].LastName}\n");
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine($"Next we have {drill.CrewPeople[i].FirstName} \"The {drill.CrewPeople[i].Trait}\" {drill.CrewPeople[i].LastName}\n");
                    }
                    else
                    {
                        Console.WriteLine($"Then we have {drill.CrewPeople[i].FirstName} \"The {drill.CrewPeople[i].Trait}\" {drill.CrewPeople[i].LastName}\n");
                    }
                }
            }
            Console.WriteLine($"And finally we have you, {drill.Player.FirstName} \"The {drill.Player.Trait}\" {drill.Player.LastName}.\n");
            Console.WriteLine("I wish you all luck on your journey and I hope you are prepared for whatever you find.");
            Thread.Sleep(3_000); // 3 seconds
            Console.ReplaceAllColorsWithDefaults();

        }
        public static void Surface() // depth 0-10
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.LimeGreen;
            Console.Clear();
            Console.ForegroundColor = Color.Sienna;
            Console.CursorVisible = false;
        }
        public static void Soil()// depth 11-50
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Chocolate;
            Console.Clear();
            Console.ForegroundColor = Color.DimGray;
            Console.CursorVisible = false;
        }
        public static void Crust() // depth 51-100
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DimGray;
            Console.Clear();
            Console.ForegroundColor = Color.DarkOrange;
            Console.CursorVisible = false;
        }
        public static void UpperMantle() //  depth 101-200
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Coral;
            Console.Clear();
            Console.ForegroundColor = Color.DarkRed;
            Console.CursorVisible = false;
        }
        public static void LowerMantle() //  depth 201-300
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkRed;
            Console.Clear();
            Console.ForegroundColor = Color.DarkOrange;
            Console.CursorVisible = false;
        }
        public static void OuterCore() //  depth 301-400
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkOrange;
            Console.Clear();
            Console.ForegroundColor = Color.Gold;
            Console.CursorVisible = false;
        }
        public static void InnerCore() //  depth 401-500
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Goldenrod;
            Console.Clear();
            Console.ForegroundColor = Color.LightGoldenrodYellow ;
            Console.CursorVisible = false;
        }

        //public static void Traveling(Drill drill)
        //{

        //}
    }
}
