using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameProject
{
    class Drill
    {
        List<CrewPerson> CrewPeople = new List<CrewPerson>();
        CrewPerson Player;
        public Drill(CrewPerson player, int crewSize)
        {
            this.Player = player;
            this.CrewPeople = CrewSelector(crewSize);

        }

        private List<CrewPerson> CrewSelector(int crewSize)
        {
            for(int i = crewSize; i < crewSize; i++)
            {
                // make this acutally make a crew
            }
        }
    }
}
