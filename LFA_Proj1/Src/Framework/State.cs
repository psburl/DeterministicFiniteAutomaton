using System;
using System.Collections.Generic;
using System.Text;

namespace Proj1LFA.Src.Framework
{
    class State
    {
        public State(int id, bool initialState, bool finalState)
        {
            this.Id = id;
            this.IsInitialState = initialState;
            this.IsFinalState = finalState;
        }

        public readonly int Id;
        public readonly bool IsInitialState = false;
        public readonly bool IsFinalState = false;
        public NeighborhoodMap neighborhood = new NeighborhoodMap();
    }
}