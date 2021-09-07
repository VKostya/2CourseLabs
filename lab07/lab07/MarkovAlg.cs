using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace lab07
{
    class MarkovAlg
    {
        public List<MarkovLine> Alg;
        public string Line;
        public string Run()
        {
            for (int i = 0; i < Alg.Count; i++)
            {
                if (Line.Contains(Alg[i].income))
                {
                    Line = Step(Alg[i]);
                    if (Alg[i].final) return Line;
                    i = -1;
                }
            }
            return Line;
        }
        public string Step(MarkovLine markovLine)
        {
            var regex = new Regex(Regex.Escape(markovLine.income));
            var newText = regex.Replace(Line, markovLine.outcome, 1);
            return newText;
        }
    }
}
