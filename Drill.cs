using System;
using System.Collections.Generic;
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
        public int RepairKits { get; private set; }
        public int HealKits { get; private set; }
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
            this.HealKits = crewSize - 1;
            this.RepairKits = crewSize / 2;
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
        private ConsoleKey ValidKeyPress()
        {
            Debug.WriteLine($"prekeypress");
            var comparison = Console.ReadKey(true).Key;
            Debug.WriteLine($"post key press");
            if (comparison != ConsoleKey.D && comparison != ConsoleKey.S && comparison != ConsoleKey.F)
            {
                Debug.WriteLine($"error key press");
                Console.WriteLine("\nPlease push a valid key or you'll damage the drill!");
                return ValidKeyPress();
            }
            else if (comparison == ConsoleKey.D)
            {
                Debug.WriteLine($"d key press");
                return comparison;
            }
            else if (comparison == ConsoleKey.S)
            {
                Debug.WriteLine($"s key press");
                return comparison;
            }
            else if (comparison == ConsoleKey.F)
            {
                Debug.WriteLine($"f key press");
                return comparison;
            }
            else { return ValidKeyPress(); }

        }
        private bool ValidHeal()
        {
            if (HealKits > 0) {return true;}
            else { return false; }
        }
        //private bool ValidFix()
        //{
        //    if (Console.ReadKey().Key != ConsoleKey.F)
        //    {
        //        Console.WriteLine("\nPlease push a valid key or you'll damage the drill!");
        //        return ValidDown();
        //    }
        //    else
        //    { return true; }
        //}
        private int ValidCrewPerson()
        {
            bool valid = Int32.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int crewpersonNumber) ; //do a try parse and check if it is a number between 1-length of crew list 
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
                if (HaveTrait("Brave"))
                {
                    for (int i = 0; i < CrewPeople.Count; i++)
                    {
                        if (CrewPeople[i].Trait == "Brave")
                        {
                            Console.WriteLine($"{CrewPeople[i].FirstName} sacrifices themselves to perform a last minute fix.\n\n" +
                                $"The drill manages to not explode.\n\n" +
                                $"Their bravery will hopefully live on through us.");
                            DrillDamage(-30);
                            Sounds.DeathScream();
                            CrewPeople[i].Death();
                            Thread.Sleep(3_000);
                            Console.Clear();
                        }
                    }
                }
                else
                {
                    Texts.DrillHealthDepletedEnding();
                    Sounds.DeathScream();
                }
            }
            else if (AllDead)
            {
                Coloring.CrewAllDeadColor();
                Texts.CrewAllDeadEnding();
                Sounds.DeathScream();
            }
            else if (Depth > 490)
            {
                Coloring.AtTheCenterColor();
                Texts.AtTheCenterEnding();
            }

            Console.WriteLine($"{Player.FirstName} \"The {Player.Trait}\" {Player.LastName}\n");
            Texts.DrillApperanceText(this.Health);
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
            Console.WriteLine($"To drill down press the \"d\" key\n" +
                $"To heal push \"s\"\n" +
                $"To fix the drill push \"f\"\n");
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
                Coloring.SurfaceColor();
            }
            else if (Depth <= 50 && Depth > 10)
            {
                Coloring.SoilColor();
            }
            else if (Depth <= 100 && Depth > 50)
            {
                Coloring.CrustColor();
            }
            else if (Depth <= 200 && Depth > 100)
            {
                Coloring.UpperMantleColor();
            }
            else if (Depth <= 300 && Depth > 200)
            {
                Coloring.LowerMantleColor();
            }
            else if (Depth <= 400 && Depth > 300)
            {
                Coloring.OuterCoreColor();
            }
            else if (Depth <= 500 && Depth > 400)
            {
                Coloring.InnerCoreColor();
            }
        }
        private void RepairEngines()
        {
            Console.WriteLine("Choose the number of the crewperson going outside:\n");
            CrewStatus(true);
            int crewMember = ValidCrewPerson();
            Console.WriteLine($"{CrewPeople[crewMember].FirstName} goes outside to try and repair the damage.\n\n");
            Sounds.HatchOpen();
            Random random = new Random();
            int prob = random.Next(1, 7);
            //prob = 5; // determinism
            if (prob <= 3)
            {
                if (CrewPeople[crewMember].Chances == 1)
                {
                    Console.WriteLine($"{CrewPeople[crewMember].FirstName} died fixing the engine but it works better then ever. \n\n You drop 30.");
                    CrewPeople[crewMember].Death();
                    Sounds.DeathScream();
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
        private void UseHealthKit()
        {
            Console.Clear();
            Console.WriteLine("Choose the number of the crewperson you will heal:\n");
            CrewStatus(true);
            int crewMember = ValidCrewPerson();
            CrewPeople[crewMember].HealthKit();
            HealKits--;
            Console.WriteLine($"{CrewPeople[crewMember].FirstName} uses up a health kit and feels much better.\n\n");
            Thread.Sleep(3_000);
        }
        private void Event()
        {
            Random random = new Random();
            int eventChance = random.Next(1, 101); //1-101
            //eventChance = 70; //determinism
            if (eventChance <= 65) // triggers maintence issues, some dangerous
            {
                Console.Clear();
                if (eventChance <= 20)
                {
                    Console.WriteLine(" You found a very soft pocket of material and went double the speed you expected");
                    DrillDown(20);
                    Thread.Sleep(2_000);
                }
                else if (eventChance <= 45)
                {
                    Console.WriteLine("The engines have stopped.\n\nYou will have to send someone out to repair them.\n\nBe warned it is dangerous out there.\n\n");
                    RepairEngines();
                    Thread.Sleep(2_000);
                }
                else if (eventChance <= 55) //<=55
                {
                    Console.WriteLine("Odd. It felt like you went nowhere. Try digging again.");
                    Thread.Sleep(2_000);
                }
                else if (eventChance <= 64)//<=64
                {
                    Console.WriteLine($"You found a way to boost the drill sytem.");
                    DrillDamage(-10);
                    Thread.Sleep(2_000);
                }
                else//61-65
                {
                    Console.WriteLine("All operations normal");
                    DrillDown();
                    Thread.Sleep(2_000);
                }

            }
            if (Depth <= 100 && eventChance > 65) // triggers crust level scenarios
            {
                if (!VistedLostCity)
                {
                    if (eventChance > 65 && eventChance <= 85)//Archaeologist
                    {
                        Coloring.LostCityColor();
                        Texts.LostCityText(HaveTrait("Archaeologist"));
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
                        Coloring.TardisCaveColor();
                        Texts.TardisCaveText(HaveTrait("Doctor"));
                        if (HaveTrait("Doctor"))
                        {
                            for (int i = 0; i < CrewPeople.Count; i++)
                            {
                                if (CrewPeople[i].Trait == "Doctor")
                                {
                                    CrewPeople[i].Death();
                                }
                            }
                            DrillDown(40);
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
                        Texts.MagmaFlowText(HaveTrait("Geologist"));
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
                        Coloring.HeySatanColor();
                        Texts.HeySatanText(HaveTrait("Priest"));
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
                        Coloring.DinosaursColor();
                        Texts.DinosaursText(HaveTrait("Paleontologist"));
                        if (HaveTrait("Paleontologist"))
                        {
                            for (int i = 0; i < CrewPeople.Count; i++)
                            {
                                if (CrewPeople[i].Trait == "Paleontologist")
                                {
                                    Sounds.DeathScream();
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
                        Coloring.HeyCthulhuColor();
                        Texts.HeyCthulhuText(HaveTrait("Priest"));
                        if (HaveTrait("Priest"))
                        {
                            Coloring.YouFreakingSummonedCthulhuColor();
                            Texts.YouFreakingSummonedCthulhuEnding();
                            VistedCthulu = true;
                        }
                        else if (!HaveTrait("Priest"))
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
                        Coloring.HeyLizardPeepsColor();
                        Texts.HeyLizardPeepsText(HaveTrait("Mechanist"));
                        if (HaveTrait("Mechanist"))
                        {
                            Texts.BowToTheRobotsIMeanLizardsEnding();
                            VistedLizardPeeps = true;
                        }
                        else if (!HaveTrait("Mechanist"))
                        {
                            DrillDown(50);
                            DrillDamage(50);
                            VistedLizardPeeps = true;
                        }
                    }
                }
                else { DrillDown(); }
            }
        }
        public void DriveDrill()
        {
            DepthIndicator();
            CrewStatus();
            var comparison = ValidKeyPress();
            if (comparison == ConsoleKey.D)
            {
                DepthIndicator();
                Debug.WriteLine($"Dig down happened, Depth is {Depth}");
                Event();
                DriveDrill();
                //Thread.Sleep(2_000);
            }
            else if (comparison == ConsoleKey.S)
            {
                if (ValidHeal())
                { UseHealthKit();}
                else { Console.WriteLine("You don't have any health kits remaining."); Thread.Sleep(2_000); }
                Debug.WriteLine($"Heal happened, heal kits is {HealKits}");
                DriveDrill();
            }
            else if (ValidKeyPress() == ConsoleKey.F)
            {
                Debug.WriteLine($"Fix happened, repair kits is {RepairKits}");

            }
            //Thread.Sleep(1_000);
            DriveDrill();
        }
    }
}
