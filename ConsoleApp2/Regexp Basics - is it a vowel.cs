using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/567bed99ee3451292c000025
namespace ConsoleApp2
{
    static internal class Regexp_Basics___is_it_a_vowel
    {
        public static bool Vowel(this string s)
        {
            return Regex.IsMatch(s, @"^(a|e|u|i|o)\z", RegexOptions.IgnoreCase);
        }
    }
}
