using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/57b2020eb69bfcbf64000375
namespace ConsoleApp2
{
    internal class Weird_words
    {
        public static string NextLetter(string str)
        {
            return Regex.Replace(str, @"[\w]", x => char.IsLower(x.Value[0]) ? 
                string.Concat((char)(((int)x.Value[0] - 97 + 1) % 26 + 97)) :
                string.Concat((char)(((int)x.Value[0] - 65 + 1) % 26 + 65)));
        }
        //((int)chr + 1) % 122 < 97 ? (char)(((int)chr + 1) % 122 + 96) : (char)((int)chr + 1)
    }
}
