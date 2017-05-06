using System;
using System.Collections.Generic;
using System.Linq;
using Proj1LFA.Src.Framework.Grammar;

namespace Proj1LFA.Src.Framework.Automaton
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
            foreach(var state in automaton.states)
            {
                var terminals = state.GetTerminalsWithIndeterminism();
                foreach(var terminalWithIndeterminism in terminals.ToList())
                {
                    var nonTerminals = state.neighborhood.GetTerminalStates(terminalWithIndeterminism);
                    string newId = string.Join("", nonTerminals);
                    state.neighborhood.OverwriteNeighbor(terminalWithIndeterminism, newId);
                    
                }
            }           
        }

        public void GenerateNewStates(string terminalWithIndeterminism)
        {
             
        }
    }
}