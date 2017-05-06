using System;
using System.Collections.Generic;
using System.Linq;
using Proj1LFA.Src.Framework.Grammar;

namespace Proj1LFA.Src.Framework.Automaton
{
    class FiniteAutomaton
    {
        public List<State> states = new List<State>();

        public FiniteAutomaton(RegularGrammar grammar)
        {
            this.states = SerializeStates(grammar).ToList();
        }

        public static IEnumerable<State> SerializeStates(RegularGrammar grammar)
        {
            foreach(var rule in grammar.rules)
                yield return new State(rule);
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

        public void Determine()
        {
            var determinizer = new Determinizer(this);
            determinizer.Determine();
        }
    }
}