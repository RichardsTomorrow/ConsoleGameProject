using System;

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

            //Texts.HeyCthulhuText(true);
            //Texts.HeyCthulhuText(false);
            //Texts.HeyLizardPeepsText(true);
            //Texts.HeyLizardPeepsText(false);
            //Texts.HeySatanText(true);
            //Texts.HeySatanText(false);
            //Texts.LostCityText(true);
            //Texts.LostCityText(false);
            //Texts.MagmaFlowText(true);
            //Texts.MagmaFlowText(false);
            //Texts.TardisCaveText(true);
            //Texts.TardisCaveText(false);
            //Texts.DinosaursText(true);
            //Texts.DinosaursText(false);

            //Console.WriteLine("\nend of test");
            //Console.ReadKey();

        }
    }
}
