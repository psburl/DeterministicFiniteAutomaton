using System;
using System.Collections.Generic;
using System.Text;
using Proj1LFA.Src.Framework.Grammar;

namespace Proj1LFA.Src.Framework.Automaton
{
    class State
    {
        public State(Rule rule)
        {
            this.Id = rule.alias;
            this.IsInitialState = rule.IsInitialState();
            this.IsFinalState = rule.IsFinalState();
            rule.productions.ForEach(p => this.neighborhood.AddNeighbor(p));
        }

        public readonly string Id;
        public readonly bool IsInitialState = false;
        public readonly bool IsFinalState = false;
        public NeighborhoodMap neighborhood = new NeighborhoodMap();
    }
}