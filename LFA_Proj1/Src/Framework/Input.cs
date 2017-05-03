using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Proj1LFA.Src.Framework
{
    public class Production
    {
        public string terminal = "";
        public string nonTerminal = "";

        public static IEnumerable<Production> MountProductions(string text)
        {
            foreach(var singleText in text.SplitBy(Define.BREAKPRODUCTIONS))
                yield return Serialize(singleText);
        }

        public static Production Serialize(string text)
        {
            var term_nonTerm = text.SplitBy(Define.BREAKSINGLEPRODUCTION);
            var production = new Production();
            production.terminal = term_nonTerm.FirstOrDefault() ?? "";
            if(term_nonTerm.Count() > 1)
                 production.terminal = term_nonTerm.Last().Replace(">","");
            return new Production();
        }
    }

    public class Rule
    {
        public string alias = "";
        public List<Production> productions = new List<Production>();

        public static Rule Serialize(string inputLine)
        {
            var rule = new Rule();
            var rule_production = inputLine.SplitBy(Define.BREAKRULES);

            if(rule_production.Count() != 2)
                throw new Exception($"Invalid line found.\r\n 0 or More than"+
                $" 1 token \"{Define.BREAKRULES}\" in the same line");

            rule.alias = rule_production.First();
            rule.productions = Production.MountProductions(rule_production.Last()).ToList();
            return rule;
        }
    }

    public class Input
    {
        public List<Rule> rules = new List<Rule>();

        public static Input FromPath(string inputPath)
        {
            var input = new Input();
            var file = GetFile(inputPath);
            var lines = file.SplitBy(Define.BREAKLINES);
            lines.ForEach(l => input.rules.Add(Rule.Serialize(l)));
            return input;
        }

        private static string GetFile(string path)
        {
            if(File.Exists(path) == false)
                throw new Exception($"Input file does not exists. Path: {path}\r\n");
            
            return File.ReadAllText(path);
        }
    }
}