using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleGameProject
{
    public class CrewPerson
    {
        static HashSet<string> usedNames = new HashSet<string>();
        static HashSet<string> usedTraits = new HashSet<string>();
        static string[] possibleFirstNames = new string[] { "Richard", "Ben", "Breana", "Chris", "Christopher", "David", "Nic", "Evan", "Iqra", "Jing", "Matt", "Melissa", "Mike", "Michael", "Radiah", "Rob", "Ruying", "Sakariya", "Vivien", "Wei", "Yelena", "Ivy", "Peter", "Ed", "Auriana", "Grant" };
        static string[] possibleLastNames = new string[] { "Morrow", "Bartel", "Mozzone", "Gutierrez", "Masters", "Malloy", "Cook", "Slaton", "Osman", "Xie", "Juel", "Stock", "Barta", "Gorzelsky", "Jones", "Schroeder", "Chen", "Mohamed", "Renee", "Kuang", "Dovgal", "Muir", "Choe", "Thorsteinson", "Robin", "Dams" };
        static string[] possibleTraits = new string[] { "Captain", "Conspiracist", "Paleontologist", "Archaeologist", "Geologist", "Stout", "Brave", "Occultist", "Bungersome", "Roboticist", "Priest", "Doctor" };
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Trait { get; private set; }
        public int Chances { get; private set; }
        public CrewPerson()
        {
            this.FirstName = NameGenerator(possibleFirstNames);
            this.LastName = NameGenerator(possibleLastNames);
            this.Trait = Traitor(possibleTraits);
            this.Chances = Trait == "Stout" ? 3 : 2; // this will give the stout person an extra life
        }

        public CrewPerson(string firstName, string lastName)
        {
            this.FirstName = firstName; usedNames.Add(firstName);
            this.LastName = lastName; usedNames.Add(lastName);
            this.Trait = possibleTraits[0];
            this.Chances = 2;
        }
        public void Injury()
        {
            Chances -= 1;
        }
        private string NameGenerator(string[] possibleNames)
        {
            Random random = new Random();
            string newName = possibleNames[random.Next(0, possibleNames.Length)];
            if (usedNames.Contains(newName)) { newName = NameGenerator(possibleNames); }
            usedNames.Add(newName);
            Debug.WriteLine($"Possible name length is: {possibleNames.Length}");
            return newName;
            //add code to check if there is a crewmember with that name
        }

        private string Traitor(string[] possibleTs)
        {
            Random random = new Random();
            string traitSelection = possibleTs[random.Next(1, possibleTs.Length)];
            if (usedTraits.Contains(traitSelection)) { traitSelection = Traitor(possibleTs); }
            usedTraits.Add(traitSelection);
            Debug.WriteLine($"Possible traits length is: {possibleTs.Length}");
            return traitSelection;
            //add code to check if there is a crewmember with that name
        }
    }
}
