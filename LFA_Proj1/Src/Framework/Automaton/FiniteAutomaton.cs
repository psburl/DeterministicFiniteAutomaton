using System;
using System.Collections.Generic;
using System.Linq;
using Proj1LFA.Src.Framework.Grammar;

namespace Proj1LFA.Src.Framework.Automaton
{
    class FiniteAutomaton
    {
        public readonly List<State> states = new List<State>();

        public static FiniteAutomaton Serialize(RegularGrammar grammar)
        {
            var automaton = new FiniteAutomaton();
            grammar.rules.ForEach(r => automaton.states.Add(new State(r)));           
            return automaton;
        }    

        public State GetInitialState()
        {
            return states.FirstOrDefault(s => s.IsInitialState);
        }

        public void Print()
        {
            foreach(var state in this.states)
            {
                Console.WriteLine(state.Id);
                state.neighborhood.Print();
            }
        }
    }
}