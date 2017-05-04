using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Proj1LFA.Src.Framework.Grammar
{
    public class RegularGrammar
    {
        public List<Rule> rules = new List<Rule>();

        public static RegularGrammar FromPath(string inputPath)
        {
            var file = GetFile(inputPath);

            return Validate(new RegularGrammar()
            {
                rules = SerializeRules(file).ToList()
            });
        }

        private static RegularGrammar Validate(RegularGrammar grammar)
        {
            var rules = grammar.rules;
            var initialRule = rules.FirstOrDefault(r => r.alias == Defines.INITIALSTATEALIAS);
            if(initialRule == null)
                throw new Exception("The input grammar does not contains an initial Rule <S>\r\n");
            return grammar;
        }

        private static IEnumerable<Rule> SerializeRules(string file)
        {
            var lines = file.SplitBy(Defines.BREAKLINES);
            foreach(var line in lines)
                yield return Rule.Serialize(line);
        }

        private static string GetFile(string path)
        {
            return "<S> ::= a<A> | a<S> | e<A> | i<A> | o<A> | u<A> \r\n < A > ::= a<A> | e<A> | i<A> | o<A> | u<A> |";

            if (File.Exists(path) == false)
                throw new Exception($"Input file does not exists. Path: {path}\r\n");

            return File.ReadAllText(path);
        }
    }
}