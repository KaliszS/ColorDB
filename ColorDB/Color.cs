using System;
using System.Collections.Generic;
using System.Text;

namespace ColorDB
{
    public class Color
    {
        public string Name { get; private set; }
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public Color(string n, int r, int g, int b)
        {
            Name = n;
            Red = r;
            Green = g;
            Blue = b;
        }
    }
}
