using System;
using System.Collections.Generic;
using System.Text;

namespace ColorDB
{
    public static class Menu
    {
        public static void ShowMenu(int c = -1)
        {
            Console.Clear();

            Console.WriteLine("Wpisz do konsoli numer z nawiasow [] i wcisnij enter, aby wybrac dana opcje\n");
            if (c < 0)
            {
                Console.WriteLine("[1] Wyswietl aktualna palete kolorow\n[2] Dodaj nowy kolor recznie\n[3] Dodaj kolory z pliku\n[4] Zapisz palete kolorow do pliku\n" +
                    "[5] Wyszukaj kolor z palety\n\n" +
                "[0] Wyjdz z programu\n");

                try
                {
                    c = Convert.ToInt32(Console.ReadLine());
                    if (c < 0 || c > 5) throw new ArgumentOutOfRangeException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wpisz liczbe calkowita! Wcisnij enter, by wpisac ponownie.");
                    Console.ReadLine(); ShowMenu(-1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Wybierz liczbe z zakresu 0-5! Wcisnij enter, by wpisac ponownie.");
                    Console.ReadLine(); ShowMenu(-1);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wybrana liczba jest zbyt duza! Wcisnij enter, by wpisac ponownie.");
                    Console.ReadLine(); ShowMenu(-1);
                }
            }
            if (c == 0) System.Environment.Exit(0);
            if (c == 1) Palette.ShowPalette();
            if (c == 2) AddFromConsole();
        }

        public static void AddFromConsole()
        {
            string n;
            int r, g, b;

            try
            {
                Console.WriteLine("Podaj nazwe koloru: ");
                n = Console.ReadLine();
                Console.WriteLine("Podaj nasycenie czerwieni: ");
                r = Convert.ToInt32(Console.ReadLine());
                if (r < 0 || r > 255) throw new ArgumentOutOfRangeException();
                Console.WriteLine("Podaj nasycenie zieleni: ");
                g = Convert.ToInt32(Console.ReadLine());
                if (g < 0 || g > 255) throw new ArgumentOutOfRangeException();
                Console.WriteLine("Podaj nasycenie niebieskiego: ");
                b = Convert.ToInt32(Console.ReadLine());
                if (b < 0 || b > 255) throw new ArgumentOutOfRangeException();

                Palette.AddColor(n, r, g, b);
            }
            catch (FormatException)
            {
                Console.WriteLine("To nie jest liczba calkowita! Dodawanie koloru zakonczone niepowodzeniem.");
                Console.ReadLine(); ShowMenu(-1);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Bajt miesci tylko liczby z zakresu 0-255! Dodawanie koloru zakonczone niepowodzeniem.");
                Console.ReadLine(); ShowMenu(-1);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Wybrana liczba jest zbyt duza! Dodawanie koloru zakonczone niepowodzeniem.");
                Console.ReadLine(); ShowMenu(-1);
            }

            Palette.ShowPalette();
        }
    }
}

