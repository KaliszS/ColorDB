﻿using System;
using System.IO;

namespace ColorDB
{
    public static class ExternalFiles
    {
        public static void ReadFromFile(string fileName = "palette")
        {
            try
            {
                using (StreamReader readFrom = new StreamReader(fileName + ".txt"))
                {
                    string line = "", n = "";
                    string[] parts = new string[3];
                    int i = 0, r = 0, g = 0, b = 0;
                    while (!readFrom.EndOfStream)
                    {
                        if (i % 2 == 0) n = readFrom.ReadLine();
                        else
                        {
                            line = readFrom.ReadLine();
                            parts = line.Split(' ');
                            r = Convert.ToInt32(parts[0]);
                            g = Convert.ToInt32(parts[1]);
                            b = Convert.ToInt32(parts[2]);
                            if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                                throw new ArgumentOutOfRangeException();

                            Palette.AddColor(n, r, g, b);

                        }
                        i++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Nie znaleziono pliku o podanej nazwie!\nWcisnij enter, aby wrocic do menu.");
                Console.ReadLine(); Menu.ShowMenu(-1);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Dodano tyle kolorow, ile sie dalo, ale gdzies wystapil ponizszy blad:\n" +
                    "Bajt miesci tylko liczby z zakresu 0-255!\n" +
                    "Wcisnij enter, aby wrocic do menu, a nastepnie popraw blad w pliku.");
                Console.ReadLine(); Menu.ShowMenu(-1);
            }

            Console.Clear();
            Console.WriteLine("Dane z pliku {0}.txt wczytano poprawnie.\nWcisnij enter, aby zobaczyc zmiany w palecie.", fileName);
            Console.ReadLine();  Palette.ShowPalette();
        }

        public static void SaveIntoFile(string fileName)
        {
            using (StreamWriter saveInto = new StreamWriter(fileName + ".txt", true))
            {
                Console.WriteLine("\r\n");
                foreach (Color color in Palette.c)
                {
                    saveInto.WriteLine("{0}\r\n{1} {2} {3}",
                    color.Name, color.Red, color.Green, color.Blue);
                }
            }
        }
    }
}
