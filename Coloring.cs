using System;
using System.Drawing;
using Console = Colorful.Console;

namespace ConsoleGameProject
{
    public static class Coloring
    {
        public static void IntroGradientColor(string[] strings)
        {
            int r = 50; int g = 255; int b = 50;
            for (int i = 0; i < strings.Length; i += 2)
            {
                Console.WriteLine(strings[i], Color.FromArgb(Math.Clamp(r, 0, 255), Math.Clamp(g, 0, 255), Math.Clamp(b, 0, 255)));
                if (i + 1 < strings.Length)
                { Console.WriteLine(strings[i + 1], Color.FromArgb(Math.Clamp(r, 0, 255), Math.Clamp(g, 0, 255), Math.Clamp(b, 0, 255))); }
                if (i <= 10) { r += 30; b -= 15; } // transition of green to yellow
                else if (i > 10) { g -= 30; } // transition of yellow to orange
            }
        }
        public static void PaperworkColor() // papery white and black text
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.AntiqueWhite;
            Console.Clear();
            Console.ForegroundColor = Color.Black;
        }
        public static void SurfaceColor() // depth 0-10
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.LimeGreen;
            Console.Clear();
            Console.ForegroundColor = Color.Sienna;
            Console.CursorVisible = false;
        }
        public static void SoilColor()// depth 11-50 
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.FromArgb(101, 67, 33);
            Console.Clear();
            Console.ForegroundColor = Color.LightGray;
            Console.CursorVisible = false;
        }
        public static void CrustColor() // depth 11-100
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DimGray;
            Console.Clear();
            Console.ForegroundColor = Color.DarkOrange;
            Console.CursorVisible = false;
        }
        public static void UpperMantleColor() //  depth 101-200
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Coral;
            Console.Clear();
            Console.ForegroundColor = Color.DarkRed;
            Console.CursorVisible = false;
        }
        public static void LowerMantleColor() //  depth 201-300
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkRed;
            Console.Clear();
            Console.ForegroundColor = Color.DarkOrange;
            Console.CursorVisible = false;
        }
        public static void OuterCoreColor() //  depth 301-400
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkOrange;
            Console.Clear();
            Console.ForegroundColor = Color.Gold;
            Console.CursorVisible = false;
        }
        public static void InnerCoreColor() //  depth 401-500
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Goldenrod;
            Console.Clear();
            Console.ForegroundColor = Color.LightGoldenrodYellow;
            Console.CursorVisible = false;
        }
        public static void LostCityColor()// coffee brownish, text a light sharp blue 
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Tan;
            Console.Clear();
            Console.ForegroundColor = Color.Cyan;
            Console.CursorVisible = false;
        }
        public static void TardisCaveColor()// color this like tardis
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = Color.LightBlue;
            Console.CursorVisible = false;
        }
        public static void HeySatanColor()// some kind of red and black theme
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Black;
            Console.Clear();
            Console.ForegroundColor = Color.Red;
            Console.CursorVisible = false;
        }
        public static void DinosaursColor()// darker but still jungly green background with orangered text
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Green;
            Console.Clear();
            Console.ForegroundColor = Color.OrangeRed;
            Console.CursorVisible = false;
        }
        public static void HeyCthulhuColor()// dark olive green and  dark magenta since cthulu sleeps
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkOliveGreen;
            Console.Clear();
            Console.ForegroundColor = Color.DarkMagenta;
            Console.CursorVisible = false;
        }
        public static void YouFreakingSummonedCthulhuColor()// dark olive green and regular magenta since cthulu wakes
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkOliveGreen;
            Console.Clear();
            Console.ForegroundColor = Color.Magenta;
            Console.CursorVisible = false;
        }
        public static void HeyLizardPeepsColor()// deep blue background with gold text
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.DarkBlue;
            Console.Clear();
            Console.ForegroundColor = Color.Gold;
            Console.CursorVisible = false;
        }
        public static void CrewAllDeadColor()// black with text the color of bones
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.Black;
            Console.Clear();
            Console.ForegroundColor = Color.WhiteSmoke;
            Console.CursorVisible = false;
        }
        public static void AtTheCenterColor()// pinks
        {
            Console.ReplaceAllColorsWithDefaults();
            Console.BackgroundColor = Color.MediumOrchid;
            Console.Clear();
            Console.ForegroundColor = Color.LightPink;
            Console.CursorVisible = false;
        }
    }
}
