using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/56a946cd7bd95ccab2000055
namespace ConsoleApp2
{
    internal class RegexCountLowercaseLetters
    {
        public static int LowercaseCountCheck(string s)
        {
            return Regex.Matches(s, "[a-z]").Count;
        }
    }
}
