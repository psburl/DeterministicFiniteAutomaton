using System;
using Proj1LFA.Src.Framework.Automaton;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var automaton = FiniteAutomaton.FromFilePath("");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
