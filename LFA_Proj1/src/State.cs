using System;
using System.Collections.Generic;
using System.Text;

namespace LFA_Proj1.src
{
    class State
    {
        public State(int id, bool initialState, bool finalState)
        {
            this.id = id;
            this.initialState = initialState;
            this.finalState = finalState;
        }

        public readonly int id;
        public Dictionary<string, int> map = new Dictionary<string, int>(); // key = terminal, int = state id.
        private bool initialState = false;
        private bool finalState = false;

        public bool isInitialState()
        {
            return initialState;
        }

        public bool isFinalState()
        {
            return finalState;
        }
    }
}
