using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace ConsoleGameProject
{
    public class Drill
    {
        public List<CrewPerson> CrewPeople { get; }
        public CrewPerson Player { get; }
        public int Health { get; private set; }
        public int Depth { get; private set; }
        public int CrewSize { get; private set; }
        public bool AllDead { get; private set; }
        public bool VistedLostCity { get; private set; }
        public bool VistedTardisCave { get; private set; }
        public bool VistedCoreMantel { get; private set; }
        public bool VistedSatan { get; private set; }
        public bool VistedDinoDNA { get; private set; }
        public bool VistedCthulu { get; private set; }
        public bool VistedLizardPeeps { get; private set; }

        public Drill(CrewPerson player, int crewSize)
        {
            this.Player = player;
            this.CrewPeople = CrewSelector(crewSize);
            this.Health = Math.Clamp(100, 0, 120);
            this.Depth = 0;
            this.CrewSize = crewSize;
            this.AllDead = false;
            this.VistedLostCity = false;
            this.VistedTardisCave = false;
            this.VistedCoreMantel = false;
            this.VistedSatan = false;
            this.VistedDinoDNA = false;

        }

        private List<CrewPerson> CrewSelector(int crewSize)
        {
            List<CrewPerson> crew = new List<CrewPerson>();
            for (int i = 1; i < crewSize; i++)
            {
                crew.Add(new CrewPerson());
            }
            Debug.WriteLine($"The non-player crew person list has {crew.Count} people on it");
            return crew;
        }
        public void DrillDown(int dig = 10)
        {
            this.Depth += dig;
            Debug.WriteLine($"DrillDown was called, Depth is {Depth}");
        }
        public void DrillDamage(int damageTaken = 10)
        {
            this.Health -= damageTaken;
            this.Health = Math.Clamp(this.Health, 0, 120);
            Debug.WriteLine($"DrillDamage was called, Health is {Health}");
        }
        private void AreAllDead()
        {
            int count = 0;
            foreach (CrewPerson crew in CrewPeople)
            {
                if (crew.Dead == true)
                {
                    count++;
                }
            }
            if (count == CrewPeople.Count)
            {
                AllDead = true;
            }

        }
        public void CrewStatus()
        {
            AreAllDead();
            if (Health <= 0)
            {
                ColoringAndText.DrillHealthDepletedEnding();
            }
            else if (AllDead)
            {
                ColoringAndText.CrewAllDeadColor();
                ColoringAndText.CrewAllDeadEnding();
            }
            else if (Depth > 490)
            {
                ColoringAndText.AtTheCenterColor();
                ColoringAndText.AtTheCenterEnding();
            }

            Console.WriteLine($"{Player.FirstName} \"The {Player.Trait}\" {Player.LastName}\n");
            ColoringAndText.DrillApperanceText(this.Health);
            for (int i = 0; i < CrewSize - 1; i++)
            {
                char healthSymbol = '*';
                if (CrewPeople[i].Chances > 1)
                {
                    healthSymbol = ')';
                }
                else if (CrewPeople[i].Chances == 1)
                {
                    healthSymbol = '(';
                }
                else if (CrewPeople[i].Chances < 1)
                {
                    CrewPeople[i].Death();
                    healthSymbol = 'X';
                }
                Console.WriteLine($"{i + 1}. :{healthSymbol} - {CrewPeople[i].FirstName} \"The {CrewPeople[i].Trait}\" {CrewPeople[i].LastName}\n");
            }
            Console.WriteLine($"To drill down press the \"d\" key ");
        }
        public void CrewStatus(bool showOnlyCrew)
        {
            if (showOnlyCrew)
            {

                for (int i = 0; i < CrewSize - 1; i++)
                {
                    char healthSymbol = '*';
                    if (CrewPeople[i].Chances > 1)
                    {
                        healthSymbol = ')';
                    }
                    else if (CrewPeople[i].Chances == 1)
                    {
                        healthSymbol = '(';
                    }
                    else if (CrewPeople[i].Dead)
                    {
                        healthSymbol = 'X';
                    }
                    Console.WriteLine($"{i + 1}. :{healthSymbol} - {CrewPeople[i].FirstName} \"The {CrewPeople[i].Trait}\" {CrewPeople[i].LastName}\n");
                }
            }
        }
        public void DepthIndicator()
        {
            if (Depth <= 10)
            {
                ColoringAndText.SurfaceColor();
            }
            else if (Depth <= 50 && Depth > 10)
            {
                ColoringAndText.SoilColor();
            }
            else if (Depth <= 100 && Depth > 50)
            {
                ColoringAndText.CrustColor();
            }
            else if (Depth <= 200 && Depth > 100)
            {
                ColoringAndText.UpperMantleColor();
            }
            else if (Depth <= 300 && Depth > 200)
            {
                ColoringAndText.LowerMantleColor();
            }
            else if (Depth <= 400 && Depth > 300)
            {
                ColoringAndText.OuterCoreColor();
            }
            else if (Depth <= 500 && Depth > 400)
            {
                ColoringAndText.InnerCoreColor();
            }
        }
        private void RepairEngines()
        {
            Console.WriteLine("Choose the number of the crewperson going outside:\n");
            CrewStatus(true);
            int crewMember = ValidCrewPerson();
            Console.WriteLine($"{CrewPeople[crewMember].FirstName} goes outside to try and repair the damage.\n\n");
            Random random = new Random();
            int prob = random.Next(1, 7);
            //prob = 5; // determinism
            if (prob <= 3)
            {
                if (CrewPeople[crewMember].Chances == 1)
                {
                    Console.WriteLine($"{CrewPeople[crewMember].FirstName} died fixing the engine but it works better then ever. \n\n You drop 30.");
                    CrewPeople[crewMember].Death();
                    DrillDown(30);
                }
                else
                {
                    Console.WriteLine($"{CrewPeople[crewMember].FirstName} got an injury while outside but they feel ok trying to continue on.");
                    CrewPeople[crewMember].Injury();
                    DrillDown();

                }
            }
            else if (prob == 4 || prob == 5)
            {
                Console.WriteLine($"{CrewPeople[crewMember].FirstName} fixed the engine but found that the drill has been damaged.");
                DrillDamage();
                DrillDown();
            }
            else
            {
                Console.WriteLine($"All went well and {CrewPeople[crewMember].FirstName} returned to us safely.");
                DrillDown();
            }

        }
        private void Event()
        {
            Random random = new Random();
            int eventChance = random.Next(1, 101); //1-101
            //eventChance = 90; //determinism
            if (eventChance <= 65) // triggers maintence issues, some dangerous
            {
                Console.Clear();
                if (eventChance <= 20)
                {
                    Console.WriteLine(" You found a very soft pocket of material and went double the speed you expected");
                    DrillDown(20);
                }
                else if (eventChance <= 45)
                {
                    Console.WriteLine("The engines have stopped.\n\nYou will have to send someone out to repair them.\n\nBe warned it is dangerous out there.\n\n");
                    RepairEngines();
                }
                else if (eventChance <= 55)
                {
                    Console.WriteLine("Odd. It felt like you went nowhere. Try digging again.");
                }
                else if (eventChance <= 64 )
                {
                    Console.WriteLine($"You found a way to boost the drill sytem.");
                    DrillDamage(-10);
                }
                else//61-65
                {
                    Console.WriteLine("All operations normal");
                    DrillDown();
                }

            }
            if (Depth <= 100 && eventChance > 65) // triggers crust level scenarios
            {
                if (!VistedLostCity)
                {
                    if (eventChance > 65 && eventChance <= 85)//Archaeologist
                    {
                        ColoringAndText.LostCityColor();
                        ColoringAndText.LostCityText(HaveTrait("Archaeologist"));
                        if (HaveTrait("Archaeologist"))
                        {
                            DrillDamage(-20);
                            DrillDown(40);
                            VistedLostCity = true;
                        }
                        else if (!HaveTrait("Archaeologist"))
                        {
                            DrillDamage(20);
                            DrillDown(20);
                            VistedLostCity = true;
                        }
                    }
                }
                else { DrillDown(); }

                if (!VistedTardisCave)
                {
                    if (eventChance > 85)// doctor
                    {
                        ColoringAndText.TardisCaveColor();
                        ColoringAndText.TardisCaveText(HaveTrait("Doctor"));
                        if (HaveTrait("Doctor"))
                        {
                            for (int i = 0; i < CrewPeople.Count; i++)
                            {
                                if (CrewPeople[i].Trait == "Doctor")
                                {
                                    CrewPeople[i].Death();
                                }
                                DrillDown(40);
                            }
                            VistedTardisCave = true;
                        }
                        else if (!HaveTrait("Doctor"))
                        {
                            DrillDown(40);
                            VistedTardisCave = true;
                        }
                    }
                }
                else { DrillDown(); }

            }
            else if (Depth <= 300 && eventChance >= 65) // triggers mantle level scenarios
            {
                if (!VistedCoreMantel)
                {
                    if (eventChance > 65 && eventChance < 77)//geologist
                    {
                        //no custom color for this event
                        ColoringAndText.MagmaFlowText(HaveTrait("Geologist"));
                        if (HaveTrait("Geologist"))
                        {
                            DrillDown(150);
                            DrillDamage();
                            VistedCoreMantel = true;
                        }
                        else if (!HaveTrait("Geologist"))
                        {
                            DrillDown(50);
                            DrillDamage(30);
                            VistedCoreMantel = true;
                        }
                    }
                }
                else { DrillDown(); }

                if (!VistedSatan)
                {
                    if (eventChance >= 77 && eventChance <= 88)// priest
                    {
                        ColoringAndText.HeySatanColor();
                        ColoringAndText.HeySatanText(HaveTrait("Priest"));
                        if (HaveTrait("Priest"))
                        {
                            DrillDown(50);
                            VistedSatan = true;
                        }
                        else if (!HaveTrait("Priest"))
                        {
                            DrillDamage(30);
                            VistedSatan = true;
                        }
                    }
                }
                else { DrillDown(); }

                if (!VistedDinoDNA)
                {
                    if (eventChance > 88)// dinos
                    {
                        ColoringAndText.DinosaursColor();
                        ColoringAndText.DinosaursText(HaveTrait("Paleontologist"));
                        if (HaveTrait("Paleontologist"))
                        {
                            for (int i = 0; i < CrewPeople.Count; i++)
                            {
                                if (CrewPeople[i].Trait == "Paleontologist")
                                {
                                    CrewPeople[i].Death();
                                }
                            }
                            VistedDinoDNA = true;
                        }
                        else if (!HaveTrait("Paleontologist"))
                        {
                            for (int i = 0; i < CrewPeople.Count; i++)
                            {
                                if (CrewPeople[i].Chances == 1 && !CrewPeople[i].Dead)
                                {
                                    CrewPeople[i].Injury(-1);
                                }
                            }
                            DrillDown(20);
                            VistedDinoDNA = true;
                        }
                    }
                }
                else { DrillDown(); }
            }
            else if (Depth > 300 && eventChance >= 65) // triggers core level scenarios
            {
                if (!VistedCthulu)
                {
                    if (eventChance > 65 && eventChance <= 85)//Cthulu
                    {
                        ColoringAndText.HeyCthulhuColor();
                        ColoringAndText.HeyCthulhuText(HaveTrait("Occultist"));
                        if (HaveTrait("Occultist"))
                        {
                            ColoringAndText.YouFreakingSummonedCthulhuColor();
                            ColoringAndText.YouFreakingSummonedCthulhuEnding();
                            VistedCthulu = true;
                        }
                        else if (!HaveTrait("Occultist"))
                        {
                            DrillDown(30);
                            VistedCthulu = true;
                        }
                    }
                }
                else { DrillDown(); }

                if (!VistedLizardPeeps)
                {
                    if (eventChance > 85) // Lizard Peeps
                    {
                        ColoringAndText.HeyLizardPeepsColor();
                        ColoringAndText.HeyLizardPeepsText(HaveTrait("Roboticist"));
                        if (HaveTrait("Roboticist"))
                        {
                            ColoringAndText.BowToTheRobotsIMeanLizardsEnding();
                            VistedLizardPeeps = true;
                        }
                        else if (!HaveTrait("Roboticist"))
                        {
                            DrillDamage(50);
                            VistedLizardPeeps = true;
                        }
                    }
                }
                else { DrillDown(); }
            }
        }
        private bool ValidDown()
        {
            if (Console.ReadKey().Key != ConsoleKey.D)
            {
                Console.WriteLine("\nPlease push a valid key or you'll damage the drill!");
                return ValidDown();
            }
            //else if (Console.ReadKey().Key != ConsoleKey.D && counter > 0)
            //{
            //    Console.WriteLine("\nThe drill took damage due to your carelessness.");
            //    return ValidDown();
            //}
            else
            {
                return true;
            }


        }
        private int ValidCrewPerson()
        {
            bool valid = Int32.TryParse(Console.ReadLine(), out int crewpersonNumber); //do a try parse and check if it is a number between 1-length of crew list 

            if (!valid)
            {
                Console.WriteLine("\nPlease push a choose a valid crewperson or you'll confuse someone.");
                return ValidCrewPerson();

            }
            else if (crewpersonNumber > CrewPeople.Count || crewpersonNumber <= 0)
            {
                Console.WriteLine("\nThere isn't that many crewpeople on our rooster.");
                return ValidCrewPerson();

            }
            else if (CrewPeople[crewpersonNumber - 1].Dead)
            {
                Console.WriteLine($"\n{CrewPeople[crewpersonNumber - 1].FirstName} is dead, they respond to the commands of no one now.");
                return ValidCrewPerson();
            }
            else
            {
                return crewpersonNumber - 1;
            }

        }
        private bool HaveTrait(string desiredTrait)
        {
            bool HaveTrait = false;
            for (int i = 0; i < CrewPeople.Count; i++)
            {
                if (CrewPeople[i].Trait.Equals(desiredTrait) && !CrewPeople[i].Dead)
                {
                    HaveTrait = true;
                }
            }
            Debug.WriteLine($"HaveTrait was used and came out {HaveTrait}");
            return HaveTrait;
        }
        public void Gameplay()
        {
            DepthIndicator();
            CrewStatus();
            if (ValidDown())
            {
                DepthIndicator();
                Debug.WriteLine($"Event happened, Depth is {Depth}");
                Event();
                Thread.Sleep(2_000);
            }
            Gameplay();


        }

    }
}
