using System.Collections.Generic;
using System.Linq;

namespace Proj1LFA.Src.Framework.Grammar
{
    public class Production
    {
        public string terminal = "";
        public string nonTerminal = "";

        /* Serialize a list of productions from text input
           Expect Format:  a<A> | a<S> | e<A> | i<A> | o<A> | u<A> 
        */
        public static IEnumerable<Production> MountProductions(string text)
        {
            foreach(var singleText in text.SplitBy(Defines.BREAKPRODUCTIONS))
                yield return Serialize(singleText);
        }

        /* Serialize a production from text input
           Expect Format: a<A>
           about: a is a terminal and <A> is a nonTerminal.
        */
        public static Production Serialize(string text)
        {
            var pair = text.SplitBy(Defines.BREAKSINGLEPRODUCTION).ToList();
            pair.Add(""); // guarantees that had more than 2 elements
            return new Production()
            {
                terminal =  pair[0].Trim(),
                nonTerminal = pair[1].Replace(">","").Trim()
            };
        }
    }
}