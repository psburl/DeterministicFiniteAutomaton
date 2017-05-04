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
            var input = new RegularGrammar();
            var file = GetFile(inputPath);
            var lines = file.SplitBy(Defines.BREAKLINES);
            lines.ForEach(l => input.rules.Add(Rule.Serialize(l)));
            var initialRule = input.rules.FirstOrDefault(r => r.alias == Defines.INITIALSTATEALIAS);
            if(initialRule == null)
                throw new Exception("The input grammar does not contains an initial Rule <S>\r\n");
            return input;
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