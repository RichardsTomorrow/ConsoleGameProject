using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Console = Colorful.Console;

namespace ConsoleGameProject
{
    public static class ColoringAndText
    {
        static
        public void IntroGradient(string[] strings)
        {
            int r = 50; int g = 255; int b = 50;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(strings[i], Color.FromArgb(Math.Clamp(r,0,255), Math.Clamp(g, 0, 255), Math.Clamp(b, 0, 255)));
                if (i <= 5)
                {
                    r += 50;
                    b -= 10;
                //Math.Clamp(r, 0, 255);
                //Math.Clamp(g, 0, 255);
                //Math.Clamp(b, 0, 255);
                }
                else { g -= 30; }
            }

        }

    }
}
