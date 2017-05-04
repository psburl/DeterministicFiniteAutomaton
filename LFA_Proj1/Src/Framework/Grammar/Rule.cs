using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj1LFA.Src.Framework.Grammar
{
    public class Rule
    {
        public string alias = "";
        public List<Production> productions = new List<Production>();

        /* Serialize a grammar rule from text input
           Expect Format:  <S> ::= a<A> | a<S> | e<A> | i<A> | o<A> | u<A> 
        */
        public static Rule Serialize(string inputLine)
        {
            var pair = inputLine.SplitBy(Defines.BREAKRULES);

            if (pair.Count() != 2)
                throw new Exception($"Invalid line found.\r\n 0 or More"+
                $" than 1 token \"{Defines.BREAKRULES}\" in the same line");
                
            return new Rule()
            {
                alias = RemoveInputControlTokens(pair[0]),
                productions =  Production.MountProductions(pair[1]).ToList()
            };
        }

        /* Remove tokens "<", ">" and white spaces
           from input beacuse input it's like "< A >"
         */
        private static string RemoveInputControlTokens(string alias)
        {
            return alias.Replace("<", "").Replace(">", "").Trim();
        }

        public bool IsInitialState()
        {
            return this.alias == Defines.INITIALSTATEALIAS;
        }

        public bool IsFinalState()
        {
            return this.productions.Where(p => p.nonTerminal == "").Count() > 0;
        }
    }
}