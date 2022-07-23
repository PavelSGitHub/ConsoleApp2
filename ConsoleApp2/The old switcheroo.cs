using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/55d410c492e6ed767000004f
namespace ConsoleApp2
{
    internal class TheOldSwitcheroo
    {
        public static string Vowel2Index(string str)
        {
            //return string.Concat(str.Select((c, i) => "aeuio".Contains(c) ? (i + 1).ToString() : c.ToString())); 
            return Regex.Replace(str, "[aeuio]", c => (c.Index+1).ToString());
        }
    }
}
