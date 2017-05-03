using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj1LFA.Src.Framework.Grammar
{
    public class Rule
    {
        public string alias = "";
        public List<Production> productions = new List<Production>();

        public static Rule Serialize(string inputLine)
        {
            var rule = new Rule();
            var rule_production = inputLine.SplitBy(Defines.BREAKRULES);

            if (rule_production.Count() != 2)
                throw new Exception($"Invalid line found.\r\n 0 or More than" +
                $" 1 token \"{Defines.BREAKRULES}\" in the same line");

            rule.alias = rule_production.First().Replace("<", "").Replace(">", "").Trim();
            rule.productions = Production.MountProductions(rule_production.Last()).ToList();
            return rule;
        }
    }
}