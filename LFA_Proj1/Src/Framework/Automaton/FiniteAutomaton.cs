using System;
using System.Collections.Generic;
using System.Linq;
using Proj1LFA.Src.Framework.Grammar;
using Proj1LFA.Src.Framework.Determinization;

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

        public State GetStateWithId(string id)
        {
            return states.FirstOrDefault(s => s.id == id);
        }

        public State GetInitialState()
        {
            return states.FirstOrDefault(s => s.isInitialState);
        }

        public void Print()
        {
            foreach(var state in this.states)
            {
                Console.WriteLine(state.id);
                state.neighbors.Print();
            }
        }

        public void Determine()
        {
            var determinizer = new Determinizer(this);
            determinizer.Determine();
        }
    }
}