using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/5668e3800636a6cd6a000018
namespace ConsoleApp2
{
    internal class Ghostbusters_whitespace_removal_
    {
        public static string GhostBusters(string building)
        {
            return Regex.IsMatch(building, " ") ? Regex.Replace(building, " ", "") : "You just wanted my autograph didn't you?";
        }
    }
}
