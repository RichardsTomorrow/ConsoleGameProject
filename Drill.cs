﻿using System;
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
        private bool VistedLostCity { get; set; }
        private bool VistedTardisCave { get; set; }
        private bool VistedCoreMantel { get; set; }
        private bool VistedSatan { get; set; }
        private bool VistedDinoDNA { get; set; }
        private bool VistedCthulu { get; set; }
        private bool VistedLizardPeeps { get; set; }
        public Drill(CrewPerson player, int crewSize) // constructor
        {
            this.Player = player;
            this.CrewPeople = CrewSelector(crewSize);
            this.Health = Math.Clamp(10, 0, 120);
            this.HealKits = crewSize - 1;
            this.RepairKits = crewSize / 2;
            this.Depth = 0;
            this.CrewSize = crewSize;
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
        private int RandomCrewPerson()// selects a random but living crew person
        {
            Random random = new Random();
            int i = random.Next(0, CrewPeople.Count);
            if (!CrewPeople[i].Dead)
            {
                return i;
            }
            else
            {
                return RandomCrewPerson();
            }
        }
        private void DrillDown(int dig = 10)//moves your drill down
        {
            this.Depth += dig;
            Debug.WriteLine($"DrillDown was called, Depth is {Depth}");
        }
        private void DrillDamage(int damageTaken = 10)//breaks your drill
        {
            this.Health -= damageTaken;
            this.Health = Math.Clamp(this.Health, 0, 120);
            Debug.WriteLine($"DrillDamage was called, Health is {Health}");
        }
        private void UseRepairKit()//fixes drill and checks if the chracter repairing is the mechanist
        {
            Console.Clear();
            Console.WriteLine("Choose the number of the crewperson that will patch up the drill:\n");
            CrewSelection();
            int crewMember = ValidCrewPerson();
            Random random = new Random();
            if (CrewPeople[crewMember].Trait.Equals("Mechanist"))
                DrillDamage(-random.Next(3, 7) * 10);
            else
                DrillDamage(-random.Next(1, 5) * 10);
            RepairKits--;
            Console.WriteLine($"{CrewPeople[crewMember].FirstName} uses up a repair kit and the drill machine looks better.\n\n");
            Thread.Sleep(5_000);
        }
        private void UseHealthKit()// heals a person unless that person doesn't need it
        {
            Console.Clear();
            Console.WriteLine("Choose the number of the crewperson you will heal:\n");
            CrewSelection();
            int crewMember = ValidCrewPerson();
            if (CrewPeople[crewMember].Chances < 2)
            {
                CrewPeople[crewMember].HealthKit();
                HealKits--;
                Console.WriteLine($"{CrewPeople[crewMember].FirstName} uses up a health kit and feels much better.\n\n");
            }
            else
            {
                Console.WriteLine($"Captain {Player.LastName}, I can't in good conscience use a health kit when I don't need one.");
            }
            Thread.Sleep(5_000);
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
            if (HealKits > 0) { return true; }
            else { return false; }
        }
        private bool ValidFix()
        {
            if (RepairKits > 0) { return true; }
            else { return false; }
        }
        private int ValidCrewPerson()
        {
            bool valid = Int32.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int crewpersonNumber); //do a try parse and check if it is a number between 1-length of crew list 
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
        private bool AreAllDeadValidation()// checks if the entire crew minus the player are dead 
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
                return true;
            }
            else
                return false;
        }
        private bool HaveTrait(string desiredTrait)// checks if you have a trait on your team
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
        private void CrewStatus()// displayed on main screen
        {
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
                            Thread.Sleep(5_000);
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
            else if (AreAllDeadValidation())
            {
                Coloring.CrewAllDeadColor();
                Texts.CrewAllDeadEnding();
            }
            else if (Depth > 490)
            {
                Coloring.AtTheCenterColor();
                Texts.AtTheCenterEnding();
            }
            Console.Clear();
            Console.WriteLine($"{Player.FirstName} \"The {Player.Trait}\" {Player.LastName}\n");
            Texts.DrillApperanceText(this.Health);
            Texts.KitInventoryText(this.HealKits, this.RepairKits);
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
        private void CrewSelection()//displayed during times that require crew selections
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
        private void RepairEngines()//chooses an engine repair scenario
        {
            Console.WriteLine("Choose the number of the crewperson going outside:\n");
            CrewSelection();
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
                    Console.WriteLine($"{CrewPeople[crewMember].FirstName} died fixing the engine but it works better then ever. \n\nYou drop 30 units.");
                    CrewPeople[crewMember].Death();
                    Sounds.DeathScream();
                    DrillDown(30);
                }
                else
                {
                    Console.WriteLine($"{CrewPeople[crewMember].FirstName} got an injury while outside but they feel that they can continue on.");
                    CrewPeople[crewMember].Injury();
                    DrillDown();
                }
            }
            else if (prob == 4 || prob == 5)
            {
                Console.WriteLine($"{CrewPeople[crewMember].FirstName} fixed the engine but found that the drill has been damaged.");
                DrillDamage(20);
                DrillDown();
            }
            else
            {
                Console.WriteLine($"All went well and {CrewPeople[crewMember].FirstName} returned to us safely.");
                DrillDown();
            }
        }
        private void Event()// determines where you go
        {
            Random random = new Random();
            int eventChance = random.Next(1, 101); //1-101
            //eventChance = 52; //determinism used to test specific events
            if (eventChance <= 65) // triggers maintence issues, some dangerous
            {
                Console.Clear();
                if (eventChance <= 20)//20%
                {
                    Console.WriteLine("You found a very soft pocket of material and went double the speed you expected");
                    DrillDown(20);
                    Thread.Sleep(4_000);
                }
                else if (eventChance <= 50)//30%
                {
                    Console.WriteLine("The engines have stopped.\n\nYou will have to send someone out to repair them.\n\nBe warned it is dangerous out there.\n\n");
                    RepairEngines();
                    Thread.Sleep(4_000);
                }
                else if (eventChance <= 55) //5% 
                {
                    Console.WriteLine("You hear the whistle of escaping steam but it is too late a pipe bursts.\n");
                    int i = RandomCrewPerson();
                    CrewPeople[i].Injury();
                    if (CrewPeople[i].Chances == 0)
                    {
                        CrewPeople[i].Death();
                        Console.WriteLine($"{CrewPeople[i].FirstName} died from their injuries");
                        Sounds.DeathScream();
                    }
                    else
                        Console.WriteLine($"{CrewPeople[i].FirstName} was hit by the blast.\n\nLuckily it wasn't deadly.");
                    DrillDown();
                    Debug.WriteLine($"{CrewPeople[i].FirstName} is {CrewPeople[i].Dead}");
                    Thread.Sleep(3_000);
                }
                else if (eventChance <= 60) //5%
                {
                    Console.WriteLine("Odd. It felt like you went nowhere. Try digging again.");
                    Thread.Sleep(4_000);
                }
                else if (eventChance <= 65)//5%
                {
                    Console.WriteLine($"You found a way to boost the drill sytem.");
                    DrillDamage(-10);
                    Thread.Sleep(4_000);
                }
                else//0%
                {
                    Console.WriteLine("All operations normal");
                    DrillDown();
                    Thread.Sleep(4_000);
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
                            DrillDown(60);
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
                        Console.Clear();//no custom color for this event
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
                            DrillDown(40);
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
        public void DriveDrill()//takes input, validates it, and calls the correct method
        {
            Coloring.DepthIndicator(Depth);
            CrewStatus();
            var comparison = ValidKeyPress();
            if (comparison == ConsoleKey.D)
            {
                Debug.WriteLine($"Dig down happened, Depth is {Depth}");
                Event();
            }
            else if (comparison == ConsoleKey.S)
            {
                if (ValidHeal())
                { UseHealthKit(); }
                else { Console.WriteLine("You don't have any health kits remaining."); Thread.Sleep(2_000); }
                Debug.WriteLine($"Heal happened, heal kits is {HealKits}");
            }
            else if (comparison == ConsoleKey.F)
            {
                if (ValidFix())
                { UseRepairKit(); }
                else { Console.WriteLine("You don't have any repair kits remaining."); Thread.Sleep(2_000); }
                Debug.WriteLine($"Fix happened, repair kits is {RepairKits}");
            }
            else
                Console.WriteLine("whoops this line shouldn't be displayed");
            DriveDrill();
        }
    }
}
