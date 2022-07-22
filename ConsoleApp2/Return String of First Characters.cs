using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/5639bdcef2f9b06ce800005b
namespace ConsoleApp2
{
    internal class Return_String_of_First_Characters
    {
        public static string MakeString(string s)
        {
            return string.Concat(Regex.Matches(s, @"\b[a-zA-Z]"));
        }
    }
}
