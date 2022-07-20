using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/57faf32df815ebd49e000117
namespace ConsoleApp2
{
    internal class RemoveAllExclamationMarksFromTheEndOfWords
    {
        public static string Remove(string s)
        {
            return Regex.Replace(s, @"[!]* |[!]*\z", " ").TrimEnd();
        }
    }
}
