using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/55ccdf1512938ce3ac000056
namespace ConsoleApp2
{
    internal class AStrangeTripToTheMarket
    {
        public static bool IsLockNessMonster(string sentence)
        {
            return Regex.IsMatch(sentence, @"tree [fF]iddy|3.50|three fifty");
        }
    }
}
