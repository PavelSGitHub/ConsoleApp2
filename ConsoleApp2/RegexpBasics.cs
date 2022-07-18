using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/567bf4f7ee34510f69000032/
namespace ConsoleApp2
{
    static class RegexpBasics
    {
        public static bool Digit(this string s)
        {
            return s.Length == 1 && Regex.IsMatch(s, @"[0-9]"); 
        }
    }
}
