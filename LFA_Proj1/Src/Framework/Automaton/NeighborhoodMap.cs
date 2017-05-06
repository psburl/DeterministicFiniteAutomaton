using System;
using System.Collections.Generic;
using Proj1LFA.Src.Framework.Grammar;
using System.Linq;

namespace Proj1LFA.Src.Framework.Automaton
{
    using Terminal = String;
    using StateId = String;
    using StatesId = List<String>;

    class NeighborhoodMap : Dictionary<Terminal, StatesId>
    {
        public bool HasTerminal(Terminal terminal)
        {
            return ContainsKey(terminal);
        }

        public StatesId GetStatesByTerminal(Terminal terminal)
        {
            return this[terminal];
        }

        public void OverwriteNeighbor(string terminal, string nonTerminal)
        {
            this[terminal] = new StatesId() {nonTerminal};
        }

        public void AddNeighbor(Production production)
        {
            if (HasTerminal(production.terminal))
                this[production.terminal].Add(production.nonTerminal);
            else
                this[production.terminal] = new StatesId() {production.nonTerminal};
        }

        public void AddNeighbor(string terminal, IEnumerable<string> nonTerminal)
        {
            if (HasTerminal(terminal))
                this[terminal].AddRange(nonTerminal);
            else
                this[terminal] = nonTerminal.ToList();
        }

        public void Print()
        {
             foreach(var pair in this)
             {
                Console.Write(pair.Key);
                Console.Write("->");
                Console.WriteLine(string.Join(", ", pair.Value));
             }
        }
    }
}