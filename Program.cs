using System;

namespace ConsoleGameProject
{
    class Program
    {
        static void Main()
        {
            Texts.IntroScreenText();
            Drill drill = Texts.PlayerSetup();
            drill.DriveDrill();
        }
    }
}
