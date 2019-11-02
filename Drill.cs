using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

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

        public void CrewStatus(bool display)
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

        public void Gameplay()
        {
            bool statusDisplay = true;
            DepthIndicator();
            CrewStatus(statusDisplay);
        }

    }
}
