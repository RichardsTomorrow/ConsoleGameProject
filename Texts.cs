using System;
using System.Diagnostics;
using Console = Colorful.Console;
using System.Threading;
using System.Text.RegularExpressions;

namespace ConsoleGameProject
{
    public static class Texts
    {
        public static Drill PlayerSetup()
        {
            Coloring.PaperworkColor();
            Console.CursorVisible = true;
            Console.WriteLine("Hello Captain! It seems we mis-placed the paperwork. What is your first name?\n");
            string firstName = NameValidation();
            //Sounds.PenClick();
            Console.WriteLine($"Ok, so your first name is {firstName}! Sorry I am new here what was your last name again?\n");
            string lastName = NameValidation();
            //Sounds.PenClick();
            Console.WriteLine($"OHHHH!! You are {firstName} {lastName}! It is a pleasure to meet you.\n");
            int crewSize = CrewSizeValidation();
            //Sounds.PenClick();
            Console.WriteLine($"Ahh yes! Now I found you! Captain {firstName} {lastName}, total crew of {crewSize}.\n\nGive me a second and I will grab your crew roster.\n");
            CrewPerson player = new CrewPerson(firstName, lastName);
            Drill drill = new Drill(player, crewSize);
            Sounds.Printer();
            //Thread.Sleep(2_000); // 2 seconds
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
        public static void RosterText(Drill drill)
        {
            Coloring.PaperworkColor();
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
            Thread.Sleep(4_000); // 4 seconds
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

            Coloring.IntroGradientColor(introbox);
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
                    "They furiously take notes while pointing out the advanced quartz crystal based technology the inhitants once used.\n\n" +
                    "They are able to fashion some repairs and upgrades for the drill machine with what they have found.\n\n" +
                    "The  Archaeologist begs for more time but you must press on\n\n" +
                    "Oh they also found a secret Atlantean tunnel system beneath the city");
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("Your crew feels as though this place should be more explored but they all must work to stabalize the drill.\n\n" +
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
                Sounds.TardisWoosh();
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("Your crew is amazed by the box.\n\n" +
                    "They try to open it no avail and find nothing external powering it\n\n" +
                    "You make sure to log it so you can report it to the SPC foundation when you get surface side\n\n" +
                    "As you prepare to resume your journey you find some lava tubes leading deeper into the Earth\n\n");
                //Thread.Sleep(5_000); // Tardis sound takes a while
            }
        }
        public static void MagmaFlowText(bool geologistPresent)// leave default coloration
        {
            Console.WriteLine("The magma is viscuos\n");
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
            Console.WriteLine("neutral description of Hell");
            Sounds.HellNoise();
            if (priestPresent)
            {
                Console.WriteLine("Priest says something funny that lightens the mood and lets you escape.\n\n" +
                    "Satan says something along the lines of \"I have always wanted to cast someone into the depths of Hell\"");
                Sounds.SantaLaugh();
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
                    "Your crew bolts the door and continues on before they attract any more attention");
                Sounds.DinoRoar();
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("You drive your drill around marveling at the dinosaur life you see around you.\n\n" +
                    "No one wants to exit the drill since they have all seen the Jurassic Park movies but you all enjoy the distraction.");
                Thread.Sleep(5_000);
            }
        }
        public static void HeyCthulhuText(bool priestPresent) // 
        {
            Console.WriteLine("neutral scene description\n");
            if (priestPresent)
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
                Sounds.ActuallyRobots();
                Thread.Sleep(5_000);
            }
            else
            {
                Console.WriteLine("they are angry about interuption and we fight our way out.\n\n" +
                    "You push the machine to its limits getting away. \n\n" +
                    "Luckily most of the damaged camme from the attack");
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
            Sounds.CthulhuRises();
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
