using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleGameProject
{
    class CrewPerson
    {
        string Name;
        public CrewPerson()
        {

        }


        private string NameGenerator()
        {
            Random random = new Random();
            string[] possibleNames = new string[] { "Richard", "Ben", "Breana", "Chris", "Christopher", "David", "Nic", "Evan", "Iqra", "Jing", "Matt", "Melissa", "Mike", "Michael", "Radiah", "Rob", "Ruying", "Sakariya", "Vivien", "Wei", "Yelena", "Ivy", "Peter", "Ed", "Auriana" };
            string newName = possibleNames[random.Next(0, possibleNames.Length)];

            // add code to check if there is a crewmember with that name

        }
    }
}
