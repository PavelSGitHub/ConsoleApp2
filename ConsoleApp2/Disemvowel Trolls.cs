using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


//https://www.codewars.com/kata/52fba66badcd10859f00097e
namespace ConsoleApp2
{
    internal class Disemvowel_Trolls
    {
        public static string Disemvowel(string str)
        {
            return Regex.Replace(str, @"[euioaEUIOA]", string.Empty);
        }
    }
}
