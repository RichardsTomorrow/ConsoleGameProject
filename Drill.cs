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
        public Drill(CrewPerson player, int crewSize)
        {
            this.Player = player;
            this.CrewPeople = CrewSelector(crewSize);
            this.Health = 50;
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
        public void DrillDown(int dig = 10)
        {
            this.Depth += dig;
        }
        public void DrillDamage(int damageTaken = 10)
        {
            this.Health -= damageTaken;
        }

        public void CrewStatus()
        {
            Console.WriteLine($"{Player.FirstName} \"The {Player.Trait}\" {Player.LastName}\n");
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
                    CrewPeople.Remove(CrewPeople[i]);
                }
                Console.WriteLine($"{i + 1}. :{healthSymbol} {CrewPeople[i].FirstName} \"The {CrewPeople[i].Trait}\" {CrewPeople[i].LastName}\n");
            }
            Console.WriteLine($"To drill down press the \"D\" key ");
        }
        public void DepthIndicator()
        {
            if (Depth <= 10)
            {
                ColoringAndText.Surface();
            }
            else if (Depth <= 50)
            {
                ColoringAndText.Soil();
            }
            else if (Depth <= 100)
            {
                ColoringAndText.Crust();
            }
            else if (Depth <= 200)
            {
                ColoringAndText.UpperMantle();
            }
            else if (Depth <= 300)
            {
                ColoringAndText.LowerMantle();
            }
            else if (Depth <= 400)
            {
                ColoringAndText.OuterCore();
            }
            else if (Depth <= 500)
            {
                ColoringAndText.InnerCore();
            }
        }
        private void RepairEngines()
        {
            Console.WriteLine("Choose the number of the crewperson going outside:");
            int crewMember = ValidCrewPerson();
        }
        private void Event()
        {
            Random random = new Random();
            int eventChance = random.Next(1, 101);
            eventChance = 9;
            if (eventChance <= 50) // triggers maintence issues, some dangerous
            {
                Console.Clear();
                if (eventChance <= 10)
                {
                    Console.WriteLine(" You found a very soft pocket of material and went double the speed you expected");
                    DrillDown(20);
                }
                else if (eventChance <= 20)
                {
                    Console.WriteLine("The engines have stopped.\nYou will have to send someone out to repair them.\nBe warned it is dangerous out there.");
                    RepairEngines();
                }
                else if (eventChance <= 30)
                {

                }
                else if (eventChance <= 40)
                {

                }
                else
                {

                }

            }
            if (Depth <= 100 && eventChance > 50)// triggers crust level scenarios
            {

            }
            else if (Depth <= 300 && eventChance >= 50) // triggers mantle level scenarios
            {

            }
            else if (Depth > 300 && eventChance >= 50) // triggers core level scenarios
            {

            }
        }
        private bool ValidDown()
        {
            int counter = 0;
            if (Console.ReadKey(true).Key != ConsoleKey.D && counter == 0)
            {
                Console.WriteLine("Please push a valid key or you'll damage the drill");
                counter++;
                ValidDown();
                return false;
            }
            else if (Console.ReadKey(true).Key != ConsoleKey.D && counter > 0)
            {
                Console.WriteLine("The drill took damage due to your carelessness.");
                ValidDown();
                return false;
            }
            else
            {
                DrillDown();
                return true;
            }


        }
        private int ValidCrewPerson()
        {
            int counter = 0;
            Console.ReadKey(true); //do a try parse and check if it is a number between 1-length of crew list 
            
            if (Console.ReadKey().Key != ConsoleKey.Z && counter == 0)
            {
                Console.WriteLine("Please push a choose a valid crewperson or you'll confuse someone.");
                counter++;
                ValidCrewPerson();
                return 10;
            }
            else if (Console.ReadKey().Key != ConsoleKey.D && counter > 0)
            {
                Console.WriteLine("In blanks confusion they hurt themselves");
                ValidCrewPerson();
                return 10;
            }
            else
            {
                DrillDown();
                return true;
            }

        }
        public void Gameplay()
        {
            DepthIndicator();
            CrewStatus();
            if (ValidDown())
            {
                Debug.WriteLine("Event happened");
                Event();
                Thread.Sleep(2_000);
                Gameplay();
            }


        }

    }
}
