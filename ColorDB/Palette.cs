using System;
using System.Collections.Generic;

namespace ColorDB
{
    public static class Palette
    {
        public static List<Color> c = new List<Color>();

        public static void AddColor(string n, int r, int g, int b)
        {
            c.Add(new Color(n, r, g, b));
        }

        public static void ShowPalette()
        {
            Console.Clear();

            Console.WriteLine("{0,-20}{1,14}{2,21}\n", "Nazwa koloru", "Kod decymalny", "Kod heksadecymalny");
            foreach (Color color in Palette.c)
            {
                Console.WriteLine("{0,-20} {1:D3} {2:D3} {3:D3} {1,6:X2} {2:X2} {3:X2}",
                    color.Name, color.Red, color.Green, color.Blue);
            }

            int c, i=0;
            try
            {
                do
                {
                    if (i > 0) Console.WriteLine("Dostepna jest jedynie opcja 1\n");
                    Console.WriteLine("\nAby wrocic do menu wpisz 1 i nacisnij enter.");
                    c = Convert.ToInt32(Console.ReadLine());
                    i++;
                } while (c != 1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Wpisz liczbe calkowita! Wcisnij enter, by wpisac ponownie.");
                Console.ReadLine(); ShowPalette();
            }
            catch (OverflowException)
            {
                Console.WriteLine("Wybrana liczba jest zbyt duza! Wcisnij enter, by wpisac ponownie.");
                Console.ReadLine(); ShowPalette();
            }
            Menu.ShowMenu(-1);
        }

    }
}
