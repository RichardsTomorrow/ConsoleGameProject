﻿using System;

namespace ConsoleGameProject
{
    class Program
    {
        static void Main()
        {
            Texts.IntroScreenText();
            Drill drill = Texts.PlayerSetup();
            Texts.RosterText(drill);
            drill.DriveDrill();
        }
    }
}
