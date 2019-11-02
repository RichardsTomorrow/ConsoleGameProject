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

    }
}
