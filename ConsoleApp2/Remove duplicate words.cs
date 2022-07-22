using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/5b39e3772ae7545f650000fc
namespace ConsoleApp2
{
    internal class Remove_duplicate_words
    {
        public static string RemoveDuplicateWords(string s)
        {
            return string.Join(' ', Regex.Matches(s, @"\S+").DistinctBy(match => match.Value));
  }
    }
}
