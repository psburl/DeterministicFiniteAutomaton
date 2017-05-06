using System;
using System.Collections.Generic;
using System.Text;
using Proj1LFA.Src.Framework.Grammar;
using System.Linq;

namespace Proj1LFA.Src.Framework.Automaton
{
    class State
    {
        public string id;
        public bool isInitialState = false;
        public bool isFinalState = false;
        public NeighborhoodMap neighbors = new NeighborhoodMap();

        public State(Rule rule)
        {
            this.id = rule.alias;
            this.isInitialState = rule.IsInitialState();
            this.isFinalState = rule.IsFinalState();
            rule.productions.ForEach(p => this.neighbors.AddNeighbor(p));
        }        

        public State(string id, bool isInitial)
        {
            this.id = id;
            this.isInitialState = isInitial;
        }

        public IEnumerable<string> GetIndeterministicIds()
        {
            return neighbors.
                Keys.
                Where(
                    k => 
                    neighbors.GetStatesByTerminal(k).Count() > 1
                );
        }
    }
}