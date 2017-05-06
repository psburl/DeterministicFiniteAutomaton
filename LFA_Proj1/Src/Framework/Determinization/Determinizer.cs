using System;
using System.Collections.Generic;
using System.Linq;
using Proj1LFA.Src.Framework.Grammar;
using Proj1LFA.Src.Framework.Automaton;

namespace Proj1LFA.Src.Framework.Determinization
{
    class Determinizer
    {
        private FiniteAutomaton automaton;

        public Determinizer(FiniteAutomaton automaton)
        {
            this.automaton = automaton;
        }

        public void Determine()
        {
            var states = new List<State>();
            states.AddRange(automaton.states);

            foreach (var state in states)
            {
                var inderterministicIds = state.GetIndeterministicIds().ToList();

                foreach(var id in inderterministicIds)
                {
                    var nonTerminals = state.neighbors.GetStatesByTerminal(id);

                    string newId = string.Join("", nonTerminals);

                    state.neighbors.OverwriteNeighbor(id, newId);

                    bool isFinal = nonTerminals.Where(r => automaton.GetStateWithId(r)?.isFinalState ?? false).Count() > 0;

                    var NewState = new State(newId, false);
                    bool hasFinalState = false;
                    foreach(var nonTerminal in nonTerminals)
                    {
                        var referencestate = automaton.GetStateWithId(nonTerminal);

                        if (referencestate.isFinalState)
                            hasFinalState = true;

                        var productions = referencestate.neighbors[id];
                        NewState.neighbors.AddNeighbor(id, productions);
                    }
                    NewState.isFinalState = hasFinalState;

                    automaton.states.Add(NewState);
                }
            }
            
            foreach(var state in automaton.states)
            {
                foreach (var token in SingletonAlphabet.Instance.Tokens)
                    if (!state.neighbors.HasTerminal(token.Value))
                        state.neighbors.AddNeighbor("ERROR", new List<string>() { "ERROR" });
            }

            var error = new State("ERROR", false) { isFinalState = true };
            foreach (var token in SingletonAlphabet.Instance.Tokens)
                error.neighbors.AddNeighbor("ERROR", new List<string>() { "ERROR" });

            automaton.states.Add(error);
        }

    }
}