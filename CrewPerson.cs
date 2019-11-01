using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleGameProject
{
    class CrewPerson
    {
        static HashSet<string> usedNames = new HashSet<string>();
        static string[] possibleFirstNames = new string[] { "Richard", "Ben", "Breana", "Chris", "Christopher", "David", "Nic", "Evan", "Iqra", "Jing", "Matt", "Melissa", "Mike", "Michael", "Radiah", "Rob", "Ruying", "Sakariya", "Vivien", "Wei", "Yelena", "Ivy", "Peter", "Ed", "Auriana" };
        static string[] possibleLastNames = new string[] { "Morrow", "Bartel", "Mozzone", "Gutierrez", "Masters", "Malloy", "Cook", "Slaton", "Osman", "Xie", "Juel", "Stock", "Barta", "Gorzelsky", "Jones", "Schroeder", "Chen", "Mohamed", "Renee", "Kuang", "Dovgal", "Muir", "Choe", "Thorsteinson", "Robin" };
        

        public string FirstName{get; private set;}
        public string LastName { get; private set; }
        public string Trait { get; private set; }
        public CrewPerson()
        {
            this.FirstName = NameGenerator(possibleFirstNames);
            this.LastName = NameGenerator(possibleLastNames);
        }


        private string NameGenerator(string[] possibleNames)
        {
            Random random = new Random();
            string newName = possibleNames[random.Next(0, possibleNames.Length)];
            if (usedNames.Contains(newName)) { newName = NameGenerator(possibleNames); }
            usedNames.Add(newName);
            Debug.WriteLine($"Possible name length is:{possibleNames.Length}");
            return newName;
            //add code to check if there is a crewmember with that name
        }
    }
}
