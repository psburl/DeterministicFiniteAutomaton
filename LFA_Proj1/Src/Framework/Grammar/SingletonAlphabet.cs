using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proj1LFA.Src.Framework.Grammar
{
    class SingletonAlphabet
    {
        private static readonly Lazy<SingletonAlphabet> lazy = new Lazy<SingletonAlphabet>(() => new SingletonAlphabet());

        public static SingletonAlphabet Instance { get { return lazy.Value; } }

        public readonly List<Token> Tokens = new List<Token>(); 

        public void AddToken(string token)
        {
            if (Tokens.Where(t => t.Value == token).Count() == 0)
                Tokens.Add(new Token() { Value = token });
        }
    }

    class Token
    {
        public string Value = "";
    }
}
