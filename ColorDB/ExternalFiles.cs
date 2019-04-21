using System;
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
            
            Console.Clear();
            Console.WriteLine("Dane z pliku {0}.txt wczytano poprawnie.\nWcisnij enter, aby zobaczyc zmiany w palecie.", fileName);
            Console.ReadLine();  Palette.ShowPalette();
        }
    }
}
