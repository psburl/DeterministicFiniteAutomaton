using System;
using Proj1LFA.Src.Framework.Automaton;
using Proj1LFA.Src.Framework.Grammar;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var grammar = RegularGrammar.FromPath(""); 
                var automaton = new FiniteAutomaton(grammar);
                automaton.Print();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
