using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/585b1fafe08bae9988000314
namespace ConsoleApp2
{
    internal class DigitsExplosion
    {
        public static string Explode(string s)
        {
            return string.Concat(Regex.Matches(s, @"\d").Select(match => new string(char.Parse(match.Value), int.Parse(match.Value))));
        }
    }
}
