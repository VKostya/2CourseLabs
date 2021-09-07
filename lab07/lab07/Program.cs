using System;
using System.Collections.Generic;

namespace lab07
{

    class Program
    {
        static void Main(string[] args)
        {
            List <MarkovLine> Ml = new List<MarkovLine>()
            {
                new MarkovLine(){ income = "*a", outcome = "aA"},
                new MarkovLine(){ income = "*b", outcome = "bB"},
                new MarkovLine(){ income = "*", outcome = "#"},
                new MarkovLine(){ income = "Aa", outcome = "aA"},
                new MarkovLine(){ income = "Ab", outcome = "bA"},
                new MarkovLine(){ income = "Ba", outcome = "aB"},
                new MarkovLine(){ income = "Bb", outcome = "bB"},
                new MarkovLine(){ income = "A#", outcome = "#a"},
                new MarkovLine(){ income = "B#", outcome = "#b"},
                new MarkovLine(){ income = "#", outcome = " ", final = true},
                new MarkovLine(){ income = " ", outcome = "*"},
            };
            MarkovAlg Alg = new MarkovAlg() { Alg = Ml, Line = "*aa*bb" };
            Console.WriteLine(Alg.Run());
        }
    }
}
