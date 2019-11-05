﻿using System;
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
        public static Drill PlayerSetup()
        {
            PaperworkColor();
            Console.CursorVisible = true;
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
        public static void RosterColorAndText(Drill drill)
        {
            PaperworkColor();
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
        static void IntroGradientColor(string[] strings)
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
        }
        public static void PaperworkColor() // papery white and black text
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.AntiqueWhite;
            Console.Clear();
            Console.ForegroundColor = Color.Black;
        }
        public static void SurfaceColor() // depth 0-10
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.LimeGreen;
            Console.Clear();
            Console.ForegroundColor = Color.Sienna;
            Console.CursorVisible = false;
        }
        public static void SoilColor()// depth 11-50 
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.FromArgb(101, 67, 33);
            Console.Clear();
            Console.ForegroundColor = Color.LightGray;
            Console.CursorVisible = false;
        }
        public static void CrustColor() // depth 11-100
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DimGray;
            Console.Clear();
            Console.ForegroundColor = Color.DarkOrange;
            Console.CursorVisible = false;
        }
        public static void UpperMantleColor() //  depth 101-200
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Coral;
            Console.Clear();
            Console.ForegroundColor = Color.DarkRed;
            Console.CursorVisible = false;
        }
        public static void LowerMantleColor() //  depth 201-300
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkRed;
            Console.Clear();
            Console.ForegroundColor = Color.DarkOrange;
            Console.CursorVisible = false;
        }
        public static void OuterCoreColor() //  depth 301-400
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkOrange;
            Console.Clear();
            Console.ForegroundColor = Color.Gold;
            Console.CursorVisible = false;
        }
        public static void InnerCoreColor() //  depth 401-500
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Goldenrod;
            Console.Clear();
            Console.ForegroundColor = Color.LightGoldenrodYellow;
            Console.CursorVisible = false;
        }
        public static void LostCityColor()// coffee brownish, text a light sharp blue 
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Tan;
            Console.Clear();
            Console.ForegroundColor = Color.Cyan;
            Console.CursorVisible = false;
        }
        public static void TardisCaveColor()// color this like tardis
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = Color.LightBlue;
            Console.CursorVisible = false;
        }
        public static void HeySatanColor()// some kind of red and black theme
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Black;
            Console.Clear();
            Console.ForegroundColor = Color.Red;
            Console.CursorVisible = false;
        }
        public static void DinosaursColor()// darker but still jungly green background with orangered text
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Green;
            Console.Clear();
            Console.ForegroundColor = Color.OrangeRed;
            Console.CursorVisible = false;
        }
        public static void HeyCthulhuColor()// dark olive green and  dark magenta since cthulu sleeps
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkOliveGreen;
            Console.Clear();
            Console.ForegroundColor = Color.DarkMagenta;
            Console.CursorVisible = false;
        }
        public static void YouFreakingSummonedCthulhuColor()// dark olive green and regular magenta since cthulu wakes
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkOliveGreen;
            Console.Clear();
            Console.ForegroundColor = Color.Magenta;
            Console.CursorVisible = false;
        }
        public static void HeyLizardPeepsColor()// deep blue background with gold text
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = Color.Gold;
            Console.CursorVisible = false;
        }
        public static void CrewAllDeadColor()// black with text the color of bones
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Black;
            Console.Clear();
            Console.ForegroundColor = Color.WhiteSmoke;
            Console.CursorVisible = false;
        }
        public static void AtTheCenterColor()// pinks
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.MediumOrchid;
            Console.Clear();
            Console.ForegroundColor = Color.LightPink;
            Console.CursorVisible = false;
        }
        public static void IntroScreenText()
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

            IntroGradientColor(introbox);
            Thread.Sleep(5_000); //5 seconds

            Debug.WriteLine($"text color before reset:{Console.ForegroundColor}");

            Console.ReplaceAllColorsWithDefaults();
            Console.Clear();

            Debug.WriteLine($"text color after reset:{Console.ForegroundColor}");
        }
        public static void DrillApperanceText(int health)
        {
            if (health > 100)
            {
                Console.WriteLine("Somehow your drill looks better than it did in the drill bay\n");
            }
            else if (health >= 80)
            {
                Console.WriteLine("The drill looks mostly pristine\n");
            }
            else if (health >= 60)
            {
                Console.WriteLine("The drill has some wear on it\n");
            }
            else if (health >= 40)
            {
                Console.WriteLine("The drill will need repairs at the end of this.\n");
            }
            else if (health > 20)
            {
                Console.WriteLine("The drill is worse for wear\n\n");
            }
            else if (health > 0)
            {
                Console.WriteLine("If it wasn't so bad outside you wouldn't want to be in here\n");
            }
        }
        public static void LostCityText(bool archaeologistPresent)//
        {

            Console.WriteLine("Your drill pops out of a cavern roof and falls to the floor.\n\n All around you lay the ruins of an strange ancient city.\n");
            if (archaeologistPresent)
            {
                Console.WriteLine("The Archaeologist realizes this is actually the lost city of Lemuria!\n\n" +
                    "They furiously take notes while pointing out the advance quartz crystal based technology the inhitants once used.\n\n" +
                    "They are able to fashion some repairs and upgrades for the drill machine with what they have found.\n\n" +
                    "The  Archaeologist begs for more time but you must press on\n\n" +
                    "Oh they also found a secret Atlantean tunnel system beneath the city"); // throw in a stargate reference to a circle in Atlantis
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("Your crew feels as though this place should be more explored but they all must work to stabalize the drill after its fall.\n\n" +
                    "They prevent too much damage from happening but there is some that can't be fixed until you get to the surface ");
                Thread.Sleep(5_000);
            }
        }
        public static void TardisCaveText(bool doctorPresent)
        {
            Console.WriteLine("Your drill emerges into a vast cave system, right next to a blue phone box with a light glow eminating from its windows\n");
            if (doctorPresent)
            {
                Console.WriteLine("The Doctor is ecstatic! They talk about how this situation turned out to be better than fishfingers and custard.\n\n" +
                    "They bid everyone adieu and enter the box.\n\n" +
                    "The blue phone box turns transparent and disappears\n\n" +
                    "Eveyone pauses for a moment to realize they now have one less in the party\n\n" +
                    "On the plus side you found a lava tube");
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("Your crew is amazed by the box.\n\n" +
                    "They try to open it no avail and find nothing external powering it\n\n" +
                    "You make sure to log it so you can report it to the SPC foundation when you gret surface side\n\n" +
                    "As you prepare to resume your journey you find some lava tubes leading deeper into the Earth\n\n");
                Thread.Sleep(5_000);
            }
        }
        public static void MagmaFlowText(bool geologistPresent)// leave default coloration
        {
            Console.WriteLine("Your drill emerges into a vast cave system, right next to a blue phone box with a light glow eminating from its windows\n");
            if (geologistPresent)
            {
                Console.WriteLine("The Geologist pipes up \"Hey guys I think I figured out a way to use some of the unique conditions in the mantel to propel us mostly through it\"\n\n" +
                    "\"Would it harm the ship?\"\n\n" +
                    "\"It will put a little stress on us but we should be able to take it\"\n\n" +
                    "\"Make it so\"\n\n" +
                    "The whole ship lurches forward and after 15 minutes of worry you slow to a pace similar to before.\n\n" +
                    "Your shields were a little damaged but you are much closer to your goals");
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("You feel a jolt\n\n" +
                    "The ship has been caught in a magma flow and you feel it get dragged down\n\n" +
                    "You are deeper but your drill has gotten tossed around");
                Thread.Sleep(5_000);
            }
        }
        public static void HeySatanText(bool priestPresent) //some kind of red and black theme
        {
            Console.WriteLine("description of Hell");
            if (priestPresent)
            {
                Console.WriteLine("Priest says something funny that lightens the mood and lets you escape.\n\n" +
                    "Satan says something along the lines of \"I have always wanted to cast someone into the depths of Hell\"");
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("You run from the fires of hell while they attack");
                Thread.Sleep(5_000);
            }
        }
        public static void DinosaursText(bool paleoPresent)
        {
            Console.WriteLine("You emerge from the Earth into a strangely lit cavern.");
            if (paleoPresent)
            {
                Console.WriteLine("The Paleontologist is amazed at what they see.Dinosaurs of all types and from many different eras coexisting in a space a thousand miles from the surface.\n\n" +
                    "The Paleontologist demands they be allowed out of the machine and then they immediately run over and start digging in a pile on dino droppings.\n\n" +
                    "Unfortunately dino droppings are stickier than movies would have you believe, and the Paleontologist is stuck as a Deinonychus approaches\n\n" +
                    "\"GO ON WITHOUT ME\", they yell, \"YOU MUST TELL THE WORLD OF THIS BRAND NEW UNTHOUGHT OF HUNTING TECHNIQUE\"" +
                    "Your crew bolts the door and continues on before they attract anymore attention");
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("You drive your drill around marveling at the dinosaur life you see around you.\n\n" +
                    "No one wants to exit the drill since they have all seen the Jurassic Park movies but you all enjoy the distraction.");
                Thread.Sleep(5_000);
            }
        }
        public static void HeyCthulhuText(bool occultPresent) // 
        {
            Console.WriteLine("neutral scene description\n");
            if (occultPresent)
            {
                Console.WriteLine("Occultist recognizes this place as Raleigh and breaks away\n\n" +
                    "but I thought that Raleigh was under the ocean? technically we are");
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("The crewfeels a dark prescence full of words that that only spooky white dude would say.\n\n" +
                    "My boyfriend James could help fill this out. Basically the crew flees exhistantal dread or something");
                Thread.Sleep(5_000);
            }
        }
        public static void HeyLizardPeepsText(bool robotPresent)
        {
            Console.WriteLine("neutral scene description there are lizard illuminati masons having a meeting in this decorated chamber\n\n" +
                "Crew interupts");
            if (robotPresent)
            {
                Console.WriteLine("Robot dude realizes that the lizard illuminati masons are actually robots. They bribe us with world hero ending");
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("they are angry about interuption and we fight our way out");
                Thread.Sleep(5_000);
            }
        }
        public static void BowToTheRobotsIMeanLizardsEnding()
        {
            Console.Clear();
            Console.WriteLine("Your crew takes the offer from the robot ... I mean lizard rulers of the world.\n\n" +
                "Everywhere you are thanked for discovering the cure to cancer/ the common cold at the center of the earth\n\n" +
                "Mention feeling hollow");
            Thread.Sleep(5_000); // 5 seconds
            Environment.Exit(0);
        }
        public static void YouFreakingSummonedCthulhuEnding()
        {
            Console.Clear();
            Console.WriteLine("basically summons cthulhu and causes cthulu and destroyed the earth end game good job");
            Thread.Sleep(5_000); // 5 seconds
            Environment.Exit(0);
        }
        public static void DrillHealthDepletedEnding()// no custom color
        {
            Console.Clear();
            Console.WriteLine("You didn't take proper care of your drill and it exploded.More story will go here at some point");
            Thread.Sleep(5_000); // 5 seconds
            Environment.Exit(0);
        }
        public static void CrewAllDeadEnding()
        {
            Console.Clear();
            Console.WriteLine("You didn't take proper care of your crew and now you can't hand a situation.\n\nYour heat shields are now failing and no one can go out and fix it.\n\n More story will go here at some point");
            Thread.Sleep(5_000); // 5 seconds
            Environment.Exit(0);
        }
        public static void AtTheCenterEnding()
        {
            Console.Clear();
            Console.WriteLine("You made it to the center of the planet. WOOWOWOWOWOWOWO!!@!1!\n\n" +
                "Who would've thought it was pink?");
            Thread.Sleep(5_000); // 5 seconds
            Environment.Exit(0);
        }
    }
}
