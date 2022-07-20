using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


// https://www.codewars.com/kata/57a37f3cbb99449513000cd8
namespace ConsoleApp2
{
    internal class GetNumberFromString
    {
        public static int getNumberFromString(string s)
        {
            return int.Parse(string.Concat(Regex.Matches(s, @"\d")));
        }
    }
}
