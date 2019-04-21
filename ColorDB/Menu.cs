using System;

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
                    "[5] Wyszukaj kolor z palety\n[6] Usun kolor\n[7] Zmodyfikuj kolor\n\n" +
                "[0] Wyjdz z programu\n");

                try
                {
                    c = Convert.ToInt32(Console.ReadLine());
                    if (c < 0 || c > 7) throw new ArgumentOutOfRangeException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wpisz liczbe calkowita! Wcisnij enter, by wpisac ponownie.");
                    Console.ReadLine();  ShowMenu(-1);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Wybierz liczbe z zakresu 0-7! Wcisnij enter, by wpisac ponownie.");
                    Console.ReadLine(); ShowMenu(-1);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wybrana liczba jest zbyt duza! Wcisnij enter, by wpisac ponownie.");
                    Console.ReadLine(); ShowMenu(-1);
                }
            }
            if (c == 0) Environment.Exit(0);
            if (c == 1) Palette.ShowPalette();
            if (c == 2) AddFromConsole();
            if (c == 3) ReadFile();
            if (c == 4)
            {
                Console.Clear();
                Console.WriteLine("Podaj nazwe pliku (bez rozszerzenia .txt), do ktorego chcesz zapisac aktualna palete.\n\n" +
                    "[*] Jesli plik o podanej nazwie nie istnieje, to zostanie utworzony.\n" +
                    "[*] Jesli istnieje i sa tam juz wpisane kolory, to nowe zostana dopisane, bez nadpisywania starych.\n\n");
                string fileName = Console.ReadLine();
                ExternalFiles.SaveIntoFile(fileName);

                Console.WriteLine("\nZapisywanie do pliku powiodlo sie! Wcisnij enter, aby wrocic do menu.");
                Console.ReadLine(); ShowMenu(-1);
            }
            if (c == 5) FindColor();
            if (c == 6) Console.WriteLine("empty so far");
            if (c == 7) Console.WriteLine();
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
                if(r < 0 || r > 255) throw new ArgumentOutOfRangeException();
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

        public static void ReadFile()
        {
            Console.Clear();
            Console.WriteLine("Czy chcesz wczytac dane z przygotowanego przykladowego pliku?\n\n[y] Wczyta dane z palette.txt\n[n] Bedzie wymagalo podania nazwy wlasnego pliku\n");

            string s = " ";
            int j = 0;
            while(s != "y" && s != "n")
            {
                if (j > 0) Console.WriteLine("Dostepne sa jedynie opcje y oraz n\n");
                s = Console.ReadLine().ToLower();
                j++;
            }
            if (s == "y") ExternalFiles.ReadFromFile();
            else
            {
                Console.WriteLine("Podaj nazwe wlasnego pliku (ale bez rozszerzenia .txt): ");
                string fileName = Console.ReadLine();
                ExternalFiles.ReadFromFile(fileName);
            }
        }

        public static void FindColor()
        {
            Console.Clear();
            Console.WriteLine("Podaj nazwe koloru, ktory chcesz wyszukac: ");
            try
            {
                string toFind = Console.ReadLine();
                Color color = Palette.c.Find(e => e.Name == toFind);
                Console.Clear();
                Console.WriteLine("Odnaleziono: {0} ( RGB: {1} {2} {3} )\n\nNacisjnij enter, aby powrocic do menu.", color.Name, color.Red, color.Green, color.Blue);
                Console.ReadLine(); ShowMenu(-1);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Taki kolor nie wystepuje w palecie. Nacisnij enter, aby wrocic do menu.");
                Console.ReadLine(); ShowMenu(-1);
            }
            
        }
    }
}

