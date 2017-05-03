using System;
using System.Collections.Generic;

namespace Proj1LFA.Src.Framework.Automaton
{
    using Terminal = String;
    using StateId = Int32;
    using StatesId = List<Int32>;

    class NeighborhoodMap : Dictionary<Terminal, StatesId>
    {
        public bool HasTerminal(Terminal terminal)
        {
            return ContainsKey(terminal);
        }

        public StatesId GetTerminalStates(Terminal terminal)
        {
            return this[terminal];
        }

        public void AddNeighbor(Terminal terminal, StatesId statesId)
        {
            if (HasTerminal(terminal))
                this[terminal].AddRange(statesId);
            else
                this[terminal] = statesId;
        }

        public void AddNeighbor(Terminal terminal, StateId stateId)
        {
            if (HasTerminal(terminal))
                this[terminal].Add(stateId);
            else
                this[terminal] = new StatesId() { stateId };
        }
    }
}