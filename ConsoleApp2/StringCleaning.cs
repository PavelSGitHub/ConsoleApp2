using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace ConsoleApp2
{
    internal class StringCleaning
    {
        public static string StringClean(string s)
        {
            return string.Concat(Regex.Matches(s, @"[~#$%^&!@*():;'.,?`\u0022a-zA-Z\s]*"));
        }
    }
}
