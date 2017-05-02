using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LFA_Proj1.src
{
    class Automaton
    {
        public readonly List<State> states = new List<State>();

        public State GetInitialState()
        {
            return states.FirstOrDefault(s => s.isInitialState());
        }

        public void CreateState()
        {
            int stateId = states.Count();

            var state = new State(stateId, false, false);
        }
    }
}
