using System;
using System.Collections.Generic;
using System.Linq;

namespace Proj1LFA.Src.Framework
{
    public static class StringExtensions
    {
        public static List<string> SplitBy(this string text, string delimiter)
        {
            return text.Split(new string[] { delimiter }, StringSplitOptions.None).ToList();
        }
    }
}