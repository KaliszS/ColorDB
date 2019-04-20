using System;
using System.Collections.Generic;

namespace ColorDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Palette.AddColor("Red", 220, 20, 60);
            Palette.AddColor("Indigo", 75, 0, 130);
            Palette.AddColor("Peru", 205, 133, 63);

            Menu.ShowMenu();

            Console.ReadKey();
        }
    }

}
