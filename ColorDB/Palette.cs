using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorDB
{
    public static class Palette
    {
        public static List<Color> c = new List<Color>();

        public static void AddColor(string n, int r, int g, int b)
        {
            c.Add(new Color(n, r, g, b));
        }

        public static void ModifyColor(int index)
        {
            Console.WriteLine("nazwa -> {0}  |  RGB -> {1} {2} {3}\n\n", c[index].Name, c[index].Red, c[index].Green, c[index].Blue);

            string[] s = new string[4];
            string k = "";
            int[] l = new int[4];
            string[] attributes = {"nazwe koloru", "nasycenie czerwieni", "nasycenie zieleni", "nasycenie niebieskiego" };

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    while (s[i] != "y" && s[i] != "n")
                    {
                        Console.WriteLine("Czy chcesz zmienic {0}? Wpisz [y] tak lub [n] nie, a nastepnie wcisnij enter.", attributes[i]);
                        s[i] = Console.ReadLine().ToLower();
                    }
                    if (i == 0)
                    {
                        if (s[i] == "y")
                        {
                            Console.WriteLine("Podaj nowa nazwe: ");
                            k = Console.ReadLine();
                        }
                        else k = c[index].Name;
                    }
                    else
                    {
                        if (s[i] == "y")
                        {
                            Console.WriteLine("Podaj wartosc w zakresie 0-255: ");
                            l[i] = Convert.ToInt32(Console.ReadLine());
                            if (l[i] < 0 || l[i] > 255) throw new ArgumentOutOfRangeException();
                        }
                        else
                        {
                            if (i == 1) l[i] = c[index].Red;
                            if (i == 2) l[i] = c[index].Green;
                            if (i == 3) l[i] = c[index].Blue;
                        }
                    }
                }
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentOutOfRangeException || ex is OverflowException)
            {
                Console.WriteLine("Modyfikacja zakonczona niepowodzeniem ze wzgledu na wpisanie zlych wartosci. Pamietaj, ze nasycenie koloru musi byc liczba calkowita i miescic sie w zakresie 0-255." +
                    "\n\nWcisnij enter, aby powrocic do menu glownego.");
                Console.ReadLine(); Menu.ShowMenu(-1);
            }

            AddColor(k, l[1], l[2], l[3]);
            c.RemoveAt(index);

            int newIndex = c.Count - 1;
            Console.WriteLine("Zmienione wartosci:\nnazwa -> {0}  |  RGB -> {1} {2} {3}\n\n", c[newIndex].Name, c[newIndex].Red, c[newIndex].Green, c[newIndex].Blue);
            Console.WriteLine("Wcisnij enter, aby przejsc do zmodyfikowanej palety.");
            Console.ReadLine(); ShowPalette();

        }

        public static void ShowPalette()
        {
            Console.Clear();

            Console.WriteLine("{0,-20}{1,14}{2,21}\n", "Nazwa koloru", "Kod decymalny", "Kod heksadecymalny");
            foreach (Color color in Palette.c.OrderBy(x => x.Name).ThenBy(x => x.Red).ToList())
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
