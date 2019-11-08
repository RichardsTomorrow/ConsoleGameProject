/// Some text and dialog provided by my beautiful husband, James Morrow.
using System;
using System.Diagnostics;
using Console = Colorful.Console;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;

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
            Console.WriteLine($"Ok, so your first name is {firstName}! Sorry I am new here what was your last name again?\n");
            string lastName = NameValidation();
            Console.WriteLine($"OHHHH!! You are {firstName} {lastName}! It is a pleasure to meet you.\n");
            int crewSize = CrewSizeValidation();
            Console.WriteLine($"Ahh yes! Now I found you! Captain {firstName} {lastName}, total crew of {crewSize}.\n\nGive me a second and I will grab your crew roster.\n");
            Sounds.Printer();
            Console.WriteLine($"It looks like eveyone is ready to go and already waiting for you in the drill.\n\n" +
                $"Some of your crew is a little quirky but just like you they went through a drill development apprenticeship,\nso you should be fine.\n\nI wish you luck on your journey!");
            CrewPerson player = new CrewPerson(firstName, lastName);
            Drill drill = new Drill(player, crewSize);
            Thread.Sleep(8_000);
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
        static int CrewSizeValidation()//validates the crew size
        {
            Console.WriteLine($"One more question! Are you rated for a three-person, four-person, or five-person crew?\n");
            if (!Int32.TryParse(Console.ReadLine(), out int crewSize))
            {
                Console.WriteLine($"Sorry I must've misheard you, since that doesn't sound like a number. How many are in your crew?\n");
                crewSize = CrewSizeValidation();
            }
            else if (crewSize < 3 || crewSize > 5)
            {
                Console.WriteLine($"Wooah!, you must of misheard me. We only have drills that can hold 3-5 people. How many are on your crew?\n");
                crewSize = CrewSizeValidation();
            }
            return crewSize;
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
                @"+|                                 _______             __                          __                                |+",
                @"%|                                |       \           |  \                        |  \                               |%",
                @"+|                                | $$$$$$$\  ______  | $$  ______   __   __   __ | $$                               |+",
                @"%|                                | $$__/ $$ /      \ | $$ /      \ |  \ |  \ |  \| $$                               |%",
                @"+|                                | $$    $$|  $$$$$$\| $$|  $$$$$$\| $$ | $$ | $$| $$                               |+",
                @"%|                                | $$$$$$$\| $$    $$| $$| $$  | $$| $$ | $$ | $$ \$$                               |%",
                @"+|                                | $$$$$$$\| $$    $$| $$| $$  | $$| $$ | $$ | $$ \$$                               |+",
                @"%|                                | $$__/ $$| $$$$$$$$| $$| $$__/ $$| $$_/ $$_/ $$ __                                |%",
                @"+|                                | $$    $$ \$$     \| $$ \$$    $$ \$$   $$   $$|  \                               |+",
                @"%|                                 \$$$$$$$   \$$$$$$$ \$$  \$$$$$$   \$$$$$\$$$$  \$$                               |%",
                @"+|                                                                                                                   |+",
                @"%|         Good morning Captain! You have been selected to lead an expedition to the center of the earth!            |%",
                @"+|      Your crew is the best of the best, but drilling is hard work, and there’s not a lot of room in there.        |+",
                @"%|       You must balance the needs of your crew with the maintenance of your craft else you’ll never reach          |%",
                @"+|                                                the center of the Earth!                                           |+",
                @"[]+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+%+[]"
            };
            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            Debug.WriteLine($"Intro screen width:{Console.WindowWidth}");
            Debug.WriteLine($"Intro screen height:{Console.WindowHeight}");

            Coloring.IntroGradientColor(introbox);
            Thread.Sleep(10_000); //5 seconds

            Debug.WriteLine($"text color before reset:{Console.ForegroundColor}");

            Console.ReplaceAllColorsWithDefaults();
            Console.Clear();

            Debug.WriteLine($"text color after reset:{Console.ForegroundColor}");
        }
        public static void DrillApperanceText(int health)
        {
            if (health > 100)
                Console.WriteLine("Somehow your drill looks better than it did in the drill bay\n");
            else if (health >= 80)
                Console.WriteLine("The drill looks mostly pristine\n");
            else if (health >= 60)
                Console.WriteLine("The drill has some wear on it\n");
            else if (health >= 40)
                Console.WriteLine("The drill will need repairs at the end of this.\n");
            else if (health > 20)
                Console.WriteLine("The drill is worse for wear\n");
            else if (health > 0)
                Console.WriteLine("If it wasn't so bad outside you wouldn't want to be in here\n");
        }
        public static void KitInventoryText(int heal, int repair)
        {
            if (heal >= 2)
                Console.Write($"You have {heal} health kits and ");
            else if (heal == 1)
                Console.Write($"You have only {heal} health kit and ");
            else  //(heal == 0)
                Console.Write($"You have zero health kits and ");

            if (repair >= 2)
                Console.Write($"{repair} repair kits.\n\n");
            else if (repair == 1)
                Console.Write($"just {repair} repair kit remains.\n\n");
            else // (repair > 0)
                Console.Write($"are out of repair kits.\n\n");
        }
        public static void LostCityText(bool archaeologistPresent)//
        {
            Console.WriteLine("Your drill pops out of a cavern roof and falls to the floor.\n\n" +
                " All around you lay the ruins of an strange, ancient city.\n\n\n");
            if (archaeologistPresent)
            {
                Console.WriteLine("The Archaeologist realizes this is actually the lost city of Lemuria!\n\n" +
                    "They furiously take notes while pointing out the advanced quartz crystal-based technology the inhabitants once used.\n\n" +
                    "They are able to fashion some repairs and upgrades for the drill with the native technology in the city.\n\n" +
                    "The  Archaeologist swears they can supercharge the drill and begs for more time but you must press on\n\n" +
                    "Oh, they also found a secret Atlantean tunnel system beneath the city which takes you deeper into the earth…");
                Thread.Sleep(15_000);
            }
            else
            {
                Console.WriteLine("Your crew feels like someone should explore this place but they are all too busy working to stabilize the drill.\n\n" +
                    "They prevent much of the damage but there are some parts that can't be fixed until you get back to the surface.");
                Thread.Sleep(10_000);
            }
        }
        public static void TardisCaveText(bool doctorPresent)// change this a little more
        {
            Console.WriteLine("Your drill emerges into a vast cave system, right next to a blue phone box with a light glow eminating from its windows\n\n");
            if (doctorPresent)
            {
                Console.WriteLine("The Doctor is ecstatic!\n\n" +
                    "\"I was hoping I left my TARDIS here!\"\n\n" +
                    "The Doctor mummbles something about \"fishfingers and custard\".\n\n" +
                    "They bid everyone adieu and enter the box.\n\n" +
                    "The blue phone box turns transparent and disappears with a distinctive noise.\n\n" +
                    "Eveyone pauses for a moment to realize they now have one less in the party.\n\n" +
                    "On the plus side when the TARDIS leaves you find a deep lava tube behind it.");
                Sounds.TardisWoosh();
                //Thread.Sleep(5_000); // Tardis sound takes a while
            }
            else
            {
                Console.WriteLine("Your crew is amazed by the box.\n\n" +
                    "They try to open it no avail and find nothing external powering it\n\n" +
                    "You make sure to log it so you can report it to the SCP foundation when you get surface side\n\n" +
                    "As you prepare to resume your journey you find some lava tubes leading deeper into the Earth\n\n");
                Thread.Sleep(10_000); // Tardis sound takes a while
            }
        }
        public static void MagmaFlowText(bool geologistPresent)// leave default coloration
        {
            Console.WriteLine("The magma here isn't viscous\n\n");
            if (geologistPresent)
            {
                Console.WriteLine("The Geologist pipes up \"Hey guys! I think I’ve figured out a way to use the unique conditions in this part of the mantel to propel us faster!\"\n\n" +
                    "\"Will it harm the ship?\"\n\n" +
                    "\"It will put a little stress on us but we should be able to take it.\"\n\n" +
                    "\"Make it so, number one!\"\n\n" +
                    "The whole ship lurches forward and makes a continuous creaking sound.\n\n" +
                    "After 20 minutes of tense worrying, you slow to a pace similar to before.\n\n" +
                    "Your shields are a little damaged but you are much closer to your goal.");
                Thread.Sleep(16_000);
            }
            else
            {
                Console.WriteLine("You feel a jolt\n\n" +
                    "The ship has been caught in a magma flow that swiftly drags it down.\n\n" +
                    "You are deeper but your drill has gotten tossed around");
                Thread.Sleep(8_000);
            }
        }
        public static void HeySatanText(bool priestPresent) //some kind of red and black theme
        {
            Console.WriteLine("You fall into a cave system. All around, rocks are bursting into flame and pools of acid bubble.\n\n" +
                "A huge being with curved horns and massive hooves sits upon a throne and speaks in a powerful, terrible voice.\n\n" +
                "\"Who dares enter my domain ?\"\n\n");
            Sounds.HellNoise();
            if (priestPresent)
            {
                Console.WriteLine("The Priest shakily creeps up to the microphone, a rosary clutched in one fist.\n\n" +
                    "We are the servants of the most high God! I rebuke thee, Satan! I cast the into Hell in the name of the Father,\nand the Son, and the Holy Ghost!\n\n" +
                    "The great beast laughs as nothing happens.\n\n" +
                    "\"You cannot command me from within my own domain!\"\n\n" +
                    "The beast laughed again, then grew thoughtful.\n\n" +
                    "\"But you know, I have always wanted to cast someone into the depths of Hell.\"\n\n" +
                    "The beast flicks his finger and tosses your drill deep into the depths of hell… and that much closer to your goal.");
                Sounds.SantaLaugh();
                Thread.Sleep(15_000);
            }
            else
            {
                Console.WriteLine("None of you know how to answer the beast’s challenge. You run from the demons of hell as they attack.");
                Thread.Sleep(10_000);
            }
        }
        public static void DinosaursText(bool paleoPresent)
        {
            Console.WriteLine("You emerge from the earth into a strangely lit cavern that is covered in tropical vegetation… and dinosaurs.\n\n" +
                "Did we mention the dinosaurs? There are dinosaurs here.\n\n");
            if (paleoPresent)
            {
                Console.WriteLine("The Paleontologist is amazed!\n\n" +
                    "Dinosaurs of all types and from many different eras of prehistory are coexisting in a space a thousand miles from the surface!\n\n" +
                    "The Paleontologist demands they be allowed out of the machine and immediately runs over and starts digging in a pile of dino droppings.\n\n" +
                    "Unfortunately, dino droppings are stickier than movies would have you believe.\n\n" +
                    "The Paleontologist is stuck fast to the dino poop as a Deinonychus notices them and begins stalking closer.\n\n" +
                    "\"GO ON WITHOUT ME!\" they yell, \"YOU MUST TELL THE WORLD OF THIS BRAND NEW, UNTHOUGHT-OF HUNTING TECHNIQUE!\"\n\n" +
                    "Your crew bolts the door and continues on before they attract any more attention.");

                Sounds.DinoRoar();
                Thread.Sleep(16_000); // seven seconds
            }
            else
            {
                Console.WriteLine("You drive your drill around marveling at the dinosaur life you see around you.\n\n" +
                    "No one wants to exit the drill.\n\n" +
                    "You have all seen the Jurassic Park movies, and you know how these things usually turn out,\n" +
                    "but you all enjoy the distraction before you get on your way.");

                Thread.Sleep(10_000);
            }
        }
        public static void HeyCthulhuText(bool priestPresent) // 
        {
            Console.WriteLine("Your drill breaks through into a massive underground cavern.\n\n" +
                "Dank water drips from archways and staircases at unnatural angles.\n\n" +
                "Everywhere vast spheres and stone surfaces push from the floor,\ntoo great to belong to anything right and proper for this earth,\n" +
                "and impious with horrible images and disturbing hieroglyphs.\n\n" +
                "Above the city, a hideous, monolith-crowned citadel glares down at you. \n");
            if (priestPresent)
            {
                Console.WriteLine("The Priest recognizes this place from their study of ancient heathen practices.\n\n" +
                    "\"This looks like the city of R’lyeh!\" they say in amazement.\n" +
                    "Their words stir something in your memory.\n" +
                    "\"R’lyeh? But I thought that R’lyeh was under the ocean?\"\n" +
                    "The Priest nods \"Technically we are!\"\n\n" +
                    "The Priest immediately starts cataloguing the hieroglyphs, following them deeper and\n" +
                    "deeper into the city… deeper and deeper into madness.\n\n" +
                    "The Priest comes upon a green vault redolent with slime and repugnant vapors.\n" +
                    "Carved in the wall above it are these words:\n");
                Console.WriteLine("\"Ph'nglui mglw'nafh Cthulhu R'lyeh wgah'nagl fhtagn\"\n", Color.Magenta);
                Console.WriteLine("The Priest’s mind breaks as he reads the words, and he is already gibbering in madness when the\nfirst tentacle slips above the edge of the vault.");
                Thread.Sleep(18_000);
            }
            else
            {
                Console.WriteLine("The crew feels a dark presence in this nightmare corpse-city.\n\n" +
                    "Words with too many consonants for human tongues dance on the edges of your understanding.\n\n" +
                    "A deep, existential dread overtakes you. Your crew flees from this awful place without bothering to explore it.");

                Thread.Sleep(10_000);
            }
        }
        public static void HeyLizardPeepsText(bool mechanistPresent)
        {
            Console.WriteLine("You break through a wall into a room that is lavishly decorated in blue and gold.\n\n" +
                "A wide table spans the center of the room and robed figures cluster around it.\n\n" +
                "They seem to have been involved in a meeting of some sort, and they look up when you break through.\n\n" +
                "Long, scaly snouts protrude from their hoods, sniffing the air with forked tongues.\n\n" +
                "You have interrupted a meeting of the secret lizard illuminati masons!\n\n");
            if (mechanistPresent)
            {
                Console.WriteLine("The Mechanist realizes that the blinking in their eyes conforms to a Fourier series.\n\n" +
                    "\"They’re robots!\" he yells.\n\n" +
                    "The secret lizard illuminati masons are embarrassed to have been discovered so easily.\n\n" +
                    "They promise to provide you with the cure to the common cold if you will leave and not tell anyone about their secret.");
                Sounds.ActuallyRobots();
                Thread.Sleep(15_000);
            }
            else
            {
                Console.WriteLine("The secret lizard illuminati masons are angry that you have interrupted their planning meeting.\n\n" +
                    "They attack you and you must fight your way out.\n\n" +
                    "You push your drill to its limits and keep going until the only thing outside is the harsh glow of the core");
                Thread.Sleep(15_000);
            }
        }
        public static void BowToTheRobotsIMeanLizardsEnding()
        {
            Console.Clear();
            Console.WriteLine("Your crew takes the offer from the robot... I mean secret lizard illuminati mason rulers of the world.\n\n" +
                "Everywhere you are thanked for discovering the cure to cancer AND the common cold at the center of the earth\n\n" +
                "You live out the rest of your days in opulent celebrity, your every whim attended to. But somehow, it all feels hollow…");
            Thread.Sleep(10_000); 
            Environment.Exit(0);
        }
        public static void YouFreakingSummonedCthulhuEnding()
        {
            Console.Clear();
            Console.WriteLine("You have summoned Cthulhu and doomed the world!\n\n" +
                "Luckily, you and your crew will be eaten first as the rest of the world descends into chaos.");
            Sounds.CthulhuRises();
            Thread.Sleep(10_000); // 5 seconds
            Environment.Exit(0);
        }
        public static void DrillHealthDepletedEnding()// no custom color
        {
            Console.Clear();
            Console.WriteLine("You didn't take proper care of your drill and it exploded.\n\n" +
                "Your whole crew died, stranded hundreds of miles beneath the earth.\n\n" +
                "Good job!");
            Thread.Sleep(10_000); // 5 seconds
            Environment.Exit(0);
        }
        public static void CrewAllDeadEnding()
        {
            Console.Clear();
            Console.WriteLine("You didn't take proper care of your crew and now you don’t have enough people to maintain your drill.\n\n" +
                "Your heat shields are now failing and no one can go out and fix it.\n");
            Sounds.DeathScream();
            Console.WriteLine("You burn to a crisp inside the drill, leaving a pile of cremains.\n\n" +
                "The drill will keep digging without you until it runs out of fuel or hits some impediment it cannot overcome.\n\n" +
                "Maybe you will make it to the center of the Earth after all.",Color.DarkGray);
            Thread.Sleep(10_000); // 5 seconds
            Environment.Exit(0);
        }
        public static void AtTheCenterEnding()
        {
            Console.Clear();
            Console.WriteLine("The around you begins glowing a pleasing pink.\n\n" +
                "You consult your instruments and confirm that you have infact made it to the center of the Earth!\n\n" +
                "Who would've thought it was pink?\n\n" +
                "You take your samples and prepare to head back.");
            Thread.Sleep(10_000); // 5 seconds
            Environment.Exit(0);
        }
    }
}
