using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/5b37a50642b27ebf2e000010
namespace ConsoleApp2
{
    internal class Sum_of_a_Beach
    {
        public static int SumOfABeach(string s)
        {
            return Regex.Matches(s, @"sand|water|fish|sun", RegexOptions.IgnoreCase).Count;
        }
    }
}
