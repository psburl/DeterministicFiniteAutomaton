using System.Collections.Generic;
using System.Linq;

namespace Proj1LFA.Src.Framework.Grammar
{
    public class Production
    {
        public string terminal = "";
        public string nonTerminal = "";

        public static IEnumerable<Production> MountProductions(string text)
        {
            foreach(var singleText in text.SplitBy(Defines.BREAKPRODUCTIONS))
                yield return Serialize(singleText);
        }

        public static Production Serialize(string text)
        {
            var term_nonTerm = text.SplitBy(Defines.BREAKSINGLEPRODUCTION);
            var production = new Production();
            production.terminal = term_nonTerm.FirstOrDefault() ?? "";
            if(term_nonTerm.Count() > 1)
                 production.nonTerminal = term_nonTerm.Last().Replace(">","").Trim();
            return production;
        }
    }
}