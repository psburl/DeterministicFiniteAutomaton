using System;
using System.Collections.Generic;
using System.Linq;
using Proj1LFA.Src.Framework.Grammar;

namespace Proj1LFA.Src.Framework.Automaton
{
    class FiniteAutomaton
    {
        public static FiniteAutomaton FromFilePath(string inputPath)
        {
            var automaton = new FiniteAutomaton();     
            var input = RegularGrammar.FromPath(inputPath); 
            var initialRule = input.rules.FirstOrDefault(r => r.alias == "S");

            if(initialRule == null)
                throw new Exception("The input grammar does"+
                " not contains an initial Rule <S>\r\n");

            return automaton;
        }

        public readonly List<State> states = new List<State>();

        public State GetInitialState()
        {
            return states.FirstOrDefault(s => s.IsInitialState);
        }

        public void CreateState()
        {
            int stateId = states.Count();

            var state = new State(stateId, false, false);
        }
    }
}