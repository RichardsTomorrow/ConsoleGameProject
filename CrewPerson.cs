﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace ConsoleGameProject
{
    class CrewPerson
    {
        static HashSet<string> usedNames = new HashSet<string>();
        static HashSet<string> usedTraits = new HashSet<string>();
        static string[] possibleFirstNames = new string[] { "Richard", "Ben", "Breana", "Chris", "Christopher", "David", "Nic", "Evan", "Iqra", "Jing", "Matt", "Melissa", "Mike", "Michael", "Radiah", "Rob", "Ruying", "Sakariya", "Vivien", "Wei", "Yelena", "Ivy", "Peter", "Ed", "Auriana", "Grant" };
        static string[] possibleLastNames = new string[] { "Morrow", "Bartel", "Mozzone", "Gutierrez", "Masters", "Malloy", "Cook", "Slaton", "Osman", "Xie", "Juel", "Stock", "Barta", "Gorzelsky", "Jones", "Schroeder", "Chen", "Mohamed", "Renee", "Kuang", "Dovgal", "Muir", "Choe", "Thorsteinson", "Robin", "Dams" };
        static string[] possibleTraits = new string[] { "Captain", "Conspiracist", "Paleontologist", "Archaeologist", "Geologist", "Stout", "Brave", "Occultist", "Bungersome", "Roboticist" };
        public string FirstName{get; private set;}
        public string LastName { get; private set; }
        public string Trait { get; private set; }
        public CrewPerson()
        {
            this.FirstName = NameGenerator(possibleFirstNames);
            this.LastName = NameGenerator(possibleLastNames);
            this.Trait = Traitor(possibleTraits);
        }

        public CrewPerson(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Trait = possibleTraits[0];
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
